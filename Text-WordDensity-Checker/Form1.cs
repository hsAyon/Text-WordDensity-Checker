using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Windows.Markup;
using System.Xml;

namespace Text_WordDensity_Checker
{
    public partial class Form1 : Form
    {
        List<List<string>> listOutput = new List<List<string>>();

        List<List<string>> wordCheck = new List<List<string>>();
        List<List<string>> wordOutput = new List<List<string>>();

        Stack<string> undoList = new Stack<string>();
        Stack<string> redoList = new Stack<string>();

        int countAllWords;

        bool undo = false;

        saveInfo saveData;

        public Form1()
        {
            /*listOutput.Add(new List<string>());
            listOutput[0].Add("");
            listOutput[0].Add("Word");*/

            InitializeComponent();
            tbSource.Font = new Font ("Calibri", 11);
            tbSource.SelectionFont = new Font("Calibri", 11);
            undoList.Push("");
            countAllWords = 0;

            saveData = new saveInfo();
            //pbScrollbarColors.BackColor = Color.Transparent;
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog openSource = new OpenFileDialog();
            openSource.Title = "Open source text";
            
            if (openSource.ShowDialog() == DialogResult.OK)
            {
                string filePath = openSource.FileName;
                tbSource.Text = File.ReadAllText(filePath);
            }
        }

        private void btnSelectCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectCSV = new OpenFileDialog();
            selectCSV.Title = "Select CSV";
            selectCSV.DefaultExt = "csv";
            selectCSV.Multiselect = false;

            if (selectCSV.ShowDialog() == DialogResult.OK)
            {
                List<List<string>> wordCheckTemp = new List<List<string>>();
                List<List<string>> wordOutputTemp = new List<List<string>>();


                using (var reader = new StreamReader(selectCSV.FileName))
                {
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values[0].Equals("")) { break; }

                        //wordCheck.Add(values.ToList());
                        wordCheckTemp.Add(new List<string>());
                        wordOutputTemp.Add(new List<string>());

                        values[0].Replace('\u00a0', '\u0020');
                        values[1].Replace('\u00a0', '\u0020');

                        

                        wordOutputTemp.Add(new List<string>());
                        wordOutputTemp[i].Add(values[0]);
                        wordOutputTemp[i].Add("");
                        wordOutputTemp[i].Add("");

                        wordCheckTemp[i].Add(values[0]);
                        wordCheckTemp[i].Add(values[1].Replace("%",""));

                        i++;
                    }
                }

                wordOutput = wordOutputTemp;
                wordCheck = wordCheckTemp;
            }
        }


        private void btnCheck_Click(object sender, EventArgs e)
        {

            tbSource.Text = tbSource.Text.Replace('\u00a0', '\u0020');

            var source = tbSource.Text;

            countAllWords = tbSource.Text.Split(new[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

            dgvOutput.Rows.Clear();
            dgvOutput.Refresh();

            double multiplier = double.Parse(nudMultiplier.Value.ToString());

            dgvOutput.ColumnCount = 6;

            dgvOutput.Columns[0].HeaderText = "Word";
            dgvOutput.Columns[1].HeaderText = "Actual Density";
            dgvOutput.Columns[2].HeaderText = "Count";
            dgvOutput.Columns[3].HeaderText = "Count Difference";
            
            dgvOutput.Columns[4].HeaderText = "#";
            dgvOutput.Columns[4].DisplayIndex = 0;
            dgvOutput.Columns[4].ValueType = typeof(int);

            dgvOutput.Columns[1].ValueType = typeof(double);
            dgvOutput.Columns[2].ValueType = typeof(int);

            dgvOutput.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvOutput.Columns[3].ValueType = typeof(double);

            dgvOutput.Columns[5].ValueType = typeof(double);
            dgvOutput.Columns[5].HeaderText = "Given Density";
            dgvOutput.Columns[5].DisplayIndex = 2;

            /*int tempColumnId = dgvOutput.ColumnCount - 1;
            dgvOutput.Columns[tempColumnId].HeaderText = "Difference";
            dgvOutput.Columns[tempColumnId].ValueType = typeof(float);*/

            //dgvOutput.Columns[2].Visible = false;
            int rowAddCounter = 0;

            Parallel.For(0, wordCheck.Count, i =>
            {
                string regex = @"\b" + wordCheck[i][0] + @"\b";
                int countMatches = Regex.Matches(source, regex, RegexOptions.IgnoreCase).Count;
                // | RegexOptions.Compiled

                wordOutput[i][2] = countMatches.ToString();
                wordOutput[i][1] = (((float)countMatches * 100) / (float)countAllWords).ToString();

                float actualDensity = float.Parse(wordOutput[i][1]);
                float expectedDensity = float.Parse(wordCheck[i][1]);

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(this.dgvOutput);
                row.DefaultCellStyle = dgvOutput.DefaultCellStyle;

                row.Cells[0].Value = wordOutput[i][0];
                row.Cells[1].Value = float.Parse(wordOutput[i][1]);
                row.Cells[2].Value = wordOutput[i][2];
                row.Cells[4].Value = i+1;
                row.Cells[5].Value = wordCheck[i][1];

                //row.Cells[tempColumnId].Value = expectedDensity - actualDensity;

                if (actualDensity > multiplier * expectedDensity)
                {
                    row.Cells[3].Value = (expectedDensity * multiplier - actualDensity)/100 * (float)countAllWords;
                }
                else if(actualDensity > expectedDensity)
                {
                    row.Cells[3].Value = 0;
                }
                else
                {
                    row.Cells[3].Value = (expectedDensity - actualDensity)/100 * (float)countAllWords;
                }

                if (actualDensity > multiplier * expectedDensity)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                        cell.Style.ForeColor = Color.Red;
                    }
                }
                else if (actualDensity > expectedDensity)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                        cell.Style.ForeColor = Color.Green;
                    }
                } 
                else if (actualDensity <= 0)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Regular);
                        cell.Style.ForeColor = Color.Black;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Regular);
                        cell.Style.ForeColor = Color.Blue;
                    }
                }

                //dgvOutput.Invoke(new Action(() => { dgvOutput.Rows.Add(row); }));
                dgvOutput.BeginInvoke(new Action(() => { 
                    dgvOutput.Rows.Add(row);
                    rowAddCounter++;
                    if(rowAddCounter == wordCheck.Count)
                    {
                        dgvOutput.Sort(dgvOutput.Columns[4], ListSortDirection.Ascending);
                        dgvOutput.ClearSelection();
                    }
                }));

                //dgvOutput.Sort(dgvOutput.Columns[2], ListSortDirection.Ascending);
            });

        }

        private void formClose_Click(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close the program?", "Exit Confirmation", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                saveData.source = tbSource.Text;
                saveData.countAllWords = countAllWords;
                saveData.multiplier = double.Parse(nudMultiplier.Value.ToString());
                saveData.words = wordCheck;
                saveData.output = wordOutput;
                //saveData.dgvOut = dgvOutput;
                saveData.find = tbFind.Text;


                XmlSerializer serializer = new XmlSerializer(typeof(saveInfo));
                TextWriter textWriter = new StreamWriter(Application.StartupPath + @"\saveData.xml");
                serializer.Serialize(textWriter, saveData);
                textWriter.Close();


                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            tbSource.Text = tbSource.Text.Replace('\u00a0', '\u0020');

            string[] words = tbFind.Text.Split(',');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            foreach (var word in words)
            {
                string regex = @"\b" + word + @"\b";
                MatchCollection keywordMatches = Regex.Matches(tbSource.Text, regex, RegexOptions.IgnoreCase);
                foreach (Match m in keywordMatches)
                {
                    //rtbADB.Select(m.Index, m.Length);
                    tbSource.SelectionStart = m.Index;
                    tbSource.SelectionLength = m.Length;
                    tbSource.SelectionBackColor = Color.Yellow;
                }
            }
            tbSource.DeselectAll();
        }

        private void btnFindClear_Click(object sender, EventArgs e)
        {
            tbSource.SelectAll();
            tbSource.SelectionBackColor = Color.White;
        }

        private void tbSource_TextChanged(object sender, EventArgs e)
        {
            if (undo == false)
            {
                undoList.Push(tbSource.Text);
            }
            else
            {

            }
        }

        private void dgvOutput_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.ValueType == typeof(double))
            {
                double a = double.Parse(e.CellValue1.ToString()), b = double.Parse(e.CellValue2.ToString());

                e.SortResult = a.CompareTo(b);

                e.Handled = true;
            }

            if (e.Column.ValueType == typeof(int))
            {
                int a = int.Parse(e.CellValue1.ToString()), b = int.Parse(e.CellValue2.ToString());

                e.SortResult = a.CompareTo(b);

                e.Handled = true;
            }
        }

        private void tbSource_KeyDown(object sender, KeyEventArgs e)
        {
            bool ctrlV = e.Modifiers == Keys.Control && e.KeyCode == Keys.V;
            bool shiftIns = e.Modifiers == Keys.Shift && e.KeyCode == Keys.Insert;

            if (ctrlV || shiftIns)
            {
                tbSource.SelectedText = string.Empty;
                tbSource.SelectedText = (string)Clipboard.GetData("Text");
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Z && (e.Control))
            {
                if (undoList.Count > 1)
                {
                    int cursor = tbSource.SelectionStart;

                    undo = true;

                    string temp = undoList.Pop();
                    redoList.Push(temp);
                    tbSource.Text = undoList.First();

                    undo = false;

                    if (cursor < tbSource.TextLength)
                    {
                        tbSource.SelectionStart = cursor;
                    }
                    else
                    {
                        tbSource.SelectionStart = tbSource.TextLength;
                    }
                }
            }

            if (e.KeyCode == Keys.Y && (e.Control))
            {
                if (redoList.Count > 1)
                {
                    int cursor = tbSource.SelectionStart;

                    undo = true;
                    string temp = redoList.Pop();
                    undoList.Push(temp);
                    tbSource.Text = undoList.First();
                    undo = false;

                    if (cursor < tbSource.TextLength)
                    {
                        tbSource.SelectionStart = cursor;
                    }
                    else
                    {
                        tbSource.SelectionStart = tbSource.TextLength;
                    }
                }
            }
        }

        private void tbFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFind.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void nudMultiplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCheck.PerformClick();

                e.SuppressKeyPress = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\saveData.xml"))
            {
                saveInfo loadData;

                XmlSerializer xs = new XmlSerializer(typeof(saveInfo));
                using (FileStream fs = new FileStream(Application.StartupPath + @"\saveData.xml", FileMode.Open))
                {
                    loadData = xs.Deserialize(fs) as saveInfo;
                }

                if (loadData != null)
                {
                    tbSource.Text = loadData.source;
                    nudMultiplier.Value = decimal.Parse(loadData.multiplier.ToString());
                    wordCheck = loadData.words;
                    wordOutput = loadData.output;
                    countAllWords = loadData.countAllWords;

                    loadOutput();

                    //dgvOutput = loadData.dgvOut;
                    tbFind.Text = loadData.find;

                }

            }
        }

        private void loadOutput()
        {
            double multiplier = double.Parse(nudMultiplier.Value.ToString());
            int rowAddCounter = 0;

            dgvOutput.ColumnCount = 6;

            dgvOutput.Rows.Clear();
            dgvOutput.Refresh();

            dgvOutput.Columns[0].HeaderText = "Word";
            dgvOutput.Columns[1].HeaderText = "Actual Density";
            dgvOutput.Columns[2].HeaderText = "Count";
            dgvOutput.Columns[3].HeaderText = "Count Difference";

            dgvOutput.Columns[1].ValueType = typeof(double);
            dgvOutput.Columns[2].ValueType = typeof(int);


            dgvOutput.Columns[4].HeaderText = "#";
            dgvOutput.Columns[4].DisplayIndex = 0;
            dgvOutput.Columns[4].ValueType = typeof(int);

            dgvOutput.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvOutput.Columns[3].ValueType = typeof(double);

            dgvOutput.Columns[5].ValueType = typeof(double);
            dgvOutput.Columns[5].HeaderText = "Given Density";
            dgvOutput.Columns[5].DisplayIndex = 2;

            Parallel.For(0, wordCheck.Count, i =>
            {
                float actualDensity = float.Parse(wordOutput[i][1]);
                float expectedDensity = float.Parse(wordCheck[i][1]);

                DataGridViewRow row = new DataGridViewRow();

                row.CreateCells(this.dgvOutput);
                row.DefaultCellStyle = dgvOutput.DefaultCellStyle;

                row.Cells[0].Value = wordOutput[i][0];
                row.Cells[1].Value = float.Parse(wordOutput[i][1]);
                row.Cells[2].Value = wordOutput[i][2];
                row.Cells[5].Value = wordCheck[i][1];


                row.Cells[4].Value = i;

                //row.Cells[tempColumnId].Value = expectedDensity - actualDensity;

                if (actualDensity > multiplier * expectedDensity)
                {
                    row.Cells[3].Value = (expectedDensity * multiplier - actualDensity) / 100 * (float)countAllWords;
                }
                else if (actualDensity > expectedDensity)
                {
                    row.Cells[3].Value = 0;
                }
                else
                {
                    row.Cells[3].Value = (expectedDensity - actualDensity) / 100 * (float)countAllWords;
                }

                if (actualDensity > multiplier * expectedDensity)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                        cell.Style.ForeColor = Color.Red;
                    }
                }
                else if (actualDensity > expectedDensity)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                        cell.Style.ForeColor = Color.Green;
                    }
                }
                else if (actualDensity <= 0)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Regular);
                        cell.Style.ForeColor = Color.Black;
                    }
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Regular);
                        cell.Style.ForeColor = Color.Blue;
                    }
                }

                //dgvOutput.Invoke(new Action(() => { dgvOutput.Rows.Add(row); }));
                dgvOutput.BeginInvoke(new Action(() => {
                    dgvOutput.Rows.Add(row);
                    rowAddCounter++;
                    if (rowAddCounter == wordCheck.Count)
                    {
                        dgvOutput.Sort(dgvOutput.Columns[4], ListSortDirection.Ascending);
                        dgvOutput.ClearSelection();
                    }
                }));
            });
        }
    }

    public class saveInfo
    {
        public string source { get; set; }
        public int countAllWords { get; set; }
        public double multiplier { get; set; }
        public List<List<string>> words { get; set; }
        public List<List<string>> output { get; set; }
        //public DataGridView dgvOut { get; set; }
        public string find { get; set; }
    }
}

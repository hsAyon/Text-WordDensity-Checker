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

namespace Text_WordDensity_Checker
{
    public partial class Form1 : Form
    {
        List<List<string>> listOutput = new List<List<string>>();

        List<List<string>> wordCheck = new List<List<string>>();
        List<List<string>> wordOutput = new List<List<string>>();

        public Form1()
        {
            /*listOutput.Add(new List<string>());
            listOutput[0].Add("");
            listOutput[0].Add("Word");*/

            InitializeComponent();
            tbSource.Font = new Font ("Calibri", 11);
            tbSource.SelectionFont = new Font("Calibri", 11);


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

                wordCheck = wordCheckTemp;
                wordOutput = wordOutputTemp;

                dgvWords.Rows.Clear();
                dgvWords.Refresh();

                dgvWords.ColumnCount = 2;
                for (int r = 0; r < wordCheck.Count; r++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dgvWords);

                    for (int c = 0; c < 2; c++)
                    {
                        row.Cells[c].Value = wordCheck[r][c];
                    }

                    this.dgvWords.Rows.Add(row);
                }
            }
        }
        

        private void btnCheck_Click(object sender, EventArgs e)
        {

            tbSource.Text = tbSource.Text.Replace('\u00a0', '\u0020');

            var source = tbSource.Text;

            var countAllWords = tbSource.Text.Split(new[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

            dgvOutput.Rows.Clear();
            dgvOutput.Refresh();

            double multiplier = double.Parse(nudMultiplier.Value.ToString());

            dgvOutput.ColumnCount = 4;

            dgvOutput.Columns[0].HeaderText = "Word";
            dgvOutput.Columns[1].HeaderText = "Density";
            dgvOutput.Columns[2].HeaderText = "Count";
            dgvOutput.Columns[3].HeaderText = "Count Difference";

            dgvOutput.Columns[3].ValueType = typeof(double);

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
                        cell.Style.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Regular);
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
                        cell.Style.ForeColor = Color.Orange;
                    }
                }

                //dgvOutput.Invoke(new Action(() => { dgvOutput.Rows.Add(row); }));
                dgvOutput.BeginInvoke(new Action(() => { 
                    dgvOutput.Rows.Add(row);
                    rowAddCounter++;
                    if(rowAddCounter == wordCheck.Count)
                    {
                        dgvOutput.Sort(dgvOutput.Columns[3], ListSortDirection.Ascending);
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

        }

        private void dgvOutput_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.ValueType == typeof(double))
            {
                double a = double.Parse(e.CellValue1.ToString()), b = double.Parse(e.CellValue2.ToString());

                e.SortResult = a.CompareTo(b);

                e.Handled = true;
            }
        }
    }
}

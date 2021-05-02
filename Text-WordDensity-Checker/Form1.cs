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
        int countPages = 1;

        List<List<string>> wordCheck = new List<List<string>>();
        List<List<string>> wordOutput = new List<List<string>>();


        public void showOutput()
        {
            /*tbOutput.Clear();
            for (int i = 0; i < listOutput[0].Count; i++)
            {
                for (int j = 0; j < listOutput.Count; j++)
                {
                    tbOutput.Text += listOutput[j][i] + "\t";
                }
                tbOutput.Text += "\r\n";
            }*/
        }

        public Form1()
        {
            /*listOutput.Add(new List<string>());
            listOutput[0].Add("");
            listOutput[0].Add("Word");*/

            InitializeComponent();
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

            var countAllWords = tbSource.Text.Split(new[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

            int nTerm = 1 + (countPages - 1) * 2; // nth term of arithmatic sequence (a1 = 1, d = 2)

            /*listOutput.Add(new List<string>());
            listOutput.Add(new List<string>());

            listOutput[nTerm].Add("Page " + countPages);
            listOutput[nTerm].Add("Count");
            listOutput[nTerm + 1].Add("");
            listOutput[nTerm + 1].Add("Density");*/

            Parallel.For(0, wordCheck.Count, i => {
                
                
                string regex = @"\b" + wordCheck[i][0] + @"\b";
                int countMatches = Regex.Matches(tbSource.Text, regex, RegexOptions.IgnoreCase | RegexOptions.Compiled).Count;

                wordOutput[i][2] = countMatches.ToString();
                wordOutput[i][1] = (((float)countMatches*100)/ (float)countAllWords).ToString();

                dgvOutput.Rows.Clear();
                dgvOutput.Refresh();

                dgvOutput.ColumnCount = 3;
                dgvOutput.Columns[2].Visible = false;

                float actualDensity = float.Parse(wordOutput[i][1]);
                float expectedDensity = float.Parse(wordCheck[i][1]);

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dgvOutput);
                for (int c = 0; c < 2; c++)
                {
                    row.Cells[c].Value = wordOutput[i][c];
                    row.Cells[2].Value = expectedDensity - actualDensity;
                }

                if (actualDensity >= 1.5*expectedDensity)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                }
                else if (actualDensity >= expectedDensity)
                {
                    row.DefaultCellStyle.ForeColor = Color.Yellow;
                    row.DefaultCellStyle.Font = new Font(row.DefaultCellStyle.Font, FontStyle.Bold);
                }

                dgvOutput.Rows.Add(row);

                /*for (int r = 0; r < wordCheck.Count; r++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dgvWords);

                    for (int c = 0; c < 2; c++)
                    {
                        row.Cells[c].Value = wordCheck[r][c];
                    }

                    this.dgvWords.Rows.Add(row);
                }*/

                /*listOutput[nTerm].Add(countMatches.ToString());
                listOutput[nTerm + 1].Add(((float)countMatches / (float)countAllWords).ToString());*/
            });

            dgvOutput.Sort(dgvOutput.Columns[2], ListSortDirection.Descending);

            /*foreach (var row in wordCheck)
            {

                string regex = @"\b" + row[0] + @"\b";
                int countMatches = Regex.Matches(tbSource.Text, regex, RegexOptions.IgnoreCase | RegexOptions.Compiled).Count;

                

                listOutput[nTerm].Add(countMatches.ToString());
                listOutput[nTerm + 1].Add(((float)countMatches / (float)countAllWords).ToString());
            }*/

            //countPages++;

            /*if (countPages != 1)
            {
                //tbSearchString.ReadOnly = true;
            }*/

            /*showOutput();*/
        }

        private void btnClearPrev_Click(object sender, EventArgs e)
        {
            DialogResult confClear = MessageBox.Show("Are you sure you want to clear the last output?", "Clear Confirmation", MessageBoxButtons.YesNo);
            if (confClear == DialogResult.Yes)
            {
                if (countPages > 1)
                {
                    listOutput.Remove(listOutput.Last());
                    listOutput.Remove(listOutput.Last());
                    countPages--;
                    showOutput();
                }
            }
            else if (confClear == DialogResult.No)
            {

            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult confClear = MessageBox.Show("Are you sure you want to clear all output?", "Clear Confirmation", MessageBoxButtons.YesNo);
            if (confClear == DialogResult.Yes)
            {
                /*tbOutput.Clear();*/
                countPages = 1;

                listOutput.Clear();

                listOutput.Add(new List<string>());
                listOutput[0].Add("");
                listOutput[0].Add("Word");

                //tbSearchString.ReadOnly = false;
            }
            else if (confClear == DialogResult.No)
            {
                
            }          
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

        /*
        SaveFileDialog saveCSV = new SaveFileDialog();
        saveCSV.Title = "Save CSV";
            saveCSV.DefaultExt = "csv";
            
            if (saveCSV.ShowDialog() == DialogResult.OK)
            {
                string finalCSV = "";

                for (int i = 0; i<listOutput[0].Count; i++)
                {
                    for (int j = 0; j<listOutput.Count; j++)
                    {
                        finalCSV += listOutput[j][i] + ",";
                    }
                finalCSV += "\r\n";
                }

            string filePath = saveCSV.FileName;
            File.WriteAllText(filePath, finalCSV);
            }
        */


        /*
        tbSearchString.Text = tbSearchString.Text.Replace('\u00a0', '\u0020');
        tbSource.Text = tbSource.Text.Replace('\u00a0', '\u0020');

        string[] searchWords = tbSearchString.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        var countAllWords = tbSource.Text.Split(new[] { " ", "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Length;

        int nTerm = 1 + (countPages - 1) * 2; // nth term of arithmatic sequence (a1 = 1, d = 2)

        listOutput.Add(new List<string>());
            listOutput.Add(new List<string>());

            listOutput[nTerm].Add("Page "+countPages);
        listOutput[nTerm].Add("Count");
        listOutput[nTerm + 1].Add("");
        listOutput[nTerm + 1].Add("Density");

            foreach (var word in searchWords)
            {
                if (countPages <= 1)
                {
                    listOutput[0].Add(word);
            }

            string regex = @"\b" + word + @"\b";
            int countMatches = Regex.Matches(tbSource.Text, regex, RegexOptions.IgnoreCase).Count;

            listOutput[nTerm].Add(countMatches.ToString());
            listOutput[nTerm + 1].Add(((float) countMatches / (float) countAllWords).ToString());
                    }

        countPages++;

        if (countPages != 1)
        {
            tbSearchString.ReadOnly = true;
        }

        showOutput();
        */
    }
}

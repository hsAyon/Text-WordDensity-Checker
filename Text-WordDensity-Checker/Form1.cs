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

        public void showOutput()
        {
            tbOutput.Clear();
            for (int i = 0; i < listOutput[0].Count; i++)
            {
                for (int j = 0; j < listOutput.Count; j++)
                {
                    tbOutput.Text += listOutput[j][i] + "\t";
                }
                tbOutput.Text += "\r\n";
            }
        }

        public Form1()
        {
            listOutput.Add(new List<string>());
            listOutput[0].Add("");
            listOutput[0].Add("Word");

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
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

                string regex = @"\b"+word+@"\b";
                int countMatches = Regex.Matches(tbSource.Text, regex, RegexOptions.IgnoreCase).Count;

                listOutput[nTerm].Add(countMatches.ToString());
                listOutput[nTerm + 1].Add(((float)countMatches / (float)countAllWords).ToString());
            }

            countPages++;

            if(countPages != 1)
            {
                tbSearchString.ReadOnly = true;
            }

            showOutput();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveCSV = new SaveFileDialog();
            saveCSV.Title = "Save CSV";
            saveCSV.DefaultExt = "csv";
            
            if (saveCSV.ShowDialog() == DialogResult.OK)
            {
                string finalCSV = "";

                for (int i = 0; i < listOutput[0].Count; i++)
                {
                    for (int j = 0; j < listOutput.Count; j++)
                    {
                        finalCSV += listOutput[j][i] + ",";
                    }
                    finalCSV += "\r\n";
                }

                string filePath = saveCSV.FileName;
                File.WriteAllText(filePath, finalCSV);
            }
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
                tbOutput.Clear();
                countPages = 1;

                listOutput.Clear();

                listOutput.Add(new List<string>());
                listOutput[0].Add("");
                listOutput[0].Add("Word");

                tbSearchString.ReadOnly = false;
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
    }
}

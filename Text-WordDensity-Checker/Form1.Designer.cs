
namespace Text_WordDensity_Checker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCheck = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSelectCSV = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnFindClear = new System.Windows.Forms.Button();
            this.btnSource = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvWords = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSource = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnCheck);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(609, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(399, 94);
            this.panel6.TabIndex = 5;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(3, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(113, 88);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnSelectCSV);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(407, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(196, 94);
            this.panel5.TabIndex = 4;
            // 
            // btnSelectCSV
            // 
            this.btnSelectCSV.Location = new System.Drawing.Point(3, 3);
            this.btnSelectCSV.Name = "btnSelectCSV";
            this.btnSelectCSV.Size = new System.Drawing.Size(114, 91);
            this.btnSelectCSV.TabIndex = 0;
            this.btnSelectCSV.Text = "Select";
            this.btnSelectCSV.UseVisualStyleBackColor = true;
            this.btnSelectCSV.Click += new System.EventHandler(this.btnSelectCSV_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbFind);
            this.panel4.Controls.Add(this.btnFind);
            this.panel4.Controls.Add(this.btnFindClear);
            this.panel4.Controls.Add(this.btnSource);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(398, 94);
            this.panel4.TabIndex = 3;
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(3, 70);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(230, 20);
            this.tbFind.TabIndex = 9;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(239, 68);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 10;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnFindClear
            // 
            this.btnFindClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindClear.Location = new System.Drawing.Point(320, 68);
            this.btnFindClear.Name = "btnFindClear";
            this.btnFindClear.Size = new System.Drawing.Size(75, 23);
            this.btnFindClear.TabIndex = 11;
            this.btnFindClear.Text = "Clear";
            this.btnFindClear.UseVisualStyleBackColor = true;
            this.btnFindClear.Click += new System.EventHandler(this.btnFindClear_Click);
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(3, 3);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(91, 41);
            this.btnSource.TabIndex = 8;
            this.btnSource.Text = "Open Source";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvOutput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(609, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(399, 540);
            this.panel3.TabIndex = 2;
            // 
            // dgvOutput
            // 
            this.dgvOutput.AllowUserToAddRows = false;
            this.dgvOutput.AllowUserToDeleteRows = false;
            this.dgvOutput.AllowUserToResizeRows = false;
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutput.Location = new System.Drawing.Point(0, 0);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.ReadOnly = true;
            this.dgvOutput.RowHeadersVisible = false;
            this.dgvOutput.Size = new System.Drawing.Size(399, 540);
            this.dgvOutput.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvWords);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(407, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 540);
            this.panel2.TabIndex = 1;
            // 
            // dgvWords
            // 
            this.dgvWords.AllowUserToAddRows = false;
            this.dgvWords.AllowUserToDeleteRows = false;
            this.dgvWords.AllowUserToResizeRows = false;
            this.dgvWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWords.ColumnHeadersVisible = false;
            this.dgvWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvWords.Location = new System.Drawing.Point(0, 0);
            this.dgvWords.Name = "dgvWords";
            this.dgvWords.ReadOnly = true;
            this.dgvWords.RowHeadersVisible = false;
            this.dgvWords.Size = new System.Drawing.Size(196, 540);
            this.dgvWords.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSource);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 540);
            this.panel1.TabIndex = 0;
            // 
            // tbSource
            // 
            this.tbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSource.Location = new System.Drawing.Point(0, 0);
            this.tbSource.MaxLength = 0;
            this.tbSource.Name = "tbSource";
            this.tbSource.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.tbSource.Size = new System.Drawing.Size(398, 540);
            this.tbSource.TabIndex = 0;
            this.tbSource.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1011, 646);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 646);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1027, 685);
            this.Name = "Form1";
            this.Text = "Keyword Density Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClose_Click);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSelectCSV;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvWords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox tbSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnFindClear;
        private System.Windows.Forms.Button btnSource;
    }
}


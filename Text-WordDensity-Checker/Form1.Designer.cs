
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
            this.cbExact = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnSelectCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudMultiplier = new System.Windows.Forms.NumericUpDown();
            this.btnCheck = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnFindClear = new System.Windows.Forms.Button();
            this.btnSource = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSource = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiplier)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbExact);
            this.panel6.Controls.Add(this.btnFilter);
            this.panel6.Controls.Add(this.tbFilter);
            this.panel6.Controls.Add(this.btnSelectCSV);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.nudMultiplier);
            this.panel6.Controls.Add(this.btnCheck);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(574, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(367, 104);
            this.panel6.TabIndex = 5;
            // 
            // cbExact
            // 
            this.cbExact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbExact.AutoSize = true;
            this.cbExact.Location = new System.Drawing.Point(326, 82);
            this.cbExact.Name = "cbExact";
            this.cbExact.Size = new System.Drawing.Size(42, 17);
            this.cbExact.TabIndex = 14;
            this.cbExact.Text = "EM";
            this.cbExact.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFilter.Location = new System.Drawing.Point(245, 78);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 12;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // tbFilter
            // 
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbFilter.Font = new System.Drawing.Font("Calibri", 11F);
            this.tbFilter.Location = new System.Drawing.Point(6, 77);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(233, 25);
            this.tbFilter.TabIndex = 12;
            // 
            // btnSelectCSV
            // 
            this.btnSelectCSV.Location = new System.Drawing.Point(6, 3);
            this.btnSelectCSV.Name = "btnSelectCSV";
            this.btnSelectCSV.Size = new System.Drawing.Size(114, 49);
            this.btnSelectCSV.TabIndex = 0;
            this.btnSelectCSV.Text = "Select CSV";
            this.btnSelectCSV.UseVisualStyleBackColor = true;
            this.btnSelectCSV.Click += new System.EventHandler(this.btnSelectCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Multiplying Factor";
            // 
            // nudMultiplier
            // 
            this.nudMultiplier.DecimalPlaces = 2;
            this.nudMultiplier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudMultiplier.Location = new System.Drawing.Point(98, 53);
            this.nudMultiplier.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMultiplier.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMultiplier.Name = "nudMultiplier";
            this.nudMultiplier.Size = new System.Drawing.Size(141, 20);
            this.nudMultiplier.TabIndex = 1;
            this.nudMultiplier.Value = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.nudMultiplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudMultiplier_KeyDown);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(126, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(113, 49);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
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
            this.panel4.Size = new System.Drawing.Size(565, 104);
            this.panel4.TabIndex = 3;
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbFind.Font = new System.Drawing.Font("Calibri", 11F);
            this.tbFind.Location = new System.Drawing.Point(3, 77);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(397, 25);
            this.tbFind.TabIndex = 9;
            this.tbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFind_KeyDown);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFind.Location = new System.Drawing.Point(406, 77);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 10;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnFindClear
            // 
            this.btnFindClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFindClear.Location = new System.Drawing.Point(487, 78);
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
            this.btnSource.Size = new System.Drawing.Size(165, 49);
            this.btnSource.TabIndex = 8;
            this.btnSource.Text = "Open Source (Raw Text)";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvOutput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(574, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(367, 507);
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
            this.dgvOutput.Size = new System.Drawing.Size(367, 507);
            this.dgvOutput.TabIndex = 0;
            this.dgvOutput.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvOutput_SortCompare);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSource);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 507);
            this.panel1.TabIndex = 0;
            // 
            // tbSource
            // 
            this.tbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSource.Font = new System.Drawing.Font("Calibri", 11F);
            this.tbSource.Location = new System.Drawing.Point(0, 0);
            this.tbSource.MaxLength = 0;
            this.tbSource.Name = "tbSource";
            this.tbSource.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbSource.Size = new System.Drawing.Size(565, 507);
            this.tbSource.TabIndex = 0;
            this.tbSource.Text = "";
            this.tbSource.TextChanged += new System.EventHandler(this.tbSource_TextChanged);
            this.tbSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSource_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.59322F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.40678F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 623);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 623);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 298);
            this.Name = "Form1";
            this.Text = "Text Word Density Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClose_Click);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMultiplier)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSelectCSV;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox tbSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnFindClear;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.NumericUpDown nudMultiplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.CheckBox cbExact;
    }
}


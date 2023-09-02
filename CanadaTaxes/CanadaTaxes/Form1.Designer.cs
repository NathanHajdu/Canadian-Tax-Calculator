namespace CanadaTaxes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.calculatorTitle = new System.Windows.Forms.Label();
            this.usrDetails = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.provinceLabel = new System.Windows.Forms.Label();
            this.provinceDropdown = new System.Windows.Forms.ComboBox();
            this.salaryField = new System.Windows.Forms.TextBox();
            this.nameField = new System.Windows.Forms.TextBox();
            this.salaryLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.taxGrid = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.Button();
            this.taxCalculation = new System.Windows.Forms.GroupBox();
            this.deleteAll = new System.Windows.Forms.Button();
            this.taxBreakdownChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSection = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.taxOther = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.usrDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxGrid)).BeginInit();
            this.taxCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxBreakdownChart)).BeginInit();
            this.chartSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxOther)).BeginInit();
            this.SuspendLayout();
            // 
            // calculatorTitle
            // 
            this.calculatorTitle.AutoSize = true;
            this.calculatorTitle.BackColor = System.Drawing.SystemColors.Control;
            this.calculatorTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculatorTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.calculatorTitle.Location = new System.Drawing.Point(417, 14);
            this.calculatorTitle.Name = "calculatorTitle";
            this.calculatorTitle.Size = new System.Drawing.Size(312, 32);
            this.calculatorTitle.TabIndex = 0;
            this.calculatorTitle.Text = "Canada Tax Calculator";
            // 
            // usrDetails
            // 
            this.usrDetails.Controls.Add(this.btnSubmit);
            this.usrDetails.Controls.Add(this.provinceLabel);
            this.usrDetails.Controls.Add(this.provinceDropdown);
            this.usrDetails.Controls.Add(this.salaryField);
            this.usrDetails.Controls.Add(this.nameField);
            this.usrDetails.Controls.Add(this.salaryLabel);
            this.usrDetails.Controls.Add(this.nameLabel);
            this.usrDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usrDetails.Location = new System.Drawing.Point(18, 72);
            this.usrDetails.Name = "usrDetails";
            this.usrDetails.Size = new System.Drawing.Size(282, 230);
            this.usrDetails.TabIndex = 1;
            this.usrDetails.TabStop = false;
            this.usrDetails.Text = "Your Information";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Purple;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSubmit.Location = new System.Drawing.Point(13, 184);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(98, 30);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // provinceLabel
            // 
            this.provinceLabel.AutoSize = true;
            this.provinceLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provinceLabel.Location = new System.Drawing.Point(10, 122);
            this.provinceLabel.Name = "provinceLabel";
            this.provinceLabel.Size = new System.Drawing.Size(57, 15);
            this.provinceLabel.TabIndex = 5;
            this.provinceLabel.Text = "Province:";
            // 
            // provinceDropdown
            // 
            this.provinceDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.provinceDropdown.ForeColor = System.Drawing.SystemColors.InfoText;
            this.provinceDropdown.FormattingEnabled = true;
            this.provinceDropdown.Location = new System.Drawing.Point(83, 120);
            this.provinceDropdown.Name = "provinceDropdown";
            this.provinceDropdown.Size = new System.Drawing.Size(178, 21);
            this.provinceDropdown.TabIndex = 4;
            // 
            // salaryField
            // 
            this.salaryField.Location = new System.Drawing.Point(83, 79);
            this.salaryField.Name = "salaryField";
            this.salaryField.Size = new System.Drawing.Size(178, 21);
            this.salaryField.TabIndex = 3;
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(83, 35);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(178, 21);
            this.nameField.TabIndex = 2;
            // 
            // salaryLabel
            // 
            this.salaryLabel.AutoSize = true;
            this.salaryLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salaryLabel.Location = new System.Drawing.Point(10, 81);
            this.salaryLabel.Name = "salaryLabel";
            this.salaryLabel.Size = new System.Drawing.Size(44, 15);
            this.salaryLabel.TabIndex = 1;
            this.salaryLabel.Text = "Salary:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(10, 37);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(47, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(378, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // taxGrid
            // 
            this.taxGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.taxGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taxGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taxGrid.Location = new System.Drawing.Point(6, 19);
            this.taxGrid.Name = "taxGrid";
            this.taxGrid.Size = new System.Drawing.Size(750, 158);
            this.taxGrid.TabIndex = 3;
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Purple;
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.delete.Location = new System.Drawing.Point(17, 183);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(98, 30);
            this.delete.TabIndex = 7;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // taxCalculation
            // 
            this.taxCalculation.Controls.Add(this.deleteAll);
            this.taxCalculation.Controls.Add(this.delete);
            this.taxCalculation.Controls.Add(this.taxGrid);
            this.taxCalculation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taxCalculation.Location = new System.Drawing.Point(306, 73);
            this.taxCalculation.Name = "taxCalculation";
            this.taxCalculation.Size = new System.Drawing.Size(762, 229);
            this.taxCalculation.TabIndex = 8;
            this.taxCalculation.TabStop = false;
            this.taxCalculation.Text = "Your Tax Summary";
            // 
            // deleteAll
            // 
            this.deleteAll.BackColor = System.Drawing.SystemColors.Control;
            this.deleteAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAll.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAll.ForeColor = System.Drawing.Color.Purple;
            this.deleteAll.Location = new System.Drawing.Point(121, 183);
            this.deleteAll.Name = "deleteAll";
            this.deleteAll.Size = new System.Drawing.Size(98, 30);
            this.deleteAll.TabIndex = 8;
            this.deleteAll.Text = "Delete All";
            this.deleteAll.UseVisualStyleBackColor = false;
            this.deleteAll.Click += new System.EventHandler(this.deleteAll_Click);
            // 
            // taxBreakdownChart
            // 
            this.taxBreakdownChart.BackColor = System.Drawing.SystemColors.Control;
            this.taxBreakdownChart.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.BackImageTransparentColor = System.Drawing.SystemColors.Control;
            chartArea1.BackSecondaryColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.taxBreakdownChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.SystemColors.Control;
            legend1.Name = "LegendPie";
            this.taxBreakdownChart.Legends.Add(legend1);
            this.taxBreakdownChart.Location = new System.Drawing.Point(14, 19);
            this.taxBreakdownChart.Name = "taxBreakdownChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "LegendPie";
            series1.Name = "Series1";
            series1.XValueMember = "Province";
            series1.YValueMembers = "Net Salary";
            this.taxBreakdownChart.Series.Add(series1);
            this.taxBreakdownChart.Size = new System.Drawing.Size(389, 274);
            this.taxBreakdownChart.TabIndex = 9;
            this.taxBreakdownChart.Text = "Pie Chart Tax Breakdown";
            this.taxBreakdownChart.UseWaitCursor = true;
            // 
            // chartSection
            // 
            this.chartSection.Controls.Add(this.label1);
            this.chartSection.Controls.Add(this.taxOther);
            this.chartSection.Controls.Add(this.taxBreakdownChart);
            this.chartSection.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartSection.Location = new System.Drawing.Point(18, 308);
            this.chartSection.Name = "chartSection";
            this.chartSection.Size = new System.Drawing.Size(1050, 304);
            this.chartSection.TabIndex = 10;
            this.chartSection.TabStop = false;
            this.chartSection.Text = "Tax Summary Breakdown";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(429, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 250);
            this.label1.TabIndex = 11;
            // 
            // taxOther
            // 
            this.taxOther.BackColor = System.Drawing.SystemColors.Control;
            this.taxOther.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea2.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.BackSecondaryColor = System.Drawing.SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            this.taxOther.ChartAreas.Add(chartArea2);
            this.taxOther.Location = new System.Drawing.Point(462, 14);
            this.taxOther.Name = "taxOther";
            this.taxOther.Size = new System.Drawing.Size(582, 279);
            this.taxOther.TabIndex = 10;
            this.taxOther.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            title1.Name = "Title1";
            title1.Text = "Comparison of Total Taxes Across Provinces";
            this.taxOther.Titles.Add(title1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 613);
            this.Controls.Add(this.chartSection);
            this.Controls.Add(this.taxCalculation);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.usrDetails);
            this.Controls.Add(this.calculatorTitle);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.Text = "Canada Taxt Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.usrDetails.ResumeLayout(false);
            this.usrDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxGrid)).EndInit();
            this.taxCalculation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taxBreakdownChart)).EndInit();
            this.chartSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taxOther)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label calculatorTitle;
        private System.Windows.Forms.GroupBox usrDetails;
        private System.Windows.Forms.Label salaryLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox salaryField;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.ComboBox provinceDropdown;
        private System.Windows.Forms.Label provinceLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView taxGrid;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox taxCalculation;
        private System.Windows.Forms.Button deleteAll;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataVisualization.Charting.Chart taxBreakdownChart;
        private System.Windows.Forms.GroupBox chartSection;
        private System.Windows.Forms.DataVisualization.Charting.Chart taxOther;
        private System.Windows.Forms.Label label1;
    }
}


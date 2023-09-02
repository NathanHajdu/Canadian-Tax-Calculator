using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CanadaTaxes
{
    public partial class Form1 : Form
    {
        private string[] provinces;

        private Dictionary<string, double[]> taxRates;

        public Form1()
        {
            InitializeComponent();
            InitializeProvinceDropdown();
            InitializeTaxGrid();
        }

        private void InitializeProvinceDropdown()
        {
            provinces = new string[] { "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland & Labrador", "Northwest Territories", "Nova Scotia", "Nunavut", "Ontario", "PEI", "Quebec", "Saskatchewan", "Yukon" };
            provinceDropdown.Items.AddRange(provinces);
        }


        private void InitializeTaxGrid()
        {
            taxGrid.ColumnCount = 7;
            taxGrid.Columns[0].Name = "Name";
            taxGrid.Columns[1].Name = "Province";
            taxGrid.Columns[2].Name = "Salary";
            taxGrid.Columns[3].Name = "Federal Tax Amount";
            taxGrid.Columns[4].Name = "Provincial Tax Amount";
            taxGrid.Columns[5].Name = "Total Tax Deduction";
            taxGrid.Columns[6].Name = "Net Salary";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string inputName = nameField.Text;
            string inputSalaryText = salaryField.Text;
            string province = provinceDropdown.SelectedItem?.ToString();


            // Check that name and salary fields are not empty.
            if (string.IsNullOrEmpty(inputName))
            {
                MessageBox.Show("Please enter a name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(inputSalaryText))
            {
                MessageBox.Show("Please enter a salary.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check that name field doesn't contain digits, symbols or punctuation.
            if (nameField.Text.Any(c => char.IsDigit(c)) || nameField.Text.Any(c => char.IsSymbol(c)) || nameField.Text.Any(c => char.IsPunctuation(c)))
            {
                MessageBox.Show("Please enter a valid name (must not contain numbers, symbols, or punctuation).", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check that the salary is valid (not negative and numerical)
            if (!double.TryParse(inputSalaryText, out double inputSalary) || inputSalary < 0.0)
            {
                MessageBox.Show("Please enter a valid positive salary (must contain only numbers).", "Invalid Salary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check that a province is selected
            if (string.IsNullOrEmpty(province))
            {
                MessageBox.Show("Please select a province.", "Province not selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            inputName = nameField.Text.Trim();
            province = provinceDropdown.SelectedItem.ToString();

            double fedTax = CalculateFederalTaxes(inputSalary);
            double provTax = CalculateProvincialTaxes(inputSalary, province);
            double totalTaxes = CalculateTotalTaxes(inputSalary, province);
            double netSalary = inputSalary - totalTaxes;


            int rowIndex = taxGrid.Rows.Add();
            DataGridViewRow row = taxGrid.Rows[rowIndex];
            row.Cells["Name"].Value = inputName;
            row.Cells["Province"].Value = province;
            row.Cells["Salary"].Value = inputSalary.ToString("C2");
            row.Cells["Federal Tax Amount"].Value = fedTax.ToString("C2");
            row.Cells["Provincial Tax Amount"].Value = provTax.ToString("C2");
            row.Cells["Total Tax Deduction"].Value = totalTaxes.ToString("C2");
            row.Cells["Net Salary"].Value = netSalary.ToString("C2");

            // Store the values in a double array for pie chart representation
            double[] taxBreakdown = new double[]
            {
                netSalary,
                provTax,
                fedTax
            };

            string[] taxLabels = new string[] { "Net Worth", "Provincial Tax", "Federal Tax" };

            taxBreakdownChart.Series.Clear();
            taxBreakdownChart.Series.Add(new Series("TaxBreakdown"));
            taxBreakdownChart.Series["TaxBreakdown"].ChartType = SeriesChartType.Pie;

            for (int i = 0; i < taxBreakdown.Length; i++)
            {
                string label = taxLabels[i];
                double value = taxBreakdown[i];

                DataPoint dataPoint = taxBreakdownChart.Series[0].Points.Add(value);
                dataPoint.Label = value.ToString("C2");
                dataPoint.LegendText = label;
            }

            // Show group box section once entry has been added
            chartSection.Visible = taxGrid.Rows.Count > 0;

            // Calculate total taxes of other provinces for bar chart
            List<double> totalTaxesOther = new List<double>();
            taxOther.Series.Clear();
            taxOther.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            taxOther.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Bar;
            taxOther.Series.Add(series);

            for (int i = 0; i < provinces.Length; i++)
            {
                string provinceName = provinces[i];
                fedTax = CalculateFederalTaxes(inputSalary);
                provTax = CalculateProvincialTaxes(inputSalary, provinceName);
                totalTaxes = CalculateTotalTaxes(inputSalary, provinceName);
                totalTaxesOther.Add(totalTaxes);

                DataPoint dataPoint = new DataPoint(i, totalTaxes);
                dataPoint.AxisLabel = provinceName;

                series.Points.Add(dataPoint);
            }

            // Highlight user province selection in red for comparison
            foreach (DataPoint dataPoint in series.Points)
            {
                string provinceName = dataPoint.AxisLabel;
                if (provinceName.Equals(province))
                {
                    dataPoint.Color = Color.Red;
                }
            }

            taxOther.ChartAreas[0].AxisX.Interval = 1;
            taxOther.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            taxOther.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            taxOther.Refresh();

        }

        private double CalculateFederalTaxes(double salary)
        {
            double taxFed = 0.0;

            // Federal Tax Calculation
            if (salary <= 53359)
                taxFed = Math.Round(salary * 0.15, 2);
            else if (salary <= 106717)
                taxFed = Math.Round(53359 * 0.15 + (salary - 53359) * 0.205, 2);
            else if (salary <= 165430)
                taxFed = Math.Round(53359 * 0.15 + (106717 - 53359) * 0.205 + (salary - 106717) * 0.26, 2);
            else if (salary <= 235675)
                taxFed = Math.Round(53359 * 0.15 + (106717 - 53359) * 0.205 + (165430 - 106717) * 0.26 + (salary - 165430) * 0.29, 2);
            else
                taxFed = Math.Round(53359 * 0.15 + (106717 - 53359) * 0.205 + (165430 - 106717) * 0.26 + (235675 - 165430) * 0.29 + (salary - 235675) * 0.33, 2);

            return taxFed;
        }


        private double CalculateProvincialTaxes(double salary, string province)
        {
            double taxProv = 0.0;

            // Tax Calculation Source: https://www.canada.ca/en/revenue-agency/services/tax/individuals/frequently-asked-questions-individuals/canadian-income-tax-rates-individuals-current-previous-years.html 

            // Provincial Tax Calculation
            switch (province)
            {
                case "Alberta":
                    if (salary <= 142292)
                        taxProv = salary * 0.1;
                    else if (salary <= 170751)
                        taxProv = 142292 * 0.1 + (salary - 142292) * 0.12;
                    else if (salary <= 227668)
                        taxProv = 142292 * 0.1 + (170751 - 142292) * 0.12 + (salary - 170751) * 0.13;
                    else if (salary <= 341502)
                        taxProv = 142292 * 0.1 + (170751 - 142292) * 0.12 + (227668 - 170751) * 0.13 + (salary - 227668) * 0.14;
                    else
                        taxProv = 142292 * 0.1 + (170751 - 142292) * 0.12 + (227668 - 170751) * 0.13 + (341502 - 227668) * 0.14 + (salary - 341502) * 0.15;
                    break;


                case "British Columbia":
                    if (salary <= 45654)
                        taxProv = salary * 0.0506;
                    else if (salary <= 91310)
                        taxProv = 45654 * 0.0506 + (salary - 45654) * 0.077;
                    else if (salary <= 104835)
                        taxProv = 45654 * 0.0506 + (91310 - 45654) * 0.077 + (salary - 91310) * 0.105;
                    else if (salary <= 127299)
                        taxProv = 45654 * 0.0506 + (91310 - 45654) * 0.077 + (104835 - 91310) * 0.105 + (salary - 104835) * 0.1229;
                    else if (salary <= 172602)
                        taxProv = 45654 * 0.0506 + (91310 - 45654) * 0.077 + (104835 - 91310) * 0.105 + (127299 - 104835) * 0.1229 + (salary - 127299) * 0.147;
                    else if (salary <= 240716)
                        taxProv = 45654 * 0.0506 + (91310 - 45654) * 0.077 + (104835 - 91310) * 0.105 + (127299 - 104835) * 0.1229 + (172602 - 127299) * 0.147 + (salary - 172602) * 0.168;
                    else
                        taxProv = 45654 * 0.0506 + (91310 - 45654) * 0.077 + (104835 - 91310) * 0.105 + (127299 - 104835) * 0.1229 + (172602 - 127299) * 0.147 + (240716 - 172602) * 0.205;
                    break;


                case "Manitoba":
                    if (salary <= 36842)
                        taxProv = salary * 0.108;
                    else if (salary <= 79625)
                        taxProv = 36842 * 0.108 + (salary - 36842) * 0.1275;
                    else
                        taxProv = 36842 * 0.108 + (79625 - 36842) * 0.1275 + (salary - 79625) * 0.174;
                    break;


                case "New Brunswick":
                    if (salary <= 47715)
                        taxProv = salary * 0.094;
                    else if (salary <= 95431)
                        taxProv = 47715 * 0.094 + (salary - 47715) * 0.14;
                    else if (salary <= 176756)
                        taxProv = 47715 * 0.094 + (95431 - 47715) * 0.14 + (salary - 95431) * 0.16;
                    else
                        taxProv = 47715 * 0.094 + (95431 - 47715) * 0.14 + (176756 - 95431) * 0.16 + (salary - 176756) * 0.195;
                    break;


                case "Newfoundland & Labrador":
                    if (salary <= 41457)
                        taxProv = salary * 0.087;
                    else if (salary <= 82913)
                        taxProv = 41457 * 0.087 + (salary - 41457) * 0.145;
                    else if (salary <= 148027)
                        taxProv = 41457 * 0.087 + (82913 - 41457) * 0.145 + (salary - 82913) * 0.158;
                    else if (salary <= 207239)
                        taxProv = 41457 * 0.087 + (82913 - 41457) * 0.145 + (148027 - 82913) * 0.158 + (salary - 148027) * 0.178;
                    else if (salary <= 264750)
                        taxProv = 41457 * 0.087 + (82913 - 41457) * 0.145 + (148027 - 82913) * 0.158 + (207239 - 148027) * 0.178 + (salary - 207239) * 0.198;
                    else if (salary <= 529500)
                        taxProv = 41457 * 0.087 + (82913 - 41457) * 0.145 + (148027 - 82913) * 0.158 + (207239 - 148027) * 0.178 + (264750 - 207239) * 0.198 + (salary - 264750) * 0.208;
                    else if (salary <= 1059000)
                        taxProv = 41457 * 0.087 + (82913 - 41457) * 0.145 + (148027 - 82913) * 0.158 + (207239 - 148027) * 0.178 + (264750 - 207239) * 0.198 + (529500 - 264750) * 0.208 + (salary - 529500) * 0.213;
                    else
                        taxProv = 41457 * 0.087 + (82913 - 41457) * 0.145 + (148027 - 82913) * 0.158 + (207239 - 148027) * 0.178 + (264750 - 207239) * 0.198 + (529500 - 264750) * 0.208 + (1059000 - 529500) * 0.213 + (salary - 1059000) * 0.218;
                    break;


                case "Northwest Territories":
                    if (salary <= 48326)
                        taxProv = salary * 0.059;
                    else if (salary <= 96655)
                        taxProv = 48326 * 0.059 + (salary - 48326) * 0.086;
                    else if (salary <= 157139)
                        taxProv = 48326 * 0.059 + (96655 - 48326) * 0.086 + (salary - 96655) * 0.122;
                    else
                        taxProv = 48326 * 0.059 + (96655 - 48326) * 0.086 + (157139 - 96655) * 0.122 + (salary - 157139) * 0.1405;
                    break;


                case "Nova Scotia":
                    if (salary <= 29590)
                        taxProv = salary * 0.0879;
                    else if (salary <= 59180)
                        taxProv = 29590 * 0.0879 + (salary - 29590) * 0.1495;
                    else if (salary <= 93000)
                        taxProv = 29590 * 0.0879 + (59180 - 29590) * 0.1495 + (salary - 59180) * 0.1667;
                    else if (salary <= 150000)
                        taxProv = 29590 * 0.0879 + (59180 - 29590) * 0.1495 + (93000 - 59180) * 0.1667 + (salary - 93000) * 0.175;
                    else
                        taxProv = 29590 * 0.0879 + (59180 - 29590) * 0.1495 + (93000 - 59180) * 0.1667 + (150000 - 93000) * 0.175 + (salary - 150000) * 0.21;
                    break;

                case "Nunavut":
                    if (salary <= 50877)
                        taxProv = salary * 0.04;
                    else if (salary <= 101754)
                        taxProv = 50877 * 0.04 + (salary - 50877) * 0.07;
                    else if (salary <= 165429)
                        taxProv = 50877 * 0.04 + (101754 - 50877) * 0.07 + (salary - 101754) * 0.09;
                    else
                        taxProv = 50877 * 0.04 + (101754 - 50877) * 0.07 + (165429 - 101754) * 0.09 + (salary - 165429) * 0.115;
                    break;



                case "Ontario":
                    if (salary <= 49231)
                        taxProv = salary * 0.0505;
                    else if (salary <= 98463)
                        taxProv = 49231 * 0.0505 + (salary - 49231) * 0.0915;
                    else if (salary <= 150000)
                        taxProv = 49231 * 0.0505 + (98463 - 49231) * 0.0915 + (salary - 98463) * 0.1116;
                    else if (salary <= 220000)
                        taxProv = 49231 * 0.0505 + (98463 - 49231) * 0.0915 + (150000 - 98463) * 0.1116 + (salary - 150000) * 0.1216;
                    else
                        taxProv = 49231 * 0.0505 + (98463 - 49231) * 0.0915 + (150000 - 98463) * 0.1116 + (220000 - 150000) * 0.1216 + (salary - 220000) * 0.1316;
                    break;


                case "PEI":
                    if (salary <= 31984)
                        taxProv = salary * 0.098;
                    else if (salary <= 63969)
                        taxProv = 31984 * 0.098 + (salary - 31984) * 0.138;
                    else
                        taxProv = 31984 * 0.098 + (63969 - 31984) * 0.138 + (salary - 63969) * 0.167;
                    break;


                case "Quebec":
                    if (salary <= 49275)
                        taxProv = salary * 0.14;
                    else if (salary <= 98540)
                        taxProv = 49275 * 0.14 + (salary - 49275) * 0.19;
                    else if (salary <= 119910)
                        taxProv = 49275 * 0.14 + (98540 - 49275) * 0.19 + (salary - 98540) * 0.24;
                    else
                        taxProv = 49275 * 0.14 + (98540 - 49275) * 0.19 + (119910 - 98540) * 0.24 + (salary - 119910) * 0.2575;
                    break;


                case "Saskatchewan":
                    if (salary <= 49720)
                        taxProv = salary * 0.105;
                    else if (salary <= 142058)
                        taxProv = 49720 * 0.105 + (salary - 49720) * 0.125;
                    else
                        taxProv = 49720 * 0.105 + (142058 - 49720) * 0.125 + (salary - 142058) * 0.145;
                    break;


                case "Yukon":
                    if (salary <= 53359)
                        taxProv = salary * 0.064;
                    else if (salary <= 106717)
                        taxProv = 53359 * 0.064 + (salary - 53359) * 0.09;
                    else if (salary <= 165430)
                        taxProv = 53359 * 0.064 + (106717 - 53359) * 0.09 + (salary - 106717) * 0.109;
                    else if (salary <= 500000)
                        taxProv = 53359 * 0.064 + (106717 - 53359) * 0.09 + (165430 - 106717) * 0.109 + (salary - 165430) * 0.128;
                    else
                        taxProv = 53359 * 0.064 + (106717 - 53359) * 0.09 + (165430 - 106717) * 0.109 + (500000 - 165430) * 0.128 + (salary - 500000) * 0.15;
                    break;


                default:
                    break;
            }
            return taxProv;
        }

        private double CalculateTotalTaxes(double salary, string province)
        {
            double taxFed = CalculateFederalTaxes(salary);
            double taxProv = CalculateProvincialTaxes(salary, province);

            double taxTotal = taxFed + taxProv;

            return taxTotal;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (taxGrid.SelectedCells.Count > 0)
            {
                int rowIndex = taxGrid.SelectedCells[0].RowIndex;

                // Check if the row being delete isn't the new entry row (last one) and that it contains data
                if (rowIndex != taxGrid.Rows.Count - 1 || taxGrid.Rows[rowIndex].Cells[0].Value != null)
                {
                    taxGrid.Rows.RemoveAt(rowIndex);
                }
            }

        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            taxGrid.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chartSection.Visible = false;
        }

       
    }
}

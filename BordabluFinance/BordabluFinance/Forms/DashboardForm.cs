using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Presentation.Forms
{
    public partial class DashboardForm : Form
    {
        #region Properties
        private UserModel model = new UserModel();
        private CustomChart salesChart = new CustomChart();
        private CustomChart earnExpenseChart = new CustomChart();
        private bool filling = false;
        #endregion

        #region Constructor
        public DashboardForm()
        {
            InitializeComponent();

            salesYearCmb.Visible = salesMonthCmb.Visible =
                salesYearLbl.Visible = salesMonthLbl.Visible = false;
            graphYearCmb.Visible = graphYearLbl.Visible =
                graphMonthCmb.Visible = graphMonthLbl.Visible = false;

            filling = true;
            FillCombos();
            filling = false;

            salesChart.Location = new Point(24, 105);
            salesChart.Parent = dashPanel;
            salesChart.DataSource = null;
            salesChart.DataSource = model.SalesPerProduct();
            salesChart.Series[0].XValueMember = "Product";
            salesChart.Series[0].YValueMembers = "Qty";
            salesChart.ChartAreas[0].AxisX.Interval = 1;
            salesChart.Series[0].LegendText = "Ventas";

            earnExpenseChart.Location = new Point(24, 615);
            earnExpenseChart.Parent = dashPanel;
            earnExpenseChart.AddSeries();
            earnExpenseChart.Series[1].ChartArea = "ChartArea1";
            earnExpenseChart.Series[0].ChartType =
                earnExpenseChart.Series[1].ChartType = SeriesChartType.Line;
            earnExpenseChart.DataSource = null;
            earnExpenseChart.DataSource =
                BindTables(model.EarningsPerYear(), model.ExpensesPerYear()); ;
            earnExpenseChart.Series[0].XValueMember =
                earnExpenseChart.Series[1].XValueMember = "Year";
            earnExpenseChart.Series[0].YValueMembers = "Earnings";
            earnExpenseChart.Series[1].YValueMembers = "Expenses";
            earnExpenseChart.ChartAreas[0].AxisX.Interval = 1;
            earnExpenseChart.Series[0].LegendText = "Ganancias";
            earnExpenseChart.Series[1].LegendText = "Gastos";
            earnExpenseChart.ChartAreas[0].AxisY.LabelStyle.Format = "$0.00";
            earnExpenseChart.Series[0].LabelFormat = 
                earnExpenseChart.Series[1].LabelFormat = "$0.00";

            salesChart.Series[0].BorderWidth = earnExpenseChart.Series[0].BorderWidth =
                earnExpenseChart.Series[1].BorderWidth = 3;

            if (((DataTable)salesChart.DataSource).Rows.Count != 0)
                noDataPict1.Visible = false;
            if (((DataTable)earnExpenseChart.DataSource).Rows.Count != 0)
                noDataPict2.Visible = false;
        }
        #endregion

        #region Functional Methods
        private DataTable BindTables(DataTable earningsTable, DataTable expensesTable)
        {
            DataTable bindedTable = new DataTable();
            List<int> yearsVisited = new List<int>();
            bindedTable.Columns.Add("Year", typeof(int));
            bindedTable.Columns.Add("Earnings", typeof(decimal));
            bindedTable.Columns.Add("Expenses", typeof(decimal));
            foreach (DataRow row in earningsTable.Rows)
            {
                decimal second = 0;
                foreach (DataRow row1 in expensesTable.Rows)
                {
                    if (row1.ItemArray[0].ToString() == row.ItemArray[0].ToString())
                    {
                        yearsVisited.Add(Convert.ToInt32(row1.ItemArray[0]));
                        second = Convert.ToDecimal(row1.ItemArray[1]);
                    }
                }
                bindedTable.Rows.Add(row.ItemArray[0], row.ItemArray[1], second);
            }
            foreach (DataRow row2 in expensesTable.Rows)
            {
                bool finded = false;
                foreach (int year in yearsVisited)
                {
                    if (year == Convert.ToInt32(row2.ItemArray[0]))
                        finded = true;
                }
                if (!finded)
                    bindedTable.Rows.Add(row2.ItemArray[0], 0, row2.ItemArray[1]);
            }
            DataView dv = bindedTable.DefaultView;
            dv.Sort = "Year ASC";
            return dv.ToTable();
        }
        private DataTable FillAllMonths(DataTable dataTable)
        {
            bool find;
            for (int i = 1; i <= 12; i++)
            {
                find = false;
                foreach (DataRow item in dataTable.Rows)
                    if (item.ItemArray[0].ToString() == i.ToString())
                        find = true;
                if (!find)
                    dataTable.Rows.Add(i, 0);
            }
            dataTable.Columns[0].ColumnName = "Year";
            DataView dv = dataTable.DefaultView;
            dv.Sort = "Year asc";
            DataTable dt1 = dv.ToTable();
            DataTable dt2 = dt1.Clone();
            dt2.Columns[0].DataType = typeof(string);
            foreach (DataRow row in dt1.Rows)
                dt2.ImportRow(row);
            foreach (DataRow item in dt2.Rows)
                item[0] = MonthName(Convert.ToInt32(item.ItemArray[0]));
            return dt2;
        }
        private void FillCombos()
        {
            Dictionary<int, string> salesBy = new Dictionary<int, string>();
            salesBy.Add(1, "Producto");
            salesBy.Add(2, "Año");
            salesBy.Add(3, "Mes");
            salesBy.Add(4, "Día");
            salesPerCmb.DataSource = null;
            salesPerCmb.DataSource = new BindingSource(salesBy, null);
            salesPerCmb.ValueMember = "Key";
            salesPerCmb.DisplayMember = "Value";


            Dictionary<int, string> years = new Dictionary<int, string>();
            int year = DateTime.Now.Year;
            for (int i = 1; i <= 10; i++)
            {
                years.Add(i, year.ToString());
                year -= 1;
            }
            salesYearCmb.DataSource = null;
            salesYearCmb.DataSource = new BindingSource(years, null);
            salesYearCmb.ValueMember = "Key";
            salesYearCmb.DisplayMember = "Value";

            Dictionary<int, string> months = new Dictionary<int, string>();
            months.Add(1, "Enero");
            months.Add(2, "Febrero");
            months.Add(3, "Marzo");
            months.Add(4, "Abril");
            months.Add(5, "Mayo");
            months.Add(6, "Junio");
            months.Add(7, "Julio");
            months.Add(8, "Agosto");
            months.Add(9, "Septiembre");
            months.Add(10, "Octubre");
            months.Add(11, "Noviembre");
            months.Add(12, "Diciembre");
            salesMonthCmb.DataSource = null;
            salesMonthCmb.DataSource = new BindingSource(months, null);
            salesMonthCmb.ValueMember = "Key";
            salesMonthCmb.DisplayMember = "Value";

            Dictionary<int, string> charType = new Dictionary<int, string>();
            charType.Add(1, "Barras");
            charType.Add(2, "Líneas");
            charType.Add(3, "Pastel");
            chartTypeCmb.DataSource = null;
            chartTypeCmb.DataSource = new BindingSource(charType, null);
            chartTypeCmb.ValueMember = "Key";
            chartTypeCmb.DisplayMember = "Value";

            Dictionary<int, string> salesBy2 = new Dictionary<int, string>();
            salesBy2.Add(1, "Año");
            salesBy2.Add(2, "Mes");
            salesBy2.Add(3, "Día");
            graphByCmb.DataSource = null;
            graphByCmb.DataSource = new BindingSource(salesBy2, null);
            graphByCmb.ValueMember = "Key";
            graphByCmb.DisplayMember = "Value";


            Dictionary<int, string> years2 = new Dictionary<int, string>();
            int year2 = DateTime.Now.Year;
            for (int i = 1; i <= 10; i++)
            {
                years2.Add(i, year2.ToString());
                year2 -= 1;
            }
            graphYearCmb.DataSource = null;
            graphYearCmb.DataSource = new BindingSource(years2, null);
            graphYearCmb.ValueMember = "Key";
            graphYearCmb.DisplayMember = "Value";

            Dictionary<int, string> months2 = new Dictionary<int, string>();
            months2.Add(1, "Enero");
            months2.Add(2, "Febrero");
            months2.Add(3, "Marzo");
            months2.Add(4, "Abril");
            months2.Add(5, "Mayo");
            months2.Add(6, "Junio");
            months2.Add(7, "Julio");
            months2.Add(8, "Agosto");
            months2.Add(9, "Septiembre");
            months2.Add(10, "Octubre");
            months2.Add(11, "Noviembre");
            months2.Add(12, "Diciembre");
            graphMonthCmb.DataSource = null;
            graphMonthCmb.DataSource = new BindingSource(months2, null);
            graphMonthCmb.ValueMember = "Key";
            graphMonthCmb.DisplayMember = "Value";

            Dictionary<int, string> charType2 = new Dictionary<int, string>();
            charType2.Add(1, "Líneas");
            charType2.Add(2, "Barras");
            graphTypeCmb.DataSource = null;
            graphTypeCmb.DataSource = new BindingSource(charType2, null);
            graphTypeCmb.ValueMember = "Key";
            graphTypeCmb.DisplayMember = "Value";
        }
        private string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
        #endregion

        #region Sales Event Methods
        private void salesPerCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            salesYearCmb.Visible = salesMonthCmb.Visible =
                salesYearLbl.Visible = salesMonthLbl.Visible = false;
            if (!filling)
            {
                switch (salesPerCmb.SelectedIndex)
                {
                    case 0:
                        salesChart.DataSource = null;
                        salesChart.DataSource = model.SalesPerProduct();
                        salesChart.Series[0].XValueMember = "Product";
                        salesChart.Series[0].YValueMembers = "Qty";
                        break;
                    case 1:
                        salesChart.DataSource = null;
                        salesChart.DataSource = model.SalesPerYear();
                        salesChart.Series[0].XValueMember = "Year";
                        salesChart.Series[0].YValueMembers = "Sales";
                        break;
                    case 2:
                        salesYearCmb.Visible = salesYearLbl.Visible = true;
                        salesChart.DataSource = null;
                        salesChart.DataSource = model.SalesPerMonth(DateTime.Now.Year);
                        salesChart.Series[0].XValueMember = "Month";
                        salesChart.Series[0].YValueMembers = "Sales";
                        break;
                    case 3:
                        salesYearCmb.Visible = salesMonthCmb.Visible =
                            salesYearLbl.Visible = salesMonthLbl.Visible = true;
                        salesChart.DataSource = null;
                        salesChart.DataSource = model.SalesPerDay(DateTime.Now.Year, 1);
                        salesChart.Series[0].XValueMember = "Day";
                        salesChart.Series[0].YValueMembers = "Sales";
                        break;
                }
                salesChart.DataBind();
                if (((DataTable)salesChart.DataSource).Rows.Count != 0)
                    noDataPict1.Visible = false;
                else
                    noDataPict1.Visible = true;
            }
        }
        private void salesYearCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling)
            {
                switch (salesPerCmb.SelectedIndex)
                {
                    case 2:
                        salesYearCmb.Visible = true;
                        salesChart.DataSource = null;
                        salesChart.DataSource =
                            model.SalesPerMonth(Convert.ToInt32(
                                ((KeyValuePair<int, string>)salesYearCmb.SelectedItem).Value));
                        salesChart.Series[0].XValueMember = "Month";
                        salesChart.Series[0].YValueMembers = "Sales";
                        break;
                    case 3:
                        salesYearCmb.Visible = salesMonthCmb.Visible = true;
                        salesChart.DataSource = null;
                        salesChart.DataSource = model.SalesPerDay(Convert.ToInt32(
                                ((KeyValuePair<int, string>)salesYearCmb.SelectedItem).Value),
                                ((KeyValuePair<int, string>)salesMonthCmb.SelectedItem).Key);
                        salesChart.Series[0].XValueMember = "Day";
                        salesChart.Series[0].YValueMembers = "Sales";
                        break;
                }
                salesChart.DataBind();
                if (((DataTable)salesChart.DataSource).Rows.Count != 0)
                    noDataPict1.Visible = false;
                else
                    noDataPict1.Visible = true;
            }
        }
        private void salesMonthCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling)
            {
                salesYearCmb.Visible = salesMonthCmb.Visible = true;
                salesChart.DataSource = null;
                salesChart.DataSource = model.SalesPerDay(Convert.ToInt32(
                        ((KeyValuePair<int, string>)salesYearCmb.SelectedItem).Value),
                        ((KeyValuePair<int, string>)salesMonthCmb.SelectedItem).Key);
                salesChart.Series[0].XValueMember = "Day";
                salesChart.Series[0].YValueMembers = "Sales";
                salesChart.DataBind();
                if (((DataTable)salesChart.DataSource).Rows.Count != 0)
                    noDataPict1.Visible = false;
                else
                    noDataPict1.Visible = true;
            }
        }
        private void chartTypeCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling)
            {
                salesChart.Series[0].LegendText = "Ventas";
                switch (chartTypeCmb.SelectedIndex)
                {
                    case 0:
                        salesChart.Series[0].ChartType = SeriesChartType.Column;
                        break;
                    case 1:
                        salesChart.Series[0].ChartType = SeriesChartType.Line;
                        break;
                    case 2:
                        salesChart.Series[0].LegendText = "";
                        salesChart.Series[0].ChartType = SeriesChartType.Pie;
                        break;
                }
            }
        }
        #endregion

        #region Incomes And Outcomes Event Methods
        private void graphByCmb_SelectedValueChanged(object sender, EventArgs e)
        {

            graphYearCmb.Visible = graphYearLbl.Visible =
                graphMonthCmb.Visible = graphMonthLbl.Visible = false;
            if (!filling)
            {
                switch (graphByCmb.SelectedIndex)
                {
                    case 0:
                        earnExpenseChart.DataSource = null;
                        earnExpenseChart.DataSource =
                            BindTables(model.EarningsPerYear(), model.ExpensesPerYear());
                        earnExpenseChart.Series[0].XValueMember = "Year";
                        earnExpenseChart.Series[0].YValueMembers = "Earnings";
                        earnExpenseChart.Series[1].XValueMember = "Year";
                        earnExpenseChart.Series[1].YValueMembers = "Expenses";
                        break;
                    case 1:
                        graphYearCmb.Visible = graphYearLbl.Visible = true;
                        earnExpenseChart.DataSource = null;
                        earnExpenseChart.DataSource =
                            FillAllMonths(
                            BindTables(model.EarningsPerMonth(DateTime.Now.Year),
                            model.ExpensesPerMonth(DateTime.Now.Year)));
                        earnExpenseChart.Series[0].XValueMember = "Year";
                        earnExpenseChart.Series[0].YValueMembers = "Earnings";
                        earnExpenseChart.Series[1].XValueMember = "Year";
                        earnExpenseChart.Series[1].YValueMembers = "Expenses";
                        break;
                    case 2:
                        graphYearCmb.Visible = graphYearLbl.Visible =
                            graphMonthCmb.Visible = graphMonthLbl.Visible = true;
                        earnExpenseChart.DataSource = null;
                        earnExpenseChart.DataSource =
                            BindTables(model.EarningsPerDay(DateTime.Now.Year, 1),
                            model.ExpensesPerDay(DateTime.Now.Year, 1));
                        earnExpenseChart.Series[0].XValueMember = "Year";
                        earnExpenseChart.Series[0].YValueMembers = "Earnings";
                        earnExpenseChart.Series[1].XValueMember = "Year";
                        earnExpenseChart.Series[1].YValueMembers = "Expenses";
                        break;
                }
                earnExpenseChart.DataBind();
                if (((DataTable)earnExpenseChart.DataSource).Rows.Count != 0)
                    noDataPict2.Visible = false;
                else
                    noDataPict2.Visible = true;
            }
        }
        private void graphYearCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling)
            {
                switch (graphByCmb.SelectedIndex)
                {
                    case 1:
                        graphYearCmb.Visible = graphYearLbl.Visible = true;
                        earnExpenseChart.DataSource = null;
                        earnExpenseChart.DataSource =
                            FillAllMonths(
                            BindTables(model.EarningsPerMonth(Convert.ToInt32(
                        ((KeyValuePair<int, string>)graphYearCmb.SelectedItem).Value)),
                            model.ExpensesPerMonth(Convert.ToInt32(
                        ((KeyValuePair<int, string>)graphYearCmb.SelectedItem).Value))));
                        earnExpenseChart.Series[0].XValueMember = "Year";
                        earnExpenseChart.Series[0].YValueMembers = "Earnings";
                        earnExpenseChart.Series[1].XValueMember = "Year";
                        earnExpenseChart.Series[1].YValueMembers = "Expenses";
                        break;
                    case 2:
                        graphYearCmb.Visible = graphYearLbl.Visible =
                            graphMonthCmb.Visible = graphMonthLbl.Visible = true;
                        earnExpenseChart.DataSource = null;
                        earnExpenseChart.DataSource =
                            BindTables(model.EarningsPerDay(Convert.ToInt32(
                                ((KeyValuePair<int, string>)graphYearCmb.SelectedItem).Value),
                                ((KeyValuePair<int, string>)graphMonthCmb.SelectedItem).Key),
                            model.ExpensesPerDay(Convert.ToInt32(
                                ((KeyValuePair<int, string>)graphYearCmb.SelectedItem).Value),
                                ((KeyValuePair<int, string>)graphMonthCmb.SelectedItem).Key));
                        earnExpenseChart.Series[0].XValueMember = "Year";
                        earnExpenseChart.Series[0].YValueMembers = "Earnings";
                        earnExpenseChart.Series[1].XValueMember = "Year";
                        earnExpenseChart.Series[1].YValueMembers = "Expenses";
                        break;
                }
                earnExpenseChart.DataBind();
                if (((DataTable)earnExpenseChart.DataSource).Rows.Count != 0)
                    noDataPict2.Visible = false;
                else
                    noDataPict2.Visible = true;
            }
        }
        private void graphMonthCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling)
            {
                earnExpenseChart.DataSource = null;
                earnExpenseChart.DataSource =
                    BindTables(model.EarningsPerDay(Convert.ToInt32(
                        ((KeyValuePair<int, string>)graphYearCmb.SelectedItem).Value),
                        ((KeyValuePair<int, string>)graphMonthCmb.SelectedItem).Key),
                    model.ExpensesPerDay(Convert.ToInt32(
                        ((KeyValuePair<int, string>)graphYearCmb.SelectedItem).Value),
                        ((KeyValuePair<int, string>)graphMonthCmb.SelectedItem).Key));
                earnExpenseChart.Series[0].XValueMember = "Year";
                earnExpenseChart.Series[0].YValueMembers = "Earnings";
                earnExpenseChart.Series[1].XValueMember = "Year";
                earnExpenseChart.Series[1].YValueMembers = "Expenses";
                earnExpenseChart.DataBind();
                if (((DataTable)earnExpenseChart.DataSource).Rows.Count != 0)
                    noDataPict2.Visible = false;
                else
                    noDataPict2.Visible = true;
            }
        }
        private void graphTypeCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling)
            {
                switch (graphTypeCmb.SelectedIndex)
                {
                    case 0:
                        earnExpenseChart.Series[0].ChartType =
                            earnExpenseChart.Series[1].ChartType = SeriesChartType.Line;
                        break;
                    case 1:
                        earnExpenseChart.Series[0].ChartType =
                            earnExpenseChart.Series[1].ChartType = SeriesChartType.Column;
                        break;
                }
            }
        }
        #endregion



        #region Internal Classes
        public class CustomChart : Chart
        {
            public CustomChart()
            {
                InitializeChart();
                this.Enabled = false;
                this.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                this.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                this.CustomizeLegend += CustomChart_CustomizeLegend;
            }
            private void CustomChart_CustomizeLegend(object sender, CustomizeLegendEventArgs e)
            {
                foreach (LegendItem lit in e.LegendItems)
                {
                    var cells = lit.Cells;
                    cells[0].Margins = new Margins(0, 0, 0, 0);
                    cells[1].Margins = new Margins(0, 0, 0, 0);
                }
            }
            private void InitializeChart()
            {
                ChartArea chartArea1 = new ChartArea();
                Legend legend1 = new Legend();
                ((ISupportInitialize)(this)).BeginInit();
                this.BackColor = Color.FromArgb(211, 140, 86);
                chartArea1.Area3DStyle.IsRightAngleAxes = false;
                chartArea1.Area3DStyle.Rotation = 5;
                chartArea1.Area3DStyle.WallWidth = 5;
                chartArea1.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chartArea1.AxisX2.IntervalAutoMode = IntervalAutoMode.VariableCount;
                chartArea1.BackColor = Color.FromArgb(211, 140, 86);
                chartArea1.Name = "ChartArea1";
                this.ChartAreas.Add(chartArea1);
                legend1.BackColor = Color.FromArgb(211, 140, 86);
                legend1.Font = new Font("Roboto Condensed", 10F);
                legend1.InterlacedRowsColor = Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
                legend1.IsTextAutoFit = false;
                legend1.Name = "Legend1";
                legend1.Title = "Cantidad";
                this.Legends.Add(legend1);
                this.Location = new Point(40, 177);
                this.Name = "chart";
                this.Palette = ChartColorPalette.Chocolate;
                AddSeries();
                this.Size = new Size(652, 400);
                this.TabIndex = 0;
                this.Text = "chartTop5";
            }
            public void AddSeries()
            {
                Series series = new Series();
                series.ChartArea = "ChartArea1";
                series.Font = new Font("Roboto Condensed", 13F, FontStyle.Bold);
                series.IsValueShownAsLabel = true;
                series.LabelBackColor = Color.Transparent;
                series.LabelForeColor = Color.Black;
                series.Legend = "Legend1";
                this.Series.Add(series);
            }
        }
        #endregion
    }
}

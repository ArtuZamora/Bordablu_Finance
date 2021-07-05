using BordabluFinance;
using Common.Model;
using Domain;
using Presentation.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace Presentation.Forms
{
    public partial class CheckOrderForm : Form
    {
        #region Properties
        private UserModel model = new UserModel();
        private Filters filters = new Filters();
        private static List<Order> orders, sortedOrders;
        #endregion

        #region Constructor
        public CheckOrderForm()
        {
            InitializeComponent();
            orders = model.Select_Orders();
            ordersDgv.ShowCellToolTips = false;

            toolStripMenuItem5.Click += ToolStripMenuItem5_Click;
            toolStripMenuItem6.Click += ToolStripMenuItem6_Click;
            FilterDgv();
            ordersDgv.MultiSelect = false;
            if (ordersDgv.Rows.Count > 0)
                if (ordersDgv.Rows[0].Cells[11].Value.ToString().Trim() == "En Proceso")
                    ordersDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 241, 205);
                else
                    ordersDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(114, 194, 0);
        }
        #endregion

        #region Functional Events
        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (ordersDgv.CurrentRow.Cells[11].Value.ToString().Trim() == "En Proceso")
            {
                model.Update_Order_Status(
                    ordersDgv.CurrentRow.Cells[0].Value.ToString(), "Terminado");
                orders = model.Select_Orders();
                FilterDgv();
            }
        }
        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (ordersDgv.CurrentRow.Cells[11].Value.ToString().Trim() == "Terminado")
            {
                model.Update_Order_Status(
                    ordersDgv.CurrentRow.Cells[0].Value.ToString(), "En Proceso");
                orders = model.Select_Orders();
                FilterDgv();
            }
        }
        private void ordersDgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in ordersDgv.Rows)
                if (Myrow.Cells[11].Value.ToString().Trim() == "En Proceso")
                    Myrow.DefaultCellStyle.BackColor = Color.FromArgb(255, 241, 205);
                else
                    Myrow.DefaultCellStyle.BackColor = Color.FromArgb(114, 194, 0);
        }
        private void ordersDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalMethods.ContextDGV((DataGridView)sender, e, MousePosition, ordersCtxtMenu);
        }
        private void ordersCtxtMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Ver detalle":
                    SeeOrderDetail();
                    break;
                case "Modificar":
                    EditOrder();
                    break;
                case "Eliminar":
                    ((ContextMenuStrip)sender).Hide();
                    if (DialogResult.Yes ==
                        MessageBox.Show("¿Está seguro de querer eliminar esta orden por completo?",
                            "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        try
                        {
                            Order order = new Order();
                            order.ID_O = ordersDgv.CurrentRow.Cells[0].Value.ToString();
                            order.Total_Amount = Convert.ToDecimal(ordersDgv.CurrentRow.Cells[7].Value);
                            order.Earned_Amount = Convert.ToDecimal(ordersDgv.CurrentRow.Cells[8].Value);
                            order.Help = Convert.ToBoolean(ordersDgv.CurrentRow.Cells[12].Value);
                            order.ID_PM = ordersDgv.CurrentRow.Cells[9].Value.ToString();
                            model.Delete_Order(order);
                            orders = model.Select_Orders();
                            FilterDgv();
                            MessageBox.Show("Orden eliminada con éxito",
                             "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("La solicitud no pudo ser procesada. Error: " + ex.Message,
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }
        private void filterLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OrderFilter orderFilter = new OrderFilter(ref filters);
            orderFilter.FormClosed += OrderFilter_FormClosed;
            orderFilter.ShowDialog();
        }
        private void OrderFilter_FormClosed(object sender, FormClosedEventArgs e)
        {
            FilterDgv();
        }
        private void searchTxt_TextChanged(object sender, EventArgs e)
        {
            switch (filters.SearchBy)
            {
                case 0:
                    ordersDgv.DataSource =
                        sortedOrders.Where(o => o.Order_Date.ToString("MM/dd/yyyy")
                        .Contains(searchTxt.Text))
                        .ToList();
                    break;
                case 1:
                    ordersDgv.DataSource =
                        sortedOrders.Where(o => o.Delivery_Date.ToString("MM/dd/yyyy")
                        .Contains(searchTxt.Text))
                        .ToList();
                    break;
                case 2:
                    ordersDgv.DataSource =
                        sortedOrders.Where(o => o.Client.ToLower()
                        .Contains(searchTxt.Text.ToLower()))
                        .ToList();
                    break;
                case 3:
                    ordersDgv.DataSource =
                        sortedOrders.Where(o => o.Total_Amount.ToString()
                        .Contains(searchTxt.Text))
                        .ToList();
                    break;
            }
        }
        #endregion

        #region Functional Methods
        private void DgvConfig()
        {
            ordersDgv.Columns[0].Visible = false;
            ordersDgv.Columns[1].Visible = true;
            ordersDgv.Columns[1].HeaderText = "Fecha Pedido";
            ordersDgv.Columns[2].Visible = true;
            ordersDgv.Columns[2].HeaderText = "Fecha Entrega";
            ordersDgv.Columns[3].Visible = true;
            ordersDgv.Columns[3].HeaderText = "Cliente";
            ordersDgv.Columns[4].Visible = false;
            ordersDgv.Columns[5].Visible = false;
            ordersDgv.Columns[6].Visible = false;
            ordersDgv.Columns[7].Visible = true;
            ordersDgv.Columns[7].HeaderText = "Costo";
            ordersDgv.Columns[7].DefaultCellStyle.Format = "$0.00";
            ordersDgv.Columns[8].Visible = false;
            ordersDgv.Columns[9].Visible = false;
            ordersDgv.Columns[10].Visible = false;
            ordersDgv.Columns[11].Visible = false;
            ordersDgv.Columns[12].Visible = false;
            ordersDgv.Columns[13].Visible = false;
        }
        private void FilterDgv()
        {
            ordersDgv.DataSource = null;
            switch (filters.OrderBy)
            {
                case 0:
                    if (filters.OrderTo == 0)
                        ordersDgv.DataSource = orders.OrderBy(o => o.Order_Date).ToList();
                    else
                        ordersDgv.DataSource = orders.OrderByDescending(o => o.Order_Date).ToList();
                    break;
                case 1:
                    if (filters.OrderTo == 0)
                        ordersDgv.DataSource = orders.OrderBy(o => o.Delivery_Date).ToList();
                    else
                        ordersDgv.DataSource = orders.OrderByDescending(o => o.Delivery_Date).ToList();
                    break;
                case 2:
                    if (filters.OrderTo == 0)
                        ordersDgv.DataSource = orders.OrderBy(o => o.Client).ToList();
                    else
                        ordersDgv.DataSource = orders.OrderByDescending(o => o.Client).ToList();
                    break;
                case 3:
                    if (filters.OrderTo == 0)
                        ordersDgv.DataSource = orders.OrderBy(o => o.Total_Amount).ToList();
                    else
                        ordersDgv.DataSource = orders.OrderByDescending(o => o.Total_Amount).ToList();
                    break;
            }
            if (!(filters.YearIndex == 0 && filters.Month == 0 && filters.Day == 0))
            {
                string year, month, day;
                year = filters.YearIndex == 0 ? "[0-9][0-9][0-9][0-9]" : filters.Year;
                month = filters.Month == 0 ? "[0-9][0-9]" : filters.Month.ToString();
                day = filters.Day == 0 ? "[0-9][0-9]" : filters.Day.ToString();

                if(filters.Day != 0)
                    if (day.Length == 1)
                        day = "0" + day;
                if (filters.Month != 0)
                    if (month.Length == 1)
                        month = "0" + month;

                List<Order> currOrders = (List<Order>)ordersDgv.DataSource;
                string rx = string.Format("{0}/{1}/{2}", month, day, year);
                var myRegex = new Regex(rx);

                if (filters.DateFilter == 0)
                {
                    ordersDgv.DataSource = currOrders.
                        Where(o => myRegex.IsMatch(o.Order_Date.ToString("MM/dd/yyyy"))).ToList();
                }
                else
                {
                    ordersDgv.DataSource = currOrders.
                        Where(o => myRegex.IsMatch(o.Delivery_Date.ToString("MM/dd/yyyy"))).ToList();
                }
            }
            sortedOrders = (List<Order>)ordersDgv.DataSource;
            DgvConfig();
            if (ordersDgv.Rows.Count > 0)
                if (ordersDgv.Rows[0].Cells[11].Value.ToString().Trim() == "En Proceso")
                    ordersDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 241, 205);
                else
                    ordersDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(114, 194, 0);
        }
        private void SeeOrderDetail()
        {
            Order order = model.Select_Orders(ordersDgv.CurrentRow.Cells[0].Value.ToString());
            List<OrderDetail> orderDetails = model.Select_Order_Details(order.ID_O);
            List<ProductQty> products = model.Select_Order_Detail_Products(order.ID_O);
            List<Control> controls = new List<Control>();
            foreach (ProductQty product in products)
            {
                Panel productPanel =
                    CreateProductPanel(product,
                    orderDetails.FindAll(od => od.ID_P == product.ID_P && od.P_Num == product.P_Num));
                controls.Add(productPanel);
            }
            Program.mainForm.EnterForm(Program.mainForm.addOrderPanel, 3,
                "Detalle de orden", order, ref controls);
        }
        private void EditOrder()
        {
            Order order = model.Select_Orders(ordersDgv.CurrentRow.Cells[0].Value.ToString());
            List<OrderDetail> orderDetails = model.Select_Order_Details(order.ID_O);
            List<ProductQty> products = model.Select_Order_Detail_Products(order.ID_O);
            List<Control> controls = new List<Control>();
            Program.mainForm.EnterForm(Program.mainForm.addOrderPanel, 3,
                "Editar Orden", order, ref orderDetails, ref products);
        }
        private string FindMatch(ref List<OrderDetail> orderDetails, string ID_S)
        {
            foreach (OrderDetail order in orderDetails)
            {
                if (order.ID_S == ID_S) return order.Detail;
            }
            return "null";
        }
        #endregion

        #region Appearence Methods
        private Panel CreateProductPanel(Product product, List<OrderDetail> orderDetails)
        {
            List<Specification> specifications =
                model.Select_Specifications(product.ID_P);
            Panel panel = new Panel();
            Label label = new Label();
            PictureBox erase = new PictureBox();
            TableLayoutPanel table = new TableLayoutPanel();

            panel.AutoSize = label.AutoSize = table.AutoSize = true;
            panel.BorderStyle = BorderStyle.FixedSingle;
            label.Text = product.Name;
            label.Font = new Font("Roboto Condensed", (float)16, FontStyle.Bold);
            erase.Size = new Size(29, 25);
            erase.Image = Properties.Resources.Black_CancelIcon1;
            erase.SizeMode = PictureBoxSizeMode.Zoom;
            erase.Cursor = Cursors.Hand;
            erase.Visible = false;

            table.ColumnCount = 2;
            table.RowCount = (int)Math.Ceiling(Convert.ToDouble(specifications.Count / 2));

            panel.Controls.Add(label);
            panel.Controls.Add(erase);
            panel.Controls.Add(table);

            label.Location = new Point(18, 10);
            table.Location = new Point(45, 36);
            erase.Location = new Point(618, 4);

            foreach (Specification specification in specifications)
            {
                string data = FindMatch(ref orderDetails, specification.ID_S);
                table.Controls.Add(CreateSpecificationPanel(specification, data));
            }
            return panel;
        }
        private void ordersDgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (ordersDgv.CurrentRow != null)
                    if (ordersDgv.CurrentRow.Cells[11].Value.ToString().Trim() == "En Proceso")
                        ordersDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 241, 205);
                    else
                        ordersDgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(114, 194, 0);
            }
            catch (Exception)
            {
            }
        }
        private Panel CreateSpecificationPanel(Specification specification, string data)
        {
            Panel panel = new Panel();
            Label label = new Label();

            panel.AutoSize = label.AutoSize = true;
            label.Text = specification.Property;
            label.Font = new Font("Roboto Condensed", (float)11, FontStyle.Italic);
            panel.Controls.Add(label);
            label.Location = new Point(10, 10);
            Control control = null;
            switch (specification.Data_Type.ToLower().Trim())
            {
                case "texto corto":
                    TextBox textBox = new TextBox();
                    textBox.Text = data;
                    textBox.Size = new Size(258, 27);
                    textBox.ReadOnly = true;
                    control = textBox;
                    break;
                case "texto largo":
                    RichTextBox richTextBox = new RichTextBox();
                    richTextBox.Text = data;
                    richTextBox.Size = new Size(274, 96);
                    richTextBox.ReadOnly = true;
                    control = richTextBox;
                    break;
                case "número entero":
                    NumericUpDown numericUpDown = new NumericUpDown();
                    numericUpDown.Minimum = 1;
                    numericUpDown.Maximum = Int32.MaxValue;
                    numericUpDown.Size = new Size(120, 33);
                    if (data != null)
                        numericUpDown.Value = Convert.ToDecimal(data);
                    numericUpDown.TextAlign = HorizontalAlignment.Center;
                    numericUpDown.Font = new Font("Roboto Condensed", (float)15.75);
                    numericUpDown.Enabled = false;
                    control = numericUpDown;
                    break;
                case "número decimal":
                    NumericUpDown numericUpDownDec = new NumericUpDown();
                    numericUpDownDec.DecimalPlaces = 2;
                    numericUpDownDec.Maximum = decimal.MaxValue;
                    if (data != null)
                        numericUpDownDec.Value = Convert.ToDecimal(data);
                    numericUpDownDec.Size = new Size(120, 33);
                    numericUpDownDec.TextAlign = HorizontalAlignment.Center;
                    numericUpDownDec.Font = new Font("Roboto Condensed", (float)15.75);
                    numericUpDownDec.Enabled = false;
                    control = numericUpDownDec;
                    break;
                case "dinero":
                    NumericUpDown numericUpDownMoney = new NumericUpDown();
                    Label moneyLbl = new Label();
                    moneyLbl.AutoSize = true;
                    moneyLbl.Text = "USD";
                    numericUpDownMoney.DecimalPlaces = 2;
                    numericUpDownMoney.Maximum = decimal.MaxValue;
                    if (data != null)
                        numericUpDownMoney.Value = Convert.ToDecimal(data);
                    numericUpDownMoney.Size = new Size(112, 33);
                    numericUpDownMoney.TextAlign = HorizontalAlignment.Center;
                    numericUpDownMoney.Font = new Font("Roboto Condensed", (float)15.75);
                    numericUpDownMoney.Enabled = false;
                    control = numericUpDownMoney;
                    panel.Controls.Add(moneyLbl);
                    moneyLbl.Location = new Point(127, 37);
                    break;
                case "color":
                    TextBox textBox1 = new TextBox();
                    textBox1.Size = new Size(258, 27);
                    textBox1.Text = data;
                    textBox1.ReadOnly = true;
                    control = textBox1;
                    break;
            }
            panel.Controls.Add(control);
            control.Location = new Point(11, 32);
            return panel;
        }
        #endregion
    }
    #region Internal Class
    public class Filters
    {
        #region Properties
        public int OrderBy { get; set; }
        public int OrderTo { get; set; }
        public int DateFilter { get; set; }
        public int YearIndex { get; set; }
        public string Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int SearchBy { get; set; }
        #endregion

        #region Constructors
        public Filters()
        {
            OrderBy = OrderTo = Month = Day =
                SearchBy = DateFilter = YearIndex = 0;
            Year = "Ninguno";
        }
        #endregion
    }
    #endregion
}

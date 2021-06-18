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

namespace Presentation.Forms
{
    public partial class CheckOrderForm : Form
    {
        UserModel model = new UserModel();
        public CheckOrderForm()
        {
            InitializeComponent();
            ordersDgv.ShowCellToolTips = false;

            toolStripMenuItem5.Click += ToolStripMenuItem5_Click;
            toolStripMenuItem6.Click += ToolStripMenuItem6_Click;
            FillOrdersDgv();
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (ordersDgv.CurrentRow.Cells[11].Value.ToString().Trim() == "En Proceso")
            {
                model.Update_Order_Status(
                    ordersDgv.CurrentRow.Cells[0].Value.ToString(), "Terminado");
                FillOrdersDgv();
            }
        }
        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (ordersDgv.CurrentRow.Cells[11].Value.ToString().Trim() == "Terminado")
            {
                model.Update_Order_Status(
                    ordersDgv.CurrentRow.Cells[0].Value.ToString(), "En Proceso");
                FillOrdersDgv();
            }
        }
        private void ordersDgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in ordersDgv.Rows)
                if (Myrow.Cells[11].Value.ToString().Trim() == "En Proceso")
                    Myrow.DefaultCellStyle.BackColor = Color.FromArgb(241, 89, 42);
                else
                    Myrow.DefaultCellStyle.BackColor = Color.FromArgb(37, 170, 225);
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
                            FillOrdersDgv();
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

        private void FillOrdersDgv()
        {
            ordersDgv.DataSource = null;
            ordersDgv.DataSource = model.Select_Orders();
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
            ordersDgv.Columns[11].Visible = false; //status
            ordersDgv.Columns[12].Visible = false;


        }
        private void SeeOrderDetail()
        {
            Order order = model.Select_Orders(ordersDgv.CurrentRow.Cells[0].Value.ToString());
            List<OrderDetail> orderDetails = model.Select_Order_Details(order.ID_O);
            List<Product> products = model.Select_Order_Detail_Products(order.ID_O);
            List<Control> controls = new List<Control>();
            foreach (Product product in products)
            {
                Panel productPanel = 
                    CreateProductPanel(product, orderDetails.FindAll(od => od.ID_P == product.ID_P));
                controls.Add(productPanel);
            }
            Program.mainForm.EnterForm(Program.mainForm.addOrderPanel, 3,
                "Detalle de orden", order, controls);
        }
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
                string data = FindMatch(orderDetails, specification.ID_S);
                table.Controls.Add(CreateSpecificationPanel(specification, data));
            }
            return panel;
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
                    numericUpDown.Value = Convert.ToDecimal(data);
                    numericUpDown.Minimum = 1;
                    numericUpDown.Size = new Size(120, 33);
                    numericUpDown.TextAlign = HorizontalAlignment.Center;
                    numericUpDown.Font = new Font("Roboto Condensed", (float)15.75);
                    numericUpDown.Enabled = false;
                    control = numericUpDown;
                    break;
                case "número decimal":
                    NumericUpDown numericUpDownDec = new NumericUpDown();
                    numericUpDownDec.Value = Convert.ToDecimal(data);
                    numericUpDownDec.Size = new Size(120, 33);
                    numericUpDownDec.DecimalPlaces = 2;
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
                    numericUpDownMoney.Value = Convert.ToDecimal(data);
                    numericUpDownMoney.DecimalPlaces = 2;
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
        private string FindMatch(List<OrderDetail> orderDetails, string ID_S)
        {
            foreach (OrderDetail order in orderDetails)
            {
                if (order.ID_S == ID_S) return order.Detail;
            }
            return "null";
        }
    }
}

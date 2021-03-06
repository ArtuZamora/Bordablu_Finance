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
    public partial class AddOrderForm : Form
    {
        #region Static Properties
        private static UserModel model = new UserModel();
        private static List<Color> colors = new List<Color>();
        private static List<State> status = new List<State>();
        private static List<List<Control>> textBoxes = new List<List<Control>>();
        private static List<NumericUpDown> subTotals = new List<NumericUpDown>();
        private static List<string> ids = new List<string>();
        private static Order actualOrder = null;
        #endregion

        #region Constructors
        public AddOrderForm(string title) //Add
        {
            InitializeComponent();

            actualOrder = null;
            ids.Clear();

            subTotals.Clear();

            colors = FillColors();
            FillStatus();

            titleLbl.Text = title;
            toolTip1.SetToolTip(addProdBtn, "Agregar producto");

            productListCmb.DataSource = model.Select_Products();
            productListCmb.ValueMember = "ID_P";
            productListCmb.DisplayMember = "Name";

            payMCmb.DataSource = model.Select_Payment_Methods();
            payMCmb.ValueMember = "ID_PM";
            payMCmb.DisplayMember = "Method";

            textBoxes.Clear();
            List<Control> client = new List<Control>();
            client.Add(clientTxt);
            textBoxes.Add(client);

            deliveryDate.MinDate = orderDate.Value;

            deliveryPrice.Maximum = handPrice.Maximum = orderPrice.Maximum = decimal.MaxValue;

            givenPrice.Maximum = Convert.ToDecimal(orderTotLbl.Text.Substring(1));
        }
        public AddOrderForm(string title, Order order, ref List<Control> controls) //View
        {
            InitializeComponent();

            deliveryPrice.Maximum = handPrice.Maximum = orderPrice.Maximum = decimal.MaxValue;

            actualOrder = null;
            subTotals.Clear();
            ids.Clear();
            titleLbl.Text = title;

            FillStatus();

            payMCmb.DataSource = model.Select_Payment_Methods();
            payMCmb.ValueMember = "ID_PM";
            payMCmb.DisplayMember = "Method";

            deliveryDate.MinDate = orderDate.Value;
            addPanel.Visible = false;

            orderDate.Value = order.Order_Date;
            deliveryDate.Value = order.Delivery_Date;
            clientTxt.Text = order.Client;
            orderPrice.Value = order.Order_Amount;
            deliveryPrice.Value = order.Delivery_Amount;
            handPrice.Value = order.Labor_Amount;
            descriptionTxt.Text = order.Description;
            teamWorkChk.Checked = order.Help;
            payMCmb.SelectedValue = order.ID_PM;
            statusCmb.SelectedValue =
                status.Find(s => s.Status.Trim().ToLower() == order.Status.Trim().ToLower()).ID;
            UpdateTotal();
            foreach (Control control in controls)
                mainFlowPanel.Controls.Add(control);
            mainFlowPanel.Controls.Add(lastPanel);
            orderBtn.Visible = false;

            clientTxt.ReadOnly = descriptionTxt.ReadOnly = true;
            orderPrice.Enabled = deliveryPrice.Enabled =
                handPrice.Enabled = teamWorkChk.Enabled =
                payMCmb.Enabled = statusCmb.Enabled = givenPrice.Enabled = false;
            givenPrice.Maximum = Convert.ToDecimal(orderTotLbl.Text.Substring(1));
            givenPrice.Value = order.Given_Amount;
        }
        public AddOrderForm(string title, Order order, ref List<OrderDetail> orderDetails,
            ref List<ProductQty> products) //Edit
        {
            InitializeComponent();


            deliveryPrice.Maximum = handPrice.Maximum = orderPrice.Maximum = decimal.MaxValue;

            subTotals.Clear();
            actualOrder = order;
            ids.Clear();

            titleLbl.Text = title;
            toolTip1.SetToolTip(addProdBtn, "Agregar producto");

            colors = FillColors();
            FillStatus();

            productListCmb.DataSource = model.Select_Products();
            productListCmb.ValueMember = "ID_P";
            productListCmb.DisplayMember = "Name";

            payMCmb.DataSource = model.Select_Payment_Methods();
            payMCmb.ValueMember = "ID_PM";
            payMCmb.DisplayMember = "Method";

            deliveryDate.MinDate = orderDate.Value;

            orderDate.Value = order.Order_Date;
            deliveryDate.Value = order.Delivery_Date;
            clientTxt.Text = order.Client;
            orderPrice.Value = order.Order_Amount;
            deliveryPrice.Value = order.Delivery_Amount;
            handPrice.Value = order.Labor_Amount;
            descriptionTxt.Text = order.Description;
            teamWorkChk.Checked = order.Help;
            payMCmb.SelectedValue = order.ID_PM;
            statusCmb.SelectedValue =
                status.Find(s => s.Status.Trim().ToLower() == order.Status.Trim().ToLower()).ID;

            textBoxes.Clear();
            List<Control> client = new List<Control>();
            client.Add(clientTxt);
            textBoxes.Add(client);

            foreach (ProductQty product in products)
            {
                Panel productPanel =
                    CreateProductPanel(
                        product, 
                        orderDetails.FindAll(od => od.ID_P == product.ID_P && od.P_Num == product.P_Num));
                mainFlowPanel.Controls.Add(productPanel);
            }
            mainFlowPanel.Controls.Add(addPanel);
            mainFlowPanel.Controls.Add(lastPanel);

            orderBtn.Text = "Modificar Orden";

            UpdateTotal();

            givenPrice.Maximum = Convert.ToDecimal(orderTotLbl.Text.Substring(1));
            givenPrice.Value = order.Given_Amount;
        }
        #endregion

        #region Event Methods
        private void addProdBtn_Click(object sender, EventArgs e)
        {
            Control prod = CreateProductPanel((Product)productListCmb.SelectedItem, null);
            if(prod != null)
            {
                mainFlowPanel.Controls.Add(prod);
                mainFlowPanel.Controls.Add(addPanel);
                mainFlowPanel.Controls.Add(lastPanel);
            }
            else
            {
                MessageBox.Show("No existen especificaciones para este producto",
                     "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Erase_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==
                MessageBox.Show("¿Seguro de querer eliminar este producto?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                int index = mainFlowPanel.Controls.IndexOf(((Control)sender).Parent);
                if(textBoxes.Count > 1)
                    textBoxes.RemoveAt(index + 1);
                if (subTotals.Count > 0)
                    subTotals.RemoveAt(index);
                ids.RemoveAt(index);
                mainFlowPanel.Controls.Remove(((Control)sender).Parent);
            }
        }
        private void NumericUpDownMoney_ValueChanged(object sender, EventArgs e)
        {
            UpdateSubTotal();
        }
        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            GlobalMethods.errorProvider.SetIconAlignment((RichTextBox)sender, ErrorIconAlignment.TopRight);
            GlobalMethods.errorProvider.SetIconPadding((RichTextBox)sender, -16);
            if (string.IsNullOrEmpty(((RichTextBox)sender).Text))
                GlobalMethods.errorProvider.SetError((RichTextBox)sender, "No debe dejar el campo vacío");
            else
                GlobalMethods.errorProvider.SetError((RichTextBox)sender, null);
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            GlobalMethods.VerifyEmpty((TextBox)sender);
            GlobalMethods.errorProvider.SetIconPadding((TextBox)sender, -18);
        }
        private void orderDate_ValueChanged(object sender, EventArgs e)
        {
            deliveryDate.MinDate = orderDate.Value;
        }
        private void clientTxt_TextChanged(object sender, EventArgs e)
        {
            GlobalMethods.VerifyEmpty((TextBox)sender);
        }
        private void payMCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            CalculateBIM();
        }
        private void orderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (mainFlowPanel.Controls.Count > 2)
                {
                    if (VerifyTextBoxes())
                    {
                        if(actualOrder != null)
                        {
                            model.Delete_Order(actualOrder);
                        }
                        Order order = new Order();
                        order.ID_O = "O0000000";
                        order.Order_Date = orderDate.Value;
                        order.Delivery_Date = deliveryDate.Value;
                        order.Client = clientTxt.Text;
                        order.Order_Amount = orderPrice.Value;
                        order.Delivery_Amount = deliveryPrice.Value;
                        order.Labor_Amount = handPrice.Value;
                        order.Total_Amount = Convert.ToDecimal(orderTotLbl.Text.Substring(1));
                        if(actAmortLbl.Text.Substring(0,1) == "-")
                            order.Earned_Amount = Convert.ToDecimal(actAmortLbl.Text.Substring(2)) * - 1;
                        else
                            order.Earned_Amount = Convert.ToDecimal(actAmortLbl.Text.Substring(1));
                        order.Given_Amount = givenPrice.Value;
                        order.ID_PM = payMCmb.SelectedValue.ToString();
                        order.Description = descriptionTxt.Text;
                        order.Status = statusCmb.SelectedItem.ToString();
                        order.Help = teamWorkChk.Checked;

                        List<OrderDetail> orderDetails = new List<OrderDetail>();
                        int length = mainFlowPanel.Controls.Count - 2;
                        for (int i = 0; i < length; i++)
                        {
                            string ID_P = ids[i];
                            List<Specification> specifications = model.Select_Specifications(ID_P);
                            int length2 = mainFlowPanel.Controls[i].Controls[2].Controls.Count;
                            for (int j = 0; j < length2; j++)
                            {
                                OrderDetail orderDetail = new OrderDetail();
                                orderDetail.ID_OD = "OD0000000";
                                orderDetail.ID_S = specifications[j].ID_S;
                                orderDetail.ID_P = ID_P;
                                orderDetail.P_Num = i;
                                string detail = "";
                                Control controlSpec = mainFlowPanel.Controls[i].Controls[2].Controls[j].Controls[1];
                                switch (specifications[j].Data_Type.ToLower().Trim())
                                {
                                    case "texto corto":
                                        detail = ((TextBox)controlSpec).Text;
                                        break;
                                    case "texto largo":
                                        detail = ((RichTextBox)controlSpec).Text;
                                        break;
                                    case "número entero":
                                        detail = ((NumericUpDown)controlSpec).Value.ToString();
                                        break;
                                    case "número decimal":
                                        detail = ((NumericUpDown)controlSpec).Value.ToString();
                                        break;
                                    case "dinero":
                                        detail = subTotals[i].Value.ToString();
                                        break;
                                    case "color":
                                        detail = ((ComboBox)controlSpec).SelectedItem.ToString();
                                        break;
                                }
                                orderDetail.Detail = detail;
                                orderDetails.Add(orderDetail);
                            }
                        }

                        model.Insert_Order(order, orderDetails);
                        MessageBox.Show("Orden ingresada con éxito",
                             "INGRESO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (actualOrder != null)
                        {
                            Cache.ModifyOrderForm.Close();
                            Cache.ModifyOrderForm = null;
                            Program.mainForm.EnterForm(Program.mainForm.checkOrderPanel, 1, false);
                        }
                        ReloadForm();
                    }
                    else
                    {
                        MessageBox.Show("Existen campos sin llenar",
                             "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe agregar productos a la orden",
                           "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La solicitud no pudo ser procesada. Error: " + ex.Message,
                       "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void orderPrice_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }
        private void handPrice_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }
        private void deliveryPrice_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }
        private void orderTotLbl_TextChanged(object sender, EventArgs e)
        {
            givenPrice.Maximum = Convert.ToDecimal(orderTotLbl.Text.Substring(1));
        }
        private void givenPrice_ValueChanged(object sender, EventArgs e)
        {
            CalculateBIM();
        }
        #endregion

        #region Visual Methods
        private Panel CreateProductPanel(Product product, List<OrderDetail> orderDetails)
        {
            List<Specification> specifications = model.Select_Specifications(product.ID_P);
            if(specifications.Count != 0)
            {
                List<Control> controls = new List<Control>();
                Panel panel = new Panel();
                Label label = new Label();
                PictureBox erase = new PictureBox();
                TableLayoutPanel table = new TableLayoutPanel();

                panel.AutoSize = label.AutoSize = table.AutoSize = true;
                panel.BorderStyle = BorderStyle.FixedSingle;
                label.Text = product.Name;
                ids.Add(product.ID_P);
                label.Font = new Font("Roboto Condensed", (float)16, FontStyle.Bold);
                erase.Size = new Size(29, 25);
                erase.Image = Properties.Resources.Black_CancelIcon1;
                erase.SizeMode = PictureBoxSizeMode.Zoom;
                erase.Cursor = Cursors.Hand;
                erase.Click += Erase_Click;

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
                    if (orderDetails != null)
                    {
                        string data = FindMatch(ref orderDetails, specification.ID_S);
                        table.Controls.Add(CreateSpecificationPanel(specification, ref controls, data));
                    }
                    else
                        table.Controls.Add(CreateSpecificationPanel(specification, ref controls, "null"));
                }
                textBoxes.Add(controls);
                return panel;
            } 
            return null;
        }
        private Panel CreateSpecificationPanel(Specification specification, ref List<Control> controls, string data)
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
                    if (data != "null")
                        textBox.Text = data;
                    textBox.TextChanged += TextBox_TextChanged;
                    textBox.Size = new Size(258, 27);
                    control = textBox;
                    controls.Add(textBox);
                    break;
                case "texto largo":
                    RichTextBox richTextBox = new RichTextBox();
                    if (data != "null")
                        richTextBox.Text = data;
                    richTextBox.TextChanged += RichTextBox_TextChanged;
                    richTextBox.Size = new Size(274, 96);
                    control = richTextBox;
                    controls.Add(richTextBox);
                    break;
                case "número entero":
                    NumericUpDown numericUpDown = new NumericUpDown();
                    numericUpDown.Minimum = 1;
                    numericUpDown.Maximum = Int32.MaxValue;
                    numericUpDown.Size = new Size(120, 33);
                    if (data != "null")
                        numericUpDown.Value = Convert.ToDecimal(data);
                    numericUpDown.TextAlign = HorizontalAlignment.Center;
                    numericUpDown.Font = new Font("Roboto Condensed", (float)15.75);
                    control = numericUpDown;
                    break;
                case "número decimal":
                    NumericUpDown numericUpDownDec = new NumericUpDown();
                    numericUpDownDec.Size = new Size(120, 33);
                    numericUpDownDec.Maximum = decimal.MaxValue;
                    numericUpDownDec.DecimalPlaces = 2;
                    if (data != "null")
                        numericUpDownDec.Value = Convert.ToDecimal(data);
                    numericUpDownDec.TextAlign = HorizontalAlignment.Center;
                    numericUpDownDec.Font = new Font("Roboto Condensed", (float)15.75);
                    control = numericUpDownDec;
                    break;
                case "dinero":
                    NumericUpDown numericUpDownMoney = new NumericUpDown();
                    Label moneyLbl = new Label();
                    numericUpDownMoney.Maximum = decimal.MaxValue;
                    if (data != "null")
                        numericUpDownMoney.Value = Convert.ToDecimal(data);
                    moneyLbl.AutoSize = true;
                    moneyLbl.Text = "USD";
                    numericUpDownMoney.ValueChanged += NumericUpDownMoney_ValueChanged;//add
                    numericUpDownMoney.DecimalPlaces = 2;
                    numericUpDownMoney.Size = new Size(112, 33);
                    numericUpDownMoney.TextAlign = HorizontalAlignment.Center;
                    numericUpDownMoney.Font = new Font("Roboto Condensed", (float)15.75);
                    control = numericUpDownMoney;
                    panel.Controls.Add(moneyLbl);
                    moneyLbl.Location = new Point(127, 37);
                    subTotals.Add(numericUpDownMoney);
                    break;
                case "color":
                    ComboBox combo = new ComboBox();
                    combo.DropDownStyle = ComboBoxStyle.DropDownList;
                    combo.Visible = true;
                    combo.FormattingEnabled = true;
                    combo.Size = new Size(258, 27);
                    combo.DataSource = null;
                    combo.ValueMember = "ID";
                    combo.DisplayMember = "Colors";
                    combo.DataSource = FillColors();
                    if (data != "null")
                    {
                        Color col = ((List<Color>)combo.DataSource)
                            .Find(c => c.Colors.Trim() == data.Trim());
                        int ix = ((List<Color>)combo.DataSource).IndexOf(col);
                        EventHandler visibleChangedHandler = null;
                        visibleChangedHandler = delegate
                        {
                            combo.SelectedIndex = ix;
                            combo.VisibleChanged -= visibleChangedHandler;
                        };
                        combo.VisibleChanged += visibleChangedHandler;
                    }
                    control = combo;
                    break;
            }
            panel.Controls.Add(control);
            control.Location = new Point(11, 32);
            return panel;
        }
        private void ReloadForm()
        {
            orderDate.Value = DateTime.Now;
            clientTxt.ResetText();
            GlobalMethods.errorProvider.SetError(clientTxt, null);
            orderPrice.Value = handPrice.Value = deliveryPrice.Value = 0m;
            teamWorkChk.Checked = false;
            statusCmb.SelectedIndex = 0;
            descriptionTxt.ResetText();
            Control c1 = lastPanel, c2 = addPanel;
            mainFlowPanel.Controls.Clear();
            mainFlowPanel.Controls.Add(c2);
            mainFlowPanel.Controls.Add(c1);
            subTotals.Clear();
            ids.Clear();
            textBoxes.Clear();
            List<Control> client = new List<Control>();
            client.Add(clientTxt);
            textBoxes.Add(client);
        }
        #endregion

        #region Functional Methods
        private string FindMatch(ref List<OrderDetail> orderDetails, string ID_S)
        {
            foreach (OrderDetail order in orderDetails)
            {
                if (order.ID_S == ID_S) return order.Detail;
            }
            return "null";
        }
        private List<Color> FillColors()
        {
            List<Color> colorss = new List<Color>();
            colorss.Clear();
            colorss.Add(new Color(1, "Azul"));
            colorss.Add(new Color(2, "Rojo"));
            colorss.Add(new Color(3, "Amarillo"));
            colorss.Add(new Color(4, "Negro"));
            colorss.Add(new Color(5, "Blanco"));
            return colorss;
        }
        private void FillStatus()
        {
            status.Clear();
            status.Add(new State(1, "En Proceso"));
            status.Add(new State(2, "Terminado"));
            statusCmb.DataSource = null;
            statusCmb.DataSource = status;
            statusCmb.ValueMember = "ID";
            statusCmb.DisplayMember = "Status";
        }
        private bool VerifyTextBoxes()
        {
            foreach (var list in textBoxes)
            {
                foreach (Control item in list)
                {
                    if (string.IsNullOrEmpty(item.Text)) return false;
                }
            }
            return true;
        }
        private void UpdateSubTotal()
        {
            decimal tot = 0;
            foreach (NumericUpDown num in subTotals)
            {
                tot += num.Value;
            }
            orderPrice.Value = tot;
        }
        private void UpdateTotal()
        {
            orderTotLbl.Text = (orderPrice.Value + handPrice.Value + deliveryPrice.Value).ToString("$0.00");
            CalculateBIM();
        }
        private void CalculateBIM()
        {
            try
            {
                if (((PaymentMethod)payMCmb.SelectedItem).ID_PM == "PM03")
                {
                    amrtzLbl.Text = CalculateBIM(orderPrice.Value + handPrice.Value)
                        .ToString("$0.00");
                    actAmortLbl.Text = CalculateBIM(givenPrice.Value - deliveryPrice.Value).ToString("$0.00");
                }
                else
                {
                    amrtzLbl.Text = (orderPrice.Value + handPrice.Value).ToString("$0.00");
                    actAmortLbl.Text = (givenPrice.Value - deliveryPrice.Value).ToString("$0.00");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private decimal CalculateBIM(decimal amount)
        {
            decimal iva, comision, ivaComision;
            iva = amount / (decimal)1.13;
            comision = iva * (decimal)0.04;
            ivaComision = comision * (decimal)0.13;
            decimal amort = amount - (comision + ivaComision);
            return amort;
        }
        #endregion

        #region Internal Classes
        private class Color
        {
            public int ID { get; set; }
            public string Colors { get; set; }
            public Color(int ID, string Color)
            {
                this.ID = ID;
                Colors = Color;
            }
            public override string ToString()
            {
                return Colors;
            }
        }
        private class State
        {
            public int ID { get; set; }
            public string Status { get; set; }
            public State(int ID, string Status)
            {
                this.ID = ID;
                this.Status = Status;
            }
            public override string ToString()
            {
                return Status;
            }
        }
        #endregion
    }
}

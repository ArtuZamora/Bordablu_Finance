
namespace Presentation.Forms
{
    partial class AddOrderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOrderForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.clientTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.orderDate = new System.Windows.Forms.DateTimePicker();
            this.titleLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addPanel = new System.Windows.Forms.Panel();
            this.productListCmb = new System.Windows.Forms.ComboBox();
            this.addProdBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lastPanel = new System.Windows.Forms.Panel();
            this.actAmortLbl = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.givenPrice = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.teamWorkChk = new System.Windows.Forms.CheckBox();
            this.orderBtn = new System.Windows.Forms.Button();
            this.statusCmb = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.descriptionTxt = new System.Windows.Forms.RichTextBox();
            this.payMCmb = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.amrtzLbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.orderTotLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.handPrice = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.deliveryPrice = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.orderPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mainFlowPanel.SuspendLayout();
            this.addPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addProdBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.lastPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.givenPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.handPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.panel1.Controls.Add(this.clientTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.deliveryDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.orderDate);
            this.panel1.Controls.Add(this.titleLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 121);
            this.panel1.TabIndex = 0;
            // 
            // clientTxt
            // 
            this.clientTxt.Location = new System.Drawing.Point(463, 79);
            this.clientTxt.Name = "clientTxt";
            this.clientTxt.Size = new System.Drawing.Size(173, 27);
            this.clientTxt.TabIndex = 6;
            this.clientTxt.TextChanged += new System.EventHandler(this.clientTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(463, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(245, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha de entrega";
            // 
            // deliveryDate
            // 
            this.deliveryDate.Location = new System.Drawing.Point(245, 79);
            this.deliveryDate.Name = "deliveryDate";
            this.deliveryDate.Size = new System.Drawing.Size(200, 27);
            this.deliveryDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha de orden";
            // 
            // orderDate
            // 
            this.orderDate.Location = new System.Drawing.Point(25, 79);
            this.orderDate.Name = "orderDate";
            this.orderDate.Size = new System.Drawing.Size(200, 27);
            this.orderDate.TabIndex = 1;
            this.orderDate.ValueChanged += new System.EventHandler(this.orderDate_ValueChanged);
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Roboto Condensed", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.titleLbl.Location = new System.Drawing.Point(9, 6);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(236, 33);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Agregar nueva orden";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainFlowPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 329);
            this.panel2.TabIndex = 1;
            // 
            // mainFlowPanel
            // 
            this.mainFlowPanel.AutoScroll = true;
            this.mainFlowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(169)))), ((int)(((byte)(156)))));
            this.mainFlowPanel.Controls.Add(this.addPanel);
            this.mainFlowPanel.Controls.Add(this.lastPanel);
            this.mainFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainFlowPanel.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.mainFlowPanel.Name = "mainFlowPanel";
            this.mainFlowPanel.Size = new System.Drawing.Size(677, 329);
            this.mainFlowPanel.TabIndex = 1;
            this.mainFlowPanel.WrapContents = false;
            // 
            // addPanel
            // 
            this.addPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addPanel.Controls.Add(this.productListCmb);
            this.addPanel.Controls.Add(this.addProdBtn);
            this.addPanel.Controls.Add(this.pictureBox1);
            this.addPanel.Location = new System.Drawing.Point(3, 3);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(652, 25);
            this.addPanel.TabIndex = 1;
            // 
            // productListCmb
            // 
            this.productListCmb.Dock = System.Windows.Forms.DockStyle.Left;
            this.productListCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productListCmb.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.productListCmb.FormattingEnabled = true;
            this.productListCmb.Location = new System.Drawing.Point(0, 0);
            this.productListCmb.Name = "productListCmb";
            this.productListCmb.Size = new System.Drawing.Size(87, 26);
            this.productListCmb.TabIndex = 21;
            // 
            // addProdBtn
            // 
            this.addProdBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addProdBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.addProdBtn.Image = ((System.Drawing.Image)(resources.GetObject("addProdBtn.Image")));
            this.addProdBtn.Location = new System.Drawing.Point(623, 0);
            this.addProdBtn.Name = "addProdBtn";
            this.addProdBtn.Size = new System.Drawing.Size(29, 25);
            this.addProdBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addProdBtn.TabIndex = 2;
            this.addProdBtn.TabStop = false;
            this.addProdBtn.Click += new System.EventHandler(this.addProdBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(652, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lastPanel
            // 
            this.lastPanel.Controls.Add(this.actAmortLbl);
            this.lastPanel.Controls.Add(this.label19);
            this.lastPanel.Controls.Add(this.label10);
            this.lastPanel.Controls.Add(this.givenPrice);
            this.lastPanel.Controls.Add(this.label12);
            this.lastPanel.Controls.Add(this.teamWorkChk);
            this.lastPanel.Controls.Add(this.orderBtn);
            this.lastPanel.Controls.Add(this.statusCmb);
            this.lastPanel.Controls.Add(this.label16);
            this.lastPanel.Controls.Add(this.label15);
            this.lastPanel.Controls.Add(this.descriptionTxt);
            this.lastPanel.Controls.Add(this.payMCmb);
            this.lastPanel.Controls.Add(this.label14);
            this.lastPanel.Controls.Add(this.amrtzLbl);
            this.lastPanel.Controls.Add(this.label13);
            this.lastPanel.Controls.Add(this.orderTotLbl);
            this.lastPanel.Controls.Add(this.label8);
            this.lastPanel.Controls.Add(this.label11);
            this.lastPanel.Controls.Add(this.handPrice);
            this.lastPanel.Controls.Add(this.label9);
            this.lastPanel.Controls.Add(this.label6);
            this.lastPanel.Controls.Add(this.deliveryPrice);
            this.lastPanel.Controls.Add(this.label7);
            this.lastPanel.Controls.Add(this.label5);
            this.lastPanel.Controls.Add(this.orderPrice);
            this.lastPanel.Controls.Add(this.label4);
            this.lastPanel.Location = new System.Drawing.Point(3, 34);
            this.lastPanel.Name = "lastPanel";
            this.lastPanel.Size = new System.Drawing.Size(652, 283);
            this.lastPanel.TabIndex = 0;
            // 
            // actAmortLbl
            // 
            this.actAmortLbl.AutoSize = true;
            this.actAmortLbl.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.actAmortLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.actAmortLbl.Location = new System.Drawing.Point(42, 254);
            this.actAmortLbl.Name = "actAmortLbl";
            this.actAmortLbl.Size = new System.Drawing.Size(51, 23);
            this.actAmortLbl.TabIndex = 30;
            this.actAmortLbl.Text = "$0.00";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(42, 227);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 19);
            this.label19.TabIndex = 29;
            this.label19.Text = "Amortizado actual";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(21, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 23);
            this.label10.TabIndex = 28;
            this.label10.Text = "$";
            // 
            // givenPrice
            // 
            this.givenPrice.DecimalPlaces = 2;
            this.givenPrice.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.givenPrice.Location = new System.Drawing.Point(46, 182);
            this.givenPrice.Name = "givenPrice";
            this.givenPrice.Size = new System.Drawing.Size(110, 30);
            this.givenPrice.TabIndex = 27;
            this.givenPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.givenPrice.ValueChanged += new System.EventHandler(this.givenPrice_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(26, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 19);
            this.label12.TabIndex = 26;
            this.label12.Text = "Monto entregado";
            // 
            // teamWorkChk
            // 
            this.teamWorkChk.AutoSize = true;
            this.teamWorkChk.Location = new System.Drawing.Point(459, 227);
            this.teamWorkChk.Name = "teamWorkChk";
            this.teamWorkChk.Size = new System.Drawing.Size(138, 23);
            this.teamWorkChk.TabIndex = 25;
            this.teamWorkChk.Text = "Trabajo Conjunto";
            this.teamWorkChk.UseVisualStyleBackColor = true;
            // 
            // orderBtn
            // 
            this.orderBtn.Location = new System.Drawing.Point(252, 227);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(150, 47);
            this.orderBtn.TabIndex = 24;
            this.orderBtn.Text = "Agregar Orden";
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // statusCmb
            // 
            this.statusCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCmb.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusCmb.FormattingEnabled = true;
            this.statusCmb.Location = new System.Drawing.Point(459, 181);
            this.statusCmb.Name = "statusCmb";
            this.statusCmb.Size = new System.Drawing.Size(176, 31);
            this.statusCmb.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(459, 159);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 19);
            this.label16.TabIndex = 22;
            this.label16.Text = "Estatus de orden";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(397, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(146, 19);
            this.label15.TabIndex = 9;
            this.label15.Text = "Descripción adicional";
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.EnableAutoDragDrop = true;
            this.descriptionTxt.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionTxt.Location = new System.Drawing.Point(397, 39);
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new System.Drawing.Size(246, 102);
            this.descriptionTxt.TabIndex = 21;
            this.descriptionTxt.Text = "";
            // 
            // payMCmb
            // 
            this.payMCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payMCmb.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.payMCmb.FormattingEnabled = true;
            this.payMCmb.Location = new System.Drawing.Point(191, 110);
            this.payMCmb.Name = "payMCmb";
            this.payMCmb.Size = new System.Drawing.Size(176, 31);
            this.payMCmb.TabIndex = 20;
            this.payMCmb.SelectedValueChanged += new System.EventHandler(this.payMCmb_SelectedValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(191, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 19);
            this.label14.TabIndex = 8;
            this.label14.Text = "Metodo de pago";
            // 
            // amrtzLbl
            // 
            this.amrtzLbl.AutoSize = true;
            this.amrtzLbl.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.amrtzLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.amrtzLbl.Location = new System.Drawing.Point(319, 186);
            this.amrtzLbl.Name = "amrtzLbl";
            this.amrtzLbl.Size = new System.Drawing.Size(51, 23);
            this.amrtzLbl.TabIndex = 19;
            this.amrtzLbl.Text = "$0.00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(319, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 19);
            this.label13.TabIndex = 18;
            this.label13.Text = "Amortizado total";
            // 
            // orderTotLbl
            // 
            this.orderTotLbl.AutoSize = true;
            this.orderTotLbl.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.orderTotLbl.Location = new System.Drawing.Point(186, 186);
            this.orderTotLbl.Name = "orderTotLbl";
            this.orderTotLbl.Size = new System.Drawing.Size(51, 23);
            this.orderTotLbl.TabIndex = 17;
            this.orderTotLbl.Text = "$0.00";
            this.orderTotLbl.TextChanged += new System.EventHandler(this.orderTotLbl_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(188, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "$";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(186, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 19);
            this.label11.TabIndex = 16;
            this.label11.Text = "Total de orden";
            // 
            // handPrice
            // 
            this.handPrice.DecimalPlaces = 2;
            this.handPrice.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.handPrice.Location = new System.Drawing.Point(211, 40);
            this.handPrice.Name = "handPrice";
            this.handPrice.Size = new System.Drawing.Size(110, 30);
            this.handPrice.TabIndex = 14;
            this.handPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.handPrice.ValueChanged += new System.EventHandler(this.handPrice_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(191, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "Precio mano de obra";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(21, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "$";
            // 
            // deliveryPrice
            // 
            this.deliveryPrice.DecimalPlaces = 2;
            this.deliveryPrice.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deliveryPrice.Location = new System.Drawing.Point(46, 111);
            this.deliveryPrice.Name = "deliveryPrice";
            this.deliveryPrice.Size = new System.Drawing.Size(110, 30);
            this.deliveryPrice.TabIndex = 11;
            this.deliveryPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.deliveryPrice.ValueChanged += new System.EventHandler(this.deliveryPrice_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(26, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Precio delivery";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(22, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "$";
            // 
            // orderPrice
            // 
            this.orderPrice.DecimalPlaces = 2;
            this.orderPrice.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orderPrice.Location = new System.Drawing.Point(42, 40);
            this.orderPrice.Name = "orderPrice";
            this.orderPrice.Size = new System.Drawing.Size(114, 30);
            this.orderPrice.TabIndex = 8;
            this.orderPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.orderPrice.ValueChanged += new System.EventHandler(this.orderPrice_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(22, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Precio por la orden";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 19);
            this.label18.TabIndex = 1;
            this.label18.Text = "Texto Corto";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(261, 23);
            this.textBox2.TabIndex = 2;
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(141)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AddOrderForm";
            this.Text = "AddOrderForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.mainFlowPanel.ResumeLayout(false);
            this.addPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addProdBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.lastPanel.ResumeLayout(false);
            this.lastPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.givenPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.handPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker orderDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker deliveryDate;
        private System.Windows.Forms.TextBox clientTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel mainFlowPanel;
        private System.Windows.Forms.Panel lastPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown deliveryPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown orderPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown handPrice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label orderTotLbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label amrtzLbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox payMCmb;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox descriptionTxt;
        private System.Windows.Forms.Button orderBtn;
        private System.Windows.Forms.ComboBox statusCmb;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel addPanel;
        private System.Windows.Forms.PictureBox addProdBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox teamWorkChk;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox productListCmb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown givenPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label actAmortLbl;
        private System.Windows.Forms.Label label19;
    }
}
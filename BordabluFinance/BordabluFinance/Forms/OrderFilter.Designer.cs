
namespace Presentation.Forms
{
    partial class OrderFilter
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.todayLink = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.searchByCmb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dayCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.monthCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.yearCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.orderToCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.orderByCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(253, 447);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.todayLink);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.searchByCmb);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dayCmb);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.monthCmb);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.yearCmb);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.orderToCmb);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.orderByCmb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 441);
            this.panel1.TabIndex = 0;
            // 
            // todayLink
            // 
            this.todayLink.AutoSize = true;
            this.todayLink.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.todayLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.todayLink.Location = new System.Drawing.Point(199, 161);
            this.todayLink.Name = "todayLink";
            this.todayLink.Size = new System.Drawing.Size(31, 18);
            this.todayLink.TabIndex = 27;
            this.todayLink.TabStop = true;
            this.todayLink.Text = "Hoy";
            this.todayLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.todayLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.todayLink_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(39, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 19);
            this.label8.TabIndex = 26;
            this.label8.Text = "Realizar búsqueda de";
            // 
            // searchByCmb
            // 
            this.searchByCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchByCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchByCmb.FormattingEnabled = true;
            this.searchByCmb.Location = new System.Drawing.Point(39, 398);
            this.searchByCmb.Name = "searchByCmb";
            this.searchByCmb.Size = new System.Drawing.Size(187, 27);
            this.searchByCmb.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(11, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "Filtro general";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(11, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "Filtro de busqueda";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(39, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 19);
            this.label6.TabIndex = 22;
            this.label6.Text = "Día";
            // 
            // dayCmb
            // 
            this.dayCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dayCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dayCmb.FormattingEnabled = true;
            this.dayCmb.Location = new System.Drawing.Point(39, 309);
            this.dayCmb.Name = "dayCmb";
            this.dayCmb.Size = new System.Drawing.Size(187, 27);
            this.dayCmb.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(39, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Mes";
            // 
            // monthCmb
            // 
            this.monthCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.monthCmb.FormattingEnabled = true;
            this.monthCmb.Location = new System.Drawing.Point(39, 254);
            this.monthCmb.Name = "monthCmb";
            this.monthCmb.Size = new System.Drawing.Size(187, 27);
            this.monthCmb.TabIndex = 19;
            this.monthCmb.SelectedValueChanged += new System.EventHandler(this.monthCmb_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(39, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Año";
            // 
            // yearCmb
            // 
            this.yearCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.yearCmb.FormattingEnabled = true;
            this.yearCmb.Location = new System.Drawing.Point(39, 202);
            this.yearCmb.Name = "yearCmb";
            this.yearCmb.Size = new System.Drawing.Size(187, 27);
            this.yearCmb.TabIndex = 17;
            this.yearCmb.SelectedValueChanged += new System.EventHandler(this.yearCmb_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(11, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Filtro de fecha";
            // 
            // orderToCmb
            // 
            this.orderToCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderToCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orderToCmb.FormattingEnabled = true;
            this.orderToCmb.Location = new System.Drawing.Point(39, 118);
            this.orderToCmb.Name = "orderToCmb";
            this.orderToCmb.Size = new System.Drawing.Size(187, 27);
            this.orderToCmb.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(30, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ordenar de";
            // 
            // orderByCmb
            // 
            this.orderByCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderByCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orderByCmb.FormattingEnabled = true;
            this.orderByCmb.Location = new System.Drawing.Point(39, 55);
            this.orderByCmb.Name = "orderByCmb";
            this.orderByCmb.Size = new System.Drawing.Size(187, 27);
            this.orderByCmb.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ordenar por";
            // 
            // OrderFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(140)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(253, 447);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OrderFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtros de visualización";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dayCmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox monthCmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox yearCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox orderToCmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox orderByCmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox searchByCmb;
        private System.Windows.Forms.LinkLabel todayLink;
    }
}
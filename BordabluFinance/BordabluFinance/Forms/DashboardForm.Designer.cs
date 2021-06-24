
namespace Presentation.Forms
{
    partial class DashboardForm
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
            this.dashPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.graphTypeCmb = new System.Windows.Forms.ComboBox();
            this.graphMonthLbl = new System.Windows.Forms.Label();
            this.graphMonthCmb = new System.Windows.Forms.ComboBox();
            this.graphYearLbl = new System.Windows.Forms.Label();
            this.graphYearCmb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.graphByCmb = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chartTypeCmb = new System.Windows.Forms.ComboBox();
            this.salesMonthLbl = new System.Windows.Forms.Label();
            this.salesMonthCmb = new System.Windows.Forms.ComboBox();
            this.salesYearLbl = new System.Windows.Forms.Label();
            this.salesYearCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.salesPerCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.dashPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.dashPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(677, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // dashPanel
            // 
            this.dashPanel.Controls.Add(this.label3);
            this.dashPanel.Controls.Add(this.graphTypeCmb);
            this.dashPanel.Controls.Add(this.graphMonthLbl);
            this.dashPanel.Controls.Add(this.graphMonthCmb);
            this.dashPanel.Controls.Add(this.graphYearLbl);
            this.dashPanel.Controls.Add(this.graphYearCmb);
            this.dashPanel.Controls.Add(this.label7);
            this.dashPanel.Controls.Add(this.graphByCmb);
            this.dashPanel.Controls.Add(this.label8);
            this.dashPanel.Controls.Add(this.label5);
            this.dashPanel.Controls.Add(this.chartTypeCmb);
            this.dashPanel.Controls.Add(this.salesMonthLbl);
            this.dashPanel.Controls.Add(this.salesMonthCmb);
            this.dashPanel.Controls.Add(this.salesYearLbl);
            this.dashPanel.Controls.Add(this.salesYearCmb);
            this.dashPanel.Controls.Add(this.label2);
            this.dashPanel.Controls.Add(this.salesPerCmb);
            this.dashPanel.Controls.Add(this.label1);
            this.dashPanel.Location = new System.Drawing.Point(4, 5);
            this.dashPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dashPanel.Name = "dashPanel";
            this.dashPanel.Size = new System.Drawing.Size(652, 1020);
            this.dashPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(211, 557);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Gráfico de:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // graphTypeCmb
            // 
            this.graphTypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphTypeCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graphTypeCmb.FormattingEnabled = true;
            this.graphTypeCmb.Location = new System.Drawing.Point(211, 579);
            this.graphTypeCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphTypeCmb.Name = "graphTypeCmb";
            this.graphTypeCmb.Size = new System.Drawing.Size(167, 27);
            this.graphTypeCmb.TabIndex = 17;
            this.graphTypeCmb.SelectedValueChanged += new System.EventHandler(this.graphTypeCmb_SelectedValueChanged);
            // 
            // graphMonthLbl
            // 
            this.graphMonthLbl.AutoSize = true;
            this.graphMonthLbl.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.graphMonthLbl.Location = new System.Drawing.Point(496, 559);
            this.graphMonthLbl.Name = "graphMonthLbl";
            this.graphMonthLbl.Size = new System.Drawing.Size(33, 18);
            this.graphMonthLbl.TabIndex = 16;
            this.graphMonthLbl.Text = "Mes";
            // 
            // graphMonthCmb
            // 
            this.graphMonthCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphMonthCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graphMonthCmb.FormattingEnabled = true;
            this.graphMonthCmb.Location = new System.Drawing.Point(493, 579);
            this.graphMonthCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphMonthCmb.Name = "graphMonthCmb";
            this.graphMonthCmb.Size = new System.Drawing.Size(134, 27);
            this.graphMonthCmb.TabIndex = 15;
            this.graphMonthCmb.SelectedValueChanged += new System.EventHandler(this.graphMonthCmb_SelectedValueChanged);
            // 
            // graphYearLbl
            // 
            this.graphYearLbl.AutoSize = true;
            this.graphYearLbl.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.graphYearLbl.Location = new System.Drawing.Point(387, 559);
            this.graphYearLbl.Name = "graphYearLbl";
            this.graphYearLbl.Size = new System.Drawing.Size(30, 18);
            this.graphYearLbl.TabIndex = 14;
            this.graphYearLbl.Text = "Año";
            // 
            // graphYearCmb
            // 
            this.graphYearCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphYearCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graphYearCmb.FormattingEnabled = true;
            this.graphYearCmb.Location = new System.Drawing.Point(384, 579);
            this.graphYearCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphYearCmb.Name = "graphYearCmb";
            this.graphYearCmb.Size = new System.Drawing.Size(101, 27);
            this.graphYearCmb.TabIndex = 13;
            this.graphYearCmb.SelectedValueChanged += new System.EventHandler(this.graphYearCmb_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(42, 559);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Grafico por:";
            // 
            // graphByCmb
            // 
            this.graphByCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphByCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graphByCmb.FormattingEnabled = true;
            this.graphByCmb.Location = new System.Drawing.Point(39, 579);
            this.graphByCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.graphByCmb.Name = "graphByCmb";
            this.graphByCmb.Size = new System.Drawing.Size(167, 27);
            this.graphByCmb.TabIndex = 11;
            this.graphByCmb.SelectedValueChanged += new System.EventHandler(this.graphByCmb_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(24, 522);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Gráfico de ganancias/gastos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(196, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gráfico de:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartTypeCmb
            // 
            this.chartTypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chartTypeCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chartTypeCmb.FormattingEnabled = true;
            this.chartTypeCmb.Location = new System.Drawing.Point(196, 70);
            this.chartTypeCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartTypeCmb.Name = "chartTypeCmb";
            this.chartTypeCmb.Size = new System.Drawing.Size(167, 27);
            this.chartTypeCmb.TabIndex = 7;
            this.chartTypeCmb.SelectedValueChanged += new System.EventHandler(this.chartTypeCmb_SelectedValueChanged);
            // 
            // salesMonthLbl
            // 
            this.salesMonthLbl.AutoSize = true;
            this.salesMonthLbl.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.salesMonthLbl.Location = new System.Drawing.Point(481, 50);
            this.salesMonthLbl.Name = "salesMonthLbl";
            this.salesMonthLbl.Size = new System.Drawing.Size(33, 18);
            this.salesMonthLbl.TabIndex = 6;
            this.salesMonthLbl.Text = "Mes";
            // 
            // salesMonthCmb
            // 
            this.salesMonthCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.salesMonthCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.salesMonthCmb.FormattingEnabled = true;
            this.salesMonthCmb.Location = new System.Drawing.Point(478, 70);
            this.salesMonthCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.salesMonthCmb.Name = "salesMonthCmb";
            this.salesMonthCmb.Size = new System.Drawing.Size(134, 27);
            this.salesMonthCmb.TabIndex = 5;
            this.salesMonthCmb.SelectedValueChanged += new System.EventHandler(this.salesMonthCmb_SelectedValueChanged);
            // 
            // salesYearLbl
            // 
            this.salesYearLbl.AutoSize = true;
            this.salesYearLbl.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.salesYearLbl.Location = new System.Drawing.Point(372, 50);
            this.salesYearLbl.Name = "salesYearLbl";
            this.salesYearLbl.Size = new System.Drawing.Size(30, 18);
            this.salesYearLbl.TabIndex = 4;
            this.salesYearLbl.Text = "Año";
            // 
            // salesYearCmb
            // 
            this.salesYearCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.salesYearCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.salesYearCmb.FormattingEnabled = true;
            this.salesYearCmb.Location = new System.Drawing.Point(369, 70);
            this.salesYearCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.salesYearCmb.Name = "salesYearCmb";
            this.salesYearCmb.Size = new System.Drawing.Size(101, 27);
            this.salesYearCmb.TabIndex = 3;
            this.salesYearCmb.SelectedValueChanged += new System.EventHandler(this.salesYearCmb_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto Condensed", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ventas por:";
            // 
            // salesPerCmb
            // 
            this.salesPerCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.salesPerCmb.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.salesPerCmb.FormattingEnabled = true;
            this.salesPerCmb.Location = new System.Drawing.Point(24, 70);
            this.salesPerCmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.salesPerCmb.Name = "salesPerCmb";
            this.salesPerCmb.Size = new System.Drawing.Size(167, 27);
            this.salesPerCmb.TabIndex = 1;
            this.salesPerCmb.SelectedValueChanged += new System.EventHandler(this.salesPerCmb_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gráfico de ventas";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(140)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.dashPanel.ResumeLayout(false);
            this.dashPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel dashPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox chartTypeCmb;
        private System.Windows.Forms.ComboBox salesMonthCmb;
        private System.Windows.Forms.Label salesYearLbl;
        private System.Windows.Forms.ComboBox salesYearCmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox salesPerCmb;
        private System.Windows.Forms.Label salesMonthLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox graphTypeCmb;
        private System.Windows.Forms.Label graphMonthLbl;
        private System.Windows.Forms.ComboBox graphMonthCmb;
        private System.Windows.Forms.Label graphYearLbl;
        private System.Windows.Forms.ComboBox graphYearCmb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox graphByCmb;
        private System.Windows.Forms.Label label8;
    }
}

namespace Presentation.Forms
{
    partial class UpdateFinance
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb = new System.Windows.Forms.ComboBox();
            this.accptBtn = new System.Windows.Forms.Button();
            this.transPM = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elija la cuenta a actualizar";
            // 
            // cmb
            // 
            this.cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmb.FormattingEnabled = true;
            this.cmb.Location = new System.Drawing.Point(12, 57);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(283, 31);
            this.cmb.TabIndex = 1;
            // 
            // accptBtn
            // 
            this.accptBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accptBtn.Location = new System.Drawing.Point(93, 94);
            this.accptBtn.Name = "accptBtn";
            this.accptBtn.Size = new System.Drawing.Size(132, 39);
            this.accptBtn.TabIndex = 2;
            this.accptBtn.Text = "Aceptar";
            this.accptBtn.UseVisualStyleBackColor = true;
            this.accptBtn.Click += new System.EventHandler(this.accptBtn_Click);
            // 
            // transPM
            // 
            this.transPM.AutoSize = true;
            this.transPM.Font = new System.Drawing.Font("Roboto Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transPM.LinkColor = System.Drawing.Color.Yellow;
            this.transPM.Location = new System.Drawing.Point(119, 39);
            this.transPM.Name = "transPM";
            this.transPM.Size = new System.Drawing.Size(162, 15);
            this.transPM.TabIndex = 3;
            this.transPM.TabStop = true;
            this.transPM.Text = "... o transferir a forma de pago";
            this.transPM.Visible = false;
            this.transPM.VisitedLinkColor = System.Drawing.Color.Yellow;
            this.transPM.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.transPM_LinkClicked);
            // 
            // UpdateFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(140)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(320, 144);
            this.Controls.Add(this.transPM);
            this.Controls.Add(this.accptBtn);
            this.Controls.Add(this.cmb);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateFinance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateFinance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb;
        private System.Windows.Forms.Button accptBtn;
        private System.Windows.Forms.LinkLabel transPM;
    }
}
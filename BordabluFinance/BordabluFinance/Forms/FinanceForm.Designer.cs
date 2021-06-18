
namespace Presentation.Forms
{
    partial class FinanceForm
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
            this.boardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // boardPanel
            // 
            this.boardPanel.AutoScroll = true;
            this.boardPanel.AutoSize = true;
            this.boardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boardPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.boardPanel.Location = new System.Drawing.Point(0, 0);
            this.boardPanel.Margin = new System.Windows.Forms.Padding(5);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Padding = new System.Windows.Forms.Padding(5);
            this.boardPanel.Size = new System.Drawing.Size(677, 450);
            this.boardPanel.TabIndex = 0;
            this.boardPanel.WrapContents = false;
            // 
            // FinanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(140)))), ((int)(((byte)(86)))));
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.boardPanel);
            this.Font = new System.Drawing.Font("Roboto Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "FinanceForm";
            this.Text = "FinanceForm";
            this.Load += new System.EventHandler(this.FinanceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel boardPanel;
    }
}
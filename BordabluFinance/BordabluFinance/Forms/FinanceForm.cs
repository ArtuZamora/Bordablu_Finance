using BordabluFinance;
using Common.Model;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class FinanceForm : Form
    {
        #region Properties
        private UserModel model = new UserModel();
        private string codeEditing = "";
        private PictureBox pictEditing = null;
        private NumericUpDown numeric = null;
        private StringBuilder ID = new StringBuilder();
        #endregion

        #region Constructors
        public FinanceForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Functional Events
        private void FinanceForm_Load(object sender, EventArgs e)
        {
            LoadFinance();
            LoadPayment();
        }
        private void LoadFinance()
        {
            boardPanel.Controls.Add(CreateTextPanel("Distribución de saldo de entidades"));
            List<FinanceDetail> financeDetails = model.Select_Finance_Details();
            foreach (FinanceDetail financeDetail in financeDetails)
            {
                Image image = Properties.Resources.CustomerIcon;
                if (financeDetail.ID_FD == "FD001")
                    image = Properties.Resources.BB_Logo_Black___Copy;
                boardPanel.Controls.Add(
                    CreateDetailPanel(financeDetail.ID_FD, financeDetail.Entity,
                    financeDetail.Balance, image));
            }
        }
        private void LoadPayment()
        {
            boardPanel.Controls.Add(CreateTextPanel("Distribución de saldo en cuentas"));
            List<PaymentMethod> paymentMethods = model.Select_Payment_Methods();
            foreach (PaymentMethod paymentMethod in paymentMethods)
            {
                Image image = Properties.Resources.BankIcon;
                if (paymentMethod.ID_PM == "PM01")
                    image = Properties.Resources.CashIcon;
                boardPanel.Controls.Add(
                    CreateDetailPanel(paymentMethod.ID_PM, paymentMethod.Method,
                    paymentMethod.Balance, image));
            }
        }
        private void CancelBtn_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox pictDlt = (PictureBox)boardPanel.Controls.Find(codeEditing + "_cancelBtn", true)[0];
            pictDlt.Visible = false;
            numeric.Visible = false;
            codeEditing = "";
            pictEditing.Image = Properties.Resources.Black_EditIcon1;
            pictEditing = null;
        }
        private void EditDoneBtn_MouseClick(object sender, MouseEventArgs e)
        {
            String s = ((PictureBox)sender).Name.Split("_")[0];
            if (codeEditing == "")
            {
                codeEditing = s;
                pictEditing = (PictureBox)sender;
                pictEditing.Image = Properties.Resources.Green_DoneIcon;
                PictureBox pictDlt = (PictureBox)boardPanel.Controls.Find(codeEditing + "_cancelBtn", true)[0];
                pictDlt.Visible = true;
                numeric = (NumericUpDown)boardPanel.Controls.Find(codeEditing + "_numeric", true)[0];
                numeric.Visible = true;
                Label lbl = ((Label)boardPanel.Controls.
                    Find(codeEditing + "_lblBalance", true)[0]);
                decimal value;
                if (lbl.Text.Substring(0, 1) == "-")
                    value = Convert.ToDecimal(lbl.Text.Substring(2)) * -1;
                else 
                    value = Convert.ToDecimal(lbl.Text.Substring(1));
                numeric.Value = value;
            }
            else if (codeEditing == s)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show("¿Está seguro de querer modificar este valor de cuenta?",
                        "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    decimal diference;
                    Label lbl = ((Label)boardPanel.Controls.
                      Find(codeEditing + "_lblBalance", true)[0]);
                    if (lbl.Text.Substring(0, 1) == "-")
                        diference = numeric.Value - Convert.ToDecimal(lbl.Text.Substring(2)) * -1;
                    else
                        diference = numeric.Value - Convert.ToDecimal(lbl.Text.Substring(1));
                    UpdateFinance update;
                    if (codeEditing.Substring(0, 2) == "PM")
                        update = new UpdateFinance(codeEditing, ref ID, diference);
                    else
                        update = new UpdateFinance(codeEditing, ref ID, diference);
                    update.FormClosed += Update_FormClosed;
                    update.ShowDialog();
                }
            }
            else
            {
                PictureBox pictDlt = (PictureBox)boardPanel.Controls.Find(codeEditing + "_cancelBtn", true)[0];
                numeric.Visible = false;
                pictDlt.Visible = false;
                pictEditing.Image = Properties.Resources.Black_EditIcon1;
                codeEditing = s;
                pictEditing = (PictureBox)sender;
                pictEditing.Image = Properties.Resources.Green_DoneIcon;
                numeric = (NumericUpDown)boardPanel.Controls.Find(codeEditing + "_numeric", true)[0];
                pictDlt = (PictureBox)boardPanel.Controls.Find(codeEditing + "_cancelBtn", true)[0];
                pictDlt.Visible = true;
                numeric.Visible = true;
                numeric.Value =
                    Convert.ToDecimal(((Label)boardPanel.Controls.
                    Find(codeEditing + "_lblBalance", true)[0]).Text.Substring(1));
            }
        }
        private void Update_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(ID.ToString() != "null")
            {
                decimal diference;
                Label lbl = ((Label)boardPanel.Controls.
                  Find(codeEditing + "_lblBalance", true)[0]);
                if (lbl.Text.Substring(0, 1) == "-")
                    diference = numeric.Value - Convert.ToDecimal(lbl.Text.Substring(2)) * -1;
                else
                    diference = numeric.Value - Convert.ToDecimal(lbl.Text.Substring(1));
                if (codeEditing.Substring(0, 2) == "PM")
                {
                    PaymentMethod paymentMethod = new PaymentMethod();
                    paymentMethod.ID_PM = codeEditing;
                    paymentMethod.Balance = numeric.Value;
                    if(ID.ToString().Substring(ID.Length - 1, 1) == "S")
                    {
                        ID.Remove(ID.Length - 1, 1);
                        diference *= -1;
                        model.Update_Payment_Method(paymentMethod, ID.ToString(), diference);
                    }
                    else
                        model.Update_Payment_Method(paymentMethod, ID.ToString(), diference);
                }
                else
                {
                    FinanceDetail financeDetail = new FinanceDetail();
                    financeDetail.ID_FD = codeEditing;
                    financeDetail.Balance = numeric.Value;
                    model.Update_Finance_Detail(financeDetail, ID.ToString(), diference);
                }
                Program.mainForm.EnterForm(Program.mainForm.financePanel, 1, true);
            }
        }
        #endregion

        #region Apearence Events
        private void EditDoneBtn_MouseLeave(object sender, EventArgs e)
        {
            if (codeEditing != "" && ((PictureBox)sender).Name.Split("_")[0] == codeEditing)
                ((PictureBox)sender).Image = Properties.Resources.Black_DoneIcon1;
            else
                ((PictureBox)sender).Image = Properties.Resources.Black_EditIcon1;
        }
        private void EditDoneBtn_MouseEnter(object sender, EventArgs e)
        {
            if (codeEditing != "" && ((PictureBox)sender).Name.Split("_")[0] == codeEditing)
                ((PictureBox)sender).Image = Properties.Resources.Green_DoneIcon;
            else
                ((PictureBox)sender).Image = Properties.Resources.Blue_EditIcon;
        }
        private void CancelBtn_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.Black_CancelIcon1;
        }
        private void CancelBtn_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Properties.Resources.Red_CancelIcon;
        }
        #endregion

        #region Object creation methods
        public Panel CreateTextPanel(String text)
        {
            Panel panel = new Panel();
            Label label = new Label();
            panel.Size = new Size(655, 47);
            panel.BackColor = Color.Transparent;
            label.AutoSize = true;
            label.Parent = panel;
            label.Text = text;
            label.Location = new Point(9, 6);
            label.Font = new Font("Roboto Condensed", (float)20.25, FontStyle.Italic);
            return panel;
        }
        public Panel CreateDetailPanel(String Code, String EntityName, decimal EntityBalance, Image EntityImage)
        {
            Panel panel = new Panel();
            Label lblEntityAux = new Label();
            Label lblBalanceAux = new Label();
            Label lblEntity = new Label();
            Label lblBalance = new Label();
            PictureBox entityImage = new PictureBox();
            PictureBox cancelBtn = new PictureBox();
            PictureBox editDoneBtn = new PictureBox();
            NumericUpDown numeric = new NumericUpDown();

            panel.Name = Code + "_Pnl";
            lblEntity.Name = Code + "_lblEntity";
            lblBalance.Name = Code + "_lblBalance";
            entityImage.Name = Code + "_entityImage";
            cancelBtn.Name = Code + "_cancelBtn";
            editDoneBtn.Name = Code + "_editDoneBtn";
            numeric.Name = Code + "_numeric";

            panel.Size = new Size(655, 105);
            panel.BackColor = Color.FromArgb(174, 147, 126);
            lblEntityAux.Text = "Entidad";
            lblBalanceAux.Text = "Balance";
            lblEntityAux.Font = lblBalanceAux.Font =
                new Font("Roboto Condensed", (float)12.0, FontStyle.Italic);

            lblEntity.Text = EntityName;
            lblBalance.Text = EntityBalance.ToString("$0.00");
            lblEntity.Font = lblBalance.Font =
                new Font("Roboto Condensed", (float)18.0, FontStyle.Bold);

            lblEntityAux.AutoSize = lblBalanceAux.AutoSize =
                lblEntity.AutoSize = lblBalance.AutoSize = true;

            entityImage.Size = new Size(130, 105);
            entityImage.Image = EntityImage;
            entityImage.SizeMode = PictureBoxSizeMode.Zoom;

            cancelBtn.Size = editDoneBtn.Size = new Size(30, 29);
            cancelBtn.Image = Properties.Resources.Black_CancelIcon1;
            editDoneBtn.Image = Properties.Resources.Black_EditIcon1;
            cancelBtn.SizeMode = editDoneBtn.SizeMode = PictureBoxSizeMode.Zoom;
            cancelBtn.Cursor = editDoneBtn.Cursor = Cursors.Hand;

            cancelBtn.MouseEnter += CancelBtn_MouseEnter;
            cancelBtn.MouseLeave += CancelBtn_MouseLeave;
            editDoneBtn.MouseEnter += EditDoneBtn_MouseEnter;
            editDoneBtn.MouseLeave += EditDoneBtn_MouseLeave;
            editDoneBtn.MouseClick += EditDoneBtn_MouseClick;
            cancelBtn.MouseClick += CancelBtn_MouseClick;

            cancelBtn.Visible = false;

            numeric.Size = new Size(120, 33);
            numeric.TextAlign = HorizontalAlignment.Center;
            numeric.DecimalPlaces = 2;
            numeric.Minimum = decimal.MaxValue * -1;
            numeric.Maximum = decimal.MaxValue;

            panel.Controls.AddRange(
                new Control[] { lblEntityAux , lblBalanceAux, lblEntity,
                    lblBalance, entityImage, editDoneBtn, cancelBtn, numeric });

            lblEntityAux.BringToFront();
            lblBalanceAux.BringToFront();
            lblEntity.BringToFront();
            lblBalance.BringToFront();
            entityImage.BringToFront();
            editDoneBtn.BringToFront();
            cancelBtn.BringToFront();
            numeric.BringToFront();

            entityImage.Location = new Point(0, 0);
            lblEntityAux.Location = new Point(178, 25);
            lblBalanceAux.Location = new Point(413, 25);
            lblEntity.Location = new Point(178, 46);
            lblBalance.Location = new Point(413, 46);
            editDoneBtn.Location = new Point(550, 47);
            cancelBtn.Location = new Point(583, 47);
            numeric.Location = new Point(412, 45);

            numeric.Visible = false;

            return panel;
        }
        #endregion
    }
}

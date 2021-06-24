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
    public partial class UpdateFinance : Form
    {
        private StringBuilder id = new StringBuilder();
        private string code;
        private static UserModel model = new UserModel();
        private decimal diference;
        private bool visited = false;
        public UpdateFinance(string code, ref StringBuilder ID, decimal diference)
        {
            InitializeComponent();
            id = ID;
            this.diference = diference;
            this.code = code;
            id.Clear();
            id.Append("null");
            if (code.Substring(0, 2) == "PM")
            {
                FillPayment();
                if (diference < 0)
                    transPM.Visible = true;
            }
            else
                FillFinance();
        }
        private void FillPayment()
        {
            cmb.DataSource = null;
            cmb.DataSource = model.Select_Finance_Details();
            cmb.ValueMember = "ID_FD";
            cmb.DisplayMember = "Entity";
        }
        private void FillFinance()
        {
            cmb.DataSource = null;
            cmb.DataSource = model.Select_Payment_Methods();
            cmb.ValueMember = "ID_PM";
            cmb.DisplayMember = "Method";
        }
        private void accptBtn_Click(object sender, EventArgs e)
        {
            if (!visited)
                if (diference < 0)
                {
                    decimal balance = model.Obtain_Balance(cmb.SelectedValue.ToString());
                    if (Math.Abs(diference) > balance)
                    {
                        MessageBox.Show("Saldo insuficiente en cuenta.", "ERROR",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }
            id.Clear();
            id.Append(cmb.SelectedValue.ToString());
            if (visited)
                id.Append("S");
            this.Close();
        }

        private void transPM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            visited = true;
            cmb.DataSource = null;
            cmb.DataSource = model.Select_Payment_Methods().FindAll(pm => pm.ID_PM != code);
            cmb.ValueMember = "ID_PM";
            cmb.DisplayMember = "Method";
        }
    }
}

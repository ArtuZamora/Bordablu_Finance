﻿using Presentation.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Bordablu : Form
    {
        private Control active = null;
        private Form activeForm = null;
        public Bordablu()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            active = dashPanel;
            StayColor(active, 1);
            activeForm = new DashboardForm();
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            childFormPanel.Controls.Add(activeForm);
            activeForm.BringToFront();
            activeForm.Show();
        }

        #region Appearence Methods
            #region Change Control Colors
        private void StayColor(Control control, int color)
        {
            switch(color)
            {
                case 1:
                    control.BackColor = Color.FromArgb(211, 140, 86);
                    break;
                case 2:
                    control.BackColor = Color.FromArgb(200, 163, 136);
                    break;
                case 3:
                    control.BackColor = Color.FromArgb(85, 141, 161);
                    break;
            }
        }
        private void EnterColor(Control control, int color)
        {
            if (control != active)
            {
                control.BackColor = color == 1 ? Color.FromArgb(211, 140, 86) :
                    control.BackColor = Color.FromArgb(85, 141, 161);
            }
        }
        private void LeaveColor(Control control)
        {
            if (control != active)
            {
                control.BackColor = Color.FromArgb(200, 163, 136);
            }
        }
        private void EnterForm(Control control, int color)
        {
            if(active != control)
            {
                activeForm.Close();
                StayColor(active, 2);
                active = control;
                StayColor(active, color);
                switch(control.Name)
                {
                    case "dashPanel":
                        activeForm = new DashboardForm();
                        break;
                    case "rawMatPanel":
                        activeForm = new RawMaterialForm();
                        break;
                    case "productPanel":
                        activeForm = new ProductsForm();
                        break;
                    case "financePanel":
                        activeForm = new FinanceForm();
                        break;
                    case "addOrderPanel":
                        activeForm = new AddOrderForm();
                        break;
                }
                activeForm.TopLevel = false;
                activeForm.FormBorderStyle = FormBorderStyle.None;
                activeForm.Dock = DockStyle.Fill;
                childFormPanel.Controls.Add(activeForm);
                activeForm.BringToFront();
                activeForm.Show();
            }
        }

        private void productPanel_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(productPanel, 1);
        }
        private void productPanel_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(productPanel);
        }
        private void rawMatPanel_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(rawMatPanel, 1);
        }
        private void rawMatPanel_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(rawMatPanel);
        }
        private void dashPanel_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(dashPanel, 1);
        }
        private void dashPanel_MouseLeave(object sender, EventArgs e)
        {

            LeaveColor(dashPanel);
        }
        private void dashPict_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(dashPanel, 1);
        }
        private void dashPict_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(dashPanel);
        }
        private void dashLbl_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(dashPanel, 1);
        }
        private void dashLbl_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(dashPanel);
        }
        private void rawMatPict_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(rawMatPanel, 1);
        }
        private void rawMatPict_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(rawMatPanel);
        }
        private void rawMatLbl_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(rawMatPanel, 1);
        }
        private void rawMatLbl_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(rawMatPanel);
        }
        private void productPic_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(productPanel, 1);
        }
        private void productPic_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(productPanel);
        }
        private void productLbl_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(productPanel, 1);
        }
        private void productLbl_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(productPanel);
        }
        private void financePanel_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(financePanel, 1);
        }
        private void financePanel_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(financePanel);
        }
        private void financeLbl_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(financePanel, 1);
        }
        private void financeLbl_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(financePanel);
        }
        private void financePict_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(financePanel, 1);
        }
        private void financePict_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(financePanel);
        }
        private void addOrderPanel_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(addOrderPanel, 2);
        }
        private void addOrderPanel_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(addOrderPanel);
        }
        private void addOrderLbl_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(addOrderPanel, 2);
        }
        private void addOrderLbl_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(addOrderPanel);
        }
        private void addOrderPict_MouseEnter(object sender, EventArgs e)
        {
            EnterColor(addOrderPanel, 2);
        }
        private void addOrderPict_MouseLeave(object sender, EventArgs e)
        {
            LeaveColor(addOrderPanel);
        }
        private void dashLbl_Click(object sender, EventArgs e)
        {
            EnterForm(dashPanel, 1);
        }
        private void dashPanel_Click(object sender, EventArgs e)
        {
            EnterForm(dashPanel, 1);
        }
        private void dashPict_Click(object sender, EventArgs e)
        {
            EnterForm(dashPanel, 1);
        }
        private void rawMatPanel_Click(object sender, EventArgs e)
        {
            EnterForm(rawMatPanel, 1);
        }
        private void rawMatPict_Click(object sender, EventArgs e)
        {
            EnterForm(rawMatPanel, 1);
        }
        private void rawMatLbl_Click(object sender, EventArgs e)
        {
            EnterForm(rawMatPanel, 1);
        }
        private void productPanel_Click(object sender, EventArgs e)
        {
            EnterForm(productPanel, 1);
        }
        private void productLbl_Click(object sender, EventArgs e)
        {
            EnterForm(productPanel, 1);
        }
        private void productPic_Click(object sender, EventArgs e)
        {
            EnterForm(productPanel, 1);
        }
        private void financePanel_Click(object sender, EventArgs e)
        {
            EnterForm(financePanel, 1);
        }
        private void financeLbl_Click(object sender, EventArgs e)
        {
            EnterForm(financePanel, 1);
        }
        private void financePict_Click(object sender, EventArgs e)
        {
            EnterForm(financePanel, 1);
        }
        private void addOrderPanel_Click(object sender, EventArgs e)
        {
            EnterForm(addOrderPanel, 3);
        }
        private void addOrderLbl_Click(object sender, EventArgs e)
        {
            EnterForm(addOrderPanel, 3);
        }
        private void addOrderPict_Click(object sender, EventArgs e)
        {
            EnterForm(addOrderPanel, 3);
        }
        #endregion

        #endregion
    }
}
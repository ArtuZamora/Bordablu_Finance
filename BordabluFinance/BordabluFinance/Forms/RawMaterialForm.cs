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
    public partial class RawMaterialForm : Form
    {
        private static UserModel model = new UserModel();
        private static RawMaterial curr_rawMat = null;
        private static Expense curr_expense = null;
        public RawMaterialForm()
        {
            InitializeComponent();
        }

        private void RawMaterialForm_Load(object sender, EventArgs e)
        {
            LoadRawMaterialData();
            LoadExpensesData();
        }

        #region Raw Material Methods
        private void LoadRawMaterialData()
        {
            FillRawMaterialDgv();
            rawMatCtxMenu.Items.Add("Modificar");
            rawMatCtxMenu.Items.Add("Eliminar");
            rawMaterialDgv.ShowCellToolTips = false;
        }
        private void FillRawMaterialDgv()
        {
            rawMaterialDgv.DataSource = null;
            rawMaterialDgv.DataSource = model.Select_Raw_Materials();
            rawMaterialDgv.Columns[0].HeaderText = "Código";
            rawMaterialDgv.Columns[1].HeaderText = "Nombre";
            rawMaterialDgv.Columns[2].HeaderText = "Stock";
            rawMaterialDgv.Columns[3].HeaderText = "Precio";
            rawMaterialDgv.Columns[3].DefaultCellStyle.Format = "$0.00";
            rawMaterialDgv.Columns[4].Visible = false;
            rawMaterialDgv.Columns[5].Visible = false;
        }
        private void rawMaterialBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(rawMaterialTxt.Text))
                    GlobalMethods.errorProvider.SetError(rawMaterialTxt, "No debe dejar el campo vacío");
                else if (string.IsNullOrEmpty(supplierTxt.Text))
                    GlobalMethods.errorProvider.SetError(supplierTxt, "No debe dejar el campo vacío");
                else
                {
                    if (curr_rawMat != null)
                    {
                        curr_rawMat.Name = rawMaterialTxt.Text;
                        curr_rawMat.Supplier = supplierTxt.Text;
                        curr_rawMat.Stock = Convert.ToInt32(stockNum.Value);
                        curr_rawMat.Cost = setPriceNum.Value;
                        curr_rawMat.Description = descriptionTxt.Text;
                        model.Update_Raw_Material(curr_rawMat);
                        curr_rawMat = null;
                        MessageBox.Show("El registro ha sido modificado con éxito",
                            "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rawMaterialBtn.Text = "Agregar";
                    }
                    else
                    {
                        model.Insert_Raw_Material(
                            new RawMaterial("RM000", rawMaterialTxt.Text, Convert.ToInt32(stockNum.Value),
                            setPriceNum.Value, supplierTxt.Text, descriptionTxt.Text));
                        MessageBox.Show("El registro ha sido ingresado con éxito",
                            "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    rawMaterialTxt.Text = "";
                    supplierTxt.Text = "";
                    descriptionTxt.Text = "";
                    stockNum.Value = 0;
                    setPriceNum.Value = 0;
                    rawMaterialTxt.Focus();
                    GlobalMethods.errorProvider.SetError(rawMaterialTxt, null);
                    GlobalMethods.errorProvider.SetError(supplierTxt, null);
                    FillRawMaterialDgv();
                    FillRawMaterialCmb();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La solicitud no pudo ser procesada. Error: " + ex.Message,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rawMaterialTxt_TextChanged(object sender, EventArgs e)
        {
            GlobalMethods.VerifyEmpty((TextBox)sender);
        }
        private void supplierTxt_TextChanged(object sender, EventArgs e)
        {
            GlobalMethods.VerifyEmpty((TextBox)sender);
        }
        private void rawMatCtxMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((ContextMenuStrip)sender).Hide();
            switch (e.ClickedItem.Text)
            {
                case "Modificar":
                    curr_rawMat =
                        new RawMaterial(rawMaterialDgv.CurrentRow.Cells[0].Value.ToString(),
                        rawMaterialDgv.CurrentRow.Cells[1].Value.ToString(),
                        Convert.ToInt32(rawMaterialDgv.CurrentRow.Cells[2].Value.ToString()),
                        Convert.ToDecimal(rawMaterialDgv.CurrentRow.Cells[3].Value.ToString()),
                        rawMaterialDgv.CurrentRow.Cells[4].Value.ToString(),
                        rawMaterialDgv.CurrentRow.Cells[5].Value.ToString());
                    rawMaterialTxt.Text = curr_rawMat.Name;
                    supplierTxt.Text = curr_rawMat.Supplier;
                    stockNum.Value = curr_rawMat.Stock;
                    setPriceNum.Value = curr_rawMat.Cost;
                    descriptionTxt.Text = curr_rawMat.Description;
                    rawMaterialTxt.Focus();
                    rawMaterialBtn.Text = "Modificar";
                    break;
                case "Eliminar":
                    if (DialogResult.Yes ==
                        MessageBox.Show("¿Está seguro de querer eliminar este registro?",
                            "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        try
                        {
                            model.Delete_Raw_Material(rawMaterialDgv.CurrentRow.Cells[0].Value.ToString());
                            MessageBox.Show("El registro ha sido eliminado con éxito",
                                    "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillRawMaterialDgv();
                            FillRawMaterialCmb();
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
        private void rawMaterialDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalMethods.ContextDGV((DataGridView)sender, e, MousePosition, rawMatCtxMenu);
        }

        #endregion

        #region Expenses Methods
        public void LoadExpensesData()
        {
            FillRawMaterialCmb();
            FillExpensesDgv();
            expensesCtxtMenu.Items.Add("Modificar");
            expensesCtxtMenu.Items.Add("Eliminar");
            expensesDetDgv.ShowCellToolTips = false;
        }
        public void FillRawMaterialCmb()
        {
            rawMaterialCmb.DataSource = null;
            rawMaterialCmb.DataSource = model.Select_Raw_Materials();
            rawMaterialCmb.ValueMember = "ID_RM";
            rawMaterialCmb.DisplayMember = "Name";
        }
        private void expensesBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (curr_expense != null)
                {
                    Expense tempExpense =
                        new Expense(curr_expense.ID_E, curr_expense.Purchase_Date,
                            curr_expense.Amount, curr_expense.Quantity, curr_expense.rawMaterial);
                    curr_expense.Purchase_Date = datePurc.Value;
                    curr_expense.Amount = expePrice.Value;
                    curr_expense.Quantity = Convert.ToInt32(qtyNum.Value);
                    curr_expense.rawMaterial.ID_RM = rawMaterialCmb.SelectedValue.ToString();
                    model.Update_Expenses(curr_expense, tempExpense);
                    curr_expense = null;
                    MessageBox.Show("El registro ha sido modificado con éxito",
                        "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    expensesBtn.Text = "Agregar";
                }
                else
                {
                    RawMaterial rawMaterial = new RawMaterial();
                    rawMaterial.ID_RM = rawMaterialCmb.SelectedValue.ToString();
                    model.Insert_Expenses(
                        new Expense("E0000000", datePurc.Value, expePrice.Value,
                        Convert.ToInt32(qtyNum.Value), rawMaterial));
                    MessageBox.Show("El registro ha sido ingresado con éxito",
                        "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                qtyNum.Value = 1;
                expePrice.Value = 0;
                rawMaterialCmb.Focus();
                FillExpensesDgv();
                FillRawMaterialDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("La solicitud no pudo ser procesada. Error: " + ex.Message,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillExpensesDgv()
        {
            try
            {
                expensesDetDgv.DataSource = null;
                expensesDetDgv.DataSource = model.Select_Expenses();
                expensesDetDgv.Columns[0].HeaderText = "Código";
                expensesDetDgv.Columns[1].HeaderText = "F. Compra";
                expensesDetDgv.Columns[2].HeaderText = "Costo";
                expensesDetDgv.Columns[2].DefaultCellStyle.Format = "$0.00";
                expensesDetDgv.Columns[3].HeaderText = "Cantidad";
                expensesDetDgv.Columns[4].Visible = false;
                expensesDetDgv.Columns[5].HeaderText = "Materia P.";
                expensesDetDgv.Columns[6].HeaderText = "Proveedor";

            }
            catch
            {
                throw;
            }
        }
        private void expensesDetDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalMethods.ContextDGV((DataGridView)sender, e, MousePosition, expensesCtxtMenu);
        }
        private void expensesCtxtMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((ContextMenuStrip)sender).Hide();
            switch (e.ClickedItem.Text)
            {
                case "Modificar":
                    RawMaterial rawMaterial = new RawMaterial();
                    rawMaterial.ID_RM = expensesDetDgv.CurrentRow.Cells[4].Value.ToString();
                    curr_expense =
                        new Expense(expensesDetDgv.CurrentRow.Cells[0].Value.ToString(),
                        Convert.ToDateTime(expensesDetDgv.CurrentRow.Cells[1].Value),
                        Convert.ToDecimal(expensesDetDgv.CurrentRow.Cells[2].Value),
                        Convert.ToInt32(expensesDetDgv.CurrentRow.Cells[3].Value),
                        rawMaterial);
                    rawMaterialCmb.SelectedValue = curr_expense.rawMaterial.ID_RM;
                    datePurc.Value = curr_expense.Purchase_Date;
                    qtyNum.Value = curr_expense.Quantity;
                    expePrice.Value = curr_expense.Amount;
                    rawMaterialCmb.Focus();
                    expensesBtn.Text = "Modificar";
                    break;
                case "Eliminar":
                    if (DialogResult.Yes ==
                        MessageBox.Show("¿Está seguro de querer eliminar este registro?",
                            "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        try
                        {
                            RawMaterial rawMaterial1 = new RawMaterial();
                            rawMaterial1.ID_RM = expensesDetDgv.CurrentRow.Cells[4].Value.ToString();
                            model.Delete_Expenses(
                                new Expense(expensesDetDgv.CurrentRow.Cells[0].Value.ToString(),
                                    Convert.ToDateTime(expensesDetDgv.CurrentRow.Cells[1].Value),
                                    Convert.ToDecimal(expensesDetDgv.CurrentRow.Cells[2].Value),
                                    Convert.ToInt32(expensesDetDgv.CurrentRow.Cells[3].Value),
                                    rawMaterial1));
                            MessageBox.Show("El registro ha sido eliminado con éxito",
                                    "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillExpensesDgv();
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
        #endregion
    }
}

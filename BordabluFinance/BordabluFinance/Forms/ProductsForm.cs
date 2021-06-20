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
    public partial class ProductsForm : Form
    {
        #region Local Properties
        private static UserModel model = new UserModel();
        private static Product curr_product = null;
        private static Specification curr_specification = null;
        private static List<DataType> dataTypes = new List<DataType>();
        private static bool filling = true;
        #endregion

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadProductData();
            LoadSpecificationData();
        }

        #region Products Methods
        private void LoadProductData()
        {
            FillProductDgv();
            productsCtxtMenu.Items.Add("Modificar");
            productsCtxtMenu.Items.Add("Eliminar");
            productsDgv.ShowCellToolTips = false;
        }
        private void FillProductDgv()
        {
            try
            {
                productsDgv.DataSource = null;
                productsDgv.DataSource = model.Select_Products();
                if (productsDgv.Rows.Count != 0)
                {
                    productsDgv.Columns[0].HeaderText = "Código";
                    productsDgv.Columns[1].HeaderText = "Producto";
                }
            }
            catch
            {
                throw;
            }
        }
        private void productBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(productNameTxt.Text))
                    GlobalMethods.errorProvider.SetError(productNameTxt, "No debe dejar el campo vacío");
                else
                {
                    if(curr_product != null)
                    {
                        curr_product.Name = productNameTxt.Text.Trim();
                        model.Update_Product(curr_product);
                        curr_product = null;
                        MessageBox.Show("El producto ha sido modificado con éxito",
                            "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        productBtn.Text = "Agregar";
                    }
                    else
                    {
                        model.Insert_Product(new Product("P000", productNameTxt.Text.Trim()));
                        MessageBox.Show("El registro ha sido ingresado con éxito",
                            "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    productNameTxt.Text = "";
                    productNameTxt.Focus();
                    GlobalMethods.errorProvider.SetError(productNameTxt, null);
                    FillProductDgv();
                    FillProductsCmb();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La solicitud no pudo ser procesada. Error: " + ex.Message,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void productNameTxt_TextChanged(object sender, EventArgs e)
        {
            GlobalMethods.VerifyEmpty((TextBox)sender);
        }
        private void productNameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                productBtn_Click(null, null);
        }
        private void productsDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalMethods.ContextDGV((DataGridView)sender, e, MousePosition, productsCtxtMenu);
        }
        private void productsCtxtMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((ContextMenuStrip)sender).Hide();
            switch (e.ClickedItem.Text)
            {
                case "Modificar":
                    curr_product = new Product(productsDgv.CurrentRow.Cells[0].Value.ToString(),
                        productsDgv.CurrentRow.Cells[1].Value.ToString());
                    productNameTxt.Text = curr_product.Name;
                    productNameTxt.Focus();
                    productBtn.Text = "Modificar";
                    break;
                case "Eliminar":
                    if(DialogResult.Yes ==
                        MessageBox.Show("¿Está seguro de querer eliminar este registro?",
                            "ADVERTENCIA",MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        try
                        {
                            model.Delete_Product(productsDgv.CurrentRow.Cells[0].Value.ToString());
                            MessageBox.Show("El producto ha sido eliminado con éxito",
                                    "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillProductsCmb();
                            FillProductDgv();
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

        #region Specification Methods
        private void LoadSpecificationData()
        {
            FillDataTypeCombo();
            FillProductsCmb();
            specifCtxtMenu.Items.Add("Modificar");
            specifCtxtMenu.Items.Add("Eliminar");
            specifDgv.ShowCellToolTips = false;
        }
        private void FillDataTypeCombo()
        {
            dataTypes.Clear();
            dataTypes.Add(new DataType(dataTypes.Count + 1, "Texto corto"));
            dataTypes.Add(new DataType(dataTypes.Count + 1, "Texto largo"));
            dataTypes.Add(new DataType(dataTypes.Count + 1, "Número entero"));
            dataTypes.Add(new DataType(dataTypes.Count + 1, "Número decimal"));
            dataTypes.Add(new DataType(dataTypes.Count + 1, "Dinero"));
            dataTypes.Add(new DataType(dataTypes.Count + 1, "Color"));
            dataTypeCmb.DataSource = dataTypes;
            dataTypeCmb.ValueMember = "ID";
            dataTypeCmb.DisplayMember = "Type";
        }
        private void FillProductsCmb()
        {
            filling = true;
            GlobalMethods.errorProvider.SetError(productCmb, null);
            productCmb.DataSource = null;
            productCmb.DataSource = model.Select_Products();
            productCmb.ValueMember = "ID_P";
            productCmb.DisplayMember = "Name";
            filling = false;
            FillSpecificationsDgv();
        }
        private void FillSpecificationsDgv()
        {
            try
            {
                specifDgv.DataSource = null;
                specifDgv.DataSource = model.Select_Specifications(productCmb.SelectedValue.ToString());
                specifDgv.Columns[0].Visible = false;
                specifDgv.Columns[2].HeaderText = "Descripción";
                specifDgv.Columns[3].HeaderText = "Tipo";
                specifDgv.Columns[1].Visible = false;
            }
            catch (Exception ex) { Console.WriteLine(ex); throw; }
        }
        private void productCmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!filling)
                FillSpecificationsDgv();
        }
        private void specifBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(specifTxt.Text))
                    GlobalMethods.errorProvider.SetError(specifTxt, "No debe dejar el campo vacío");
                else if (productCmb.SelectedValue == null)
                    GlobalMethods.errorProvider.SetError(productCmb, "No existen actualmente productos");
                else
                {
                    if (curr_specification != null)
                    {
                        curr_specification.Property = specifTxt.Text.Trim();
                        curr_specification.Data_Type = ((DataType)dataTypeCmb.SelectedItem).Type;
                        model.Update_Specification(curr_specification);
                        curr_specification = null;
                        MessageBox.Show("La especificación ha sido modificado con éxito",
                            "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        specifBtn.Text = "Agregar";
                    }
                    else
                    {
                        model.Insert_Specification(
                            new Specification("S000", productCmb.SelectedValue.ToString()
                            , specifTxt.Text.Trim(), ((DataType)dataTypeCmb.SelectedItem).Type));
                        MessageBox.Show("El registro ha sido ingresado con éxito",
                            "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    specifTxt.Text = "";
                    specifTxt.Focus();
                    GlobalMethods.errorProvider.SetError(specifTxt, null);
                    FillSpecificationsDgv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La solicitud no pudo ser procesada. Error: " + ex.Message,
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void specifTxt_TextChanged(object sender, EventArgs e)
        {
            GlobalMethods.VerifyEmpty((TextBox)sender);
        }
        private void specifCtxtMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ((ContextMenuStrip)sender).Hide();
            switch (e.ClickedItem.Text)
            {
                case "Modificar":
                    curr_specification =
                        new Specification(specifDgv.CurrentRow.Cells[0].Value.ToString(),
                        productCmb.SelectedValue.ToString(),
                        specifDgv.CurrentRow.Cells[2].Value.ToString(),
                        specifDgv.CurrentRow.Cells[3].Value.ToString());
                    specifTxt.Text = curr_specification.Property;
                    dataTypeCmb.SelectedValue = 
                        dataTypes.Find(dt => dt.Type == curr_specification.Data_Type).ID;
                    specifTxt.Focus();
                    specifBtn.Text = "Modificar";
                    break;
                case "Eliminar":
                    if (DialogResult.Yes ==
                        MessageBox.Show("¿Está seguro de querer eliminar este registro?",
                            "ADVERTENCIA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        try
                        {
                            model.Delete_Specification(specifDgv.CurrentRow.Cells[0].Value.ToString());
                            MessageBox.Show("El registro ha sido eliminado con éxito",
                                    "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillSpecificationsDgv();
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
        private void specifDgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            GlobalMethods.ContextDGV((DataGridView)sender, e, MousePosition, specifCtxtMenu);
        }
        private void specifTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                specifBtn_Click(null, null);
        }
        #endregion

        #region Local Classes
        private class DataType
        {
            public int ID { get; set; }
            public string Type { get; set; }
            public DataType(int id, string type)
            {
                ID = id;
                Type = type;
            }
        }
        #endregion
    }
}

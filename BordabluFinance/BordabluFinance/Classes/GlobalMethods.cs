using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation.Classes
{
    public static class GlobalMethods
    {
        public static ErrorProvider errorProvider = new ErrorProvider();
        public static void VerifyEmpty(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
                errorProvider.SetError(textBox, "No debe dejar el campo vacío");
            else
                errorProvider.SetError(textBox, null);
        }
        public static void ContextDGV(DataGridView dgv, DataGridViewCellMouseEventArgs e,
                                        Point MousePosition, ContextMenuStrip contextMenu)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            contextMenu.Show(MousePosition);
        }
    }
}

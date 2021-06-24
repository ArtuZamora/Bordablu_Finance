using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class Expense
    {
        #region Properties
        public string ID_E { get; set; }
        public DateTime Purchase_Date { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public RawMaterial rawMaterial { get; set; }
        #endregion

        #region Constructors
        public Expense(string ID_E, DateTime Purchase_Date, decimal Amount,
            int Quantity, RawMaterial rawMaterial)
        {
            this.ID_E = ID_E;
            this.Purchase_Date = Purchase_Date;
            this.Amount = Amount;
            this.Quantity = Quantity;
            this.rawMaterial = rawMaterial;
        }
        public Expense() { }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class Expense
    {
        public string ID_E { get; set; }
        public DateTime Purchase_Date { get; set; }
        public decimal Amount { get; set; }
        public int Quantity { get; set; }
        public string ID_RM { get; set; }
        public string Name { get; set; }

        public Expense(string ID_E, DateTime Purchase_Date, decimal Amount, int Quantity, string ID_RM)
        {
            this.ID_E = ID_E;
            this.Purchase_Date = Purchase_Date;
            this.Amount = Amount;
            this.Quantity = Quantity;
            this.ID_RM = ID_RM;
        }
        public Expense() { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class Order
    {
        #region Properties
        public string ID_O { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Delivery_Date { get; set; }
        public string Client { get; set; }
        public decimal Order_Amount { get; set; }
        public decimal Delivery_Amount { get; set; }
        public decimal Labor_Amount { get; set; }
        public decimal Total_Amount { get; set; }
        public decimal Earned_Amount { get; set; }
        public string ID_PM { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool Help { get; set; }
        public decimal Given_Amount { get; set; }
        #endregion
    }
}

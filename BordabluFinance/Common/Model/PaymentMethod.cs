using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class PaymentMethod
    {
        #region Properties
        public string ID_PM { get; set; }
        public string Method { get; set; }
        public decimal Balance { get; set; }
        #endregion

        #region Contructors
        public PaymentMethod(string ID_PM, string Method, decimal Balance)
        {
            this.ID_PM = ID_PM;
            this.Method = Method;
            this.Balance = Balance;
        }
        public PaymentMethod()
        {

        }
        #endregion
    }
}

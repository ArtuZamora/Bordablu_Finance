using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class FinanceDetail
    {
        #region Properties
        public string ID_FD { get; set; }
        public string Entity { get; set; }
        public decimal Balance { get; set; }
        #endregion

        #region Constructors
        public FinanceDetail(string ID_FD, string Entity, decimal Balance)
        {
            this.ID_FD = ID_FD;
            this.Entity = Entity;
            this.Balance = Balance;
        }
        public FinanceDetail()
        {

        }
        #endregion

    }
}

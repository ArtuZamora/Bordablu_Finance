using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class Product
    {
        #region Properties
        public string ID_P { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructor
        public Product(string ID_P, string Name)
        {
            this.ID_P = ID_P;
            this.Name = Name;
        }
        #endregion
    }
    public class ProductQty : Product
    {
        public int P_Num { get; set; }
        public ProductQty(string ID_P, string Name, int P_Num) : base(ID_P, Name)
        {
            this.P_Num = P_Num;
        }
    }
}

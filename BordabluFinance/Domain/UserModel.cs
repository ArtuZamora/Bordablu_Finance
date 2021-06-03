using Common.Model;
using DataAccess.Access;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserModel
    {
        Consults consults = new Consults();

        #region Products
        public List<Product> Select_Products()
        {
            return consults.Select_Products();
        }
        public void Insert_Product(Product product)
        {
            consults.Insert_Products(product);
        }
        public void Update_Product(Product product)
        {
            consults.Update_Products(product);
        }
        public void Delete_Product(string ID_P)
        {
            consults.Delete_Products(ID_P);
        }
        #endregion

        #region Specification
        public List<Specification> Select_Specifications(string ID_P)
        {
            return consults.Select_Specifications(ID_P);
        }
        public void Insert_Specification(Specification specification)
        {
            consults.Insert_Specification(specification);
        }
        public void Update_Specification(Specification specification)
        {
            consults.Update_Specification(specification);
        }
        public void Delete_Specification(string ID_S)
        {
            consults.Delete_Specification(ID_S);
        }
        #endregion
    }
}

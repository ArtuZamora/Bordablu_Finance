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

        #region Raw Material
        public List<RawMaterial> Select_Raw_Materials()
        {
            return consults.Select_Raw_Material();
        }
        public void Insert_Raw_Material(RawMaterial rawMaterial)
        {
            consults.Insert_Raw_Material(rawMaterial);
        }
        public void Update_Raw_Material(RawMaterial rawMaterial)
        {
            consults.Update_Raw_Material(rawMaterial);
        }
        public void Delete_Raw_Material(string ID_RM)
        {
            consults.Delete_Raw_Material(ID_RM);
        }
        #endregion

        #region Expenses
        public List<Expense> Select_Expenses()
        {
            return consults.Select_Expenses();
        }
        public void Insert_Expenses(Expense expense)
        {
            consults.Insert_Expenses(expense);
        }
        public void Update_Expenses(Expense expenseAfter, Expense expenseBefore)
        {
            consults.Update_Expenses(expenseAfter, expenseBefore);
        }
        public void Delete_Expenses(Expense expense)
        {
            consults.Delete_Expenses(expense);
        }
        #endregion
    }
}

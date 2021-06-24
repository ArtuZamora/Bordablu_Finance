using Common.Model;
using DataAccess.Access;
using System;
using System.Collections.Generic;
using System.Data;

namespace Domain
{
    public class UserModel
    {
        private Consults consults = new Consults();

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
        public DataTable Select_Expenses()
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

        #region Finance Details
        public List<FinanceDetail> Select_Finance_Details()
        {
            return consults.Select_Finance_Details();
        }
        public void Update_Finance_Detail(FinanceDetail financeDetail, string ID_PM, decimal diference)
        {
            consults.Update_Finance_Detail(financeDetail, ID_PM, diference);
        }
        #endregion

        #region Payment Method
        public List<PaymentMethod> Select_Payment_Methods()
        {
            return consults.Select_Payment_Methods();
        }
        public void Update_Payment_Method(PaymentMethod paymentMethod, string ID_FD, decimal diference)
        {
            consults.Update_Payment_Method(paymentMethod, ID_FD, diference);
        }
        #endregion

        #region Orders
        public List<Order> Select_Orders()
        {
            return consults.Select_Orders();
        }
        public Order Select_Orders(string ID_O)
        {
            return consults.Select_Orders(ID_O);
        }
        public void Insert_Order(Order order, List<OrderDetail> orderDetails)
        {
            consults.Insert_Order(order, orderDetails);
        }
        public void Update_Order_Status(string ID_O, string Status)
        {
            consults.Update_Order_Status(ID_O, Status);
        }
        public void Delete_Order(Order order)
        {
            consults.Delete_Order(order);
        }
        #endregion

        #region Order Details
        public List<OrderDetail> Select_Order_Details(string ID_O)
        {
            return consults.Select_Order_Details(ID_O);
        }
        public List<ProductQty> Select_Order_Detail_Products(string ID_O)
        {
            return consults.Select_Order_Detail_Products(ID_O);
        }
        #endregion

        #region Other
        public decimal Obtain_Balance(string ID)
        {
            return consults.Obtain_Balance(ID);
        }
        public DataTable SalesPerProduct()
        {
            return consults.SalesPerProduct();
        }
        public DataTable SalesPerYear()
        {
            return consults.SalesPerYear();
        }
        public DataTable SalesPerMonth(int Year)
        {
            return consults.SalesPerMonth(Year);
        }
        public DataTable SalesPerDay(int Year, int Month)
        {
            return consults.SalesPerDay(Year, Month);
        }
        public DataTable EarningsPerYear()
        {
            return consults.EarningsPerYear();
        }
        public DataTable ExpensesPerYear()
        {
            return consults.ExpensesPerYear();
        }
        public DataTable EarningsPerMonth(int Year)
        {
            return consults.EarningsPerMonth(Year);
        }
        public DataTable ExpensesPerMonth(int Year)
        {
            return consults.ExpensesPerMonth(Year);
        }
        public DataTable EarningsPerDay(int Year, int Month)
        {
            return consults.EarningsPerDay(Year, Month);
        }
        public DataTable ExpensesPerDay(int Year, int Month)
        {
            return consults.ExpensesPerDay(Year, Month);
        }
        #endregion
    }
}

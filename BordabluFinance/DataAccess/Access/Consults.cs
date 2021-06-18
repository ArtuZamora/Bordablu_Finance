﻿using Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Access
{
    public class Consults : Connection
    {
        SqlDataReader reader = null;

        #region Products
        public List<Product> Select_Products()
        {
            List<Product> products = new List<Product>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Products";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new Product(reader.GetString(0), reader.GetString(1)));
                    }
                    return products;
                }
            }
        }
        public void Insert_Products(Product product)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Products VALUES(@ID_P, @Name)";
                    command.Parameters.Add("@ID_P", SqlDbType.NChar).Value = product.ID_P;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update_Products(Product product)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Products SET Name = @Name WHERE ID_P = @ID_P";
                    command.Parameters.Add("@ID_P", SqlDbType.NChar).Value = product.ID_P;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = product.Name;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete_Products(string ID_P)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Products WHERE ID_P = @ID_P";
                    command.Parameters.Add("@ID_P", SqlDbType.NChar).Value = ID_P;
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Specifications
        public List<Specification> Select_Specifications(string ID_P)
        {
            List<Specification> specifications = new List<Specification>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT ID_S, ID_P, Property, Data_Type" +
                        " FROM Specifications WHERE ID_P = @ID_P";
                    command.Parameters.Add("@ID_P", SqlDbType.NChar).Value = ID_P;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specifications.Add
                            (new Specification(reader.GetString(0), reader.GetString(1),
                            reader.GetString(2), reader.GetString(3)));
                    }
                    return specifications;
                }
            }
        }
        public void Insert_Specification(Specification specification)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Specifications " +
                        "VALUES(@ID_S, @Property, @ID_P, @Data_Type)";
                    command.Parameters.Add("@ID_S", SqlDbType.NChar).Value = specification.ID_S;
                    command.Parameters.Add("@Property", SqlDbType.VarChar).Value = specification.Property;
                    command.Parameters.Add("@ID_P", SqlDbType.NChar).Value = specification.ID_P;
                    command.Parameters.Add("@Data_Type", SqlDbType.VarChar).Value = specification.Data_Type;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update_Specification(Specification specification)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Specifications SET Property = @Property, " +
                        "Data_Type = @Data_Type WHERE ID_S = @ID_S";
                    command.Parameters.Add("@ID_S", SqlDbType.NChar).Value = specification.ID_S;
                    command.Parameters.Add("@Property", SqlDbType.VarChar).Value = specification.Property;
                    command.Parameters.Add("@Data_Type", SqlDbType.VarChar).Value = specification.Data_Type;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete_Specification(string ID_S)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Specifications WHERE ID_S = @ID_S";
                    command.Parameters.Add("@ID_S", SqlDbType.NChar).Value = ID_S;
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Raw Material
        public List<RawMaterial> Select_Raw_Material()
        {
            List<RawMaterial> rawMaterials = new List<RawMaterial>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Raw_Material";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        rawMaterials.Add
                            (new RawMaterial(reader.GetString(0), reader.GetString(1),
                            reader.GetInt32(2), reader.GetDecimal(3),
                            reader.GetString(4), reader.GetString(5)));
                    }
                    return rawMaterials;
                }
            }
        }
        public void Insert_Raw_Material(RawMaterial rawMaterial)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Raw_Material " +
                        "VALUES(@ID_RM, @Name, @Stock, @Cost, @Supplier, @Description)";
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = rawMaterial.ID_RM;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = rawMaterial.Name;
                    command.Parameters.Add("@Stock", SqlDbType.Int).Value = rawMaterial.Stock;
                    command.Parameters.Add("@Cost", SqlDbType.Money).Value = rawMaterial.Cost;
                    command.Parameters.Add("@Supplier", SqlDbType.VarChar).Value = rawMaterial.Supplier;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = rawMaterial.Description;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update_Raw_Material(RawMaterial rawMaterial)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Raw_Material SET Name = @Name, " +
                        "Stock = @Stock, Cost = @Cost, Supplier = @Supplier," +
                        "Description = @Description WHERE ID_RM = @ID_RM";
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = rawMaterial.ID_RM;
                    command.Parameters.Add("@Name", SqlDbType.VarChar).Value = rawMaterial.Name;
                    command.Parameters.Add("@Stock", SqlDbType.Int).Value = rawMaterial.Stock;
                    command.Parameters.Add("@Cost", SqlDbType.Money).Value = rawMaterial.Cost;
                    command.Parameters.Add("@Supplier", SqlDbType.VarChar).Value = rawMaterial.Supplier;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = rawMaterial.Description;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete_Raw_Material(string ID_RM)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Raw_Material WHERE ID_RM = @ID_RM";
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = ID_RM;
                    command.ExecuteNonQuery();
                }
            }
        }
        public decimal Get_Raw_Material_Price(string ID_RM)
        {
            decimal price = 0;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Cost FROM Raw_Material WHERE ID_RM = @ID_RM";
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = ID_RM;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        price = reader.GetDecimal(0);
                    }
                    return price;
                }
            }
        }
        #endregion

        #region Expenses
        public DataTable Select_Expenses()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    DataTable expense = new DataTable();
                    command.Connection = connection;
                    command.CommandText = "SELECT E.ID_E, E.Purchase_Date, E.Amount, E.Quantity, " +
                        "RM.ID_RM, RM.Name, RM.Supplier FROM Expenses E " +
                        "INNER JOIN Raw_Material RM ON RM.ID_RM = E.ID_RM " +
                        "ORDER BY Purchase_Date DESC";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(expense);
                    return expense;
                }
            }
        }
        public void Insert_Expenses(Expense expense)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Expenses " +
                        "VALUES(@ID_E, @Purchase_Date, @Amount, @Quantity, @ID_RM)";
                    command.Parameters.Add("@ID_E", SqlDbType.NChar).Value = expense.ID_E;
                    command.Parameters.Add("@Purchase_Date", SqlDbType.Date).Value = expense.Purchase_Date;
                    command.Parameters.Add("@Amount", SqlDbType.Money).Value = expense.Amount;
                    command.Parameters.Add("@Quantity", SqlDbType.Int).Value = expense.Quantity;
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = expense.rawMaterial.ID_RM;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update_Expenses(Expense expenseAfter, Expense expenseBefore)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Expenses SET Purchase_Date = @Purchase_Date, " +
                        "Amount = @Amount, Quantity = @Quantity, ID_RM = @ID_RM WHERE ID_E = @ID_E";
                    command.Parameters.Add("@ID_E", SqlDbType.NChar).Value = expenseAfter.ID_E;
                    command.Parameters.Add("@Purchase_Date", SqlDbType.Date).Value = expenseAfter.Purchase_Date;
                    command.Parameters.Add("@Amount", SqlDbType.Money).Value = expenseAfter.Amount;
                    command.Parameters.Add("@Quantity", SqlDbType.Int).Value = expenseAfter.Quantity;
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = expenseAfter.rawMaterial.ID_RM;
                    command.ExecuteNonQuery();
                }
            }
            UpdateBy_Expenses(expenseAfter, expenseBefore);
        }
        public void Delete_Expenses(Expense expense)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Expenses WHERE ID_E = @ID_E";
                    command.Parameters.Add("@ID_E", SqlDbType.NChar).Value = expense.ID_E;
                    command.ExecuteNonQuery();
                }
            }
            DeleteBy_Expenses(expense);
        }
        public void UpdateBy_Expenses(Expense expenseAfter, Expense expenseBefore)
        {
            int newStock = expenseBefore.Quantity - expenseAfter.Quantity;
            decimal balance = expenseAfter.Amount - expenseBefore.Amount;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Raw_Material SET Stock -= @Stock WHERE ID_RM = @ID_RM";
                    command.Parameters.Add("@Stock", SqlDbType.Int).Value = newStock;
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = expenseBefore.rawMaterial.ID_RM;
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE Finance_Details SET Balance -= @Balance WHERE ID_FD = 'FD001'";
                    command.Parameters.Add("@Balance", SqlDbType.Decimal).Value = balance;
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE Payment_Methods SET Balance -= @Balance WHERE ID_PM = 'PM01'";
                    command.Parameters.Add("@Balance", SqlDbType.Decimal).Value = balance;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteBy_Expenses(Expense expense)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Raw_Material SET Stock -= @Stock WHERE ID_RM = @ID_RM";
                    command.Parameters.Add("@Stock", SqlDbType.Int).Value = expense.Quantity;
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = expense.rawMaterial.ID_RM;
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE Finance_Details SET Balance -= @Balance WHERE ID_FD = 'FD001'";
                    command.Parameters.Add("@Balance", SqlDbType.Decimal).Value = expense.Amount;
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE Payment_Methods SET Balance -= @Balance WHERE ID_PM = 'PM01'";
                    command.Parameters.Add("@Balance", SqlDbType.Decimal).Value = expense.Amount;
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Finance Details

        public List<FinanceDetail> Select_Finance_Details()
        {
            List<FinanceDetail> financeDetails = new List<FinanceDetail>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Finance_Details";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        financeDetails.Add(
                            new FinanceDetail(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2)));
                    }
                    return financeDetails;
                }
            }
        }
        public void Update_Finance_Detail(FinanceDetail financeDetail)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Finance_Details SET " +
                        "Balance = @Balance WHERE ID_FD = @ID_FD";
                    command.Parameters.Add("@ID_FD", SqlDbType.NChar).Value = financeDetail.ID_FD;
                    command.Parameters.Add("@Balance", SqlDbType.VarChar).Value = financeDetail.Balance;
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Payment Method
        public List<PaymentMethod> Select_Payment_Methods()
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Payment_Methods";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        paymentMethods.Add(
                            new PaymentMethod(reader.GetString(0), reader.GetString(1), reader.GetDecimal(2)));
                    }
                    return paymentMethods;
                }
            }
        }
        public void Update_Payment_Method(PaymentMethod paymentMethod)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Payment_Methods SET " +
                        "Balance = @Balance WHERE ID_PM = @ID_PM";
                    command.Parameters.Add("@ID_PM", SqlDbType.NChar).Value = paymentMethod.ID_PM;
                    command.Parameters.Add("@Balance", SqlDbType.VarChar).Value = paymentMethod.Balance;
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Orders
        public List<Order> Select_Orders()
        {
            List<Order> orders = new List<Order>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT ID_O, Order_Date, Delivery_Date, " +
                        "Client, Total_Amount, Status, Earned_Amount, Help, ID_PM," +
                        "Total_Amount FROM Orders";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.ID_O = reader.GetString(0);
                        order.Order_Date = reader.GetDateTime(1);
                        order.Delivery_Date = reader.GetDateTime(2);
                        order.Client = reader.GetString(3);
                        order.Total_Amount = reader.GetDecimal(4);
                        order.Status = reader.GetString(5);
                        order.Earned_Amount = reader.GetDecimal(6);
                        order.Help = reader.GetBoolean(7);
                        order.ID_PM = reader.GetString(8);
                        order.Total_Amount = reader.GetDecimal(9);
                        orders.Add(order);
                    }
                    return orders;
                }
            }
        }
        public Order Select_Orders(string ID_O)
        {
            Order order = new Order();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Orders WHERE ID_O = @ID_O";
                    command.Parameters.Add("@ID_O", SqlDbType.NChar).Value = ID_O;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        order.ID_O = reader.GetString(0);
                        order.Order_Date = reader.GetDateTime(1);
                        order.Delivery_Date = reader.GetDateTime(2);
                        order.Client = reader.GetString(3);
                        order.Order_Amount = reader.GetDecimal(4);
                        order.Delivery_Amount = reader.GetDecimal(5);
                        order.Labor_Amount = reader.GetDecimal(6);
                        order.Total_Amount = reader.GetDecimal(7);
                        order.Earned_Amount = reader.GetDecimal(8);
                        order.ID_PM = reader.GetString(9);
                        order.Description = reader.GetString(10);
                        order.Status = reader.GetString(11);
                        order.Help = reader.GetBoolean(12);
                    }
                    return order;
                }
            }
        }
        public void Insert_Order(Order order, List<OrderDetail> orderDetails)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Orders VALUES(@ID_O, @Order_Date, @Delivery_Date, @Client," +
                        "@Order_Amount, @Delivery_Amount, @Labor_Amount, @Total_Amount, @Earned_Amount, @ID_PM," +
                        "@Description, @Status, @Help)";
                    command.Parameters.Add("@ID_O", SqlDbType.NChar).Value = order.ID_O;
                    command.Parameters.Add("@Order_Date", SqlDbType.Date).Value = order.Order_Date;
                    command.Parameters.Add("@Delivery_Date", SqlDbType.Date).Value = order.Delivery_Date;
                    command.Parameters.Add("@Client", SqlDbType.VarChar).Value = order.Client;
                    command.Parameters.Add("@Order_Amount", SqlDbType.Money).Value = order.Order_Amount;
                    command.Parameters.Add("@Delivery_Amount", SqlDbType.Money).Value = order.Delivery_Amount;
                    command.Parameters.Add("@Labor_Amount", SqlDbType.Money).Value = order.Labor_Amount;
                    command.Parameters.Add("@Total_Amount", SqlDbType.Money).Value = order.Total_Amount;
                    command.Parameters.Add("@Earned_Amount", SqlDbType.Money).Value = order.Earned_Amount;
                    command.Parameters.Add("@ID_PM", SqlDbType.NChar).Value = order.ID_PM;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = order.Description;
                    command.Parameters.Add("@Status", SqlDbType.NChar).Value = order.Status;
                    command.Parameters.Add("@Help", SqlDbType.Bit).Value = order.Help;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                    string ID_O = "";
                    command.CommandText = "SELECT TOP 1 ID_O FROM Orders ORDER BY ID_O DESC";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ID_O = reader.GetString(0);
                    }
                    reader.Close();

                    foreach (OrderDetail orderDetail in orderDetails)
                    {
                        command.CommandText = "INSERT INTO Order_Details VALUES(@ID_OD," +
                            " @ID_O, @ID_S, @ID_P, @Detail)";
                        command.Parameters.Add("@ID_OD", SqlDbType.NChar).Value = orderDetail.ID_OD;
                        command.Parameters.Add("@ID_O", SqlDbType.NChar).Value = ID_O;
                        command.Parameters.Add("@ID_S", SqlDbType.NChar).Value = orderDetail.ID_S;
                        command.Parameters.Add("@ID_P", SqlDbType.NChar).Value = orderDetail.ID_P;
                        command.Parameters.Add("@Detail", SqlDbType.VarChar).Value = orderDetail.Detail;
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                }
            }
        }
        public void Update_Order_Status(string ID_O, string Status)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Orders SET Status = @Status WHERE ID_O = @ID_O";
                    command.Parameters.Add("@ID_O", SqlDbType.NChar).Value = ID_O;
                    command.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete_Order(Order order)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Orders WHERE ID_O = @ID_O";
                    command.Parameters.Add("@ID_O", SqlDbType.NChar).Value = order.ID_O;
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Order Details
        public List<OrderDetail> Select_Order_Details(string ID_O)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Order_Details WHERE ID_O = @ID_O";
                    command.Parameters.Add("@ID_O", SqlDbType.NChar).Value = ID_O;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.ID_OD = reader.GetString(0);
                        orderDetail.ID_O = reader.GetString(1);
                        orderDetail.ID_S = reader.GetString(2);
                        orderDetail.ID_P = reader.GetString(3);
                        orderDetail.Detail = reader.GetString(4);
                        orderDetails.Add(orderDetail);
                    }
                    return orderDetails;
                }
            }
        }
        public List<Product> Select_Order_Detail_Products(string ID_O)
        {
            List<Product> products = new List<Product>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT DISTINCT OD.ID_P, P.Name " +
                        "FROM Order_Details OD INNER JOIN Products P ON P.ID_P = OD.ID_P " +
                        "WHERE ID_O = @ID_O";
                    command.Parameters.Add("@ID_O", SqlDbType.NChar).Value = ID_O;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product(reader.GetString(0), reader.GetString(1));
                        products.Add(product);
                    }
                    return products;
                }
            }
        }
        #endregion
    }
}

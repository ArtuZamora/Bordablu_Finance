using Common.Model;
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
        public List<Expense> Select_Expenses()
        {
            List<Expense> expenses = new List<Expense>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT E.ID_E, E.Purchase_Date, E.Amount, E.Quantity, " +
                        "RM.ID_RM, RM.Name FROM Expenses E " +
                        "INNER JOIN Raw_Material RM ON RM.ID_RM = E.ID_RM " +
                        "ORDER BY Purchase_Date DESC";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Expense expenseCur = new Expense(reader.GetString(0), reader.GetDateTime(1),
                            reader.GetDecimal(2), reader.GetInt32(3), reader.GetString(4));
                        expenseCur.Name = reader.GetString(5);
                        expenses.Add(expenseCur);
                    }
                    return expenses;
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
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = expense.ID_RM;
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
                    command.Parameters.Add("@ID_RM", SqlDbType.NChar).Value = expenseAfter.ID_RM;
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
            decimal price = Get_Raw_Material_Price(expenseBefore.ID_RM);
            decimal balance = 
                price * expenseBefore.Quantity - price * expenseAfter.Quantity;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Raw_Material SET Stock -= @Stock";
                    command.Parameters.Add("@Stock", SqlDbType.Int).Value = newStock;
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE Finance_Details SET Balance -= @Balance";
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
                    command.CommandText = "UPDATE Raw_Material SET Stock -= @Stock";
                    command.Parameters.Add("@Stock", SqlDbType.Int).Value = expense.Quantity;
                    command.ExecuteNonQuery();
                    command.CommandText = "UPDATE Finance_Details SET Balance -= @Balance";
                    command.Parameters.Add("@Balance", SqlDbType.Decimal).Value = expense.Amount;
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}

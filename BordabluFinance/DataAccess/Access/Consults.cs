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
    }
}

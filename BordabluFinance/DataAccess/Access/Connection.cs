using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Access
{
    public abstract class Connection
    {
        private readonly string conectionString;
        public Connection()
        {
            conectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Bordablu;Integrated Security=True;";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(conectionString);
        }
    }
}

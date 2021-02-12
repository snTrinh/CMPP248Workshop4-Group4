using System.Collections.Generic;
using System.Data.SqlClient;
/*
 * Connection Class for SuppliersDB
 * Created by Chester Solang on January 26, 2021
 */
namespace SuppliersData
{
    public static class SuppliersDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public static List<Suppliers> GetSuppliers()
        {
            List<Suppliers> suppliers = new List<Suppliers>();
            Suppliers sup;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT SupplierId, SupName" +
                               "FROM Suppliers ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            sup = new Suppliers();
                            sup.SupplierId = (int)dr["SupplierId"];
                            sup.SupName = (char)dr["SupName"];
                        }
                    }
                }
            }
            return suppliers;
        }
    }//class
}//namespace

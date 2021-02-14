using System;
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
                string query = "SELECT SupplierId, SupName " +
                               "FROM Suppliers ORDER BY SupName Asc";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            sup = new Suppliers();
                            sup.SupplierId = (int)dr["SupplierId"];
                            sup.SupName = (string)dr["SupName"];
                            suppliers.Add(sup);
                        }
                    }
                }
            }
            return suppliers;
        }

        /// <summary>
        /// This method returns a supplier given the supplier ID
        /// This method was created by Susan Trinh on February 2, 2021
        /// </summary>
        /// <returns>list of suppliers</returns>
        public static List<Suppliers> GetSuppliersById(int supplierID)
        {
            List<Suppliers> suppliers = new List<Suppliers>();
            Suppliers sup;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT SupplierId, SupName " +
                               "FROM Suppliers ORDER BY SupName ASC " +
                               "WHERE SupplierId = @SupplierId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SuplierId", supplierID);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            sup = new Suppliers();
                            sup.SupplierId = (int)dr["SupplierId"];
                            sup.SupName = (string)dr["SupName"];
                            suppliers.Add(sup);
                        }
                    }
                }
            }
            return suppliers;
        }

        /// <summary>
        /// This method updates the supplier
        /// This method was created by Susan Trinh on February 2, 2021
        /// </summary>
        /// <param name="oldSup">old supplier</param>
        /// <param name="newSup">new supplier</param>
        /// <returns></returns>
        public static bool UpdateSelectedSupplier(Suppliers oldSup, Suppliers newSup)
        {
            bool result = false; //assumes that update is not successful
            using (SqlConnection connection = GetConnection())
            {
                string query = "UPDATE Suppliers SET SupName = @NewSupName WHERE SupplierId = @OldSupplierId ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@NewSupName", newSup.SupName);
                    cmd.Parameters.AddWithValue("@OldSupplierId", oldSup.SupplierId);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery(); //execute update 
                    if (count > 0)
                        result = true;
                }
            }
            return result;
        }


        /// <summary>
        /// Adds another supplier record to database
        /// This method was created by Susan Trinh on February 4, 2021
        /// </summary>
        /// <param name="supplier">object with new supplier data</param>
        /// <returns>generated ID for the new supplier record</returns>
        public static bool AddSupplier(Suppliers supplier)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                string insertStatement = "INSERT INTO Suppliers (SupplierId, SupName) " +
                                         //"OUTPUT INSERTED.SupplierId " + // returns single value
                                         "VALUES(@SupplierId, @SupName)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                    cmd.Parameters.AddWithValue("@SupName", supplier.SupName);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery(); //execute update 
                    if (count > 0)
                        result = true;

                }
            }
            return result;
        }

        /// <summary>
        /// Deleted supplier record
        /// This method was created by Susan Trinh on February 4, 2021
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(Suppliers supplier)
        {
            bool result = true;
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Suppliers WHERE SupplierId = @SupplierId AND SupName = @SupName";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                    cmd.Parameters.AddWithValue("@SupName", supplier.SupName);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                        return false;
                }
                return result;
            }
        }

        /// <summary>
        /// Checks if the supplier ID exists
        /// This method was created by Susan Trinh on February 13, 2021
        /// </summary>
        /// <param name="supplierId">supplier ID</param>
        /// <returns></returns>
        public static bool SupplierExists(int supplierId)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                string query = "Select SupplierId FROM Suppliers WHERE SupplierId = @SupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    connection.Open();
                    int? id = cmd.ExecuteNonQuery();
                    if (id != null)
                        return true;
                }
                return result;
            }
        }


        /// <summary>
        /// Checks to see if the supplier name exists
        /// This method was created by Susan Trinh on February 13, 2021
        /// </summary>
        /// <param name="supplierName">Supplier Name</param>
        /// <returns></returns>
        public static List<Suppliers> SupplierNameExists(string supplierName)
        {

            List<Suppliers> suppliers = new List<Suppliers>();
            Suppliers sup;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT SupName, SupplierId FROM Suppliers WHERE SupName = @SupName";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SupName", supplierName);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            sup = new Suppliers();
                            sup.SupplierId = (int)dr["SupplierId"];
                            sup.SupName = (string)dr["SupName"];
                            suppliers.Add(sup);
                        }
                    }
                }
            }
            return suppliers;
        }

    }//class
}//namespace

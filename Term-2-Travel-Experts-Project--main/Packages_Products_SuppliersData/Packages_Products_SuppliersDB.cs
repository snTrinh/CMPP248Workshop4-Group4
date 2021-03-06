﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Packages_Products_SuppliersData
{
    public static class Packages_Products_SuppliersDB
    {
        //connection string to our databse
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog = TravelExperts; Integrated Security = True";
            return new SqlConnection(connectionString);
        }
        
        /// <summary>
        /// Add new data to Packages_Products_Suppliers table in DB
        /// </summary>
        /// <param name="pkgProdSup">package product supplier object </param>
        /// <returns>true or false to indicate success or unsuccessful add</returns>
        public static bool AddPackageProductSupplier(Packages_Products_Suppliers pkgProdSup)
        {
            using (SqlConnection connection = GetConnection())
            {
                string insertStatement = "INSERT INTO Packages_Products_Suppliers (PackageId, ProductSupplierId) VALUES (@PackageId, @ProductSupplierId)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkgProdSup.PackageId);
                    cmd.Parameters.AddWithValue("@ProductSupplierId", pkgProdSup.ProductSupplerId);
                    connection.Open();
                    cmd.ExecuteScalar();
                    return true;
                }
            }
        }

        /// <summary>
        /// From Packages_Products_Supplier table, retrieve the ProductSupplierId
        /// </summary>
        /// <param name="packageID">package ID</param>
        /// <returns>a list of ProductSupplierId</returns>
        public static List<int> GetProductSupplierID(int packageID)
        {
            List<int> productSupplierID = new List<int>();
            using (SqlConnection connection = GetConnection())
            {
                string queryStatement = "SELECT ProductSupplierId FROM Packages_Products_Suppliers WHERE PackageId = @PackageId";
                using (SqlCommand cmd = new SqlCommand(queryStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", packageID);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        Packages_Products_Suppliers packProdSupp = new Packages_Products_Suppliers();
                        packProdSupp.ProductSupplerId = (int)dr["ProductSupplierId"];
                        productSupplierID.Add(packProdSupp.ProductSupplerId);
                    }
                }
            } return productSupplierID;
        }

        /// <summary>
        /// Deletes a package product supplier data in the database
        /// </summary>
        /// <param name="pkgProdSup">the object that will be deleted</param>
        /// <returns>true or false to indicate success or unsuccessful delete</returns>
        public static bool DeletePackProdSuppAssociation(Packages_Products_Suppliers pkgProdSup)
        {
            bool result = true;
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Packages_Products_Suppliers WHERE PackageId = @PackageId AND ProductSupplierId = @ProductSupplierId";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkgProdSup.PackageId);
                    cmd.Parameters.AddWithValue("@ProductSupplierId", pkgProdSup.ProductSupplerId);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                        return false;
                }
                return result;
            }

        }
    }
}

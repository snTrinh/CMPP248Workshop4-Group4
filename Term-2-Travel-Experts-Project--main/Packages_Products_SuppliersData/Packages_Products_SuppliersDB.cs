﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Packages_Products_SuppliersData
{
    public static class Packages_Products_SuppliersDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog = TravelExperts; Integrated Security = True";
            return new SqlConnection(connectionString);
        }
        public static List<Packages_Products_Suppliers> GetPackagesProductsSuppliersByID(int packageId, int productSupplierId)
        {
            List<Packages_Products_Suppliers> packProdSuppList = new List<Packages_Products_Suppliers>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT PackageId, ProductSupplierId From Packages_Products_Suppliers " +
                                "WHERE PackageId = @PackageId AND ProductSupplierId = @ProductSupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", packageId);
                    cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierId);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    if (dr.Read())
                    {
                        Packages_Products_Suppliers packProdSupp = new Packages_Products_Suppliers();
                        packProdSupp.PackageId = (int)dr["PackageId"];
                        packProdSupp.ProductSupplerId = (int)dr["ProductSupplierId"];
                        packProdSuppList.Add(packProdSupp);
                    }
                }
            }
            return packProdSuppList;

        }

        // testing
        public static List<Packages_Products_Suppliers> GetPackagesProductsSuppliers()
        {
            List<Packages_Products_Suppliers> packProdSuppList = new List<Packages_Products_Suppliers>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT PackageId, ProductSupplierId From Packages_Products_Suppliers ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Packages_Products_Suppliers packProdSupp = new Packages_Products_Suppliers();
                        packProdSupp.PackageId = (int)reader["PackageId"];
                        packProdSupp.ProductSupplerId = (int)reader["ProductSupplierId"];
                        packProdSuppList.Add(packProdSupp);
                    }
                }
            }
            return packProdSuppList;

        }

        //Created by Julie 
        //February 4
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

        //Created by Julie
        //gets ProductSupplierId, when given the packageID
        //Created on February 14 2021
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
                    if (dr.Read())
                    {
                        Packages_Products_Suppliers packProdSupp = new Packages_Products_Suppliers();
                        packProdSupp.ProductSupplerId = (int)dr["ProductSupplierId"];
                        productSupplierID.Add(packProdSupp.ProductSupplerId);
                    }

                }
            } return productSupplierID;
        
        
        
        }
        ////Created by Julie
        ////Created on February 14 
        ////description: to delete 
        //public static bool DeletePackProdSupp(int packageID)
        //{
        //    bool result = true;
        //    using (SqlConnection connection = GetConnection())
        //    {
        //        string deleteStatement = "DELETE FROM Packages_Products_Suppliers WHERE PackageId = @PackageId";
        //        using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@PackageId", packageID);

        //            connection.Open();
        //            int count = cmd.ExecuteNonQuery();
        //            if (count == 0)
        //                return false;

        //        }
        //        return result;
        //    }

        //}
        //Created by Julie 
        //Created on February 4 2021
        //Modified on February 14 2021, to allow reuse of sql delete statement
        public static bool DeletePackProdSuppAssociation(Packages_Products_Suppliers pkgProdSupp)
        {
            bool result = true;
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Packages_Products_Suppliers WHERE PackageId = @PackageId AND ProductSupplierId = @ProductSupplierId";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkgProdSupp.PackageId);
                    cmd.Parameters.AddWithValue("@PackageId", pkgProdSupp.ProductSupplerId);

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

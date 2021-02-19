using System.Collections.Generic;
using System.Data.SqlClient;

namespace Products_SuppliersData
{
    /*
     * Connection class for Product_Supplier 
     * Created by Julie  on January 26, 2021
     */
    public static class Products_SuppliersDB
    {
        // connection to datatbase 
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog = TravelExperts; Integrated Security = True";
            return new SqlConnection(connectionString);
        }

        public static List<SuppliersTypeOfProducts> GetSuppliersTypeOfProductsByID(int supplierID)
        {
            List<SuppliersTypeOfProducts> productNumSuppliersList = new List<SuppliersTypeOfProducts>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT Suppliers.SupplierId, SupName, ProdName FROM " +
                    "Products_Suppliers JOIN Products on Products_Suppliers.ProductId = Products.ProductId " +
                    "JOIN Suppliers On Products_Suppliers.SupplierId = Suppliers.SupplierId " +
                    "WHERE Suppliers.SupplierId = @SupplierId ORDER BY Suppliers.SupplierId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierID);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            SuppliersTypeOfProducts prodNumSupplier = new SuppliersTypeOfProducts();
                            prodNumSupplier.SupplierId = (int)dr["SupplierId"];
                            prodNumSupplier.SupName = (string)dr["SupName"];
                            prodNumSupplier.ProdName = (string)dr["ProdName"];
                            productNumSuppliersList.Add(prodNumSupplier);
                        }
                    }
                }
            }
            return productNumSuppliersList;
        }

        //For packages
        //Shows products and suppliers that are checkoff/associated to package.
        //code by Julie Tran: January 30 2021
        public static List<ProductSupplierAll> GetProductSupplierName(int packageID)
        {
            List<ProductSupplierAll> prodSupNameList = new List<ProductSupplierAll>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProdName, SupName, Suppliers.SupplierId, Products.ProductId, Products_Suppliers.ProductSupplierId " +
                                "FROM Packages " +
                                "JOIN Packages_Products_Suppliers on Packages.PackageId = Packages_Products_Suppliers.PackageId " +
                                "JOIN Products_Suppliers on Packages_Products_Suppliers.ProductSupplierId = Products_Suppliers.ProductSupplierId " +
                                "JOIN Suppliers on Suppliers.SupplierId = Products_Suppliers.SupplierId " +
                                "JOIN Products on Products.ProductId = Products_Suppliers.ProductId " +
                                "WHERE Packages.PackageId = @PackageId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", packageID);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            ProductSupplierAll prodSupName = new ProductSupplierAll();
                            prodSupName.SupplierId = (int)dr["SupplierId"];
                            prodSupName.ProductId = (int)dr["ProductId"];
                            prodSupName.SupName = (string)dr["SupName"];
                            prodSupName.ProdName = (string)dr["ProdName"];
                            prodSupName.ProductSupplierId = (int)dr["ProductSupplierId"];
                            prodSupNameList.Add(prodSupName);
                        }
                    }
                }
            }
            return prodSupNameList;
        }
        //Selects all ProductSupplierID that is not associated to current Package.
        //Created by Julie Tran
        //Create on Feb 16, modified on February 4 and 16 2021 
        //sql written by Susan,
        public static List<int> GetDistinctProdSupID(int packageID)
        {
            List<int> distinctProdSuppIDList = new List<int>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT DISTINCT Products_Suppliers.ProductSupplierId " +
                               "FROM Suppliers " +
                               "JOIN Products_Suppliers ON Suppliers.SupplierId = Products_Suppliers.SupplierId " +
                               "LEFT JOIN Packages_Products_Suppliers ON Products_Suppliers.ProductSupplierId = Packages_Products_Suppliers.ProductSupplierId " +
                               "JOIN Products ON Products.ProductId = Products_Suppliers.ProductId " +
                               "WHERE PackageId != @PackageId OR PackageId IS NULL " +
                               "ORDER BY ProductSupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", packageID);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            int ProductSupplierId = (int)dr["ProductSupplierId"];
                            distinctProdSuppIDList.Add(ProductSupplierId);
                        }
                    }
                }
            }
            return distinctProdSuppIDList;
        }

        //Created by Julie Tran
        //shows all products and suppliers that are not already associated to package 
        //Also, if users have already chosen the specific package, it will not display
        public static List<ProductSupplierAll>GetFilteredProductSupplier(string productName)
        {
            List<ProductSupplierAll> prodSupNameList = new List<ProductSupplierAll>();
            ProductSupplierAll prodSupName;
            using (SqlConnection connection = GetConnection())
            {
                string query = " SELECT ProdName, SupName " +
                               "FROM Suppliers " +
                               "JOIN Products_Suppliers ON Suppliers.SupplierId = Products_Suppliers.SupplierId " +
                               "JOIN Products ON Products.ProductId = Products_Suppliers.ProductId " +
                               "LEFT JOIN Packages_Products_Suppliers On Packages_Products_Suppliers.ProductSupplierId = Products_Suppliers.ProductSupplierId "+
                               "WHERE PackageId IS NULL AND ProdName= @ProdName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProdName", productName) ;
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            prodSupName = new ProductSupplierAll();
                            prodSupName.ProdName = (string)dr["ProdName"];
                            prodSupName.SupName = (string)dr["SupName"];
                            prodSupNameList.Add(prodSupName);

                        }
                    }
                }
            }
            return prodSupNameList;
        }

        //Shows all products and suppliers, that are not already checked off
        //Created by Julie Tran
        //modified on February 16 

        public static ProductSupplierAll GetProductSupplierByID(int productSupplierID)
        {
            ProductSupplierAll prodSupName = new ProductSupplierAll();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProdName, SupName " +
                                "FROM Suppliers " +
                                "JOIN Products_Suppliers ON Suppliers.SupplierId = Products_Suppliers.SupplierId " +
                                "JOIN Products ON Products.ProductId = Products_Suppliers.ProductId " +
                                "WHERE ProductSupplierId = @ProductSupplierID ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductSupplierID", productSupplierID);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            
                            prodSupName.ProdName = (string)dr["ProdName"];
                            prodSupName.SupName = (string)dr["SupName"];
                            
                        }
                    }
                }
            }
            return prodSupName;
        }

        

        /// <summary>
        /// Adds another supplier product record to database
        /// </summary>
        /// <param name="prod">object with new product data</param>
        /// <returns>generated ID for the new product record</returns>
        public static bool AddSupplierProductID(int ProdId, int SupplierID)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                string insertStatement = "Insert INTO Products_Suppliers " +
                                         "VALUES (@ProductId, @SupplierId)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", ProdId);
                    cmd.Parameters.AddWithValue("@SupplierId", SupplierID);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery(); //execute update 
                    if (count > 0)
                        result = true;
                }
            }
            return result;
        }

        //for packages 
        //shows all products and suppliers 
        //created by Julie Tran 
        // Created on February 4 2021
        public static List<ProductSupplierAll> GetAllProductSupplierName()
        {
            List<ProductSupplierAll> prodSupNameList = new List<ProductSupplierAll>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProdName, SupName, Suppliers.SupplierId, Products.ProductId, Products_Suppliers.ProductSupplierId " +
                               "FROM Products " +
                               "JOIN Products_Suppliers ON Products.ProductId = Products_Suppliers.ProductId " +
                               "JOIN Suppliers ON Suppliers.SupplierId = Products_Suppliers.SupplierId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            ProductSupplierAll prodSupName = new ProductSupplierAll();
                            prodSupName.SupplierId = (int)dr["SupplierId"];
                            prodSupName.ProductId = (int)dr["ProductId"];
                            prodSupName.SupName = (string)dr["SupName"];
                            prodSupName.ProdName = (string)dr["ProdName"];
                            prodSupName.ProductSupplierId = (int)dr["ProductSupplierId"];
                            prodSupNameList.Add(prodSupName);
                        }
                    }
                }
            }
            return prodSupNameList;
        }

        // this code should implement when modifying product suppliers
        
        public static bool DeleteProductSupplier(int productId, int supplierId)
        {
            bool result = true;
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Products_Suppliers WHERE ProductId = @ProductId AND SupplierId = @SupplierId";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                        return false;

                }
                return result;
            }

        }

        /// <summary>
        /// returns a list of Products_Suppliers with given parameters
        /// This method was created by Susan Trinh on February 13, 2021
        /// </summary>
        /// <param name="productId">ProductId</param>
        /// <param name="supplierId">SupplierId</param>
        /// <returns>List of Products_Suppliers</returns>
        public static List<Products_Suppliers> ProductSupplierExist(int productId, int supplierId)
        {
            List<Products_Suppliers> suppliers = new List<Products_Suppliers>();
            Products_Suppliers sup;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT SupplierId, ProductId " +
                               "FROM Products_Suppliers " +
                               "WHERE ProductId = @ProductId AND SupplierId = @SupplierId";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            sup = new Products_Suppliers();
                            sup.SupplierId = (int)dr["SupplierId"];
                            sup.ProductId = (int)dr["ProductId"];
                            suppliers.Add(sup);
                        }
                    }
                }
            }
            return suppliers;
        }

        /// <summary>
        /// For when a supplier is deleted and has a corresponding ProductSupplierID
        /// The data here for the supplier is also deleted
        /// This method was created by Susan Trinh on February 13, 2021
        /// </summary>
        /// <param name="supplierId">supplier id</param>
        public static void DeleteProductSupplierBySupplierId(int supplierId)
        {
            //bool result = true;
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Products_Suppliers WHERE SupplierId = @SupplierId";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    //if (count == 0)
                        //return false;

                }
                //return result;
            }

        }

        /// <summary>
        /// For when a proiduct is deleted and has a corresponding ProductSupplierID
        /// The data here for the product is also deleted
        /// </summary>
        /// <param name="productId">supplier id</param>
        public static void DeleteProductSupplierByProductId(int productId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Products_Suppliers WHERE ProductId = @ProductId";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                }

            }

        }





        /// <summary>
        /// checks to see if product supplier data exists using supplier ID
        /// </summary>
        /// <param name="supplierId">supplier ID</param>
        /// <returns></returns>
        public static bool IfProductSuppliersExistsBySupplierId(int supplierId)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                string query = "Select SupplierId FROM Products_Suppliers WHERE SupplierId = @SupplierId";
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
        /// checks to see if product supplier data exists using productID
        /// </summary>
        /// <param name="productId">product ID</param>
        /// <returns></returns>
        public static bool IfProductSuppliersExistsByProdID(int productId)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                string query = "Select ProductId FROM Products_Suppliers WHERE ProductId = @ProductId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    connection.Open();
                    int? id = cmd.ExecuteNonQuery();
                    if (id != null)
                        return true;
                }
                return result;
            }
        }

        //Created by Julie on February 16
        public static int GetProductSupplierID(string productName, string supplierName)
        {
            int prodSuppId = 0;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProductSupplierId " +
                               "FROM Products " +
                               "JOIN Products_Suppliers ON Products.ProductId = Products_Suppliers.ProductId " +
                               "JOIN Suppliers ON Suppliers.SupplierId = Products_Suppliers.SupplierId " +
                               "WHERE ProdName = @ProdName AND SupName = @SupName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProdName", productName);
                    cmd.Parameters.AddWithValue("@SupName", supplierName);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            prodSuppId = (int)dr["ProductSupplierId"];
                        }
                    }
                }
            }
            return prodSuppId;
        }

        //public static List<Products_Suppliers> Test(string productName, string supplierName)
        //{
        //    List<Products_Suppliers> testprodSupList = new List<Products_Suppliers>();
        //    Products_Suppliers testprodSup;
        //    using (SqlConnection connection = GetConnection())
        //    {
        //        string query = "SELECT ProductSupplierId, Products.ProductId, Suppliers.SupplierId " +
        //                       "FROM Products " +
        //                       "JOIN Products_Suppliers ON Products.ProductId = Products_Suppliers.ProductId " +
        //                       "JOIN Suppliers ON Suppliers.SupplierId = Products_Suppliers.SupplierId " +
        //                       "WHERE ProdName = @ProdName AND SupName = @SupName";

        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@ProdName", productName);
        //            cmd.Parameters.AddWithValue("@SupName", supplierName);
        //            connection.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
        //            {
        //                while (dr.Read())
        //                {
        //                    testprodSup = new Products_Suppliers();
        //                    testprodSup.ProductId = (int)dr["ProductId"];
        //                    testprodSup.SupplierId = (int)dr["SupplierId"];
        //                    testprodSup.ProductSupplierId = (int)dr["ProductSupplierId"];
        //                    testprodSupList.Add(testprodSup);
        //                }
        //            }
        //        }
        //    }
        //    return testprodSupList;
        //}



    }
}

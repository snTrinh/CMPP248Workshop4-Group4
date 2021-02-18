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
        //retrieving all data from ProductsSuppliers table, with two inputs (Foriegn key: productSupplierId and productId
        //public static List<Products_Suppliers> GetProducts_SuppliersByID(int productSupplierId, int productId)
        //{
        //    List<Products_Suppliers> productSuppliersList = new List<Products_Suppliers>();
        //    using (SqlConnection connection = GetConnection())
        //    {

        //        string query = "SELECT ProductSupplierId, ProductId, SupplierId " +
        //                       "FROM Products_Suppliers " +
        //                       "WHERE ProductSupplierId = @ProductSupplierId " +
        //                       "ProductId = @ProductId";

        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@ProductSupplierId", productSupplierId);
        //            cmd.Parameters.AddWithValue("@ProductId", productId);
        //            connection.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
        //            {
        //                while (dr.Read())
        //                {
        //                    Products_Suppliers prodSupplier = new Products_Suppliers();
        //                    prodSupplier.ProductSupplierId = (int)dr["ProductSupplierId"];
        //                    prodSupplier.ProductId = (int)dr["ProductId"];
        //                    prodSupplier.SupplierId = (int)dr["SupplierId"];

        //                    //add product detail to List 
        //                    productSuppliersList.Add(prodSupplier);
        //                }
        //            }


        //        }
        //    }
        //    return productSuppliersList;

        //}

        //public static List<Products_Suppliers> GetProducts_Suppliers()
        //{
        //    List<Products_Suppliers> productSuppliersList = new List<Products_Suppliers>();
        //    using (SqlConnection connection = GetConnection())
        //    {
        //        string query = "SELECT ProductSupplierId, ProductId, SupplierId " +
        //                       "FROM Products_Suppliers ";
        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            connection.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
        //            {
        //                while (dr.Read())
        //                {
        //                    Products_Suppliers prodSupplier = new Products_Suppliers();
        //                    prodSupplier.ProductSupplierId = (int)dr["ProductSupplierId"];
        //                    prodSupplier.ProductId = (int)dr["ProductId"];
        //                    prodSupplier.SupplierId = (int)dr["SupplierId"];
        //                    productSuppliersList.Add(prodSupplier);
        //                }
        //            }
        //        }
        //    }
        //    return productSuppliersList;
        //}

        // This is a display only list on Products tab
        // Displays Product ID, Product Name and Numebr of Supplierss
        // Coded by Susan Trinh: January 28, 2021
        //public static List<ProductsNumSuppliers> GetProductsNumSuppliers()
        //{
        //    List<ProductsNumSuppliers> productNumSuppliersList = new List<ProductsNumSuppliers>();
        //    using (SqlConnection connection = GetConnection())
        //    {
        //        string query = "SELECT Products_Suppliers.ProductID, ProdName, Count(Products_Suppliers.ProductID) as NumOfSup " +
        //            "FROM Products_Suppliers JOIN Products ON Products.ProductId = Products_Suppliers.ProductId " +
        //            "GROUP BY Products_Suppliers.ProductID, ProdName";

        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            connection.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
        //            {
        //                while (dr.Read())
        //                {
        //                    ProductsNumSuppliers prodNumSupplier = new ProductsNumSuppliers();
        //                    prodNumSupplier.ProductId = (int)dr["ProductId"];
        //                    prodNumSupplier.ProdName = (string)dr["ProdName"];
        //                    prodNumSupplier.NumOfSup = (int)dr["NumOfSup"];
        //                    productNumSuppliersList.Add(prodNumSupplier);
        //                }
        //            }
        //        }
        //    }
        //    return productNumSuppliersList;
        //}

        // This is a display only list
        // Displays Supplier ID, Supplier Name, and Number of Products Provided
        // Coded by Susan Trinh: February 2, 2021
        //public static List<SuppliersNumOfProducts> GetSuppliersNumOfProducts()
        //{
        //    List<SuppliersNumOfProducts> productNumSuppliersList = new List<SuppliersNumOfProducts>();
        //    using (SqlConnection connection = GetConnection())
        //    {
        //        string query =  "SELECT Products_Suppliers.SupplierId, SupName, " +
        //                        "COUNT(Products_Suppliers.SupplierId) AS [Number of Products Provided] " +
        //                        "FROM Products_Suppliers JOIN Suppliers ON Products_Suppliers.SupplierId = Suppliers.SupplierId " +
        //                        "GROUP BY Products_Suppliers.SupplierId, SupName " +
        //                        "ORDER BY SupName Asc";

        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            connection.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
        //            {
        //                while (dr.Read())
        //                {
        //                    SuppliersNumOfProducts supNumProds = new SuppliersNumOfProducts();
        //                    supNumProds.SupplierId = (int)dr["SupplierId"];
        //                    supNumProds.SupName = (string)dr["SupName"];
        //                    supNumProds.NumOfProd = (int)dr["Number of Products Provided"];
        //                    productNumSuppliersList.Add(supNumProds);
        //                }
        //            }
        //        }
        //    }
        //    return productNumSuppliersList;
        //}

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

        //public static bool AddSupplier(SuppliersProdId supplier)
        //{
        //    bool result = false;
        //    using (SqlConnection connection = GetConnection())
        //    {
        //        string query = "INSERT INTO Suppliers VALUES (@SupplierId, @SupName) INSERT INTO Products_Suppliers VALUES (@ProductId, @SupplierId)";
        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
        //            cmd.Parameters.AddWithValue("@SupName", supplier.SupName);
        //            cmd.Parameters.AddWithValue("@ProductId", supplier.ProductId);
        //            connection.Open();
        //            int count = cmd.ExecuteNonQuery(); //execute update 
        //            if (count > 0)
        //                result = true;
        //        }
        //    }
        //    return result;
        //}

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

        // when a supplier is modifying a product
        public static bool ProductSupplier(int productId, int supplierId)
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

        // if a supplier is deleted, the following code should also execute if an existing supplierID exists in the DB

        public static bool ProductSupplier(int supplierId)
        {
            bool result = true;
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Products_Suppliers WHERE SupplierId = @SupplierId";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                        return false;

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

        public static List<Products_Suppliers> Test(string productName, string supplierName)
        {
            List<Products_Suppliers> testprodSupList = new List<Products_Suppliers>();
            Products_Suppliers testprodSup;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProductSupplierId, Products.ProductId, Suppliers.SupplierId " +
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
                            testprodSup = new Products_Suppliers();
                            testprodSup.ProductId = (int)dr["ProductId"];
                            testprodSup.SupplierId = (int)dr["SupplierId"];
                            testprodSup.ProductSupplierId = (int)dr["ProductSupplierId"];
                            testprodSupList.Add(testprodSup);
                        }
                    }
                }
            }
            return testprodSupList;
        }

    }
}

using System.Collections.Generic;
using System.Data.SqlClient;

/*
 * Class constructor for ProductsDB
 * Created by Susan Trinh on January 26, 2021
 */
namespace ProductsData
{
    public static class ProductsDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        public static List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();
            Products prod;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProductId, ProdName FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            prod = new Products();
                            prod.ProductId = (int)dr["ProductId"];
                            prod.ProdName = (string)dr["ProdName"];
                            products.Add(prod);
                        }
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// retrieves the remaining products not associated to the selected supplier
        /// </summary>
        /// <param name="supplierId">supplier ID</param>
        /// <returns></returns>
        public static List<Products> GetRemainingProducts(int supplierId)
        {
            List<Products> products = new List<Products>();
            Products prod;
            using (SqlConnection connection = GetConnection())
            {
                string query =  "SELECT * FROM Products WHERE ProductId " +
                                "NOT IN (SELECT Products_Suppliers.ProductId " +
                                "FROM Products_Suppliers JOIN Products " +
                                "ON Products_Suppliers.ProductId = Products.ProductId " +
                                "JOIN Suppliers On Products_Suppliers.SupplierId = Suppliers.SupplierId " +
                                "WHERE Suppliers.SupplierId = @SupplierId)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            prod = new Products();
                            prod.ProductId = (int)dr["ProductId"];
                            prod.ProdName = (string)dr["ProdName"];
                            products.Add(prod);
                        }
                    }
                }
            }
            return products;
        }



        public static List<Products> GetProductsByID(int productID)
        {
            List<Products> products = new List<Products>();
            Products prod;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProductId, ProdName FROM Products WHERE ProductId = @ProductId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productID);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            prod = new Products();
                            prod.ProductId = (int)dr["ProductId"];
                            prod.ProdName = (string)dr["ProdName"];
                        }
                    }
                }
            }
            return products;
        }

        /// <summary>
        /// Adds another product record to database
        /// </summary>
        /// <param name="prod">object with new product data</param>
        /// <returns>generated ID for the new product record</returns>
        public static int AddProduct(Products prod)
        {
            int ProdID = 0;
            using (SqlConnection connection = GetConnection())
            {
                string insertStatement = "INSERT INTO Products (ProdName) " +
                                         "OUTPUT INSERTED.ProductId " + // returns single value
                                         "VALUES(@ProdName)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProdName", prod.ProdName);
                    connection.Open();
                    ProdID = (int)cmd.ExecuteScalar(); // returns one value
                }
            }
            return ProdID;
        }


        public static bool UpdateSelectedProduct(Products oldProduct, Products updatedProduct)
        {
            bool result = false; //assumes that update is not successful
            
            using (SqlConnection connection = GetConnection())
            {
               
                string query = "UPDATE Products SET ProdName = @NewProdName WHERE ProductId = @OldProductId ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@NewProdName", updatedProduct.ProdName);
                    cmd.Parameters.AddWithValue("@OldProductId", oldProduct.ProductId);

                    connection.Open();
                    int count = cmd.ExecuteNonQuery(); //execute update 
                    if (count > 0)
                        result = true;
                }
            }
            return result;
        }

        public static bool DeleteProduct(Products prod)
        {
            bool result = true;
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Products WHERE ProductId = @ProductId AND ProdName = @ProdName";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductId", prod.ProductId);
                    cmd.Parameters.AddWithValue("@ProdName", prod.ProdName);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                        return false;

                }
                return result;
            }

        }

        //Created by Julie on February 18
        public static List<string> GetProductName()
        {
            List<string> productNameList = new List<string>();
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT ProdName FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
              
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            
                            string prodName = (string)dr["ProdName"];

                            productNameList.Add(prodName);
                        }
                    }
                }
            }
            return productNameList;
        }



    }
}



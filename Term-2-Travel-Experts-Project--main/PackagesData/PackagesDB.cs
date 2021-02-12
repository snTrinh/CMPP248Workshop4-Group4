using System;
using System.Collections.Generic;
using System.Data.SqlClient;
/*
 * Class constructor for PackagesDB
 * Created by Susan Trinh on January 26, 2021
 */
namespace PackagesData
{
    public static class PackagesDB
    {
        /// <summary>
        /// creates SQL connection from conneection string
        /// </summary>
        /// <returns>connection</returns>
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// retreives list of Packages
        /// </summary>
        /// <returns>list of Packages</returns>
        public static List<Packages> GetPackages()
        {
            List<Packages> packages = new List<Packages>();
            Packages pkg;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission FROM Packages";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            pkg = new Packages();
                            pkg.PackageId = (int)dr["PackageId"];
                            pkg.PkgName = (string)dr["PkgName"];
                            pkg.PkgStartDate = (dr["PkgStartDate"] == DBNull.Value) ? default : (DateTime)dr["PkgStartDate"];
                            pkg.PkgEndDate = (dr["PkgEndDate"] == DBNull.Value) ? default : (DateTime)dr["PkgEndDate"]; ;
                            pkg.PkgDesc = (string)dr["PkgDesc"];
                            pkg.PkgBasePrice = (decimal)dr["PkgBasePrice"];
                            pkg.PkgAgencyCommission = (decimal)dr["PkgAgencyCommission"];
                            packages.Add(pkg);
                        }
                    }
                }
            }
            return packages;
        }

        /// <summary>
        /// retreives a package given an input product ID number
        /// </summary>
        /// <param name="packageID">product ID</param>
        /// <returns>one package value</returns>
        public static List<Packages> GetPackageByID(int packageID)
        {
            List<Packages> package = new List<Packages>();
            Packages pkg;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission  FROM Packages WHERE PackageID = @PackageID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", packageID);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            pkg = new Packages();
                            pkg.PackageId = (int)dr["PackageId"];
                            pkg.PkgName = (string)dr["PkgName"];
                            pkg.PkgStartDate = (dr["PkgStartDate"] == DBNull.Value) ? default : (DateTime)dr["PkgStartDate"];
                            pkg.PkgEndDate = (dr["PkgEndDate"] == DBNull.Value) ? default : (DateTime)dr["PkgEndDate"]; ;
                            pkg.PkgDesc = (string)dr["PkgDesc"];
                            pkg.PkgBasePrice = (decimal)dr["PkgBasePrice"];
                            pkg.PkgAgencyCommission = (decimal)dr["PkgAgencyCommission"];
                            package.Add(pkg);
                        }
                    }
                }
            }
            return package;
        }


        //public static Packages GetPackageByID(int productID)
        //{
        //    Packages package = new Packages();
        //    Packages pkg;
        //    using (SqlConnection connection = GetConnection())
        //    {
        //        string query = "SELECT * FROM Packages WHERE ProductID = @ProductID";
        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@ProductID", productID);
        //            connection.Open();
        //            using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
        //            {
        //                while (dr.Read())
        //                {
        //                    pkg = new Packages();
        //                    pkg.PackageID = (int)dr["PackageID"];
        //                    pkg.PkgName = (string)dr["PkgName"];
        //                    pkg.PkgStartDate = (dr["PkgStartDate"] == DBNull.Value) ? default : (DateTime)dr["PkgStartDate"];
        //                    pkg.PkgEndDate = (dr["PkgEndDate"] == DBNull.Value) ? default : (DateTime)dr["PkgEndDate"]; ;
        //                    pkg.PkgDesc = (string)dr["PkgDesc"];
        //                    pkg.PkgBasePrice = (decimal)dr["pkgBasePrice"];
        //                    pkg.PkgAgencyCommission = (decimal)dr["PkgAgencyCommission"];
        //                }
        //            }
        //        }
        //    }
        //    return package;
        //}

    }
}

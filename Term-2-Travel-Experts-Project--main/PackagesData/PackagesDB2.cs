using System;
using System.Collections.Generic;
using System.Data.SqlClient;

/*
 * Class constructor for PackagesDB
 * Created by Susan Trinh on January 26, 2021
 * Modified by Julie Tran January 30-February 19
 */
namespace PackagesData
{
    public static class PackagesDB
    {
        //Creates connection string to DB
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
        
        /// <summary>
        /// Retrieves list of Packages
        /// </summary>
        /// <returns>all Packages in database</returns>
        public static List<Packages> GetPackages()
        {
            List<Packages> packages = new List<Packages>();
            Packages pkg;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission FROM Packages ORDER BY PackageId";
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
        /// Updates packages in the database
        /// </summary>
        /// <param name="oldPkg">old package object to be updated </param>
        /// <param name="newPkg">new package to be displayed </param>
        /// <returns>true or false to indicate successful or unsuccessful update/returns>
        public static bool UpdatePackage(Packages oldPkg, Packages newPkg)
        {
            bool result = false; //assumes that update is not successful
            using (SqlConnection connection = GetConnection())
            {
                string updateStatement = "UPDATE Packages " +
                                         "SET PkgName = @NewPkgName, PkgStartDate = @NewPkgStartDate, PkgEndDate = @NewPkgEndDate, PkgDesc = @NewPkgDesc, PkgBasePrice =@NewPkgBasePrice, PkgAgencyCommission =@NewPkgAgencyCommission " +
                                         "WHERE PackageId = @OldPackageId";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@NewPkgName", newPkg.PkgName);
                    cmd.Parameters.AddWithValue("@NewPkgStartDate", (DateTime)newPkg.PkgStartDate);
                    cmd.Parameters.AddWithValue("@NewPkgEndDate", (DateTime)newPkg.PkgEndDate);
                    cmd.Parameters.AddWithValue("@NewPkgDesc", newPkg.PkgDesc);
                    cmd.Parameters.AddWithValue("@NewPkgBasePrice", Convert.ToDecimal(newPkg.PkgBasePrice));
                    cmd.Parameters.AddWithValue("@NewPkgAgencyCommission", Convert.ToDecimal(newPkg.PkgAgencyCommission));
                    cmd.Parameters.AddWithValue("@OldPackageId", oldPkg.PackageId);
                    connection.Open();
                    int count = cmd.ExecuteNonQuery(); //execute update 
                    if (count > 0);
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Add new Package to databse
        /// </summary>
        /// <param name="pkg">package object</param>
        /// <returns>an integer to indicate how many packages were added to database</returns>
        public static int AddPackage(Packages pkg)
        {
            int PackageId = 5;
            using (SqlConnection connection = GetConnection())
            {
                string insertStatement = "INSERT INTO Packages (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                                         "OUTPUT INSERTED.PackageId " +
                                         "VALUES(@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
                using (SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@PkgName", pkg.PkgName);
                    cmd.Parameters.AddWithValue("@PkgStartDate", (DateTime)pkg.PkgStartDate); 
                    cmd.Parameters.AddWithValue("@PkgEndDate", (DateTime)pkg.PkgEndDate);
                    cmd.Parameters.AddWithValue("@PkgDesc", pkg.PkgDesc);
                    cmd.Parameters.AddWithValue("@PkgBasePrice", Convert.ToDecimal(pkg.PkgBasePrice));
                    cmd.Parameters.AddWithValue("@PkgAgencyCommission", Convert.ToDecimal(pkg.PkgAgencyCommission));
                    connection.Open();
                    PackageId= (int)cmd.ExecuteScalar();
                }
            }
            return PackageId;
        }

        /// <summary>
        /// Delete a package from database
        /// </summary>
        /// <param name="pkg">package object</param>
        /// <returns>true or false to indicate successful or unsucessful delete</returns>
        public static bool DelPackage(Packages pkg)
        {
            bool result = true;
            using (SqlConnection connection = GetConnection())
            {
                string deleteStatement = "DELETE FROM Packages " +
                                         "WHERE PackageId = @PackageId AND PkgName = @PkgName AND PkgStartDate = @PkgStartDate AND PkgEndDate = @PkgEndDate AND PkgDesc = @PkgDesc AND PkgBasePrice = @PkgBasePrice AND PkgAgencyCommission = @PkgAgencyCommission";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@PackageId", pkg.PackageId);
                    cmd.Parameters.AddWithValue("@PkgName", pkg.PkgName);
                    cmd.Parameters.AddWithValue("@PkgStartDate", (DateTime)pkg.PkgStartDate);
                    cmd.Parameters.AddWithValue("@PkgEndDate", (DateTime)pkg.PkgEndDate);
                    cmd.Parameters.AddWithValue("@PkgDesc", pkg.PkgDesc);
                    cmd.Parameters.AddWithValue("@PkgBasePrice", Convert.ToDecimal(pkg.PkgBasePrice));
                    cmd.Parameters.AddWithValue("@PkgAgencyCommission", Convert.ToDecimal(pkg.PkgAgencyCommission));
                    connection.Open();
                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                        return false;
                }
                return result;
            }
        }
        /// <summary>
        /// Retrieves last inserted PackageId
        /// </summary>
        /// <returns>package Id</returns>
        public static int GetNextID()
        {
            using (SqlConnection connection = GetConnection())
            {
                string statement = "select top 1 PackageId from packages order by PackageId desc ";
                              
                using (SqlCommand cmd = new SqlCommand(statement, connection))
                {
                   
                    connection.Open();
                    int PackageId = (int)cmd.ExecuteScalar();
                    return PackageId;
                }
                
            }

        }
    }
}
       

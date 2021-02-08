using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentsAgencyData
{
    public static class AgentsAgencyDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog = TravelExperts; Integrated Security = True";
            return new SqlConnection(connectionString);
        }

        public static List<Agencies> GetAgencies()
        {
            List<Agencies> agencies = new List<Agencies>();
            Agencies age;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT AgencyId, AgncyAddress, AgncyCity, AgncyProv, AgncyPostal, " +
                    "AgncyCountry, AgncyPhone, AgncyFax FROM Agencies";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            age = new Agencies();
                            age.AgencyId = (int)dr["AgencyId"];
                            age.AgncyAddress = (string)dr["AgncyAddress"];
                            age.AgncyCity = (string)dr["AgncyCity"];
                            age.AgncyProv = (string)dr["AgncyProv"];
                            age.AgncyPostal = (string)dr["AgncyPostal"];
                            age.AgncyCountry = (string)dr["AgncyCountry"];
                            age.AgncyPhone = (string)dr["AgncyPhone"];
                            age.AgncyFax = (string)dr["AgncyFax"];
                            agencies.Add(age);
                        }
                    }
                }
            }
            return agencies;
        }

        public static List<Agents> GetAgents()
        {
            List<Agents> agents = new List<Agents>();
            Agents age;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT (AgtFirstName + ' ' + ISNULL(AgtMiddleInitial, '') + AgtLastName) " +
                    "as AgtFullName, AgtBusPhone, AgtEmail, AgtPosition, AgencyId from Agents";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            age = new Agents();
                            age.AgtFullName = (string)dr["AgtFullName"];
                            age.AgtBusPhone = (string)dr["AgtBusPhone"];
                            age.AgtEmail = (string)dr["AgtEmail"];
                            age.AgtPosition = (string)dr["AgtPosition"];
                            age.AgencyId = (int)dr["AgencyId"];
                            agents.Add(age);
                        }
                    }
                }
            }
            return agents;
        }


        public static List<Agents> GetAgentsByID(int agencyID)
        {
            List<Agents> agents = new List<Agents>();
            Agents age;
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT (AgtFirstName + ' ' + ISNULL(AgtMiddleInitial, '') + AgtLastName) " +
                    "as AgtFullName, AgtBusPhone, AgtEmail, AgtPosition, AgencyId from Agents WHERE AgencyId = @AgencyId";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@AgencyId", agencyID);
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            age = new Agents();
                            age.AgtFullName = (string)dr["AgtFullName"];
                            age.AgtBusPhone = (string)dr["AgtBusPhone"];
                            age.AgtEmail = (string)dr["AgtEmail"];
                            age.AgtPosition = (string)dr["AgtPosition"];
                            age.AgencyId = (int)dr["AgencyId"];
                            agents.Add(age);
                        }
                    }
                }
            }
            return agents;
        }
    }
}

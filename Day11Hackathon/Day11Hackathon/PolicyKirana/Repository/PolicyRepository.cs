using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyKirana.Exception;
using PolicyKirana.Interfaces;
using PolicyKirana.Model;
using PolicyKirana.Utility;

namespace PolicyKirana.Repository
{
    internal class PolicyRepository
    {
        List<Policy> policyData = new List<Policy>();
        SqlCommand cmd = null;
        public PolicyRepository()
        {
            cmd = new SqlCommand();
        }

        // Adding policy
        public void AddYourPolicies(PType policyType, int pTypeNum, string uname)
        {
            string pID = "";
            Int64 polID = 0;
            List<Int64> policyidCheck = new List<Int64>() { 0 };
            TimeSpan addDate = new TimeSpan(365, 0, 0, 0);
            DateTime endD = DateTime.Now.Add(addDate);
            int userID = 0;
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
                {
                    cmd.Parameters.Clear();
                    // Checking If any policy exists by storing existing policies in a list
                    cmd.CommandText = "SELECT * FROM PolicyDetails WHERE UserID = (SELECT UserID FROM UserDetails WHERE Username = @UName)";
                    cmd.Connection = sqlConn;
                    cmd.Parameters.AddWithValue("@UName", uname);
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        policyidCheck.Add(reader.GetInt64("PolicyID"));
                        Console.WriteLine(pID);
                    }
                    sqlConn.Close();

                    // Taking UserID
                    cmd.CommandText = "SELECT * FROM UserDetails WHERE Username = @UNameCheck";
                    cmd.Connection = sqlConn;
                    cmd.Parameters.AddWithValue("@UNameCheck", uname);
                    sqlConn.Open();
                    SqlDataReader reader2 = cmd.ExecuteReader();
                    if (reader2.Read())
                    {
                        userID = reader2.GetInt32("UserID");
                        Console.WriteLine(pID);
                    }
                    sqlConn.Close();

                    pID = pTypeNum.ToString() + userID.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
                    polID = Convert.ToInt64(pID);
                    foreach (var policyid in policyidCheck)
                    {

                        if (policyid != polID)
                        {
                            // Inserting
                            cmd.CommandText = "INSERT INTO PolicyDetails VALUES (@PolID, @UID, @PHName, @PolType, @SDate, @EDate)";
                            cmd.Connection = sqlConn;
                            cmd.Parameters.AddWithValue("@PolID", polID);
                            cmd.Parameters.AddWithValue("@UID", userID);
                            cmd.Parameters.AddWithValue("@PHName", uname);
                            cmd.Parameters.AddWithValue("@PolType", policyType);
                            cmd.Parameters.AddWithValue("@SDate", DateTime.Now.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@EDate", endD.ToString("yyyy-MM-dd"));
                            sqlConn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"Your Policy having ID {pID} has successfully been added.");
                            }
                            else
                            {
                                Console.WriteLine($"Policy already exists!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Policy already exists!!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Policy already exists!!!");
                Console.WriteLine(ex.Message);
            }


        }

        // Searching Policy by ID
        public List<Policy> SearchYourPolicy(string pID, string uname)
        {
            List<Policy> policyDisplay = new List<Policy>();
            using (SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM PolicyDetails WHERE PolicyID = @PolID AND UserID = (SELECT UserID FROM UserDetails WHERE Username = @UName)";
                cmd.Connection = sqlConn;
                cmd.Parameters.AddWithValue("@UName", uname);
                cmd.Parameters.AddWithValue("@PolID", pID);
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyID = reader.GetInt64("PolicyID");
                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                    policy.PolicyType = (PType)reader["PolicyType"];
                    policy.StartDate = reader.GetDateTime("StartDate");
                    policy.EndDate = reader.GetDateTime("EndDate");
                    policyDisplay.Add(policy);
                }
            }
            return policyDisplay;
        }

        // Updating Policy by ID
        public void UpdateYourPolicy(Int64 pID, string uname)
        {
            string holderName = "";
            DateTime endD = DateTime.Now;
            int poliType = 0;
            using (SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM PolicyDetails WHERE PolicyID = @PolID AND UserID = (SELECT UserID FROM UserDetails WHERE Username = @UName)";
                cmd.Connection = sqlConn;
                cmd.Parameters.AddWithValue("@UName", uname);
                cmd.Parameters.AddWithValue("@PolID", pID);
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    holderName = reader.GetString("PolicyHolderName");
                    poliType = reader.GetInt32("PolicyType");
                    endD = reader.GetDateTime("EndDate");
                }
            }
            if(poliType != 0)
            {
                Console.WriteLine("Do you want to change the policy holder name (Press y if yes): ");
                string changeName = Console.ReadLine();
                if (changeName.ToUpper() == "Y")
                {
                    Console.WriteLine("Enter policy holder name: ");
                    holderName = Console.ReadLine();
                }

                Console.WriteLine("How many years do you want the policy to be alive: ");
                var yearOfPolicies = Convert.ToInt32(Console.ReadLine());
                int diff = DateTime.Now.Year + yearOfPolicies;
                endD = new DateTime(diff, DateTime.Now.Month, DateTime.Now.Day);

                Console.WriteLine("Do you want to change the policy type (Press y if yes): ");
                string changeType = Console.ReadLine();
                if (changeType.ToUpper() == "Y")
                {
                takePolicyChoice:
                    Console.WriteLine("Which Type? Enter choice number\n(1. Life, 2. Health, 3. Vehicle, 4. Property): ");
                    poliType = Convert.ToInt32(Console.ReadLine());
                }
                try
                {
                    using (SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE PolicyDetails SET PolicyHolderName = @PHName, PolicyType = @PolType, EndDate = @eDate WHERE PolicyID = @PolicyID AND UserID = (SELECT UserID FROM UserDetails WHERE Username = @UName)";
                        cmd.Connection = sqlConn;
                        cmd.Parameters.AddWithValue("@PHName", holderName);
                        cmd.Parameters.AddWithValue("@eDate", endD);
                        cmd.Parameters.AddWithValue("@PolType", poliType);
                        cmd.Parameters.AddWithValue("@PolicyID", pID);
                        cmd.Parameters.AddWithValue("@UName", uname);
                        sqlConn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Update done successfully");
                        }
                        else
                        {
                            Console.WriteLine("No changes done.");
                        }
                    }
                }
                catch(SqlException ex)
                {
                    Console.WriteLine("End date can't be changed to the past, duh!"); // Trigger Error
                }
            }
            else
            {
                Console.WriteLine("Policy not found.");
            }
        }

        // Deleting Policy by ID
        public void DeleteYourPolicy(Int64 pID, string uname)
        {
            // Exception Handling
            try
            {
                using(SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "DELETE FROM PolicyDetails WHERE PolicyID = @PolID AND UserID = (SELECT UserID FROM UserDetails WHERE Username = @UName)";
                    cmd.Connection = sqlConn;
                    cmd.Parameters.AddWithValue("@PolID", pID);
                    cmd.Parameters.AddWithValue("@UName", uname);
                    sqlConn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Your Policy having ID {pID} has successfully been deleted.");
                    }
                    else
                    {
                        throw new PolicyNotFound("Policy not found. Please enter correct policy ID");
                    }
                }
            }
            catch (PolicyNotFound pnfex)
            {
                Console.WriteLine(pnfex.Message);
            }
        }

        // Viewing Policy
        public List<Policy> ViewYourPolicy(string uname)
        {
            List<Policy> policyDisplay = new List<Policy>();
            using (SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM PolicyDetails WHERE UserID = (SELECT UserID FROM UserDetails WHERE Username = @UName)";
                cmd.Connection = sqlConn;
                cmd.Parameters.AddWithValue("@UName", uname);
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyID = reader.GetInt64("PolicyID");
                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                    policy.PolicyType = (PType) reader["PolicyType"];
                    policy.StartDate = reader.GetDateTime("StartDate");
                    policy.EndDate = reader.GetDateTime("EndDate");
                    policyDisplay.Add(policy);
                }
            }
            return policyDisplay;
        }

        // Checking active policies
        public List<Policy> ViewYourActivePolicy(string uname)
        {
            List<Policy> policyDisplay = new List<Policy>();
            using (SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT * FROM PolicyDetails WHERE UserID = (SELECT UserID FROM UserDetails WHERE Username = @UName) AND @Now BETWEEN StartDate AND EndDate";
                cmd.Connection = sqlConn;
                cmd.Parameters.AddWithValue("@UName", uname);
                cmd.Parameters.AddWithValue("@Now", DateTime.Now.ToString("yyyy-MM-dd"));
                sqlConn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyID = reader.GetInt64("PolicyID");
                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                    policy.PolicyType = (PType)reader["PolicyType"];
                    policy.StartDate = reader.GetDateTime("StartDate");
                    policy.EndDate = reader.GetDateTime("EndDate");
                    policyDisplay.Add(policy);
                }
            }
            return policyDisplay;
        }
    }
}

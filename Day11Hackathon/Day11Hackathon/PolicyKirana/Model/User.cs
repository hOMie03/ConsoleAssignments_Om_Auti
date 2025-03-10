using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyKirana.Interfaces;
using PolicyKirana.Utility;

namespace PolicyKirana.Model
{
    internal class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        SqlCommand cmd = null;
        public User()
        {
            cmd = new SqlCommand();
        }

        public bool Login(string uname, string pswd)
        {
            Username = uname;
            Password = pswd;
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM UserDetails WHERE Username = @UName AND UserPassword = @Pswd";
                    cmd.Connection = sqlConn;
                    cmd.Parameters.AddWithValue("@UName", uname);
                    cmd.Parameters.AddWithValue("@Pswd", pswd);
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (uname == reader.GetString("Username") && pswd == reader.GetString("UserPassword"))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("Wrong credentials");
            }
            return false;
        }
        public int Register(string uname, string pswd)
        {
            Username = uname;
            Password = pswd;
            using (SqlConnection sqlConn = new SqlConnection(DBConnUtil.GetConnectionString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO UserDetails VALUES (@Uname, @Pswd)";
                cmd.Connection = sqlConn;
                cmd.Parameters.AddWithValue("@UName", uname);
                cmd.Parameters.AddWithValue("@Pswd", pswd);
                sqlConn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }
    }
}

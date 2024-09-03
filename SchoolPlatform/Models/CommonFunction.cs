using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchoolPlatform.Models
{
    public class CommonFunction
    {
        public class CommonFnx
        {

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SchoolPlatformDB"].ConnectionString);
            public void Query(string query)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            public DataTable Fetch(string query)
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

    }
}
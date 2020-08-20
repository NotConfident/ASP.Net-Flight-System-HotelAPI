using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using web2020apr_p01_t3.Models;

namespace web2020apr_p01_t3.DAL
{
    public class CommonDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        //Constructor
        public CommonDAL()
        {
            //Read ConnectionString from appsettings.json file
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string strConn = Configuration.GetConnectionString(
            "Air_Flights_DB");
            //Instantiate a SqlConnection object with the
            //Connection String read.
            conn = new SqlConnection(strConn);
        }

        public Login CheckLogin(string email, string password)
        {
            Login user = new Login();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a staff record.
            cmd.CommandText = @"SELECT * FROM Staff
                                WHERE EmailAddr = @email AND PASSWORD = @password";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “id”.
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {

                    // Fill FlightRoute properties with values from the data reader
                    user.Email = email;
                    user.Password = password;
                    user.Vocation = reader.GetString(4);
                }
            }
            //Close data reader
            reader.Close();
            //Close database connection
            conn.Close();
            return user;
        }
    }
}

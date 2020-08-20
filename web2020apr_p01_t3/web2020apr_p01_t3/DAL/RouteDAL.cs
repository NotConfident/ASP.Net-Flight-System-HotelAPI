using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace web2020apr_p01_t3.DAL
{
    public class RouteDAL
    {

        private SqlConnection conn;
        private IConfiguration configuration;

        public RouteDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configuration = builder.Build();
            string connString = configuration.GetConnectionString("Air_Flights_DB");

            conn = new SqlConnection(connString);
        }

        public int? getRouteID(string dCity, string aCity)
        {
            int? routrID = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"select RouteID from FlightRoute where DepartureCity = @dCity and ArrivalCity = @aCity";
            cmd.Parameters.AddWithValue("@dCity", dCity);
            cmd.Parameters.AddWithValue("@aCity", aCity);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    routrID = !reader.IsDBNull(0) ? reader.GetInt32(0) : (int?)null;
                }
            }
            conn.Close();
            reader.Close();
            return routrID;
        }



    }
}

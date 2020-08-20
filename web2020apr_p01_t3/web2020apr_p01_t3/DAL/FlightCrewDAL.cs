using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using web2020apr_p01_t3.Models;
//done by Isaiah, incomplete
namespace web2020apr_p01_t3.DAL
{
    public class FlightCrewDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;

        public FlightCrewDAL()
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

        public List<FlightCrew> GetFlightCrew()
        {
            FlightCrew flightCrew = new FlightCrew();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement
            cmd.CommandText = @"SELECT * FROM FlightCrew ORDER BY ScheduleID";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<FlightCrew> crewList = new List<FlightCrew>();
            while (reader.Read())
            {
                crewList.Add(
                    new FlightCrew
                    {
                        scheduleID = reader.GetInt32(0),
                        StaffId = reader.GetInt32(1),
                        Role = reader.GetString(2)
                    }
                );
            }
            reader.Close();
            conn.Close();

            return crewList;
        }
        public int Update(FlightCrew flightcrew)
        {
            //Create a sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify an INSERT SQL statement which will return the auto-generated StaffID after insertion
            cmd.CommandText = @"UPDATE FlightCrew SET StaffID = @staffID
                                WHERE scheduleID= @selectedScheduleID AND Role = @role";
            cmd.Parameters.AddWithValue("@staffID", flightcrew.StaffId);
            cmd.Parameters.AddWithValue("@role", flightcrew.Role);
            cmd.Parameters.AddWithValue("@selectedScheduleID", flightcrew.scheduleID);




            //Connection to database need to be opened
            conn.Open();

            //ExecuteScalar is used to retrieve the auto-generated
            //AircraftID after executing the INSERT SQL Statement
            int count = cmd.ExecuteNonQuery();

            //A connection should be closed after operation
            conn.Close();

            return count;
        }
    }
}

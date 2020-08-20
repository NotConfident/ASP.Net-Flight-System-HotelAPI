using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using web2020apr_p01_t3.Models;

namespace web2020apr_p01_t3.DAL
{
    public class ScheduleDAL
    {
        private SqlConnection conn;
        private IConfiguration configuration { get; set; }

        public ScheduleDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configuration = builder.Build();
            string connString = configuration.GetConnectionString("Air_Flights_DB");

            conn = new SqlConnection(connString);
        }

        public List<ScheduleModel> getScheduleList(int? routeID)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"select * from FlightSchedule where RouteID = @routeID";
            cmd.Parameters.AddWithValue("@routeID", routeID);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ScheduleModel> schedulelsit = new List<ScheduleModel>();
            while (reader.Read())
            {
                schedulelsit.Add
                    (
                        new ScheduleModel
                        {
                            scheduleID = reader.GetInt32(0),
                            flightNum = reader.GetString(1),
                            routeID = routeID,
                            aircraftID = reader.GetInt32(3),
                            departDateTime = reader.GetDateTime(4),
                            arrivalDateTime = reader.GetDateTime(5),
                            eClass = reader.GetDecimal(6),
                            bClass = reader.GetDecimal(7),
                            status = reader.GetString(8)
                        }
                    );
            }
            reader.Close();
            conn.Close();
            return schedulelsit;
        }

        public ScheduleModel getSchedule(int id)
        {
            ScheduleModel schedule = new ScheduleModel();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from FlightSchedule where ScheduleID = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    schedule.scheduleID = id;
                    schedule.flightNum = reader.GetString(1);
                    schedule.routeID = reader.GetInt32(2);
                    schedule.aircraftID = reader.GetInt32(3);
                    schedule.departDateTime = reader.GetDateTime(4);
                    schedule.arrivalDateTime = reader.GetDateTime(5);
                    schedule.eClass = reader.GetDecimal(6);
                    schedule.bClass = reader.GetDecimal(7);
                    schedule.status = reader.GetString(8);
                }
            }
            conn.Close();
            reader.Close();
            return schedule;
        }

        public List<FlightSchedule> GetSchListNoPara()
        {
            FlightSchedule flightSchedule = new FlightSchedule();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM FlightSchedule";
            conn.Open();
            SqlDataReader schedulereader = cmd.ExecuteReader();
            List<FlightSchedule> schedulelist = new List<FlightSchedule>();
            while (schedulereader.Read())
            {
                schedulelist.Add
                    (
                        new FlightSchedule
                        {
                            ScheduleID = schedulereader.GetInt32(0),
                            FlightNumber = schedulereader.GetString(1),
                            RouteID = schedulereader.GetInt32(2),
                            AircraftID = schedulereader.GetInt32(3),
                            DepartureDateTime = schedulereader.GetDateTime(4),
                            ArrivalDateTime = schedulereader.GetDateTime(5),
                            PriceEco = schedulereader.GetDecimal(6),
                            PriceBusiness = schedulereader.GetDecimal(7),
                            Status = schedulereader.GetString(8)
                        }
                    );
            }
            conn.Close();
            schedulereader.Close();
            return schedulelist;
        }


    }
}

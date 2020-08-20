using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using web2020apr_p01_t3.Models;
using System.Net;
using System.Data;

namespace web2020apr_p01_t3.DAL
{
    public class AircraftDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        //Constructor

        public AircraftDAL ()
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

        public List<Aircraft> GetAllAircraft()
        {
            //Create sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify the SELECT SQL Statement
            //cmd.CommandText = @"SELECT FlightSchedule.ScheduleID, FlightSchedule.FlightNumber, FlightSchedule.DepartureDateTime, FlightSchedule.ArrivalDateTime, Aircraft.MakeModel, Aircraft.Status
            //                    FROM FlightSchedule 
            //                        INNER JOIN Aircraft ON FlightSchedule.AircraftID = Aircraft.AircraftID";

            cmd.CommandText = @"SELECT * FROM Aircraft";
            //Open Database connection
            conn.Open();

            //Execute the SELECT SQL Through a datareader
            SqlDataReader reader = cmd.ExecuteReader();

            //Read all the records until the end, save data in the aircraft list
            List<Aircraft> aircraftList = new List<Aircraft>();
            while (reader.Read())
            {
                aircraftList.Add(
                    new Aircraft
                    {
                        AircraftID = reader.GetInt32(0), // 1st column AircraftID
                        modelName = reader.GetString(1), // 2nd column MakeModel
                        noOfEconSeats = !reader.IsDBNull(2) ? // 3rd column NumEconomySeats
                                        reader.GetInt32(2) : (int?) null, 
                        noOfBusiSeats = !reader.IsDBNull(3) ? // 4th column NumBusinessSeats
                                        reader.GetInt32(3) : (int?) null, 
                        lastMaintain = !reader.IsDBNull(4) ? // 5th column DateLastMaintenance
                                        reader.GetDateTime(4) : (DateTime?) null, 
                        Status = reader.GetString(5) // 6th column Status

                        // check for null values (meaning not assigned yet), display as null
                    });
            }

            //Close Datareader
            reader.Close();

            //Close database connection
            conn.Close();

            return aircraftList;
        }

        public List<FlightScheduleViewModel> GetAllAircraftWithFlightSchedule()
        { //Create sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify the SELECT SQL Statement
            //cmd.CommandText = @"SELECT FlightSchedule.ScheduleID, FlightSchedule.FlightNumber, FlightSchedule.DepartureDateTime, FlightSchedule.ArrivalDateTime, Aircraft.AircraftID, Aircraft.MakeModel, FlightSchedule.Status
            //                    FROM FlightSchedule 
            //                        INNER JOIN Aircraft ON FlightSchedule.AircraftID = Aircraft.AircraftID";
            cmd.CommandText = @"SELECT * FROM FlightRoute
                                INNER JOIN FlightSchedule
                                INNER JOIN Aircraft
                                ON Aircraft.AircraftID = FlightSchedule.AircraftID
                                ON FlightRoute.RouteID = FlightSchedule.RouteID
                                ORDER BY FlightSchedule.ScheduleID ASC";

            //cmd.CommandText = @"SELECT * FROM Aircraft
            //                    WHERE AircraftID NOT IN (SELECT AircraftID FROM FlightSchedule)";
            //Open Database connection
            conn.Open();

            //Execute the SELECT SQL Through a datareader
            SqlDataReader reader = cmd.ExecuteReader();

            //Read all the records until the end, save data in the aircraft list
            List<FlightScheduleViewModel> aircraftWithFlightsList = new List<FlightScheduleViewModel>();
            while (reader.Read())
            {
                aircraftWithFlightsList.Add(
                    new FlightScheduleViewModel
                    {
                        DepartureCity = reader.GetString(1),
                        DepartureCountry = reader.GetString(2),
                        ArrivalCity = reader.GetString(3),
                        ArrivalCountry = reader.GetString(4),
                        ScheduleID = reader.GetInt32(6),
                        FlightNumber = reader.GetString(7),
                        DepartureDateTime = !reader.IsDBNull(10) ?
                                            reader.GetDateTime(10) : (DateTime?)null,
                        ArrivalDateTime = !reader.IsDBNull(11) ?
                                            reader.GetDateTime(11) : (DateTime?)null,
                        AircraftID = reader.GetInt32(15),
                        AircraftModel = reader.GetString(16),
                        Status = reader.GetString(20)

                    });
            }

            //Close Datareader
            reader.Close();

            //Close database connection
            conn.Close();

            return aircraftWithFlightsList;
        }

        public List<FlightSchedule> GetAircraftFlightDetails(int aircraftID)
        {
            List<FlightSchedule> fs = new List<FlightSchedule>();

            //Create a sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify the select SQL sattement that retrieve details of the selected aircraft
            cmd.CommandText = @"SELECT * FROM FlightSchedule
                                WHERE AircraftID = @selectedAircraftID";

            //Define the paramters used in sql statement. in this case will be the aircraftID
            cmd.Parameters.AddWithValue("@selectedAircraftID", aircraftID);


            //Connection to database need to be opened
            conn.Open();

            //Execite the select SQL through a datareader
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                //read recrord from database
                while (reader.Read())
                {
                    fs.Add(new FlightSchedule
                    {
                        ScheduleID = reader.GetInt32(0),
                        FlightNumber = reader.GetString(1),
                        RouteID = reader.GetInt32(2),
                        AircraftID = aircraftID,
                        DepartureDateTime = reader.GetDateTime(4),
                        ArrivalDateTime = reader.GetDateTime(5),
                        Status = reader.GetString(8)


                    });

                }
            }
            reader.Close();
            conn.Close();
            return fs;

        }

     
        public Aircraft GetAircraftDetails(int aircraftID)
        {
            Aircraft aircraft = new Aircraft();

            //Create a sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify the select SQL sattement that retrieve details of the selected aircraft
            cmd.CommandText = @"SELECT * FROM Aircraft
                                WHERE AircraftID = @selectedAircraftID";

            //Define the paramters used in sql statement. in this case will be the aircraftID
            cmd.Parameters.AddWithValue("@selectedAircraftID", aircraftID);


            //Connection to database need to be opened
            conn.Open();

            //Execite the select SQL through a datareader
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                //read recrord from database
                while(reader.Read())
                {
                    aircraft.AircraftID = aircraftID;
                    aircraft.modelName = reader.GetString(1);
                    aircraft.noOfEconSeats = !reader.IsDBNull(2) ? // 3rd column NumEconomySeats
                                        reader.GetInt32(2) : (int?)null;
                    aircraft.noOfBusiSeats = !reader.IsDBNull(3) ? // 4th column NumBusinessSeats
                                        reader.GetInt32(3) : (int?)null;
                    aircraft.lastMaintain = !reader.IsDBNull(4) ? // 5th column DateLastMaintenance
                                        reader.GetDateTime(4) : (DateTime?)null;
                    aircraft.Status = reader.GetString(5); // 6th column Status

                }
            }
            reader.Close();
            conn.Close();
            return aircraft;
        }
   


        public int Add(Aircraft aircraft)
        {
            //Create a sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify an INSERT SQL statement which will return the auto-generated StaffID after insertion
            cmd.CommandText = @"INSERT INTO Aircraft (MakeModel, NumEconomySeat, NumBusinessSeat, DateLastMaintenance, Status)
                                OUTPUT INSERTED.AircraftID
                                VALUES(@MakeModel, @NumEconomySeats, @NumBusinessSeats, @DateLastMaintenance, @Status)";

            //Define the parameters used in SQL statement, value for each parameter is retrieved from aircraft class property
            cmd.Parameters.AddWithValue("@MakeModel",aircraft.modelName);
            cmd.Parameters.AddWithValue("@NumEconomySeats", aircraft.noOfEconSeats);
            cmd.Parameters.AddWithValue("@NumBusinessSeats", aircraft.noOfBusiSeats);
            cmd.Parameters.AddWithValue("@DateLastMaintenance", aircraft.lastMaintain);
            cmd.Parameters.AddWithValue("@Status", "Operational");
            foreach (IDataParameter param in cmd.Parameters)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }


            //Connection to database need to be opened
            conn.Open();

            //ExecuteScalar is used to retrieve the auto-generated
            //AircraftID after executing the INSERT SQL Statement
            aircraft.AircraftID = (int)cmd.ExecuteScalar();

            //A connection should be closed after operation
            conn.Close();

            return aircraft.AircraftID;

        }

        //Return number of row updated
        public int Update(Aircraft aircraft)
        {
            //Create a sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify an INSERT SQL statement which will return the auto-generated StaffID after insertion
            cmd.CommandText = @"UPDATE Aircraft SET Status=@Status
                                WHERE AircraftID = @selectedAircraftID";
            cmd.Parameters.AddWithValue("@Status", aircraft.Status);
            cmd.Parameters.AddWithValue("@selectedAircraftID", aircraft.AircraftID);



            //Connection to database need to be opened
            conn.Open();

            //ExecuteScalar is used to retrieve the auto-generated
            //AircraftID after executing the INSERT SQL Statement
            int count = cmd.ExecuteNonQuery();

            //A connection should be closed after operation
            conn.Close();

            return count;
        }

        public int Assign(int aircraftID, int scheduleID)
        {
            //Create a sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify an INSERT SQL statement which will return the auto-generated StaffID after insertion
            cmd.CommandText = @"update FlightSchedule set AircraftID = @selectedAircraftID where ScheduleID = @selectedScheduleID";

            cmd.Parameters.AddWithValue("@selectedScheduleID", scheduleID);
            cmd.Parameters.AddWithValue("@selectedAircraftID", aircraftID);



            //Connection to database need to be opened
            conn.Open();

            //ExecuteScalar is used to retrieve the auto-generated
            //AircraftID after executing the INSERT SQL Statement
            int count = cmd.ExecuteNonQuery();

            //A connection should be closed after operation
            conn.Close();

            return count;
        }


        public bool checkAircraft(int aircraftID)
        {
            List<FlightSchedule> fsList = GetAircraftFlightDetails(aircraftID);
            DateTime currentDate = DateTime.Today;

            bool check = false;
            foreach (FlightSchedule fs in fsList)
            {
                if (fs.DepartureDateTime < currentDate || fs.DepartureDateTime == null)
                {
                    check = true;
                }

            }
            return check;

        }

        public List<Aircraft> GetAllAircraftOperational()
        {
            //Create sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

           
            cmd.CommandText = @"SELECT * FROM Aircraft WHERE Aircraft.Status = 'Operational'";
            //Open Database connection
            conn.Open();

            //Execute the SELECT SQL Through a datareader
            SqlDataReader reader = cmd.ExecuteReader();

            //Read all the records until the end, save data in the aircraft list
            List<Aircraft> aircraftList = new List<Aircraft>();
            while (reader.Read())
            {
                aircraftList.Add(
                    new Aircraft
                    {
                        AircraftID = reader.GetInt32(0), // 1st column AircraftID
                        modelName = reader.GetString(1), // 2nd column MakeModel
                        noOfEconSeats = !reader.IsDBNull(2) ? // 3rd column NumEconomySeats
                                        reader.GetInt32(2) : (int?)null,
                        noOfBusiSeats = !reader.IsDBNull(3) ? // 4th column NumBusinessSeats
                                        reader.GetInt32(3) : (int?)null,
                        lastMaintain = !reader.IsDBNull(4) ? // 5th column DateLastMaintenance
                                        reader.GetDateTime(4) : (DateTime?)null,
                        Status = reader.GetString(5) // 6th column Status

                        // check for null values (meaning not assigned yet), display as null
                    });
            }

            //Close Datareader
            reader.Close();

            //Close database connection
            conn.Close();

            return aircraftList;

        }

        public List<Aircraft> GetAllAircraftWithDateFilter()
        {
            //Create sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

     

            cmd.CommandText = @"SELECT * FROM aircraft WHERE DATEDIFF(day,DateLastMaintenance,getdate()) > 30";
            //Open Database connection
            conn.Open();

            //Execute the SELECT SQL Through a datareader
            SqlDataReader reader = cmd.ExecuteReader();

            //Read all the records until the end, save data in the aircraft list
            List<Aircraft> aircraftList = new List<Aircraft>();
            while (reader.Read())
            {
                aircraftList.Add(
                    new Aircraft
                    {
                        AircraftID = reader.GetInt32(0), // 1st column AircraftID
                        modelName = reader.GetString(1), // 2nd column MakeModel
                        noOfEconSeats = !reader.IsDBNull(2) ? // 3rd column NumEconomySeats
                                        reader.GetInt32(2) : (int?)null,
                        noOfBusiSeats = !reader.IsDBNull(3) ? // 4th column NumBusinessSeats
                                        reader.GetInt32(3) : (int?)null,
                        lastMaintain = !reader.IsDBNull(4) ? // 5th column DateLastMaintenance
                                        reader.GetDateTime(4) : (DateTime?)null,
                        Status = reader.GetString(5) // 6th column Status

                        // check for null values (meaning not assigned yet), display as null
                    });
            }

            //Close Datareader
            reader.Close();

            //Close database connection
            conn.Close();

            return aircraftList;
        }

    }
}

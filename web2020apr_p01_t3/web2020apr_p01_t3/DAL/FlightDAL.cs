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
    public class FlightDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        //Constructor
        public FlightDAL()
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

        //Package 2
        public List<FlightScheduleViewModel> GetAllFlights()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement
            cmd.CommandText = @"SELECT * FROM FlightRoute
                                INNER JOIN FlightSchedule
                                ON FlightRoute.RouteID = FlightSchedule.RouteID
                                ORDER BY FlightSchedule.ScheduleID ASC";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a FlightScheduleViewModel list
            List<FlightScheduleViewModel> flightList = new List<FlightScheduleViewModel>();

            while (reader.Read())
            {
                flightList.Add(
                new FlightScheduleViewModel
                {
                    ScheduleID = reader.GetInt32(6),
                    FlightNumber = reader.GetString(7),
                    RouteID = reader.GetInt32(0),
                    DepartureCountry = reader.GetString(2),
                    DepartureCity = reader.GetString(1),
                    ArrivalCountry = reader.GetString(4),
                    ArrivalCity = reader.GetString(3),
                    DepartureDateTime = !reader.IsDBNull(10) ? reader.GetDateTime(10) : (DateTime?)null,
                    ArrivalDateTime = !reader.IsDBNull(11) ? reader.GetDateTime(11) : (DateTime?)null,
                    PriceEco = reader.GetDecimal(12),
                    PriceBusiness = reader.GetDecimal(13),
                    FlightDuration = reader.GetInt32(5),
                });
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return flightList;
        }

        //Package 2
        public List<FlightRoute> GetAllRoutes()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement
            cmd.CommandText = @"SELECT * FROM FlightRoute
                                ORDER BY RouteID ASC";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a FlightRoute list
            List<FlightRoute> flightList = new List<FlightRoute>();

            while (reader.Read())
            {
                flightList.Add(
                new FlightRoute
                {
                    RouteID = reader.GetInt32(0),
                    DepartureCountry = reader.GetString(2),
                    DepartureCity = reader.GetString(1),
                    ArrivalCountry = reader.GetString(4),
                    ArrivalCity = reader.GetString(3),
                    FlightDuration = reader.GetInt32(5),
                });
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return flightList;
        }

        //Package 2
        public FlightRoute GetRouteDetails(int id)
        {
            FlightRoute flightroute = new FlightRoute();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a staff record.
            cmd.CommandText = @"SELECT * FROM FlightRoute
             WHERE RouteID = @selectedRouteID";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “id”.
            cmd.Parameters.AddWithValue("@selectedRouteID", id);
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
                    flightroute.RouteID = id;
                    flightroute.DepartureCountry = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                    flightroute.DepartureCity = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                    flightroute.ArrivalCountry = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                    flightroute.ArrivalCity = !reader.IsDBNull(3) ? reader.GetString(3) : null;
                    flightroute.FlightDuration = reader.GetInt32(5);
                }
            }
            //Close data reader
            reader.Close();
            //Close database connection
            conn.Close();
            return flightroute;
        }

        //Package 2
        public FlightSchedule GetScheduleDetails(int id)
        {
            FlightSchedule flightSchedule = new FlightSchedule();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a staff record.
            cmd.CommandText = @"SELECT * FROM FlightSchedule
             WHERE ScheduleID = @selectedScheduleID";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “id”.
            cmd.Parameters.AddWithValue("@selectedScheduleID", id);
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {

                    // Fill FlightSchedule properties with values from the data reader
                    flightSchedule.ScheduleID = id;
                    flightSchedule.FlightNumber = reader.GetString(1);
                    flightSchedule.RouteID = reader.GetInt32(2);
                    flightSchedule.AircraftID = !reader.IsDBNull(3) ? reader.GetInt32(3) : (int?)null;
                    flightSchedule.DepartureDateTime = !reader.IsDBNull(4) ? reader.GetDateTime(4) : (DateTime?)null;
                    flightSchedule.ArrivalDateTime = !reader.IsDBNull(5) ? reader.GetDateTime(5) : (DateTime?)null;
                    flightSchedule.PriceEco = reader.GetDecimal(6);
                    flightSchedule.PriceBusiness = reader.GetDecimal(7);
                    flightSchedule.Status = reader.GetString(8);
                }
            }
            //Close data reader
            reader.Close();
            //Close database connection
            conn.Close();
            return flightSchedule;
        }

        //Package 2
        public List<ScheduleBookingViewModel> GetScheduleBookingDetails(int scheduleID)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a staff record.
            cmd.CommandText = @"SELECT * FROM FlightSchedule
                                INNER JOIN Booking
                                ON FlightSchedule.ScheduleID = Booking.ScheduleID
                                WHERE Booking.ScheduleID = @selectedScheduleID";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “id”.
            cmd.Parameters.AddWithValue("@selectedScheduleID", scheduleID);
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            List<ScheduleBookingViewModel> detailList = new List<ScheduleBookingViewModel>();

            //Read the record from database
            while (reader.Read())
            {
                detailList.Add(
                new ScheduleBookingViewModel
                {
                    // Fill ScheduleBookingViewModel properties with values from the data reader
                    RouteID = reader.GetInt32(2),
                    FlightNumber = reader.GetString(1),
                    AircraftID = !reader.IsDBNull(3) ? reader.GetInt32(3) : (int?)null,
                    DepartureDateTime = !reader.IsDBNull(4) ? reader.GetDateTime(4) : (DateTime?)null,
                    PriceEco = reader.GetDecimal(6),
                    PriceBusiness = reader.GetDecimal(7),
                    Status = reader.GetString(8),
                    BookingID = reader.GetInt32(9),
                    CustID = reader.GetInt32(10),
                    ScheduleID = scheduleID,
                    PassengerName = reader.GetString(12),
                    PassportNo = reader.GetString(13),
                    Nationality = reader.GetString(14),
                    SeatClass = reader.GetString(15),
                    AmountPayable = reader.GetDecimal(16),
                });
            }

            //Close data reader
            reader.Close();
            //Close database connection
            conn.Close();
            return detailList;
        }

        //Package 2
        public int AddFlightRoute(FlightRoute flight)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            //return the auto-generated RouteID after insertion
            cmd.CommandText = @"INSERT INTO FlightRoute (DepartureCountry, DepartureCity, ArrivalCountry, ArrivalCity, FlightDuration)
            OUTPUT INSERTED.RouteID
            VALUES(@departurecountry, @departurecity, @arrivalcountry, @arrivalcity,
            @flightduration)";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@departurecountry", flight.DepartureCountry);
            cmd.Parameters.AddWithValue("@departurecity", flight.DepartureCity);
            cmd.Parameters.AddWithValue("@arrivalcountry", flight.ArrivalCountry);
            cmd.Parameters.AddWithValue("@arrivalcity", flight.ArrivalCity);
            cmd.Parameters.AddWithValue("@flightduration", flight.FlightDuration);
            //A connection to database must be opened before any operations made.
            conn.Open();
            //ExecuteScalar is used to retrieve the auto-generated
            //RouteID after executing the INSERT SQL statement
            flight.RouteID = (int)cmd.ExecuteScalar();
            //A connection should be closed after operations.
            conn.Close();
            //Return id when no error occurs.
            return flight.RouteID;
        }

        //Package 2
        public int UpdateRouteRecord(FlightRoute flight)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an UPDATE SQL statement
            cmd.CommandText = @"UPDATE FlightRoute SET DepartureCountry=@departurecountry,
             DepartureCity=@departurecity, ArrivalCountry=@arrivalcountry,
             ArrivalCity=@arrivalcity, FlightDuration=@flightduration
            WHERE RouteID = @selectedRouteID";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@departurecountry", flight.DepartureCountry);
            cmd.Parameters.AddWithValue("@departurecity", flight.DepartureCity);
            cmd.Parameters.AddWithValue("@arrivalcountry", flight.ArrivalCountry);
            cmd.Parameters.AddWithValue("@arrivalcity", flight.ArrivalCity);
            cmd.Parameters.AddWithValue("@flightduration", flight.FlightDuration);
            cmd.Parameters.AddWithValue("@selectedRouteID", flight.RouteID);
            //Open a database connection
            conn.Open();
            //ExecuteNonQuery is used for UPDATE and DELETE
            int count = cmd.ExecuteNonQuery();
            //Close the database connection
            conn.Close();
            return count;
        }

        //Package 2
        public int UpdateScheduleRecord(FlightSchedule flight)
        {

            //DateTime newDatetime = flight.DepartureDateTime.AddHours(flight.DepartureHours).AddMinutes(flight.DepartureMins).AddSeconds(flight.DepartureSeconds);
            DateTime newDatetime = new DateTime();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an UPDATE SQL statement
            cmd.CommandText = @"UPDATE FlightSchedule SET FlightNumber = @flightnumber,
            DepartureDateTime = @departuredatetime,
            EconomyClassPrice = @economyclass, BusinessClassPrice = @businessclass
            WHERE ScheduleID = @selectedScheduleID";

            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@flightnumber", flight.FlightNumber);
            cmd.Parameters.AddWithValue("@departuredatetime", newDatetime);
            cmd.Parameters.AddWithValue("@economyclass", flight.PriceEco);
            cmd.Parameters.AddWithValue("@businessclass", flight.PriceBusiness);
            cmd.Parameters.AddWithValue("@selectedScheduleID", flight.ScheduleID);

            //Open a database connection
            conn.Open();
            //ExecuteNonQuery is used for UPDATE and DELETE
            int count = cmd.ExecuteNonQuery();
            //Close the database connection
            conn.Close();
            return count;
        }

        //Package 2
        public List<FlightRoute> CheckUnassignedRouteID()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * 
                                FROM FlightRoute fr
                                WHERE fr.RouteID NOT IN 
                                (SELECT 
                                FlightSchedule.RouteID 
                                FROM FlightSchedule)";

            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            List<FlightRoute> flightList = new List<FlightRoute>();
            //Read all records until the end, save data into a FlightRoute list

            while (reader.Read())
            {
                flightList.Add(
                new FlightRoute
                {
                    RouteID = reader.GetInt32(0),
                    DepartureCountry = reader.GetString(2),
                    DepartureCity = reader.GetString(1),
                    ArrivalCountry = reader.GetString(4),
                    ArrivalCity = reader.GetString(3),
                    FlightDuration = reader.GetInt32(5),
                });
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return flightList;
        }

        //Method to obtain FlightRoute Duration before assigning it below v
        //Package 2
        public FlightRoute ObtainRouteWithRouteID(int routeID)
        {
            FlightRoute route = new FlightRoute();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * 
                                FROM FlightRoute
                                WHERE RouteID = @RouteID";

            cmd.Parameters.AddWithValue("@RouteID", routeID);

            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a FlightRoute list
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {
                    // Fill ScheduleBookingViewModel properties with values from the data reader
                    route.RouteID = routeID;
                    route.DepartureCountry = reader.GetString(1);
                    route.DepartureCity = reader.GetString(2);
                    route.ArrivalCountry = reader.GetString(3);
                    route.ArrivalCity = reader.GetString(4);
                    route.FlightDuration = reader.GetInt32(5);
                }
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();

            return route;
        }

        //Package 2
        public FlightSchedule ConvertToScheduleObj(FlightRouteViewModel flightRoute)
        {
            if (!flightRoute.DepartureDateTime.HasValue)
            {
                //Get duration for RouteID
                FlightSchedule schedule = new FlightSchedule();

                schedule.ScheduleID = 0;
                schedule.FlightNumber = flightRoute.FlightNumber;
                schedule.RouteID = flightRoute.RouteID;
                schedule.AircraftID = null;
                schedule.DepartureDateTime = null;
                schedule.ArrivalDateTime = null;
                schedule.PriceEco = flightRoute.Economy;
                schedule.PriceBusiness = flightRoute.Business;

                return schedule;
            }
            else
            {
                DateTime newDatetime = flightRoute.DepartureDateTime.Value.AddHours((double)flightRoute.DepartureHours);
                newDatetime = newDatetime.AddMinutes((double)flightRoute.DepartureMins);
                newDatetime = newDatetime.AddSeconds((double)flightRoute.DepartureSeconds);

                //Get duration for RouteID
                FlightRoute route = ObtainRouteWithRouteID(flightRoute.RouteID);
                FlightSchedule schedule = new FlightSchedule();

                schedule.ScheduleID = 0;
                schedule.FlightNumber = flightRoute.FlightNumber;
                schedule.RouteID = flightRoute.RouteID;
                schedule.AircraftID = null;
                schedule.DepartureDateTime = newDatetime;
                schedule.ArrivalDateTime = newDatetime.AddHours((double)route.FlightDuration);
                schedule.PriceEco = flightRoute.Economy;
                schedule.PriceBusiness = flightRoute.Business;

                return schedule;
            }
        }

        //Package 2
        public int ValidateRoute(FlightRoute route)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            //return the auto-generated ScheduleID after insertion
            cmd.CommandText = @"SELECT* FROM FlightRoute
                                WHERE DepartureCountry = @departurecountry AND DepartureCity = @departurecity
                                AND ArrivalCountry = @arrivalcountry AND ArrivalCity = @arrivalcity";


            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@departurecountry", route.DepartureCountry);
            cmd.Parameters.AddWithValue("@departurecity", route.DepartureCity);
            cmd.Parameters.AddWithValue("@arrivalcountry", route.ArrivalCountry);
            cmd.Parameters.AddWithValue("@arrivalcity", route.ArrivalCity);

            //A connection to database must be opened before any operations made.
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;

            if (reader.HasRows)
            {
                count += 1;
            }

            //A connection should be closed after operations.
            conn.Close();
            //Return ScheduleID when no error occurs.
            return count;
        }

        //Package 2
        public int AddFlightSchedule(FlightSchedule flight)
        {

            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            //return the auto-generated ScheduleID after insertion
            cmd.CommandText = @"INSERT INTO FlightSchedule (FlightNumber, RouteID, DepartureDateTime, ArrivalDateTime, EconomyClassPrice, BusinessClassPrice)
            OUTPUT INSERTED.ScheduleID
            VALUES(@flightnumber, @routeid, @departuredatetime, @arrivaldatetime, @economyclass, @businessclass)";

            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@flightnumber", flight.FlightNumber);
            cmd.Parameters.AddWithValue("@routeid", flight.RouteID);
            if (!flight.DepartureDateTime.HasValue)
            {
                cmd.Parameters.AddWithValue("@departuredatetime", DBNull.Value);
                cmd.Parameters.AddWithValue("@arrivaldatetime", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@departuredatetime", flight.DepartureDateTime);
                cmd.Parameters.AddWithValue("@arrivaldatetime", flight.ArrivalDateTime);
            }
            cmd.Parameters.AddWithValue("@economyclass", flight.PriceEco);
            cmd.Parameters.AddWithValue("@businessclass", flight.PriceBusiness);

            //A connection to database must be opened before any operations made.
            conn.Open();
            //ExecuteScalar is used to retrieve the auto-generated
            //ScheduleID after executing the INSERT SQL statement
            flight.ScheduleID = (int)cmd.ExecuteScalar();
            //A connection should be closed after operations.
            conn.Close();
            //Return ScheduleID when no error occurs.
            return flight.ScheduleID;
        }

        //Package 2
        public int UpdateStatus(ViewModel scheduleDetails)
        {

            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an UPDATE SQL statement
            cmd.CommandText = @"UPDATE FlightSchedule SET Status=@status
            WHERE ScheduleID = @id";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@status", scheduleDetails.Status);
            cmd.Parameters.AddWithValue("@id", scheduleDetails.ScheduleID);

            //Open a database connection
            conn.Open();
            //ExecuteNonQuery is used for UPDATE and DELETE
            int count = cmd.ExecuteNonQuery();
            //Close the database connection
            conn.Close();
            return count;
        }

        //For Aircraft
        public List<FlightSchedule> GetAllFlightSchedule()
        {
            //Create sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();



            cmd.CommandText = @"SELECT * FROM FlightSchedule";
            //Open Database connection
            conn.Open();

            //Execute the SELECT SQL Through a datareader
            SqlDataReader reader = cmd.ExecuteReader();

            //Read all the records until the end, save data in the aircraft list
            List<FlightSchedule> flightScheduleList = new List<FlightSchedule>();
            while (reader.Read())
            {
                flightScheduleList.Add(
                    new FlightSchedule
                    {

                        ScheduleID = reader.GetInt32(0), // 1st column ScheduleID
                        FlightNumber = reader.GetString(1), // 2nd column Fligh tNumber
                        AircraftID = !reader.IsDBNull(3) ? // 3rd column aircraft ID
                                        reader.GetInt32(3) : (int?)null,
                        DepartureDateTime = !reader.IsDBNull(4) ? // 4th column Departure date and time
                                        reader.GetDateTime(4) : (DateTime?)null,
                        ArrivalDateTime = !reader.IsDBNull(5) ? // 5th column Arrival date and time
                                        reader.GetDateTime(5) : (DateTime?)null,
                        Status = reader.GetString(8)
                        // check for null values (meaning not assigned yet), display as null
                    });
            }

            //Close Datareader
            reader.Close();

            //Close database connection
            conn.Close();

            return flightScheduleList;
        }

        //for Aircraft
        public List<FlightSchedule> GetAllFlightScheduleForAssign()
        {
            //Create sqlcommand object from connection object
            SqlCommand cmd = conn.CreateCommand();



            cmd.CommandText = @"SELECT * FROM FlightSchedule WHERE DepartureDateTime >= GETDATE()";
            //Open Database connection
            conn.Open();

            //Execute the SELECT SQL Through a datareader
            SqlDataReader reader = cmd.ExecuteReader();

            //Read all the records until the end, save data in the aircraft list
            List<FlightSchedule> flightScheduleList = new List<FlightSchedule>();
            while (reader.Read())
            {
                flightScheduleList.Add(
                    new FlightSchedule
                    {

                        ScheduleID = reader.GetInt32(0), // 1st column ScheduleID
                        FlightNumber = reader.GetString(1), // 2nd column Fligh tNumber
                        AircraftID = !reader.IsDBNull(3) ? // 3rd column aircraft ID
                                        reader.GetInt32(3) : (int?)null,
                        DepartureDateTime = !reader.IsDBNull(4) ? // 4th column Departure date and time
                                        reader.GetDateTime(4) : (DateTime?)null,
                        ArrivalDateTime = !reader.IsDBNull(5) ? // 5th column Arrival date and time
                                        reader.GetDateTime(5) : (DateTime?)null,
                        Status = reader.GetString(8)
                        // check for null values (meaning not assigned yet), display as null
                    });
            }

            //Close Datareader
            reader.Close();

            //Close database connection
            conn.Close();

            return flightScheduleList;
        }

        //    public int DeleteRoute(int routeID)
        //    {
        //        string strConn = Configuration.GetConnectionString("Air_Flights_DB");
        //        try
        //        {
        //            using (conn = new SqlConnection(strConn))
        //            {
        //                conn.Open();
        //                using (SqlCommand cmd = new SqlCommand("DELETE FROM FlightRoute WHERE RouteID = @selectRouteID"))
        //                {
        //                    cmd.Parameters.AddWithValue("@selectRouteID", routeID);
        //                    cmd.ExecuteNonQuery();
        //                }
        //                conn.Close();
        //                return 0;
        //            }
        //        }
        //        catch
        //        {
        //            return 1;
        //        }
        //    }

        //    public int DeleteSchedule(int scheduleID)
        //    {
        //        //Instantiate a SqlCommand object, supply it with a DELETE SQL statement
        //        //to delete a staff record specified by a Staff ID
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = @"DELETE FROM FlightSchedule
        //        WHERE ScheduleID = @selectscheduleID";
        //        cmd.Parameters.AddWithValue("@selectscheduleID", scheduleID);
        //        //Open a database connection
        //        conn.Open();
        //        int rowAffected = 0;
        //        //Execute the DELETE SQL to remove the staff record
        //        rowAffected += cmd.ExecuteNonQuery();
        //        //Close database connection
        //        conn.Close();
        //        //Return number of row of Flight Schedule record updated or deleted
        //        return rowAffected;
        //    }
        //
    }

}

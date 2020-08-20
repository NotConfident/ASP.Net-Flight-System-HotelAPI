using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using web2020apr_p01_t3.Models;
//done by Isaiah

namespace web2020apr_p01_t3.DAL
{
    public class PersonnelDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        //Constructor
        public PersonnelDAL()
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

        public List<Personnel> GetPersonnel()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement
            cmd.CommandText = @"SELECT * FROM Staff ORDER BY StaffID";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Personnel> personnelList = new List<Personnel>();
            while (reader.Read())
            {
                personnelList.Add(
                    new Personnel
                    {
                        StaffId = reader.GetInt32(0),
                        StaffName = reader.GetString(1),
                        Gender = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                        DateEmployed = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null,
                        Vocation = !reader.IsDBNull(4) ? reader.GetString(4) : (string)null,
                        EmailAddr = reader.GetString(5),
                        Password = reader.GetString(6),
                        Status = reader.GetString(7),
                    }
                );
            }
            reader.Close();
            conn.Close();

            return personnelList;
        }
        public List<Personnel> GetPilots()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement
            cmd.CommandText = @"SELECT * FROM Staff WHERE Vocation = 'Pilot' ORDER BY StaffID";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Personnel> pilotList = new List<Personnel>();
            while (reader.Read())
            {
                pilotList.Add(
                    new Personnel
                    {
                        StaffId = reader.GetInt32(0),
                        StaffName = reader.GetString(1),
                        Gender = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                        DateEmployed = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null,
                        Vocation = !reader.IsDBNull(4) ? reader.GetString(4) : (string)null,
                        EmailAddr = reader.GetString(5),
                        Password = reader.GetString(6),
                        Status = reader.GetString(7),
                    }
                );
            }
            reader.Close();
            conn.Close();

            return pilotList;
        }
        public List<Personnel> GetFlightAttendants()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement
            cmd.CommandText = @"SELECT * FROM Staff WHERE Vocation = 'Flight Attendant' ORDER BY StaffID";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Personnel> attendantList = new List<Personnel>();
            while (reader.Read())
            {
                attendantList.Add(
                    new Personnel
                    {
                        StaffId = reader.GetInt32(0),
                        StaffName = reader.GetString(1),
                        Gender = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                        DateEmployed = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null,
                        Vocation = !reader.IsDBNull(4) ? reader.GetString(4) : (string)null,
                        EmailAddr = reader.GetString(5),
                        Password = reader.GetString(6),
                        Status = reader.GetString(7),
                    }
                );
            }
            reader.Close();
            conn.Close();

            return attendantList;
        }
        public List<Personnel> GetPersonnelForAssign()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement
            cmd.CommandText = @"SELECT * FROM Staff WHERE Status = 'Active' ORDER BY StaffID";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Personnel> personnelassignList = new List<Personnel>();
            while (reader.Read())
            {
                personnelassignList.Add(
                    new Personnel
                    {
                        StaffId = reader.GetInt32(0),
                        StaffName = reader.GetString(1),
                        Gender = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                        DateEmployed = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null,
                        Vocation = !reader.IsDBNull(4) ? reader.GetString(4) : (string)null,
                        EmailAddr = reader.GetString(5),
                        Password = reader.GetString(6),
                        Status = reader.GetString(7),
                    }
                );
            }
            reader.Close();
            conn.Close();

            return personnelassignList;
        }
        public int Add(Personnel personnel)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            //return the auto-generated StaffID after insertion
            cmd.CommandText = @"INSERT INTO Staff([StaffName], [Gender], [DateEmployed], [Vocation], [EmailAddr], [Status])
                                VALUES( @staffName, @gender, @dateEmployed, @vocation, @email, @status)";
            //Define the parameters used in SQL statement, value for each parameter     
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@staffName", personnel.StaffName);

            if (personnel.Gender == "null")
            {
                cmd.Parameters.AddWithValue("@gender", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@gender", personnel.Gender);
            }
            if (personnel.DateEmployed == null || personnel.DateEmployed.ToString() == "")
            {
                cmd.Parameters.AddWithValue("@dateEmployed", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@dateEmployed", personnel.DateEmployed);
            }

            if (personnel.Vocation == null || personnel.Vocation.ToString() == "")
            {
                cmd.Parameters.AddWithValue("@vocation", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@vocation", personnel.Vocation);
            }

            cmd.Parameters.AddWithValue("@email", personnel.EmailAddr);
            cmd.Parameters.AddWithValue("@password", "p@55Staff");
            cmd.Parameters.AddWithValue("@status", personnel.Status);
            //A connection to database must be opened before any operations made.
            conn.Open();
            //ExecuteScalar is used to retrieve the auto-generated
            //StaffID after executing the INSERT SQL statement
            int insert = cmd.ExecuteNonQuery();
            //A connection should be closed after operations.
            conn.Close();
            //Return id when no error occurs.
            return insert;
        }
        public bool IsEmailExist(string email, int staffId)
        {
            bool emailFound = false;
            //Create a SqlCommand object and specify the SQL statement
            //to get a staff record with the email address to be validated
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT StaffID FROM Staff
                                WHERE EmailAddr=@selectedEmail";
            cmd.Parameters.AddWithValue("@selectedEmail", email);
            //Open a database connection and excute the SQL statement
            conn.Open();
            //cannot add to databawse
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            { //Records found
                while (reader.Read())
                {
                    if (reader.GetInt32(0) != staffId)
                        //The email address is used by another staff
                        emailFound = true;
                }
            }
            else
            { //No record
                emailFound = false; // The email address given does not exist
            }
            reader.Close();
            conn.Close();

            return emailFound;
        }

        public Personnel GetDetails(int StaffId)
        {
            Personnel personnel = new Personnel();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a staff record.
            cmd.CommandText = @"SELECT * FROM Staff
                                 WHERE StaffId = @selectedStaffId";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “staffId”.
            cmd.Parameters.AddWithValue("@selectedStaffID", StaffId);
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {
                    // Fill staff object with values from the data reader
                    personnel.StaffId = StaffId;
                    personnel.StaffName = !reader.IsDBNull(1) ? reader.GetString(1) : null;
                    // (char) 0 - ASCII Code 0 - null value
                    personnel.Gender = !reader.IsDBNull(2) ?
                    reader.GetString(2) : null;
                    personnel.DateEmployed = (DateTime)(!reader.IsDBNull(3) ?
                    reader.GetDateTime(3) : (DateTime?)null);
                    personnel.Vocation = !reader.IsDBNull(4) ?
                    reader.GetString(4) : null;
                    personnel.EmailAddr = !reader.IsDBNull(5) ?
                    reader.GetString(5) : null;
                    personnel.Password = !reader.IsDBNull(6) ?
                    reader.GetString(6) : null;
                    personnel.Status = !reader.IsDBNull(7) ?
                    reader.GetString(7) : null;
                }
            }
            //Close data reader
            reader.Close();
            //Close database connection
            conn.Close();
            return personnel;
        }

        public List<CrewSchedule> FindScheduleBasedID(int StaffId)
        {
            List<CrewSchedule> csList = new List<CrewSchedule>();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT FlightCrew.ScheduleID,StaffID,Role,FlightNumber,RouteID,AircraftID 
                                FROM FlightCrew INNER JOIN FlightSchedule ON FlightCrew.ScheduleID = FlightSchedule.ScheduleID WHERE FlightCrew.StaffID = @selectedStaffID";
            cmd.Parameters.AddWithValue("@selectedStaffID", StaffId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    csList.Add(new CrewSchedule
                    {
                        scheduleID = reader.GetInt32(0),
                        StaffId = reader.GetInt32(1),
                        Role = reader.GetString(2),
                        FlightNumber = reader.GetString(3),
                        RouteID = reader.GetInt32(4),
                        AircraftID = reader.GetInt32(5)
                    });
                }
            }
            reader.Close();
            conn.Close();
            return csList;
        }

        public List<Personnel> GetStatus()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT StaffID, Status FROM Staff ORDER BY StaffID";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Personnel> statuslist = new List<Personnel>();
            while (reader.Read())
            {
                statuslist.Add(
                    new Personnel
                    {
                        StaffId = reader.GetInt32(0),
                        Status = reader.GetString(1)
                    }
                    );
            }
                reader.Close();
            conn.Close();
            return statuslist;
        }
        public int Update (Personnel personnel)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE Personnel SET Status = @Status WHERE StaffID = @selectedStaffID";
            cmd.Parameters.AddWithValue("@Status", personnel.Status);
            cmd.Parameters.AddWithValue("@selectedStaffID", personnel.StaffId);
            conn.Open();


            int count = cmd.ExecuteNonQuery();
            conn.Close();

            return count;
        }
    }
}

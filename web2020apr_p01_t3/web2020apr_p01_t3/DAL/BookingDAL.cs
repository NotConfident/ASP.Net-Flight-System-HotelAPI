using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using web2020apr_p01_t3.Models;

namespace web2020apr_p01_t3.DAL
{
    public class BookingDAL
    {
        private SqlConnection conn;
        private IConfiguration configuration { get; set; }

        public BookingDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configuration = builder.Build();
            string connString = configuration.GetConnectionString("Air_Flights_DB");

            conn = new SqlConnection(connString);
        }

        public List<BookingDetails> getDetails(int? id)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"select FlightRoute.DepartureCity,
                                FlightRoute.ArrivalCity, 
                                FlightSchedule.DepartureDateTime, 
                                FlightSchedule.ArrivalDateTime, 
                                Booking.DateTimeCreated, 
                                FlightRoute.FlightDuration,
                                Booking.PassengerName,
                                Booking.Nationality,
                                Booking.PassportNumber,
                                Booking.SeatClass,
                                FlightSchedule.FlightNumber,
                                Booking.AmtPayable,
                                Booking.Remarks,
                                FlightRoute.DepartureCountry,
                                FlightRoute.ArrivalCountry
                                from Customer
                                INNER JOIN Booking on Booking.CustomerID = Customer.CustomerID
                                inner join FlightSchedule on Booking.ScheduleID = FlightSchedule.ScheduleID
                                inner join FlightRoute on FlightSchedule.RouteID = FlightRoute.RouteID
                                where Customer.CustomerID = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<BookingDetails> detailList = new List<BookingDetails>();
            while (reader.Read())
            {
                detailList.Add
                    (
                        new BookingDetails
                        {
                            dCity = !reader.IsDBNull(0) ? reader.GetString(0) : null,
                            destinatiton = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                            dTime = !reader.IsDBNull(2) ? reader.GetDateTime(2) : (DateTime?)null,
                            arrival = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null,
                            datebooked = !reader.IsDBNull(4) ? reader.GetDateTime(4) : (DateTime?)null,
                            duration = !reader.IsDBNull(5) ? reader.GetInt32(5) : (int?)null,
                            name = !reader.IsDBNull(6) ? reader.GetString(6) : null,
                            nationality = !reader.IsDBNull(7) ? reader.GetString(7) : null,
                            passport = !reader.IsDBNull(8) ? reader.GetString(8) : null,
                            seatClass = !reader.IsDBNull(9) ? reader.GetString(9) : null,
                            flightNum = !reader.IsDBNull(10) ? reader.GetString(10) : null,
                            price = !reader.IsDBNull(11) ? reader.GetDecimal(11) : (Decimal?)null,
                            remark = !reader.IsDBNull(12) ? reader.GetString(12) : null,
                            dCountry = !reader.IsDBNull(13) ? reader.GetString(13) : null,
                            aCountry = !reader.IsDBNull(14) ? reader.GetString(14) : null
                        }
                    );
            }

            reader.Close();
            conn.Close();
            return detailList;

        }

        public void book(BookingViewModel booking)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"insert into Booking([CustomerID], [ScheduleID], [PassengerName], [PassportNumber], [Nationality], [SeatClass], [AmtPayable], [Remarks])
                               values(@CustomerID, @ScheduleID, @PassengerName, @PassportNumber, @Nationality, @SeatClass, @AmtPayable, @Remarks)";
            cmd.Parameters.AddWithValue("@CustomerID", booking.customerID);
            cmd.Parameters.AddWithValue("@ScheduleID", booking.scheduleID);
            cmd.Parameters.AddWithValue("@PassengerName", booking.customerName);
            cmd.Parameters.AddWithValue("@PassportNumber", booking.passpoerNum);
            cmd.Parameters.AddWithValue("@Nationality", booking.nationality);
            cmd.Parameters.AddWithValue("@SeatClass", booking.seatClass);
            cmd.Parameters.AddWithValue("@AmtPayable", booking.amtPayable);
            cmd.Parameters.AddWithValue("@Remarks", String.IsNullOrEmpty(booking.remark) ? string.Empty : "NULL");
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<BookingViewModel> getbooking(int? id)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"select * from Booking where CustomerID = @id";
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<BookingViewModel> bookinglist = new List<BookingViewModel>();
            while (reader.Read())
            {
                bookinglist.Add
                    (
                        new BookingViewModel
                        {
                            bookingID = reader.GetInt32(0),
                            customerID = reader.GetInt32(1),
                            scheduleID = reader.GetInt32(2),
                            customerName = reader.GetString(3),
                            passpoerNum = reader.GetString(4),
                            nationality = reader.GetString(5),
                            seatClass = reader.GetString(6),
                            amtPayable = reader.GetDecimal(7),
                            remark = reader.GetString(8),
                            bookingDate = reader.GetDateTime(9)
                        }
                    );
            }
            reader.Close();
            conn.Close();
            return bookinglist;
        }

       
    }
}

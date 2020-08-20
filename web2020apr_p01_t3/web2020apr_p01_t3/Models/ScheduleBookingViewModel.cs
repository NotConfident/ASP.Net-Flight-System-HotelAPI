using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web2020apr_p01_t3.Models
{

    public class ScheduleBookingViewModel
    {
        public int RouteID { get; set; }

        public string FlightNumber { get; set; }

        public int? AircraftID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm:ss tt}")]
        public DateTime? DepartureDateTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal PriceEco { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal PriceBusiness { get; set; }

        public string Status { get; set; }

        //Cust info

        [Display(Name = "Schedule ID")]
        public int ScheduleID { get; set; }

        [Display(Name = "Booking ID")]
        public int BookingID { get; set; }

        [Display(Name = "Customer ID")]
        public int CustID { get; set; }

        [Display(Name = "Passenger Name")]
        public string PassengerName { get; set; }

        [Display(Name = "Passport Number")]
        public string PassportNo { get; set; }

        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Display(Name = "Seat Class")]
        public string SeatClass { get; set; }

        [Display(Name = "Amount Payable")]
        public decimal AmountPayable { get; set; }
    }

    public class ViewModel
    {

        [Display(Name = "Route ID")]
        public int RouteID { get; set; }

        public int ScheduleID { get; set; }

        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Display(Name = "Aircraft ID")]
        public int? AircraftID { get; set; }

        [Display(Name = "Departure Date and Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm:ss tt}")]
        public DateTime? DepartureDateTime { get; set; }

        [Display(Name = "Price (Eco / Business)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal PriceEco { get; set; }

        [Display(Name = "Price (Eco / Business)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal PriceBusiness { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public List<ScheduleBookingViewModel> ScheduleBooking { get; set; }
        public List<string> statusList = new List<string>() { "Full", "Delayed", "Cancelled", "Opened" };


    }


}

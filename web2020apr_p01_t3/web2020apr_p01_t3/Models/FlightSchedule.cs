using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web2020apr_p01_t3.Models
{

    public class FlightSchedule
    {
        [Display(Name = "Schedule ID")]
        public int ScheduleID { get; set; }

        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Display(Name = "Route ID")]
        public int RouteID { get; set; }

        [Display(Name = "Flight Number")]
        public int? AircraftID { get; set; }

        [Display(Name = "Departure Date and Time")]
        [DataType(DataType.Date)]   
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm:ss tt}")]
        public DateTime? DepartureDateTime { get; set; }

        public int DepartureHours { get; set; }
        public int DepartureMins { get; set; }
        public int DepartureSeconds { get; set; }

        [Display(Name = "Arrival Date and Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm:ss tt}")]
        public DateTime? ArrivalDateTime { get; set; }

        [Display(Name = "Price (Eco)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal PriceEco { get; set; }

        [Display(Name = "Price (Business)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal PriceBusiness { get; set; }

        public string Status { get; set; }

        
    }
}

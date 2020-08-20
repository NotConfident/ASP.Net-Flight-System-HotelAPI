using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web2020apr_p01_t3.Models
{

    public class FlightScheduleViewModel
    {
        [Display(Name = "Schedule ID")]
        public int ScheduleID { get; set; }

        [Display(Name = "Route ID")]
        public int RouteID { get; set; }

        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Display(Name = "Departure / Arrival")]
        public string DepartureCountry { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCountry { get; set; }
        public string ArrivalCity { get; set; }

        [Display(Name = "Departure Date and Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm:ss tt}")]
        public DateTime? DepartureDateTime { get; set; }

        [Display(Name = "Arrival Date and Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm:ss tt}")]
        public DateTime? ArrivalDateTime { get; set; }

        [Display(Name = "Price (Eco / Business)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal PriceEco { get; set; }

        [Display(Name = "Price (Eco / Business)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal PriceBusiness { get; set; }

        public int FlightDuration { get; set; }

        public int AircraftID { get; set; }

        [Display(Name = "Aicraft Model")]
        public string AircraftModel { get; set; }

        //this is the status of the aircraft
        public string Status { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace web2020apr_p01_t3.Models
{
    public class AircraftViewModel
    { 
        //The purpose of this class is to store a Aircraft and Flight Schedule object to display Flights schedules that aircrafts are scheduled to
        //Property needed:
        //FlightScheduleID, FlightNumber, FlightDepartureDateTime, FlightArrivalDateTime, AircraftName, AircraftStatus

 

        [Display(Name = "Schedule ID")]
        public int ScheduleID { get; set; }

        public int AircraftID { get; set; }

        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }
        
        [Display(Name = "Departure Date & Time")]
        [DataType(DataType.Date)]
        public DateTime? DepartureDateTime { get; set; }

        [Display(Name = "Arrival Date & Time")]
        [DataType(DataType.Date)]
        public DateTime? ArrivalDateTime { get; set; }

        [Display(Name = "Aicraft Model")]
        public string AircraftModel { get; set; }

        //this is the status of the aircraft
        public string Status { get; set; }

        public string DepartureCountry { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCountry { get; set; }
        public string ArrivalCity { get; set; }

    }
}

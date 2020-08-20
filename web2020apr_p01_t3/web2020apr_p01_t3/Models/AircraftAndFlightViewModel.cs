using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web2020apr_p01_t3.Models
{
    public class AircraftAndFlightViewModel
    {
        public List<FlightSchedule>  flightScheduleList { get; set; }
        public List<Aircraft> aircraftList { get; set; }

        public AircraftAndFlightViewModel()
        {
            flightScheduleList = new List<FlightSchedule>();
            aircraftList = new List<Aircraft>();
        }


    }
}

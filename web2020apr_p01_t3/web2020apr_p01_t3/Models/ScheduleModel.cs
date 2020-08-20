using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web2020apr_p01_t3.Models
{
    public class ScheduleModel
    {
        //[ScheduleID], [FlightNumber], [RouteID], [AircraftID], [DepartureDateTime], [ArrivalDateTime], [EconomyClassPrice], [BusinessClassPrice], [Status]
        public int scheduleID { get; set; }
        public string flightNum { get; set; }
        public int? routeID { get; set; }
        public int aircraftID { get; set; }
        public DateTime departDateTime { get; set; }
        public DateTime arrivalDateTime { get; set; }
        public decimal eClass { get; set; }
        public decimal bClass { get; set; }
        public string status { get; set; }
    }
}

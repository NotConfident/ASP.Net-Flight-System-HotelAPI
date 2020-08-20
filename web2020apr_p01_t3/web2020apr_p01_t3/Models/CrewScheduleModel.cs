using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web2020apr_p01_t3.Models
{
    public class CrewSchedule
    {
        public int scheduleID { get; set; }
        public int StaffId { get; set; }
        public string Role { get; set; }
        public string FlightNumber { get; set; }
        public int RouteID { get; set; }
        public int? AircraftID { get; set; }
    }
}

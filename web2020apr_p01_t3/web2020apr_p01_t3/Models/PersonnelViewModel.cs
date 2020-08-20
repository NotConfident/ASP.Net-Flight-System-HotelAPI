using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace web2020apr_p01_t3.Models
{
    public class PersonnelViewModel
    {
        public int StaffId { get; set; }

        [StringLength(50)]
        public string StaffName { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateEmployed { get; set; }

        public string Vocation { get; set; }

        [StringLength(50)]
        public string EmailAddr { get; set; }

        public string Status { get; set; }

        public int scheduleID { get; set; }

        public string Role { get; set; }

        public int RouteID { get; set; }

        public string FlightNumber { get; set; }

        public int AircraftID { get; set; }

        public List<Personnel> personnelList { get; set; }
        public List<CrewSchedule> csList { get; set; }

        public PersonnelViewModel()
        {
            personnelList = new List<Personnel>();
        }
    }
}

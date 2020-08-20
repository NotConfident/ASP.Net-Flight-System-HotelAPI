using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//done by Isaiah
namespace web2020apr_p01_t3.Models
{
    public class FlightCrew
    {
        public int scheduleID { get; set; }
        [ForeignKey("ScheduleID")]
        public int StaffId { get; set; }
        [ForeignKey("StaffId")]
        public string Role { get; set; }
    }
}

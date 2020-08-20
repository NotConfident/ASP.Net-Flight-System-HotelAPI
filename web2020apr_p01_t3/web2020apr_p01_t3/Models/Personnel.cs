using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//done by Isaiah
namespace web2020apr_p01_t3.Models
{
    public class Personnel
    {
        public int StaffId { get; set; }
        [StringLength(50)]

        public string StaffName { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateEmployed { get; set; }

        public string Vocation { get; set; }

        [StringLength(50)]
        [Display(Name = "Email Address")]
        public string EmailAddr { get; set; }

        public string Password { get; set; }

        [StringLength(255)]
        public string Status { get; set; }
    }
}

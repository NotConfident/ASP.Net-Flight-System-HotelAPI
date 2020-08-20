using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web2020apr_p01_t3.Models
{
    public class CustomerModel
    {
        public int? id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string cEmail { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? cDOB { get; set; }



        public string Nationality { get; set; }


        [Display(Name = "Telephone Number")]
        public string cTeleNo { get; set; }
        [Required]
        public string Password { get; set; }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace web2020apr_p01_t3.Models
{
    public class Aircraft
    {

        //Aircraft ID (primary key)
        public int AircraftID { get; set; }

        // Make model name
        [Display(Name = "Model Name")]
        [Required(ErrorMessage = "Model Name is required!")]
        [MaxLength(50)]
        public string modelName { get; set; }


        //Number of economy seats
        [Display(Name = "No. of Economy class seats")]

        public int? noOfEconSeats { get; set; }

        //Number of business seats
        [Display(Name = "No. of Business class seats")]
        public int? noOfBusiSeats { get; set; }


        //Date of last maintenance held
        [Display(Name = "Last Maintenance ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy")]
        public DateTime? lastMaintain { get; set; }



        //Status of the aircraft, default value should be operational
        [MaxLength(50)]
        public string Status { get; set; }




        ////Setting status to default value operational
        //public Aircraft()
        //{
        //    Status = "Operational";
        //}


    }
}

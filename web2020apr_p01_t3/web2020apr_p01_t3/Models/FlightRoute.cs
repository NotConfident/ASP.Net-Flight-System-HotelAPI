using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace web2020apr_p01_t3.Models
{

    public class FlightRoute
    {
        [Display(Name = "Route ID")]
        public int RouteID { get; set; }

        [Display(Name = "Country of Departure")]
        public string DepartureCountry { get; set; }

        [Display(Name = "City of Departure")]
        public string DepartureCity { get; set; }

        [Display(Name = "Country of Arrival")]
        public string ArrivalCountry { get; set; }

        [Display(Name = "City of Arrival")]
        public string ArrivalCity { get; set; }

        [Display(Name = "Duration Of Flight")]
        public int? FlightDuration { get; set; }

    }
}

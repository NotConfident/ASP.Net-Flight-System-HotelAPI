using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace web2020apr_p01_t3.Models
{
    //ViewModel is only used if you want to filter the information you want to display / Adding multiple Models

    public class FlightRouteViewModel
    {
        public List<SelectListItem> FlightRouteOptions { get; set; }
        public List<FlightRoute> Routes { get; set; }

        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Display(Name = "Route ID")]
        public int RouteID { get; set; }

        [Display(Name = "Flight Duration")]
        public int Duration { get; set; }


        [Display(Name = "Departure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime? DepartureDateTime { get; set; }

        public int? DepartureHours { get; set; }
        public int? DepartureMins { get; set; }
        public int? DepartureSeconds { get; set; }

        [Display(Name = "Price (Eco)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal Economy { get; set; }

        [Display(Name = "Price (Business)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#,###.##}")]
        public decimal Business { get; set; }

        public FlightRouteViewModel(List<FlightRoute> _routes)
        {
            Routes = _routes;
            FlightRouteOptions = new List<SelectListItem>();
            PopulateSelectListItem();
        }

        //Generate the SelectList items based on a list
        public void PopulateSelectListItem()
        { 
            foreach (FlightRoute route in Routes)
            {
                FlightRouteOptions.Add(new SelectListItem { Value = route.RouteID.ToString(), Text = route.RouteID.ToString() });
            }
        }

        public FlightRouteViewModel()
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web2020apr_p01_t3.Models
{

    public class Hotel //Or "Comparisons?"
    {
        public string country { get; set; }

        public string hotelName { get; set; }
        public string hotelId { get; set; }

        public string price1 { get; set; }
        public string tax1 { get; set; }
        public string vendor1 { get; set; }

        public string price2 { get; set; }
        public string tax2 { get; set; }
        public string vendor2 { get; set; }

        public string price3 { get; set; }
        public string tax3 { get; set; }
        public string vendor3 { get; set; }

        public string price4 { get; set; }
        public string tax4 { get; set; }
        public string vendor4 { get; set; }

        public string price5 { get; set; }
        public string tax5 { get; set; }
        public string vendor5 { get; set; }

        public string totalHotelsCount { get; set; }
        public string currentPageNumber { get; set; }
        public string totalpageCount { get; set; }
        public int currentPageHotelsCount { get; set; }

        public List<object> Comparison { get; set; }

        public List<object> hotelList { get; set; } = new List<object>();
    }
}

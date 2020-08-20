using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web2020apr_p01_t3.Models
{
    public class BookingDetails
    {
        public string dCity { get; set; }
        public string destinatiton { get; set; }
        public DateTime? dTime { get; set; }
        public DateTime? arrival { get; set; }
        public DateTime? datebooked { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
        public string passport { get; set; }
        public string seatClass { get; set; }
        public string flightNum { get; set; }
        public decimal? price { get; set; }
        public string remark { get; set; }
        public int? duration { get; set; }
        public string dCountry { get; set; }
        public string aCountry { get; set; }
    }
}

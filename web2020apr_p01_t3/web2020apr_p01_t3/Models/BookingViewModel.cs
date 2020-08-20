using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web2020apr_p01_t3.Models
{
    public class BookingViewModel
    {
        
        public int bookingID { get; set; }
        public int customerID { get; set; }
        public int scheduleID { get; set; }
        public string customerName { get; set; }
        public string passpoerNum { get; set; }
        public string nationality { get; set; }
        public string seatClass { get; set; }
        public decimal amtPayable { get; set; }
        public string remark { get; set; }
        public DateTime bookingDate { get; set; }
    }
}

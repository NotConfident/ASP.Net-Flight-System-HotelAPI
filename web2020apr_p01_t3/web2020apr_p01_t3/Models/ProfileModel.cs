using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web2020apr_p01_t3.Models
{
    public class ProfileModel
    {
        public List<BookingDetails> details { get; set; }
        public CustomerModel customer { get; set; }
    }
}

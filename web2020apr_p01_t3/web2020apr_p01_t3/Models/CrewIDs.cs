using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web2020apr_p01_t3.Models
{
    public class CrewIDs
    {
        public int ID01 { get; set; }
        public int ID02 { get; set; }
        public int ID03 { get; set; }
        public int ID04 { get; set; }
        public int ID05 { get; set; }
        public int ID06{ get; set; }
        public List<int> crewID()
        {
            List<int> idList = new List<int>() { ID01, ID02, ID03, ID04, ID05, ID06 };
            return idList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRecord
{
    public class InitialInfoAboutClient
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string Date { get; set; }

        public override string ToString()
        {
            return "From City :" + FromCity + " to city :"+ToCity+ "Date :"+Date;
        }
    }
}

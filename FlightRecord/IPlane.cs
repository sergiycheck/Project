using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRecord
{
    interface IPlane
    {
        int MaxSpeed { get; set; }
        int MaxSitsHeight { get; set; }
        int MaxSitsWidth { get; set; }
        string PlaneImg { get; set; }
        string Firm { get; set; }
        string Name { get; set; }
        void Display();
        string ToString();
    }
}

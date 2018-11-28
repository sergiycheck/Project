using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlightRecord
{
    [XmlInclude(typeof(MediumPlane))]
    public class MediumPlane:Plane
    {
        private int _maxSpeed;
        public MediumPlane() { }
        public MediumPlane(int mspeed, int mSitsHeigth, int mSitsWidth, string firm, string name)
            : base(mspeed, mSitsHeigth, mSitsWidth, firm, name)
        {

        }
        public override int MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                if (value <= 1100)
                {
                    _maxSpeed = value;
                }
                else
                {
                    _maxSpeed = 1100;
                }
            }
        }


    }
}

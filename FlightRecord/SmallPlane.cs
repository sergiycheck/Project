using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlightRecord
{
    [XmlInclude(typeof(SmallPlane))]
    public class SmallPlane:Plane
    {
        private int _maxSpeed;
        
        public SmallPlane():base() { }
        public SmallPlane(int mspeed, int mSitsHeigth,int mSitsWidth, string firm, string name) 
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
                if (value <= 4000)
                {
                    _maxSpeed = value;
                }
                else
                {
                    _maxSpeed = 4000;
                }
            }
        }


    }
}

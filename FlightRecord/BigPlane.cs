using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlightRecord
{
    [XmlInclude(typeof(BigPlane))]
    public class BigPlane : Plane
    {
        private int _maxSpeed;
        public BigPlane() { }
        public BigPlane(int mspeed, int mSitsHeigth, int mSitsWidth, string firm, string name)
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
                if (value <= 900)
                {
                    _maxSpeed = value;
                }
                else
                {
                    _maxSpeed = 900;
                }
            }
        }



    }
}

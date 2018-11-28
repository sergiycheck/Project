using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FlightRecord
{
    [XmlRoot("Plane")]
    [XmlInclude(typeof(SmallPlane))]
    [XmlInclude(typeof(MediumPlane))]
    [XmlInclude(typeof(BigPlane))]
    [XmlInclude(typeof(Plane))]
    [Serializable]
    public abstract class Plane : Base<Plane>, IPlane, IComparable
    {

        public abstract int MaxSpeed { get; set; }
        public int MaxSitsHeight { get; set; }
        public int MaxSitsWidth { get; set; }
        public string Firm { get; set; }
        public string Name { get; set; }
        public string PlaneImg { get; set; }
        Guid key;
        FormPlane formForPlane;
        public Plane()
        {

        }
        public Plane(int mspeed, int msitsHeight, int msitsWidth, string firm, string name)
        {
            MaxSpeed = mspeed;
            MaxSitsHeight = msitsHeight;
            MaxSitsWidth = msitsWidth;
            Firm = firm;
            Name = name;
            key = Guid.NewGuid();

        }
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Plane otherPlane = obj as Plane;
            if (otherPlane != null)
                return this.MaxSpeed.CompareTo(otherPlane.MaxSpeed);
            return 0;
        }
        // compare by sits
        public void SetSitsForClient(Client client)
        {
            if (formForPlane != null)
            {
                formForPlane.ShowDialog();
                formForPlane.SetSits(client);
            }
            else
            {
                formForPlane = new FormPlane(PlaneImg, MaxSitsHeight, MaxSitsWidth);
                formForPlane.Controls.Find("labelNameOfPlane", false)[0].Text = "Name : " + Name + ". Firm : " + Firm;
                formForPlane.ShowDialog();
                formForPlane.SetSits(client);
                
            }       
            
        }
        public virtual void Display()
        {
            formForPlane = new FormPlane(PlaneImg, MaxSitsHeight, MaxSitsWidth);
            formForPlane.Controls.Find("labelNameOfPlane", false)[0].Text = "Name : "+Name+". Firm : "+Firm;
            formForPlane.ShowDialog();
        }
        public override string ToString()
        {
            return "Max speed : " + MaxSpeed + ", max place : " + MaxSitsHeight * MaxSitsWidth + ", name : " + Name + ", firm : " + Firm;
        }
    }
}

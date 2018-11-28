using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FlightRecord
{
    public class Journey:Base<Journey>
    {  
        public string ID { get; } = GenerateID();
        public string Date { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
        [XmlIgnore]
        public List<Client> clients = new List<Client>();
        [XmlIgnore]
        public List<Plane> Planes = new List<Plane>();
        public Journey() { }
        public Journey(string fromCity, string toCity, string date)
        {
            FromCity = fromCity;
            ToCity = toCity;
            Date = date;
            
        }
        public Journey(string fromCity, string toCity, string date,string time,string price)
        {
            FromCity = fromCity;
            ToCity = toCity;
            Date = date;
            Time = time;
            Price = price;
            
        }
        public override string ToString()
        {

            return " Date : " + Date + " from city : " + FromCity + " to city : " + ToCity+" at "+Time+" Price "+Price+"\n";
        }
        
        private static string GenerateID()
        {
            Guid key = Guid.NewGuid();
            return key.ToString().ToUpper();
        }
        public Client GetClientByID(Guid Id)
        {
            foreach (Client client in clients)
            {
                if (Id == client.ID)
                {
                    return client;
                }
            }
            MessageBox.Show("There is no such client");
            return null;
        }
        
    }
}

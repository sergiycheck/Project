using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace FlightRecord
{
    [XmlRoot("Client")]
    [XmlInclude(typeof(Client))]
    [Serializable]
    [DataContract]
    public class Client:Base<Client>
    {
        public Client() { }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public readonly Guid ID;
        
        public List<string> Sits = new List<string>();
        
        public Pannier ClientPannier = new Pannier();
        
        public Plane Plane { get; set; }

        public Client(string fname, string lname, string email, string password)
        {
            FName = fname;
            LName = lname;
            Email = email;
            Password = password;
            ID = Guid.NewGuid();
        }
        
        public static Client operator +(Client client1, Client client2)
        {
            client1.FName = client2.FName;
            client1.LName = client2.LName;
            client1.Email = client2.Email;
            client1.Password = client2.Password;
            return client1;
        }
        public static Client FindClient(string ID)
        {
            foreach (Client client in Items)
            {
                if (client.ID.ToString() == ID)
                {
                    return client;
                }
            }
            MessageBox.Show("There is not such client");
            return null;
        }
        public static string ShowClients()
        {
            string info = "";
            foreach (Client client in Items)
            {
                info += client.ToString()+"Id :"+client.ID.ToString()+"\n";
            }
            return info;
        }
        public override string ToString()
        {
            string allJourneys= "";

            foreach (Journey journey in ClientPannier.journeysInPannier)
            {
                allJourneys += journey.ToString();
            }
            string sits = "";
            foreach (string sit in Sits)
            {
                sits +=" Sit number : "+sit;
            }
            return "Firs Name :" + FName + " last name :" + LName + " email :" + Email + " password :" + Password + " All journeys:" + allJourneys+" plane :"+Plane+" Sits : "+sits+"\n";
        }


    }
    
}

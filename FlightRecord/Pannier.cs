using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlightRecord
{
    [Serializable]
    public class Pannier
    {
        public List<Journey> journeysInPannier = new List<Journey>();

        public Pannier() { }

        public void AddJourney(string fromCity, string toCity, string date)
        {
            if (JourneysManager.FindJourney(fromCity, toCity, date))
            {
                string timeAndPrice = JourneysManager.FindJourneyTimeAndPrice(fromCity, toCity, date);
                string[] ArrTimeAndPrice = timeAndPrice.Split(' ');
                string time = ArrTimeAndPrice[0];
                string price = ArrTimeAndPrice[1];
                Journey journeyAdd = new Journey(fromCity, toCity, date, time, price);
                journeysInPannier.Add(journeyAdd);
                MessageBox.Show("You have added journey to your list in pannier");
            }
            else
            {
                MessageBox.Show("Such journey is not available");
            }


        }
        public Journey GetJourney(string fromCity, string toCity, string date)
        {
            foreach (Journey journey in journeysInPannier)
            {
                if (journey.FromCity == fromCity
                    && journey.ToCity == toCity
                    && journey.Date == date
                    )
                {
                    return journey;
                }
            }
            MessageBox.Show("There is not such journey");
            return null;
        }

        public void DeleteJourney(string ID)
        {
            foreach (Journey journeyToDel in journeysInPannier)
            {
                if (journeyToDel.ID == ID)
                {
                    journeysInPannier.Remove(journeyToDel);
                    MessageBox.Show("You have removed journey from your list in pannier");
                }
            }
        }

        public string ShowJourneys()
        {
            string info = "";
            foreach (Journey journey in journeysInPannier)
            {
               info +=journey.ToString();
            }
            return info;
        }
    }
}
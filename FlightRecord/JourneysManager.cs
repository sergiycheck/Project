using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlightRecord
{
    public class JourneysManager:Base<JourneysManager>
    {
        //public static List<Journey>journeys= new List<Journey>();
        

        public static Journey DeleteJourney(string ID)
        {
            if (Journey.Items== null)
            {
                return null;
            }
            else
            {
                foreach (Journey journey in Journey.Items)
                {
                    if (journey.ID == ID)
                    {
                        Journey.Items.Remove(journey);
                    }
                }
                
            }
            return null;

        }
        public static Journey FindJourney(string ID)
        {
            foreach (Journey journey in Journey.Items)
            {
                if (journey.ID == ID)
                {
                    return journey;
                }
            }
            return null;
        }
        public static bool FindJourney(string fromCity, string toCity, string date)
        {
            foreach (Journey journey in Journey.Items)
            {
                if (journey.FromCity == fromCity
                    && journey.ToCity == toCity
                    && journey.Date == date
                    )
                {
                    return true;
                }
            }
            return false;
        }
        public static Journey GetJourney(string fromCity, string toCity, string date)
        {
            foreach (Journey journey in Journey.Items)
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
        public static string FindJourneyTimeAndPrice(string fromCity, string toCity, string date)
        {
            foreach (Journey journey in Journey.Items)
            {
                if (journey.FromCity == fromCity
                    && journey.ToCity == toCity
                    && journey.Date == date
                    )
                {
                    return journey.Time + " " + journey.Price;
                }
            }
            return "";
        }
        public static string ShowJourneys()
        {
            string allJourneys= "";
            if (Journey.Items != null)
            {
                foreach (Journey journey in Journey.Items)
                {
                    allJourneys+= journey.ID+"\n" + journey.ToString();
                }
            }
            return allJourneys;
        }
        public static void AddJourney(string fromCity, string toCity, string date,string time, string price,List<Plane> planes)
        {
            Journey journey = new Journey(fromCity, toCity, date, time, price);
            journey.Planes = planes;

        }
    }
}
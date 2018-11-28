
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlightRecord
{
    public class JourneyManager : AbJourneysManager
    {
        public override void AddJourney(string fromCity, string toCity, string date)
        {
            base.AddJourney(fromCity, toCity, date);
            MessageBox.Show("You have added journey to all list of Journeys");
        }

        public override Journey DeleteJourney(string ID)
        {
            MessageBox.Show("You have deleted journey from all list of Journeys");
            return base.DeleteJourney(ID);
            
        }
        public override string ShowJourneys()
        {
            return base.ShowJourneys();
        }
        public override Journey FindJourney(string ID)
        {
            return base.FindJourney(ID);
        }

    }
}
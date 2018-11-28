using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightRecord
{
    public partial class FormJourneysClients : Form
    {
        public FormJourneysClients(List<Journey> journeys, List<Client> clients)
        {
            InitializeComponent();

            SetListBox<Journey>(lbJourneys, journeys);
            SetListBox<Client>(lbClients, clients);
        }
        public static void SetListBox<T>(ListBox listBox, List<T> items)
        {
            listBox.DataSource = null;
            listBox.DataSource = items;
        }

        private void lbJourneys_SelectedIndexChanged(object sender, EventArgs e)
        {
            Journey journey = (Journey)lbJourneys.SelectedItem;
            SetListBox<Client>(lbClientsOfSelectedJourney, journey.clients);
        }

        private void lbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client client = (Client)lbClients.SelectedItem;
            SetListBox<Journey>(lbJourneysOfSelectedClient, client.ClientPannier.journeysInPannier);
        }
    }
}

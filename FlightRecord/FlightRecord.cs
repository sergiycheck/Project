using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class FlightRecord : Form
    {
        public FlightRecord()
        {
            InitializeComponent();

        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            string fromCity = comboBoxFromCity.Text;
            string toCity = comboBoxToCity.Text;
            string date = comboBoxDateTime.Text;
            InitialInfoAboutClient infoClient = new InitialInfoAboutClient();
            infoClient.FromCity = fromCity;
            infoClient.ToCity = toCity;
            infoClient.Date = date;
 
            string journeyTime = JourneysManager.GetJourney(fromCity, toCity, date).Time;
            string journeyPrice = JourneysManager.GetJourney(fromCity, toCity, date).Price;
            
            comboBoxFromCity.Text = "";
            comboBoxToCity.Text = "";
            comboBoxDateTime.Text = "";
            InitialInfoAboutJourney.TemporaryJourney.Add(JourneysManager.GetJourney(fromCity, toCity, date));
            RefreshLB<Journey>(lbClientJourneys, InitialInfoAboutJourney.TemporaryJourney);
        }
        private void RefreshLB<T>(ListBox listBox,List<T>Items)
        {
            listBox.DataSource = null;
            listBox.DataSource = Items;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fromCity = txtBoxAddFromCity.Text;
            string toCity = txtBoxAddToCity.Text;
            string date = dateTimePickerManage.Text;
            string time = textBoxTimeManage.Text;
            string price = textBoxPrice.Text;
            var Ntypeplanes = lbJourneyPlane.SelectedItems;
            List<Plane> planes = new List<Plane>();
            foreach (Plane plane in Ntypeplanes)
            {
                planes.Add((Plane)plane);
            }
            JourneysManager.AddJourney(fromCity, toCity, date, time, price, planes);
            txtBoxAddFromCity.Text = "";
            txtBoxAddToCity.Text = "";
            dateTimePickerManage.Text = "";
            textBoxTimeManage.Text = "";
            textBoxPrice.Text = "";

            comboBoxFromCity.Items.Add(fromCity);
            comboBoxToCity.Items.Add(toCity);
            comboBoxDateTime.Items.Add(date);
            lbJourneyPlane.DataSource = null;

        }

        private void btnShowJ_Click(object sender, EventArgs e)
        {
            RefreshLB<Journey>(listBoxJourneys, Journey.Items);
            
        }

        private void BtnDelJourney_Click(object sender, EventArgs e)
        {
            string journeyToDelId = txtBoxIdjourneyToDel.Text;
            Journey delJourney = JourneysManager.DeleteJourney(journeyToDelId);

            comboBoxFromCity.Items.Remove(delJourney.FromCity);
            comboBoxToCity.Items.Remove(delJourney.ToCity);
            comboBoxDateTime.Items.Remove(delJourney.Date);
            

        }

        private void btnReWrite_Click(object sender, EventArgs e)
        {
            Journey findJourney = JourneysManager.FindJourney(textBoxIdOfJourneyToFind.Text);

            comboBoxFromCity.Items.Remove(findJourney.FromCity);
            comboBoxToCity.Items.Remove(findJourney.ToCity);
            comboBoxDateTime.Items.Remove(findJourney.Date);

            findJourney.ToCity = textBoxRewToCity.Text;
            findJourney.FromCity = textBoxRewFromCity.Text;
            findJourney.Date = dateTimePickerRewDate.Text;

            comboBoxFromCity.Items.Add(findJourney.FromCity);
            comboBoxToCity.Items.Add(findJourney.ToCity);
            comboBoxDateTime.Items.Add(findJourney.Date);

            textBoxRewFromCity.Text = "";
            textBoxRewToCity.Text = "";
            dateTimePickerRewDate.Text = "";

            textBoxIdOfJourneyToFind.Text = "";

        }

        private void btnFindJourney_Click(object sender, EventArgs e)
        {
            Journey findJourney = JourneysManager.FindJourney(textBoxIdOfJourneyToFind.Text);
            textBoxRewFromCity.Text = findJourney.FromCity;
            textBoxRewToCity.Text = findJourney.ToCity;
            dateTimePickerRewDate.Text = findJourney.Date;
        }
        
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string FirstName = textBoxFirstNameClient.Text;
            string LastName = textBoxLastNameClient.Text;
            string Email = textBoxEmailClient.Text;
            string Password = textBoxPasswordClient.Text;
            
            Client client = new Client(FirstName, LastName, Email, Password);
            
            Pannier pannier = new Pannier();
            string fromCity = "";
            string toCity = "";
            string date = "";

            
            foreach (Journey Temjourney in InitialInfoAboutJourney.TemporaryJourney)
            {
                fromCity = Temjourney.FromCity;
                toCity = Temjourney.ToCity;
                date = Temjourney.Date;

                JourneysManager.GetJourney(fromCity, toCity, date).clients.Add(client);
                pannier.journeysInPannier.Add(JourneysManager.GetJourney(fromCity, toCity, date));
                client.ClientPannier = pannier;
                comboBoxClientId.Items.Add(client.ID.ToString());

                List<Plane> planes = JourneysManager.GetJourney(fromCity, toCity, date).Planes;
                foreach (Plane plane in planes)
                {
                    if (plane is BigPlane)
                    {
                        if (checkBoxBig.Checked)
                        {
                            plane.SetSitsForClient(client);
                            client.Plane = plane;
                        }

                    }
                    if (plane is MediumPlane)
                    {
                        if (checkBoxMiddle.Checked)
                        {
                            plane.SetSitsForClient(client);
                            client.Plane = plane;
                        }
                            

                    }
                    if (plane is SmallPlane)
                    {
                        if (checkBoxSmall.Checked)
                        {
                            plane.SetSitsForClient(client);
                            client.Plane = plane;
                        }
                            

                    }
                }

                
            }

            textBoxFirstNameClient.Text = "";
            textBoxLastNameClient.Text = "";
            textBoxEmailClient.Text = "";
            textBoxPasswordClient.Text = "";
            

            MessageBox.Show(client.ToString());
            MessageBox.Show("You are registered");

            lbClientJourneys.DataSource = null;
            InitialInfoAboutJourney.TemporaryJourney = new List<Journey>();
        }

        private void btnFindClientById_Click(object sender, EventArgs e)
        {
            string ID = textBoxClientId.Text.ToString();
            richTextBoxInfoClient.Text = Client.FindClient(ID).ToString();
        }

        private void btnAllClients_Click(object sender, EventArgs e)
        {
            RefreshLB<Client>(listBoxClients, Client.Items);
        }

        private void btnAddPlane_Click(object sender, EventArgs e)
        {
            string PlaneName = textBoxPlaneName.Text;
            string PlaneFirm = textBoxPlaneFirm.Text;
            int PlaneMaxSpeed = Convert.ToInt32(textBoxPlaneMaxSpeed.Text);
            int PlaneMaxFreeSitsWidth = Convert.ToInt32(textBoxPlaneMaxFreeSitsWidth.Text);
            int PlaneMaxFreeSitsHeigth = Convert.ToInt32(textBoxPlaneMaxFreeSitsHeigth.Text);
            Plane Plane;
            
            if (PlaneMaxSpeed <= 700)
            {
                Plane = new BigPlane(PlaneMaxSpeed, PlaneMaxFreeSitsWidth, PlaneMaxFreeSitsHeigth, PlaneFirm, PlaneName);
                Plane.PlaneImg = @"C:\Users\Серий\source\repos\FlightRecord\FlightRecord\objects\BigPlane.jpg";
                Plane.Display();
                
            }
            else if (PlaneMaxSpeed > 700 && PlaneMaxSpeed <= 1000)
            {
                Plane = new MediumPlane(PlaneMaxSpeed, PlaneMaxFreeSitsWidth, PlaneMaxFreeSitsHeigth, PlaneFirm, PlaneName);
                Plane.PlaneImg = @"C:\Users\Серий\source\repos\FlightRecord\FlightRecord\objects\MediumPlane.jpg";
                Plane.Display();
                
            }
            else if (PlaneMaxSpeed > 1000 && PlaneMaxSpeed <= 1300)
            {
                Plane = new SmallPlane(PlaneMaxSpeed, PlaneMaxFreeSitsWidth, PlaneMaxFreeSitsHeigth, PlaneFirm, PlaneName);
                Plane.PlaneImg = @"C:\Users\Серий\source\repos\FlightRecord\FlightRecord\objects\SmallPlane.jpg";
                Plane.Display();
                
            }
            else if (PlaneMaxSpeed >= 1300)
            {
                Plane = new SmallPlane(PlaneMaxSpeed, PlaneMaxFreeSitsWidth, PlaneMaxFreeSitsHeigth, PlaneFirm, PlaneName);
                Plane.PlaneImg = @"C:\Users\Серий\source\repos\FlightRecord\FlightRecord\objects\HigthSpeedPlane.jpg";
                Plane.Display();
                
            }


            textBoxPlaneName.Text="";
            textBoxPlaneFirm.Text = "";
            textBoxPlaneMaxSpeed.Text = "";
            textBoxPlaneMaxFreeSitsWidth.Text = "";
            textBoxPlaneMaxFreeSitsHeigth.Text = "";
            RefreshLB<Plane>(lbJourneyPlane, Plane.Items);
            
        }

        private void btnShowPlanes_Click(object sender, EventArgs e)
        {
            Plane.Items.Sort();
            RefreshLB<Plane>(lbPlanes, Plane.Items);
        }

        private void btnShowJourneysAndClients_Click(object sender, EventArgs e)
        {
            FormJourneysClients form = new FormJourneysClients(Journey.Items,Client.Items);
            form.ShowDialog();
        }

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Серий\source\copies\FlightRecord\objects\Clients.xml";
            Client[] clients = new Client[Client.Items.Count];
            for (int i = 0; i < clients.Count(); i++)
                clients[i] = Client.Items[i];
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Client[]));
            WorkFile(xmlSerializer, filePath, clients, true, typeof(Client));
        }
        public void WorkFile<U>(XmlSerializer formatter, string filePath, U Items, bool chose,Type type)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            if (chose)
            {
                formatter.Serialize(fileStream, Items);
                MessageBox.Show("Object is serialized");
            }
            else
            {
                if (type.Name == "Client")
                {
                    Client[] desirializedItems = formatter.Deserialize(fileStream) as Client[];
                    for (int i = 0; i < desirializedItems.Count(); i++)
                        Client.Items[i] = desirializedItems[i];
                    RefreshLB<Client>(listBoxClients, Client.Items);
                    
                }
                else if(type.Name == "Plane")
                {
                    Plane[] desirializedItems = formatter.Deserialize(fileStream) as Plane[];
                    for (int i = 0; i < desirializedItems.Count(); i++)
                        Plane.Items[i] = desirializedItems[i];
                    RefreshLB<Plane>(lbPlanes, Plane.Items);
                    
                }
                else if (type.Name == "Journey")
                {
                    Journey[] desirializedItems = formatter.Deserialize(fileStream) as Journey[];
                    for (int i = 0; i < desirializedItems.Count(); i++)
                        Journey.Items[i] = desirializedItems[i];
                    RefreshLB<Journey>(listBoxJourneys, Journey.Items);
                    
                }
                MessageBox.Show("Object is desirialized");
            }

            fileStream.Close();
        }

        private void btnPlaneSerialize_Click_1(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Серий\source\copies\FlightRecord\objects\Planes.xml";
            Plane[] planes = new Plane[Plane.Items.Count];
            for (int i = 0; i < planes.Count(); i++)
                planes[i] = Plane.Items[i];
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Plane[]));
            WorkFile(xmlSerializer, filePath, planes, true, typeof(Plane));
        }
        private void btnDeserializePlanes_Click_1(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Серий\source\copies\FlightRecord\objects\Planes.xml";
            Plane[] planes = new Plane[Plane.Items.Count];
            for (int i = 0; i < planes.Count(); i++)
                planes[i] = Plane.Items[i];
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Plane[]));
            WorkFile(xmlSerializer, filePath, planes, false, typeof(Plane));
        }


        private void btnJourneySerialize_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Серий\source\copies\FlightRecord\objects\Journey.xml";
            Journey[] journeys = new Journey[Journey.Items.Count];
            for (int i = 0; i < journeys.Count(); i++)
                journeys[i] = Journey.Items[i];
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Journey[]));
            WorkFile(xmlSerializer, filePath, journeys, true, typeof(Journey));
        }

        private void btnDeserializeJourney_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Серий\source\copies\FlightRecord\objects\Journey.xml";
            Journey[] journeys = new Journey[Journey.Items.Count];
            for (int i = 0; i < journeys.Count(); i++)
                journeys[i] = Journey.Items[i];
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Journey[]));
            WorkFile(xmlSerializer, filePath, journeys, false, typeof(Journey));
        }

        private void btnAddPlaneFromList_Click(object sender, EventArgs e)
        {
            List<Plane> planes = new List<Plane>();
            foreach (Plane plane in lbPlanes.SelectedItems)
                planes.Add(plane);
            RefreshLB<Plane>(lbJourneyPlane, planes);
        }

        private void btnAddJourneyFromList_Click(object sender, EventArgs e)
        {
            foreach (Journey journey in listBoxJourneys.SelectedItems)
            {
                comboBoxFromCity.Items.Add(journey.FromCity);
                comboBoxToCity.Items.Add(journey.ToCity);
                comboBoxDateTime.Items.Add(journey.Date);
                foreach (Plane plane in lbJourneyPlane.SelectedItems)
                    journey.Planes.Add(plane);
            }
            listBoxJourneys.DataSource = null;
            lbJourneyPlane.DataSource = null;
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\Серий\source\copies\FlightRecord\objects\Clients.xml";
            Client[] clients = new Client[Client.Items.Count];
            for (int i = 0; i < clients.Count(); i++)
                clients[i] = Client.Items[i];
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Client[]));
            WorkFile(xmlSerializer, filePath, clients, false, typeof(Client));
        }



        //add button to compare by sits
    }
}

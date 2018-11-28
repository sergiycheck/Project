namespace FlightRecord
{
    partial class FormJourneysClients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbJourneys = new System.Windows.Forms.ListBox();
            this.lbClients = new System.Windows.Forms.ListBox();
            this.lbClientsOfSelectedJourney = new System.Windows.Forms.ListBox();
            this.lbJourneysOfSelectedClient = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbJourneys
            // 
            this.lbJourneys.FormattingEnabled = true;
            this.lbJourneys.HorizontalScrollbar = true;
            this.lbJourneys.Location = new System.Drawing.Point(12, 12);
            this.lbJourneys.Name = "lbJourneys";
            this.lbJourneys.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbJourneys.Size = new System.Drawing.Size(371, 173);
            this.lbJourneys.TabIndex = 0;
            this.lbJourneys.SelectedIndexChanged += new System.EventHandler(this.lbJourneys_SelectedIndexChanged);
            // 
            // lbClients
            // 
            this.lbClients.FormattingEnabled = true;
            this.lbClients.HorizontalScrollbar = true;
            this.lbClients.Location = new System.Drawing.Point(408, 12);
            this.lbClients.Name = "lbClients";
            this.lbClients.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbClients.Size = new System.Drawing.Size(371, 173);
            this.lbClients.TabIndex = 1;
            this.lbClients.SelectedIndexChanged += new System.EventHandler(this.lbClients_SelectedIndexChanged);
            // 
            // lbClientsOfSelectedJourney
            // 
            this.lbClientsOfSelectedJourney.FormattingEnabled = true;
            this.lbClientsOfSelectedJourney.HorizontalScrollbar = true;
            this.lbClientsOfSelectedJourney.Location = new System.Drawing.Point(12, 191);
            this.lbClientsOfSelectedJourney.Name = "lbClientsOfSelectedJourney";
            this.lbClientsOfSelectedJourney.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbClientsOfSelectedJourney.Size = new System.Drawing.Size(371, 173);
            this.lbClientsOfSelectedJourney.TabIndex = 2;
            // 
            // lbJourneysOfSelectedClient
            // 
            this.lbJourneysOfSelectedClient.FormattingEnabled = true;
            this.lbJourneysOfSelectedClient.HorizontalScrollbar = true;
            this.lbJourneysOfSelectedClient.Location = new System.Drawing.Point(408, 191);
            this.lbJourneysOfSelectedClient.Name = "lbJourneysOfSelectedClient";
            this.lbJourneysOfSelectedClient.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbJourneysOfSelectedClient.Size = new System.Drawing.Size(371, 173);
            this.lbJourneysOfSelectedClient.TabIndex = 3;
            // 
            // FormJourneysClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 419);
            this.Controls.Add(this.lbJourneysOfSelectedClient);
            this.Controls.Add(this.lbClientsOfSelectedJourney);
            this.Controls.Add(this.lbClients);
            this.Controls.Add(this.lbJourneys);
            this.Name = "FormJourneysClients";
            this.Text = "FormJourneysClients";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbJourneys;
        private System.Windows.Forms.ListBox lbClients;
        private System.Windows.Forms.ListBox lbClientsOfSelectedJourney;
        private System.Windows.Forms.ListBox lbJourneysOfSelectedClient;
    }
}
namespace FlightRecord
{
    partial class FormPlane
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
            this.pictureBoxPlane = new System.Windows.Forms.PictureBox();
            this.labelNameOfPlane = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlane)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPlane
            // 
            this.pictureBoxPlane.Location = new System.Drawing.Point(12, 41);
            this.pictureBoxPlane.Name = "pictureBoxPlane";
            this.pictureBoxPlane.Size = new System.Drawing.Size(377, 321);
            this.pictureBoxPlane.TabIndex = 0;
            this.pictureBoxPlane.TabStop = false;
            // 
            // labelNameOfPlane
            // 
            this.labelNameOfPlane.AutoSize = true;
            this.labelNameOfPlane.Location = new System.Drawing.Point(127, 25);
            this.labelNameOfPlane.Name = "labelNameOfPlane";
            this.labelNameOfPlane.Size = new System.Drawing.Size(35, 13);
            this.labelNameOfPlane.TabIndex = 1;
            this.labelNameOfPlane.Text = "Name";
            // 
            // FormPlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 374);
            this.Controls.Add(this.labelNameOfPlane);
            this.Controls.Add(this.pictureBoxPlane);
            this.Name = "FormPlane";
            this.Text = "FormPlane";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPlane;
        private System.Windows.Forms.Label labelNameOfPlane;
    }
}
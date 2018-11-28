using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FlightRecord
{
    public partial class FormPlane : Form
    {
        public static List<Button> buttons = new List<Button>();
       
        public FormPlane(string planeImg, int maxSitsHeight,int maxSitsWidth)
        {
            InitializeComponent();

            Image image = Image.FromFile(planeImg);
            pictureBoxPlane.Image = SetImage(image);
            SetMaxSits(maxSitsHeight, maxSitsWidth);
        }
        public void SetSits(Client client)
        {
            foreach (Button btn in buttons)
            {
                if (btn.BackColor == Color.Red && btn.Enabled == true)
                {
                    client.Sits.Add(btn.Text);
                }
            }
            foreach (Button btn in buttons)
            {
                if (btn.BackColor == Color.Red)
                {
                    btn.Enabled = false;
                }
            }
        }
        public Bitmap SetImage(Image image)
        {
            Rectangle rect = new Rectangle(0, 0, pictureBoxPlane.Width, pictureBoxPlane.Height);
            Bitmap bitmap = new Bitmap(pictureBoxPlane.Width, pictureBoxPlane.Height);
            bitmap.SetResolution(image.HorizontalResolution,
                image.VerticalResolution);

            var gr = Graphics.FromImage(bitmap);
            gr.CompositingMode = CompositingMode.SourceCopy;
            gr.CompositingQuality = CompositingQuality.HighQuality;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
            using (var wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                gr.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
            return bitmap;
        }
        public void SetMaxSits(int maxSitsHeight,int maxSitsWidth)
        {
            int y = pictureBoxPlane.Width+50;
            int counter = 0;
            for (int i = 0; i < maxSitsHeight; i++)
            {
                counter++;
                for (int j = 0; j < maxSitsWidth; j++)
                {
                    
                    Button button = new Button()
                    {
                        Location = new Point(j * 30 + y, i * 30 + 60),
                        Size = new Size(30, 30),
                        BackColor = Color.Green,
                        Text = (counter).ToString(),
                        
                    };
                    button.Click += new EventHandler(button_Click);
                    
                    this.Controls.Add(button);
                    
                    buttons.Add(button);
                    counter++;
                }
                counter--;
                
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Red;
            button.Enabled = true;
            
        }

    }
}

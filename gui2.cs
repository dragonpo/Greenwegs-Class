using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace MSPaintGui
{

    public partial class Form1 : Form
    {
        Graphics g;
        Pen p = new Pen(Color.Black, 1);
        Point sp = new Point(0, 0);
        Point ep = new Point(0, 0);
        int k = 0;
        private bool opened;
        private Image file;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        void Openimage ()
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            {
                file = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = file;
                opened = true;
            }
        }

        void Filter2()
        {
            if (!opened)
            {
                MessageBox.Show("Open an Image then apply change");
            }
            else
            {
                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] { 0.393f, 0.349f + 0.5f, 0.272f, 0, 0}, //red
                    new float[] { 0.189f, 0.168f, 0.131f + 0.5f, 0, 0}, //blue
                    new float[] { 0.769f + 0.5f, 0.686f, 0.534f, 0, 0}, //green
                    new float[] { 0, 0, 0, 1, 0 }, //hue
                    new float[] { 0, 0, 0, 0, 1 }, //saturation
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }
        }

        void Hue()
        {
            float changered = redbar.Value * 0.1f;
            float changeblue = bluebar.Value * 0.1f;
            float changegreen = greenbar.Value * 0.1f;


            Clear();
            if (!opened)
            {

            }
            else
            {
                Image img = pictureBox1.Image;
                Bitmap bmpInverted = new Bitmap(img.Width, img.Height);

                ImageAttributes ia = new ImageAttributes();
                ColorMatrix cmPicture = new ColorMatrix(new float[][]
                {
                    new float[] { 1+changered, 0, 0, 0, 0}, //red
                    new float[] { 0, 1+changeblue, 0, 0, 0}, //blue
                    new float[] { 0, 0, 1+changegreen, 0, 0}, //green
                    new float[] { 0, 0, 0, 1, 0 }, //hue
                    new float[] { 0, 0, 0, 0, 1 }, //saturation
                });
                ia.SetColorMatrix(cmPicture);
                Graphics g = Graphics.FromImage(bmpInverted);
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pictureBox1.Image = bmpInverted;

            }
        }

        private void Reload()
        {
            throw new NotImplementedException();
        }

        void Clear()
        {
            if (!opened)
            {

            }
            else
            {
                if (opened)
                {
                    file = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = file;
                    opened = true;
                }
            }
        }

                void SaveImage()
        {
#pragma warning disable IDE0017 // Simplify object initialization
            SaveFileDialog sfd = new SaveFileDialog();
#pragma warning restore IDE0017 // Simplify object initialization
            sfd.Filter = "Images|*.png;* .bmp;* .jpg*;";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                pictureBox1.Image.Save(sfd.FileName, format);
            }
        }

        private void Openfile_Click(object sender, EventArgs e)
        {
            Openimage();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            redbar.Value = 0;
            greenbar.Value = 0;
            bluebar.Value = 0;
            Clear();
        }

        private void Trackerbar1_ValueChange(object sender, EventArgs e)
        {
            Hue();
        }

        private void TrackBar3_Scroll(object sender, EventArgs e)
        {
            Hue();
        }

        private void Redbar_Scroll(object sender, EventArgs e)
        {
            Hue();
        }

        private void Bluebar_Scroll(object sender, EventArgs e)
        {
            Hue();
        }

        private void Restart_Click(object sender, EventArgs e)
        {

        }

        private void Bluebar_Scroll_1(object sender, EventArgs e)
        {

        }

        private void Black_click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

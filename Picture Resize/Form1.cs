using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Picture_Resize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            string lokasi = file.InitialDirectory;
            lokasi = @"C:\Users\ardha\Desktop";
            file.Title = "Open Image File";
            file.Filter = "Image Files(*.jpg,*.png,*.tiff,*.bmp,*.gif)|*.jpg;*.png;*.tiff;*.bmp;*.gif";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                txtPathSelectectImage.Text = file.FileName;
            }
        }

        private void btnSaveAss_Click(object sender, EventArgs e)
        {
            if(txtPathSelectectImage.Text == "")
            {
                MessageBox.Show("Choose a pic for resize.");
            }
            if (txtHeight.Text == "" || txtWidth.Text == "")
            {
                MessageBox.Show("Choose a new sizes for the pic.");
            }
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = @"C:\Users\ardha\Desktop";
            saveFile.Filter = "Image  Files(*.jpg, *.png, *.tiff, *.bmp, *.gif) | *.jpg; *.png; *.tiff; *.bmp; *.gif";
            saveFile.Title = "Save an image";
            saveFile.AddExtension = true;
            saveFile.DefaultExt = "bmp";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(txtPathSelectectImage.Text);
                int new_height = Convert.ToInt32(txtHeight.Text);
                int new_width = Convert.ToInt32(txtWidth.Text);

                Bitmap new_image = new Bitmap(new_width, new_height);
                Graphics g = Graphics.FromImage((Image)new_image);
                g.InterpolationMode = InterpolationMode.High;
                g.DrawImage(image, 0, 0, new_width, new_height);

                new_image.Save(saveFile.FileName);


            }

            MessageBox.Show("Save successfully");


        }
    }
}

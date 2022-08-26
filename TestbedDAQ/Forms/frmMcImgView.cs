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

namespace TestbedDAQ.Forms
{
    public partial class frmMcImgView : Form
    {
        private string _sPath = string.Empty;
        private string _sName = string.Empty;
        private string _sFullPath = string.Empty;

        public frmMcImgView(string sPath, string sName)
        {
            InitializeComponent();

            this._sPath = sPath;
            this._sName = sName;
            this._sFullPath = sPath + "\\" + _sName;

            pictureBox1.MouseWheel += MouseWheelEvent;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frmMcImgView_Load(object sender, EventArgs e)
        {
            if (_sFullPath != string.Empty)
            {
                using (FileStream fsin = new FileStream(_sFullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                    pictureBox1.Image = Image.FromStream(fsin);
                    fsin.Close();
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {

            var pictureBox = sender as PictureBox;

            if (e.Delta > 0)
            {
                pictureBox.Size = new Size((int)(pictureBox.Width * 1.2), (int)(pictureBox.Height * 1.2));
            }
            else if (e.Delta < 0)
            {
                pictureBox.Size = new Size((int)(pictureBox.Width * 0.8), (int)(pictureBox.Height * 0.8));
            }
        }
    }
}

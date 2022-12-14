using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestbedDAQ.UseClass;

namespace TestbedDAQ.Forms
{
    public partial class frmMcImgView : Form
    {
        private string _Path = string.Empty;
        private string _Name = string.Empty;
        private string _FullPath = string.Empty;


        private int _XPos;
        private int _YPos;
        private bool _Dragging;

        TestbedFTP _Ftp = new TestbedFTP();


        public frmMcImgView(string sPath, string sName)
        {
            try
            {
                InitializeComponent();

                this._Path = sPath;
                this._Name = sName;
                this._FullPath = sPath + "\\" + _Name;

                pictureBox1.MouseWheel += MouseWheelEvent;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {
            
            }
        }

        private void frmMcImgView_Load(object sender, EventArgs e)
        {
            try
            {
                if (_FullPath != string.Empty)
                {
                    WebClient ftpClient = new WebClient();
                    ftpClient.Credentials = new NetworkCredential(_Ftp._UserId, _Ftp._Password);

                    byte[] imageByte = ftpClient.DownloadData(_Path + "/" + _Name);

                    MemoryStream mStream = new MemoryStream();
                    byte[] pData = imageByte;
                    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                    Bitmap bm = new Bitmap(mStream, false);
                    mStream.Dispose();

                    pictureBox1.Image = bm;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                var c = sender as PictureBox;
                if (null == c) return;
                _Dragging = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;
                _Dragging = true;
                _XPos = e.X;
                _YPos = e.Y;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var c = sender as PictureBox;
                if (!_Dragging || null == c) return;
                c.Top = e.Y + c.Top - _YPos;
                c.Left = e.X + c.Left - _XPos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source);
                return;
            }
            finally
            {

            }
        }
    }
}

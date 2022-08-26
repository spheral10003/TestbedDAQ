﻿using System;
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

namespace TestbedDAQ.Forms
{
    public partial class frmMcImgView : Form
    {
        private string _sPath = string.Empty;
        private string _sName = string.Empty;
        private string _sFullPath = string.Empty;

        public string host = "ftp://f1lab.co.kr";
        public string UserId = "ftpUser";
        public string Password = "f1soft@95";

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
                WebClient ftpClient = new WebClient();
                ftpClient.Credentials = new NetworkCredential(UserId, Password);

                byte[] imageByte = ftpClient.DownloadData(_sPath + "/" +_sName);

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


        private int _xPos;
        private int _yPos;
        private bool _dragging;

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            var c = sender as PictureBox;
            if (null == c) return;
            _dragging = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _dragging = true;
            _xPos = e.X;
            _yPos = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var c = sender as PictureBox;
            if (!_dragging || null == c) return;
            c.Top = e.Y + c.Top - _yPos;
            c.Left = e.X + c.Left - _xPos;
        }
    }
}

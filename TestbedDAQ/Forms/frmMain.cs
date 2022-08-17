using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestbedDAQ.Forms
{
    public partial class frmMain : Form
    {
        private bool Check = false;

        private Motor _SpindleX;
        private Motor _SpindleY;

        private PLCAddressMap _PLCAddressMap;
        private MachineInformation _MachineInformation;
        private List<MachineInformation> _MachineInformationList;

        public PLCAddressMap PLCAddressMap { get => _PLCAddressMap; set => _PLCAddressMap = value; }
        public MachineInformation MachineInformation { get => _MachineInformation; set => _MachineInformation = value; }
        public List<MachineInformation> MachineInformationList { get => _MachineInformationList; set => _MachineInformationList = value; }

        public frmMain()
        {

            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbCompany.SelectedIndex = 0;
            pnlView.Controls.Clear();
            pnlView.Dock = DockStyle.Fill;

            _SpindleX = new Motor();


            frmMonitor frm = new frmMonitor();
            frm.Owner = this;
            frm.TopLevel = false;

            pnlView.Controls.Clear();
            pnlView.Controls.Add(frm);

            frm.Show();
        }

        private void InitInfo()
        {
            _SpindleX = new Motor();
            _SpindleY = new Motor();

            MachineInformation = new MachineInformation();
            PLCAddressMap = new PLCAddressMap();

            _SpindleX.Init();
            _SpindleY.Init();

            MachineInformation.Init();
            PLCAddressMap.init();

            GetMachineInfo();   

        }

        private void GetMachineInfo()
        {
            // todo 
            // DB 쿼리
            // list에 Add
        }


        private void lblMonitor_Click(object sender, EventArgs e)
        {
            frmMonitor frm = new frmMonitor();

            frm.Owner = this;
            frm.TopLevel = false;

            pnlView.Controls.Clear();
            pnlView.Controls.Add(frm);

            frm.Show();
        }

        private void lblMCManager_Click(object sender, EventArgs e)
        {
            frmMCManager frm = new frmMCManager();

            frm.Owner = this;
            frm.TopLevel = false;
            frm.MachineInformationList = MachineInformationList;
            
            //MachineInformationList = frm.MachineInformationList;
            

            pnlView.Controls.Clear();
            pnlView.Controls.Add(frm);

            frm.Show();
        }

        public void label3_Click(object sender, EventArgs e)
        {
            if(Check)
            {
                pnlView.Dock = DockStyle.Fill;
                
                Check = true;
            }
            else
            {
                pnlView.Dock = DockStyle.None;
                pnlView.Location = new Point(0, 0);
                pnlView.Size = new Size(1920, 1080);

                Check = true;
            }
            
        }


    }
}

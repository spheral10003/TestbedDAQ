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
using TestbedDAQ.UseClass;

namespace TestbedDAQ.Forms
{
    public partial class frmMain : Form
    {
        private bool _Check = false;
        private Form _ManuForm = new Form();
        private TestbedAPI _API = new TestbedAPI();

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
            Menu_Click(lblMonitor, null);
        }

        private void Menu_Click(object sender, EventArgs e)
        {

            switch (((Control)sender).Name)
            {
                
                case "lblMonitor":
                    
                    _ManuForm.Close();
                    pnlView.Controls.Clear();

                    
                    frmMonitor MonitorForm = new frmMonitor();
                    
                    MonitorForm.Owner = this;
                    MonitorForm.TopLevel = false;
                    MonitorForm.Location = new Point(0, 0);

                    _ManuForm = MonitorForm;

                    pnlView.Controls.Add(_ManuForm);
                    _ManuForm.Show();

                    _API.SelectScreen(lblMonitor, lblManager, true);

                    break;

                case "lblManager":
                
                    _ManuForm.Close();
                    pnlView.Controls.Clear();

                    frmMCManager ManagerForm = new frmMCManager();

                    ManagerForm.Owner = this;
                    ManagerForm.TopLevel = false;
                    ManagerForm.Location = new Point(0, 0);

                    _ManuForm = ManagerForm;

                    pnlView.Controls.Add(_ManuForm);
                    _ManuForm.Show();

                    _API.SelectScreen(lblMonitor, lblManager, false);

                    break;

            }
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

    }
}

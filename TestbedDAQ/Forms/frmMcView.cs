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
using Library;


namespace TestbedDAQ.Forms
{
    public partial class frmMcView : Form
    {
        private TestbedAPI _UseAPI;
        private ViewData _ViewData;

        public ViewData ViewData { get => _ViewData; set => _ViewData = value; }

        public frmMcView()
        {
            InitializeComponent();
        }

        private void frmMcView_Load(object sender, EventArgs e)
        {
            InitVariable();
            InitColtrol();
        }

        private void InitVariable()
        {
            ViewData = new ViewData();
            _UseAPI = new TestbedAPI();
        }


        private void InitColtrol()
        {
            lblMCName.Text = string.Empty;

            lblSpindleXRpm.Text = string.Empty;
            lblSpindleXCurrent.Text = string.Empty;
            lblSpindleXLoad.Text = string.Empty;
            lblSpindleXPeakLoad.Text = string.Empty;
            lblSpindleServoXPosition.Text = string.Empty;

            lblSpindleYRpm.Text = string.Empty;
            lblSpindleYCurrent.Text = string.Empty;
            lblSpindleYLoad.Text = string.Empty;
            lblSpindleYPeakLoad.Text = string.Empty;
            lblSpindleServoYPosition.Text = string.Empty;

            lblBedServoPosition.Text = string.Empty;
            lblGuideServoPosition.Text = string.Empty;
            lblAlarmMessage.Text = string.Empty;

            lblRunTime.Text = string.Empty;
            lblStopTime.Text = string.Empty;

            _UseAPI.MachineActiveChange(lblRun, false);
            _UseAPI.NetworkChange(lblNetworkStatus, false);
            _UseAPI.AlarmChange(lblAlarmNotice, lblRun, false);
            _UseAPI.AlarmFormChange(this, false);
        }

        private void DataView()
        {
            lblMCName.Text = _ViewData.MCName;

            lblSpindleXRpm.Text = _ViewData.SpindleX.Speed;
            lblSpindleXCurrent.Text = _ViewData.SpindleX.Current;
            lblSpindleXLoad.Text = _ViewData.SpindleX.CurrentLoad;
            lblSpindleXPeakLoad.Text = _ViewData.SpindleX.PeakLoad;
            lblSpindleServoXPosition.Text = _ViewData.SpindleServoX.Position;

            lblSpindleYRpm.Text = _ViewData.SpindleY.Speed;
            lblSpindleYCurrent.Text = _ViewData.SpindleY.Current;
            lblSpindleYLoad.Text = _ViewData.SpindleY.CurrentLoad; 
            lblSpindleYPeakLoad.Text = _ViewData.SpindleY.PeakLoad;
            lblSpindleServoYPosition.Text = _ViewData.SpindleServoY.Position;

            lblBedServoPosition.Text = _ViewData.BedServo.Position;
            lblGuideServoPosition.Text = _ViewData.GuideServo.Position;
            lblAlarmMessage.Text = _ViewData.MCStatus.AlarmDescription[int.Parse(_ViewData.MCStatus.AlarmCode)];

            lblRunTime.Text = _ViewData.MCStatus.RunningTime;
            lblStopTime.Text = _ViewData.MCStatus.StopTime;
        }

    }
}

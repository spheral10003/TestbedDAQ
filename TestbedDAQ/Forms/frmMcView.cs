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
    public partial class frmMcView : Form
    {
        private string _SpindleSpeed;
        private string _SpindleVolt;
        private string _SpindleCurrent;
        private string _SpindleCuttentLoad;
        private string _SpindlePeakLoad;
        private string _SpindleServoPos;
        private string _BedServoPos;

        public string SpindleSpeed 
        { 
            get => _SpindleSpeed; 
            set
            {
                _SpindleSpeed = value;
                //lblSpindleSpd.Text = value;
            }
        }


        public string SpindleVolt 
        { 
            get => _SpindleVolt; 
            set
            { 
                _SpindleVolt = value;
                //lblSpindleVolt.Text = value;
            }
        }

        public string SpindleCurrent 
        { 
            get => _SpindleCurrent; 
            set
            {
                _SpindleCurrent = value;
                //lblSpindleCurrent.Text = value;
            }
             
        }
        public string SpindleCuttentLoad 
        { 
            get => _SpindleCuttentLoad; 
            set
            {
                _SpindleCuttentLoad = value;
                //lblSpindleCurrentLoad.Text = value;
            }
        }
        public string SpindlePeakLoad 
        { 
            get => _SpindlePeakLoad; 
            set
            {
                _SpindlePeakLoad = value;
                //lblSpindlePeakLoad.Text = value;
            }
        }
        public string SpindleServoPos 
        { 
            get => _SpindleServoPos; 
            set
            {
                _SpindleServoPos = value;
                //lblSpindleServoPos.Text = value;
            }
        }
        public string BedServoPos 
        { 
            get => _BedServoPos; 
            set
            { 
                _BedServoPos = value;
                //lblBedServoPos.Text = value;    
            }
        }


        private TestbedAPI _UseAPI;


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
            _SpindleSpeed = string.Empty;
            _SpindleVolt = string.Empty;
            _SpindleCurrent = string.Empty;
            _SpindleCuttentLoad = string.Empty;
            _SpindlePeakLoad = string.Empty;
            _SpindleServoPos = string.Empty;
            _BedServoPos = string.Empty;

            _UseAPI = new TestbedAPI();
        }


        private void InitColtrol()
        {
            //lblSpindleSpd.Text = string.Empty;
            //lblSpindleVolt.Text = string.Empty;
            //lblSpindleCurrent.Text = string.Empty;
            //lblSpindleCurrentLoad.Text = string.Empty;
            //lblSpindlePeakLoad.Text = string.Empty;
            //lblSpindleServoPos.Text = string.Empty;
            //lblBedServoPos.Text = string.Empty;
            //lblAlarmMsg.Text = string.Empty;    

            //_UseAPI.MachineActiveChange(btnActive, false);
            //_UseAPI.NetworkChange(lblPlcConn, false);
            //_UseAPI.AlarmBackColorChange(lblAlarmFlag, false);
            //_UseAPI.AlarmBackColorChange(lblAlarmMsg, false);

        }

    }
}

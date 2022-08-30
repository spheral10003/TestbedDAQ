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

        public frmMain()
        {

            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitControls();

            

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
                    _ManuForm.Show();

                    pnlView.Controls.Add(_ManuForm);
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
                    _ManuForm.Show();

                    pnlView.Controls.Add(_ManuForm);
                    _API.SelectScreen(lblMonitor, lblManager, false);

                    break;

            }
        }

        private void InitControls()
        {
            frmCombo Combo = new frmCombo();

            Combo.Owner = this;
            Combo.TopLevel = false;
            Combo.Location = new Point(350, 20);
            Combo.Show();
            Combo.BringToFront();

            this.Controls.Add(Combo);
        }


        private void InitInfo()
        {
            GetMachineInfo();   
        }

        private void GetMachineInfo()
        {
            // todo 
            // DB 쿼리
            // list에 Add
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

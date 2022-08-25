using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace TestbedDAQ.Forms
{
    public partial class frmMCManager : Form
    {
        private List<MachineInformation> _MachineInformation;

        public List<MachineInformation> MachineInformationList { get => _MachineInformation; set => _MachineInformation = value; }


        public frmMCManager()
        {
            InitializeComponent();
        }

        private void frmMCManager_Load(object sender, EventArgs e)
        {
            frmMain frm = (frmMain)this.Owner;

            //frm.MachineInformationList = _MachineInformation;

            //frm.label3_Click(null, null);
        }
    }
}

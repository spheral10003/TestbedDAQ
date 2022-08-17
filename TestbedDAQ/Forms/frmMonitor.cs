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
    public partial class frmMonitor : Form
    {
        public frmMonitor()
        {
            InitializeComponent();
        }

        private void frmMonitor_MouseClick(object sender, MouseEventArgs e)
        {

            frmMain frm = (frmMain)this.Owner;

            frm.label3_Click(null,null);
        }
    }
}

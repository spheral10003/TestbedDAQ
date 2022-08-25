using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

            //frmMain frm = (frmMain)this.Owner;

        }

        private void frmMonitor_Load(object sender, EventArgs e)
        {
            frmMcView frm1 = new frmMcView();
            frm1.Owner = this;
            frm1.TopLevel = false;
            frm1.Location = new Point(20, 13);
            
            frmMcView frm2 = new frmMcView();
            frm2.Owner = this;
            frm2.TopLevel = false;
            frm2.Location = new Point(314 + 20, 13);

            frmMcView frm3 = new frmMcView();
            frm3.Owner = this;
            frm3.TopLevel = false;
            frm3.Location = new Point(314 * 2 + 20, 13);

            frmMcView frm4 = new frmMcView();
            frm4.Owner = this;
            frm4.TopLevel = false;
            frm4.Location = new Point(314 * 3 + 20, 13);

            frmMcView frm5 = new frmMcView();
            frm5.Owner = this;
            frm5.TopLevel = false;
            frm5.Location = new Point(314 * 4 + 20, 13);

            frmMcView frm6 = new frmMcView();
            frm6.Owner = this;
            frm6.TopLevel = false;
            frm6.Location = new Point(314 * 5 + 20, 13);


            frmMcView frm7 = new frmMcView();
            frm7.Owner = this;
            frm7.TopLevel = false;
            frm7.Location = new Point(20, 463);

            frmMcView frm8 = new frmMcView();
            frm8.Owner = this;
            frm8.TopLevel = false;
            frm8.Location = new Point(314 + 20, 463);

            frmMcView frm9 = new frmMcView();
            frm9.Owner = this;
            frm9.TopLevel = false;
            frm9.Location = new Point(314 * 2 + 20, 463);

            frmMcView frm10 = new frmMcView();
            frm10.Owner = this;
            frm10.TopLevel = false;
            frm10.Location = new Point(314 * 3 + 20, 463);

            frmMcView frm11 = new frmMcView();
            frm11.Owner = this;
            frm11.TopLevel = false;
            frm11.Location = new Point(314 * 4 + 20, 463);

            frmMcView frm12 = new frmMcView();
            frm12.Owner = this;
            frm12.TopLevel = false;
            frm12.Location = new Point(314 * 5 + 20, 463);

            this.Controls.Add(frm1);
            this.Controls.Add(frm2);
            this.Controls.Add(frm3);
            this.Controls.Add(frm4);
            this.Controls.Add(frm5);
            this.Controls.Add(frm6);
            this.Controls.Add(frm7);
            this.Controls.Add(frm8);
            this.Controls.Add(frm9);
            this.Controls.Add(frm10);
            this.Controls.Add(frm11);
            this.Controls.Add(frm12);
            
            frm1.Show();
            frm2.Show();
            frm3.Show();
            frm4.Show();
            frm5.Show();
            frm6.Show();
            frm7.Show();
            frm8.Show();
            frm9.Show();
            frm10.Show();
            frm11.Show();
            frm12.Show();
        }
    }
}

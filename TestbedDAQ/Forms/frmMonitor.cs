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
        private frmMcView[] frmView;

        public frmMonitor()
        {
            InitializeComponent();
        }

        private void frmMonitor_Load(object sender, EventArgs e)
        {
            AddForms();
        }

        private void AddForms()
        {
            int LocationX, LocationY;

            frmView = new frmMcView[12];

            this.SuspendLayout();

            LocationX = 20;
            LocationY = 13;

            for (int Idx = 0; Idx < 12; Idx++)
            {

                if (Idx >= 6)
                {
                    LocationX = (314 * (Idx - 6)) + 20;
                    LocationY = 463;
                }
                else
                {
                    LocationX = (314 * Idx) + 20;
                }

                frmView[Idx] = new frmMcView
                {
                    Owner = this,
                    TopLevel = false,
                    Location = new Point(LocationX, LocationY)
                };

                frmView[Idx].Show();



            }

            this.Controls.AddRange(this.frmView);

            this.ResumeLayout(false);
        }
    }
}

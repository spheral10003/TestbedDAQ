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
    public partial class frmCombo : Form
    {
        public string CompanyName { get; set; }

        private bool _Check;
        public frmCombo()
        {
            InitializeComponent();
        }

        private void Combo_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(42, 84, 191);
        }

        private void Combo_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(39, 50, 83);
        }

        private void ComboItem_Click(object sender, EventArgs e)
        {
            lblCombo.Text = ((Label)sender).Text;
            CompanyName = lblCombo.Text;
            this.Size = new Size(179, 41);


        }


        private void lblCombo_Click(object sender, EventArgs e)
        {
            if(_Check)
            {
                this.Size = new Size(179, 41);
                _Check = false;

            }
            else
            {
                this.Size = new Size(179, 165);
                _Check = true;
            }
            
        }

        private void frmCombo_Load(object sender, EventArgs e)
        {
            lblCombo.Text = "정남사업장";
            this.Size = new Size(179, 41);

            _Check = false;
        }
    }
}

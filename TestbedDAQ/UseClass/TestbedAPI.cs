using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestbedDAQ.UseClass
{
    public class TestbedAPI
    {
        public void NetworkChange(PictureBox pic, bool Enable)
        {
            if (Enable) pic.Image = Properties.Resources.RadioOn;
            else pic.Image = Properties.Resources.RadioOff;
        }

        public void NetworkChange(Label lbl, bool Enable)
        {
            if (Enable) lbl.Image = Properties.Resources.RadioOn;
            else lbl.Image = Properties.Resources.RadioOff;
        }

        public void MachineActiveChange(Button btn, bool Enable)
        {
            if (Enable)
            {
                btn.Text = "가동";
                btn.BackgroundImage = Properties.Resources.Button1;
            }
            else
            {
                btn.Text = "비가동";
                btn.BackgroundImage = Properties.Resources.Button2;
            }
        }

        public void AlarmBackColorChange(Label lbl, bool Enable)
        {
            if (Enable)
            {
                lbl.BackColor = Color.IndianRed;
            }
            else
            {
                lbl.BackColor = Color.FromArgb(60, 71, 93);
            }
        }

    }
}

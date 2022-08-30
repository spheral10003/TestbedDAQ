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
            if (Enable) pic.Image = Properties.Resources.icon_wifi_on;
            else pic.Image = Properties.Resources.icon_wifi_off;
        }

        public void NetworkChange(Label lbl, bool Enable)
        {
            if (Enable) lbl.Image = Properties.Resources.icon_wifi_on;
            else lbl.Image = Properties.Resources.icon_wifi_off;
        }

        public void MachineActiveChange(Button btn, bool Enable)
        {
            if (Enable)
            {
                btn.Text = "가동";
                btn.BackgroundImage = Properties.Resources.button_ing;
            }
            else
            {
                btn.Text = "비가동";
                btn.BackgroundImage = Properties.Resources.button_stop;
            }
        }

        public void MachineActiveChange(Label lbl, bool Enable)
        {
            if (Enable)
            {
                lbl.Image = Properties.Resources.button_ing;
            }
            else
            {
                lbl.Image = Properties.Resources.button_stop;
            }
        }

        public void AlarmChange(Label Alarm, Label Run, bool Enable)
        {
            if (Enable)
            {
                Alarm.Image = Properties.Resources.icon_notice_on;
                Run.Image = Properties.Resources.button_warring;
            }
            else
            {
                Alarm.Image = Properties.Resources.icon_notice_off;
                Run.Image = Properties.Resources.button_stop;
            }
        }

        public void AlarmFormChange(Form frm, bool Enable)
        {
            if (Enable)
            {
                frm.BackgroundImage = Properties.Resources.container_warning01;
                
            }
            else
            {
                frm.BackgroundImage = Properties.Resources.container;
                
            }
        }

        public void SelectScreen(Label Monitor, Label Manager, bool Enable)
        {
            if (Enable)
            {
                Monitor.Image = Properties.Resources.tab01_on;
                Manager.Image = Properties.Resources.tab02_off;
            }
            else
            {
                Monitor.Image = Properties.Resources.tab01_off;
                Manager.Image = Properties.Resources.tab02_on;
            }
        }
    }
}

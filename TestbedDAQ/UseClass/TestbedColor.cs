using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TestbedDAQ.UseClass
{
    public class TestbedColor
    {
        private static Color _red;
        private static Color _white;
        private static Color _black;

        public static Color Red
        {
            get { return _red = Color.FromArgb(255, 192, 192); }
            set { _red = value; }
        }

        public static Color White
        {
            get { return _white = Color.FromArgb(255, 255, 255); }
            set { _white = value; }
        }

        public static Color Black
        {
            get { return _black = Color.FromArgb(0, 0, 0); }
            set { _black = value; }
        }


        public TestbedColor()
        {

        }
    }
}

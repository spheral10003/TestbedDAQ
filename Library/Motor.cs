using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Motor : IMotor
    {
        private string _Speed;
        private string _Volt;
        private string _Current;
        private string _CuttentLoad;
        private string _PeakLoad;

        public string Speed { get => _Speed; set => _Speed = value; }
        public string Volt { get => _Volt; set => _Volt = value; }
        public string Current { get => _Current; set => _Current = value; }
        public string CuttentLoad { get => _CuttentLoad; set => _CuttentLoad = value; }
        public string PeakLoad { get => _PeakLoad; set => _PeakLoad = value; }

        public void Init()
        {
            _Speed = string.Empty;
            _Volt = string.Empty;
            _Current = string.Empty;
            _CuttentLoad = string.Empty;
            _PeakLoad = string.Empty;
        }

    }
}

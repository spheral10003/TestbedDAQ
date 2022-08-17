using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PLCAddressMap : IPLCAddress
    {
        // Bit
        private int _AutoStartAddress;      // 제품 가공 시작

        // Word
        private int _SpeedAddress;          // 현재 속도
        private int _VoltAddress;           // 현재 전압
        private int _CurrentAddress;        // 현재 전류
        private int _CurrentLoadAddress;    // 현재 부하
        private int _PeakLoadAddress;       // 피크 부하
        private int _MachiningTimeAddress;  // 가공 시간
        private int _AlarmCodeAddress;      // 알람 코드
        private int _ProductSizeAddress;    // 제품 가공 치수
        private int _CurrentSizeAddress;    // 현재 가공 치수
        private int _MachiningCountAddress; // 가공 횟수

        public int AutoStartAddress { get => _AutoStartAddress; set => _AutoStartAddress = value; }
        public int SpeedAddress { get => _SpeedAddress; set => _SpeedAddress = value; }
        public int VoltAddress { get => _VoltAddress; set => _VoltAddress = value; }
        public int CurrentAddress { get => _CurrentAddress; set => _CurrentAddress = value; }
        public int CurrentLoadAddress { get => _CurrentLoadAddress; set => _CurrentLoadAddress = value; }
        public int PeakLoadAddress { get => _PeakLoadAddress; set => _PeakLoadAddress = value; }
        public int MachiningTimeAddress { get => _MachiningTimeAddress; set => _MachiningTimeAddress = value; }
        public int AlarmCodeAddress { get => _AlarmCodeAddress; set => _AlarmCodeAddress = value; }
        public int ProductSizeAddress { get => _ProductSizeAddress; set => _ProductSizeAddress = value; }
        public int CurrentSizeAddress { get => _CurrentSizeAddress; set => _CurrentSizeAddress = value; }
        public int MachiningCountAddress { get => _MachiningCountAddress; set => _MachiningCountAddress = value; }

        public void init()
        {

        }
    }
}

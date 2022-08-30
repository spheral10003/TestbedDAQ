using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Motor : IMotor, IMotorAddress
    {
        private string _Speed;          // 현재 속도
        private string _Current;        // 현재 전류
        private string _CurrentLoad;    // 현재 부하
        private string _PeakLoad;       // 피크 부하
        private string _Position;       // 서보 모터 위치값
        private string _ErrorNumber;    // 서보 모터 에러 번호

        public string Speed { get => _Speed; set => _Speed = value; }
        public string Position { get => _Position; set => _Position = value; }
        public string Current { get => _Current; set => _Current = value; }
        public string CurrentLoad { get => _CurrentLoad; set => _CurrentLoad = value; }
        public string PeakLoad { get => _PeakLoad; set => _PeakLoad = value; }
        public string ErrorNumber { get => _ErrorNumber; set => _ErrorNumber = value; }


        private int _SpeedAddress;          // 현재 속도 주소
        private int _CurrentAddress;        // 현재 전류 주소
        private int _CurrentLoadAddress;    // 현재 부하 주소
        private int _PeakLoadAddress;       // 피크 부하 주소
        private int _PositionAddress;       // 서보 모터 위치값 주소
        private int _ErrerNumberAddress;    // 서보 모터 에러 번호 주소

        public int SpeedAddress { get => _SpeedAddress; set => _SpeedAddress = value; }
        public int CurrentAddress { get => _CurrentAddress; set => _CurrentAddress = value; }
        public int CurrentLoadAddress { get => _CurrentLoadAddress; set => _CurrentLoadAddress = value; }
        public int PeakLoadAddress { get => _PeakLoadAddress; set => _PeakLoadAddress = value; }
        public int PositionAddress { get => _PositionAddress; set => _PositionAddress = value; }
        public int ErrerNumberAddress { get => _ErrerNumberAddress; set => _ErrerNumberAddress = value; }

        public void Init()
        {
            _Speed = string.Empty;          // 현재 속도
            _Current = string.Empty;        // 현재 전류
            _CurrentLoad = string.Empty;    // 현재 부하
            _PeakLoad = string.Empty;       // 피크 부하
            _Position = string.Empty;       // 서보 모터 위치값
            _ErrorNumber = string.Empty;    // 서보 모터 에러 번호

            _SpeedAddress = 0;              // 현재 속도 주소
            _CurrentAddress = 0;            // 현재 전류 주소
            _CurrentLoadAddress = 0;        // 현재 부하 주소
            _PeakLoadAddress = 0;           // 피크 부하 주소
            _PositionAddress = 0;           // 서보 모터 위치값 주소
            _ErrerNumberAddress = 0;        // 서보 모터 에러 번호 주소

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MachineStatus : IMachineStatus, IPLCDataAddress
    {
        public enum ALARMTYPE
        {
            None,
            Waring,
            Error
        }

        private bool _Running = false;          // 가동 비가동
        private bool _Alarm = false;            // 알람 유무
        private string _AlarmCode;            // 설비 가동 시간
        private string _RunningTime;            // 설비 가동 시간
        private string _StopTime;               // 설비 비가동 시간
        private Dictionary<int, string> _AlarmDescription;       // 알람 코멘트
        private ALARMTYPE _AlarmType;           // 알람 타입

        public bool Running { get => _Running; set => _Running = value; }
        public bool Alarm { get => _Alarm; set => _Alarm = value; }
        public string AlarmCode { get => _AlarmCode; set => _AlarmCode = value; }
        public string RunningTime { get => _RunningTime; set => _RunningTime = value; }
        public string StopTime { get => _StopTime; set => _StopTime = value; }
        public ALARMTYPE AlarmType { get => _AlarmType; set => _AlarmType = value; }
        public Dictionary<int, string> AlarmDescription { get => _AlarmDescription; set => _AlarmDescription = value; }

        // Bit
        private int _AutoStartAddress;      // 제품 가공 시작

        // Word

        private int _MachiningTimeAddress;  // 가공 시간
        private int _AlarmCodeAddress;      // 알람 코드
        private int _ProductSizeAddress;    // 제품 가공 치수
        private int _CurrentSizeAddress;    // 현재 가공 치수
        private int _MachiningCountAddress; // 가공 횟수

        public int AutoStartAddress { get => _AutoStartAddress; set => _AutoStartAddress = value; }
        public int MachiningTimeAddress { get => _MachiningTimeAddress; set => _MachiningTimeAddress = value; }
        public int AlarmCodeAddress { get => _AlarmCodeAddress; set => _AlarmCodeAddress = value; }
        public int ProductSizeAddress { get => _ProductSizeAddress; set => _ProductSizeAddress = value; }
        public int CurrentSizeAddress { get => _CurrentSizeAddress; set => _CurrentSizeAddress = value; }
        public int MachiningCountAddress { get => _MachiningCountAddress; set => _MachiningCountAddress = value; }
        

        public virtual void Init()
        {
            _Running = false;               // 가동 비가동
            _Alarm = false;                 // 알람 유무
            _RunningTime = string.Empty; ;  // 설비 가동 시간
            _StopTime = string.Empty; ;     // 설비 비가동 시간
            _AlarmDescription.Clear();      // 알람 코멘트
            _AlarmType = ALARMTYPE.None;    // 알람 타입

            _AutoStartAddress = 0;          // 제품 가공 시작
            _MachiningTimeAddress = 0;      // 가공 시간
            _AlarmCodeAddress = 0;          // 알람 코드
            _ProductSizeAddress = 0;        // 제품 가공 치수
            _CurrentSizeAddress = 0;        // 현재 가공 치수
            _MachiningCountAddress = 0;     // 가공 횟수
        }
    }
}

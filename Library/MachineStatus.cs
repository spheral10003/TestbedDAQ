using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MachineStatus : IMachineStatus
    {
        public enum ALARMTYPE
        {
            None,
            Waring,
            Error
        }

        private bool _Running = false;          // 가동 비가동
        private bool _Alarm = false;            // 알람 유무
        private string _RunningTime;            // 설비 가동 시간
        private string _StopTime;               // 설비 비가동 시간
        private string _AlarmCode;              // 알람 코드
        private string _AlarmDescription;       // 알람 코멘트
        private ALARMTYPE _AlarmType;           // 알람 타입

        public bool Running { get => _Running; set => _Running = value; }
        public bool Alarm { get => _Alarm; set => _Alarm = value; }
        public string RunningTime { get => _RunningTime; set => _RunningTime = value; }
        public string StopTime { get => _StopTime; set => _StopTime = value; }
        public string AlarmCode { get => _AlarmCode; set => _AlarmCode = value; }
        public string AlarmDescription { get => _AlarmDescription; set => _AlarmDescription = value; }
        public ALARMTYPE AlarmType { get => _AlarmType; set => _AlarmType = value; }


    }
}

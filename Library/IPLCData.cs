using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IPLCData
    {
        // 데이터 프로퍼티
        string BedServoSpeed { get; set; }
        string BedServoPosition { get; set; }
        string GuideServoSpeed { get; set; }
        string GuideServoPosition { get; set; }

        string SpindleServoSpeed { get; set; }
        string SpindleServoPosition { get; set; }

        string SpindleXSpeed { get; set; }
        string SpindleXVolt { get; set; }
        string SpindleXCurrent { get; set; }
        string SpindleXCuttentLoad { get; set; }
        string SpindleXPeakLoad { get; set; }

        string SpindleYSpeed { get; set; }
        string SpindleYVolt { get; set; }
        string SpindleYCurrent { get; set; }
        string SpindleYCuttentLoad { get; set; }
        string SpindleYPeakLoad { get; set; }


        // Events
        event EventHandler RunEvent;
        event EventHandler StopEvent;
        event EventHandler AlarmEvent;
        
        // 초기화 
        void Init();
        void OnRun();
        void OnStop();  
        void OnAlarm();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class PLCData:IPLCData
    {
        private string _BedServoSpeed;
        private string _BedServoPosition;

        private string _GuideServoSpeed;
        private string _GuideServoPosition;

        private string _SpindleServoSpeed;
        private string _SpindleServoPosition;

        private string _SpindleXSpeed;
        private string _SpindleXVolt;
        private string _SpindleXCurrent;
        private string _SpindleXCuttentLoad;
        private string _SpindleXPeakLoad;

        private string _SpindleYSpeed;
        private string _SpindleYVolt;
        private string _SpindleYCurrent;
        private string _SpindleYCuttentLoad;
        private string _SpindleYPeakLoad;

        private Motor BedServo;
        
        public string BedServoSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string BedServoPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleServoSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string GuideServoSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string GuideServoPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleServoPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleXSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleXVolt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleXCurrent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleXCuttentLoad { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleXPeakLoad { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleYSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleYVolt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleYCurrent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleYCuttentLoad { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SpindleYPeakLoad { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public event EventHandler RunEvent;
        public event EventHandler StopEvent;
        public event EventHandler AlarmEvent;

        public void Init()
        {
            _BedServoSpeed = string.Empty;
            _BedServoPosition = string.Empty;

            _GuideServoSpeed = string.Empty;
            _GuideServoPosition = string.Empty;

            _SpindleServoSpeed = string.Empty;
            _SpindleServoPosition = string.Empty;

            _SpindleXSpeed = string.Empty;
            _SpindleXVolt = string.Empty;
            _SpindleXCurrent = string.Empty;
            _SpindleXCuttentLoad = string.Empty;
            _SpindleXPeakLoad = string.Empty;

            _SpindleYSpeed = string.Empty;
            _SpindleYVolt = string.Empty;
            _SpindleYCurrent = string.Empty;
            _SpindleYCuttentLoad = string.Empty;
            _SpindleYPeakLoad = string.Empty;
        }

        public void OnAlarm()
        {
            throw new NotImplementedException();
        }

        public void OnRun()
        {
            throw new NotImplementedException();
        }

        public void OnStop()
        {
            throw new NotImplementedException();
        }
    }
}

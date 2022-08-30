using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ViewData
    {
        private string _Ip;
        private int _Port;
        private string _MCName;

        private Motor _SpindleX = new Motor();
        private Motor _SpindleY = new Motor();
        private Motor _SpindleServoX = new Motor();
        private Motor _SpindleServoY = new Motor();
        private Motor _BedServo = new Motor();
        private Motor _GuideServo = new Motor();
        private MachineStatus _MCStatus = new MachineStatus();


        public string Ip { get => _Ip; set => _Ip = value; }
        public int Port { get => _Port; set => _Port = value; }

        public Motor SpindleX { get => _SpindleX; set => _SpindleX = value; }
        public Motor SpindleY { get => _SpindleY; set => _SpindleY = value; }
        public Motor SpindleServoX { get => _SpindleServoX; set => _SpindleServoX = value; }
        public Motor SpindleServoY { get => _SpindleServoY; set => _SpindleServoY = value; }
        public Motor BedServo { get => _BedServo; set => _BedServo = value; }
        public Motor GuideServo { get => _GuideServo; set => _GuideServo = value; }
        public MachineStatus MCStatus { get => _MCStatus; set => _MCStatus = value; }
        public string MCName { get => _MCName; set => _MCName = value; }

        public virtual void Init()
        {

            _Ip = string.Empty;
            _Port = 0;
            _MCName = string.Empty;

            _SpindleX.Init();
            _SpindleY.Init();
            _SpindleServoX.Init();
            _SpindleServoY.Init();
            _BedServo.Init();
            _GuideServo.Init();

            _MCStatus.Init();

        }
    }
}

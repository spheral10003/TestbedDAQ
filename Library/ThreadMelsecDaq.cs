using KwonLib;
using KwonLib.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Library
{
    internal class ThreadMelsecDaq : ThreadMelsecBase
    {
        public ThreadMelsecDaq(string HostIP, int Port, int Index = 0)
        {
            base._HostIP = HostIP;
            base._Port = Port;
            base._PLCIndex = Index;

            base.Init();

            base._IsConn = this.ConnectTest();

            if (base._IsConn)
            {
                base.SetConnect();
            }
        }
     
        public override void Run()
        {
            double ConnetTime = 0;
            
            _KillThread = false;
            _PLCConnetTimer.Start();
            
            while (!base._KillThread)
            {
                // 일시정지
                if (_Suspend)
                {
                    Thread.Sleep(_ThreadSleepTime);
                    continue;
                }

                // PLC 연결 되지 않을시 2초마다 연결 시도
                if (SockConnState != SOCK_CONN_STATE.Connect)
                {
                    ConnetTime = _PLCConnetTimer.Elapsed.TotalMilliseconds;

                    if (ConnetTime > 2000)
                    {
                        _IsConn = ConnectTest();

                        if (_IsConn)
                        {
                            SetConnect();
                        }

                        _PLCConnetTimer.Restart();

                        Console.WriteLine($"PLC 통신이 연결되어 있지 않습니다.[{_HostIP}, {_Port}]");
                    }

                }
                    Thread.Sleep(_ThreadSleepTime);
            }
        }

        public override void OnConnet(object sender, AsyncSocketConnectionEventArgs e)
        {
            
        }

        public override void OnClose(object sender, AsyncSocketConnectionEventArgs e)
        {
            
        }

        public override void OnReceive(object sender, AsyncSocketReceiveEventArgs e)
        {
            
        }

        public override void OnError(object sender, AsyncSocketErrorEventArgs e)
        {
            
        }
    }
}

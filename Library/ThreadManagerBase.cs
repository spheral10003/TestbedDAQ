using KwonLib;
using KwonLib.Tool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    public abstract class ThreadManagerBase
    {
        public const int _ThreadSleepTime = 500;

        public bool _KillThread;
        public bool _Suspend;

        private Thread _Run;
        public LogManager _ErrLog;
        public LogManager _ActLog;

        #region Initialize

        public void Init()
        {
            _ErrLog = new LogManager("Err_", null);
            _ActLog = new LogManager("Log_", null);

            _KillThread = false;
            _Suspend = false;
        }

        #endregion
        /// <summary>
        /// Thread 시작
        /// </summary>
        public void Start()
        {
            _KillThread = false;

            _Run = new Thread(new ThreadStart(Run));
            _Run.IsBackground = true;
            _Run.Start();
        }

        /// <summary>
        /// Thread 종료
        /// </summary>
        public void Stop()
        {
            _KillThread = true;
            _Run.Abort();
        }

        /// <summary>
        /// Thread 일시정지
        /// </summary>
        public void Suspend()
        {
            _Suspend = true;
        }

        /// <summary>
        /// Thread 재시작
        /// </summary>
        public void Resume()
        {
            _Suspend = false;
        }

        /// <summary>
        /// Thread 동작 Method
        /// </summary>
        public abstract void Run();
        
    }
}

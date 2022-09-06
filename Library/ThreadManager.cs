using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    public class ThreadManager : ThreadManagerBase
    {
        private ViewData _ViewData;
        
        public ThreadManager(ViewData ViewData)
        {
            _ViewData = ViewData;
        }

        public override void Run()
        {
            while (!base._KillThread)
            {


                Thread.Sleep(_ThreadSleepTime);
            }
        }
    }
}

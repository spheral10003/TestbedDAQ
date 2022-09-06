using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DataChangeEvent : IDataChangeEvent
    {
        public event DataChangeHandler OnReset;
        public event DataChangeHandler OnAutoStart;
        public event DataChangeHandler OnEmergency;
        public event DataChangeHandler OnAlarm;
        public event DataChangeHandler OnMCDataChange;
        public event DataChangeHandler OnPLCAddressChange;
        public event DataChangeHandler OnPLCDataChange;

        public void Reset(object agr)
        {
            if (OnReset != null)
            {
                OnReset(agr);
            }
        }
        public void AutoStart(object agr)
        {
            if (OnAutoStart != null)
            {
                OnAutoStart(agr);
            }
        }
        public void Emergency(object agr)
        {
            if (OnEmergency != null)
            {
                OnEmergency(agr);
            }
        }
        public void Alarm(object agr)
        {
            if (OnAlarm != null)
            {
                OnAlarm(agr);
            }
        }
        public void MCDataChange(object agr)
        {
            if (OnMCDataChange != null)
            {
                OnMCDataChange(agr);
            }
        }
        public void PLCAddressChange(object agr)
        {
            if (OnPLCAddressChange != null)
            {
                OnPLCAddressChange(agr);
            }
        }
        public void PLCDataChange(object agr)
        {
            if (OnPLCDataChange != null)
            {
                OnPLCDataChange(agr);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public delegate void DataChangeHandler(object arg);

    public interface IDataChangeEvent
    {
        /// <summary>
        /// 리셋 이벤트
        /// </summary>
        event DataChangeHandler OnReset;             // 리셋 이벤트
        /// <summary>
        /// 자동 시작 이벤트
        /// </summary>
        event DataChangeHandler OnAutoStart;         // 자동 시작 이벤트
        /// <summary>
        /// 비상정지 이벤트
        /// </summary>
        event DataChangeHandler OnEmergency;         // 비상정지 이벤트
        /// <summary>
        /// 알람 발생 이벤트
        /// </summary>
        event DataChangeHandler OnAlarm;             // 알람 발생 이벤트
        /// <summary>
        /// 설비 정보 변경 이벤트
        /// </summary>
        event DataChangeHandler OnMCDataChange;      // 설비 정보 변경 이벤트
        /// <summary>
        /// PLC 주소 정보 변경 이벤트
        /// </summary>
        event DataChangeHandler OnPLCAddressChange;  // PLC 주소 정보 변경 이벤트
        /// <summary>
        /// PLC 데이터 변경 이벤트
        /// </summary>
        event DataChangeHandler OnPLCDataChange;     // PLC 데이터 변경 이벤트

    }
}

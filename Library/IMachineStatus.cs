using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal interface IMachineStatus
    {
        /// <summary>
        /// 가동 비가동 상태 체크
        /// </summary>
        bool Running { get; set; }              // 가동 비가동
        /// <summary>
        /// 알람 발생 여부 체크
        /// </summary>
        bool Alarm { get; set; }                // 알람 유무
        /// <summary>
        /// 하루 설비 가동 시간
        /// </summary>
        string RunningTime { get; set; }        // 설비 가동 시간
        /// <summary>
        /// 하루 설비 비가동 시간
        /// </summary>
        string StopTime { get; set; }           // 설비 비가동 시간
        /// <summary>
        /// 알람 코드
        /// </summary>
        string AlarmCode { get; set; }          // 알람 코드
        /// <summary>
        /// 알람 내용
        /// </summary>
        string AlarmDescription { get; set; }   // 알람 코멘트
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal interface IPLCAddress
    {
        
        /// <summary>
        /// 제품가공 자동 시작 주소
        /// </summary>
        int AutoStartAddress { get; set; }
        /// <summary>
        /// 모터 현재 속도 주소
        /// </summary>
        int SpeedAddress { get; set; }
        /// <summary>
        /// 모터 현재 전압 주소
        /// </summary>
        int VoltAddress { get; set; }
        /// <summary>
        /// 모터 현재 전류 주소
        /// </summary>
        int CurrentAddress { get; set; }
        /// <summary>
        /// 모터 현재 부하 주소
        /// </summary>
        int CurrentLoadAddress { get; set; }
        /// <summary>
        /// 모터 피크 부하 주소
        /// </summary>
        int PeakLoadAddress { get; set; }
        /// <summary>
        /// 가공 시간 주소
        /// </summary>
        int MachiningTimeAddress { get; set; }
        /// <summary>
        /// 알람 코드 주소
        /// </summary>
        int AlarmCodeAddress { get; set; }
        /// <summary>
        /// 제품 가공 치수 주소
        /// </summary>
        int ProductSizeAddress { get; set; }
        /// <summary>
        /// 제품 현재 치수 주소
        /// </summary>
        int CurrentSizeAddress { get; set; }
        /// <summary>
        /// 가공 횟수 주소
        /// </summary>
        int MachiningCountAddress { get; set; }

    }
}

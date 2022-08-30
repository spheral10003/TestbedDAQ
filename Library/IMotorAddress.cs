using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal interface IMotorAddress
    {
        /// <summary>
        /// 모터 현재 속도 주소
        /// </summary>
        int SpeedAddress { get; set; }
        /// <summary>
        /// 모터 현재 속도 주소
        /// </summary>
        int PositionAddress { get; set; }
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
        /// 모터 에러 번호
        /// </summary>
        int ErrerNumberAddress { get; set; }
    }
}

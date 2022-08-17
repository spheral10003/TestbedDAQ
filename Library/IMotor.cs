using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IMotor
    {
        /// <summary>
        /// 모터 현재 속도
        /// </summary>
        string Speed { get; set; }
        /// <summary>
        /// 모터 현재 전압
        /// </summary>
        string Volt { get; set; }
        /// <summary>
        /// 모터 현재 전류
        /// </summary>
        string Current { get; set; }
        /// <summary>
        /// 모터 현재 부하
        /// </summary>
        string CuttentLoad { get; set; }
        /// <summary>
        /// 모터 최대 부하
        /// </summary>
        string PeakLoad { get; set; }
    }
}

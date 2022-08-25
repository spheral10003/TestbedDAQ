using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal interface IPLCInformation
    {
        /// <summary>
        /// PLC 명칭 ( Model )
        /// </summary>
        string PLCName { get; set; }
        /// <summary>
        /// PLC 종류
        /// </summary>
        string Type { get; set; }
        /// <summary>
        /// PLC 제조사
        /// </summary>
        string Maker { get; set; }
        /// <summary>
        /// PLC 제조 일자
        /// </summary>
        string MakeDate { get; set; }
        /// <summary>
        /// PLC 프로그램 버전
        /// </summary>
        string ProgramVersion { get; set; }
    }
}

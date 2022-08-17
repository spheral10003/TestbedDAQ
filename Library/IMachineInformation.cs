using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal interface IMachineInformation
    {
        /// <summary>
        /// 설비 명칭
        /// </summary>
        string MachineName { get; set; }
        /// <summary>
        /// 설비 설명
        /// </summary>
        string MachineDescription { get; set; }
        /// <summary>
        /// 설비 관리 코드
        /// </summary>
        string MachineCode { get; set; }
        /// <summary>
        /// 설비 규격
        /// </summary>
        string MachineStandard { get; set; }
        /// <summary>
        /// 설비 제조 일자
        /// </summary>
        string MachineMakeDate { get; set; }
        /// <summary>
        /// 설비 제작사
        /// </summary>
        string MachineMaker { get; set; }
        /// <summary>
        /// 설비 설치 위치
        /// </summary>
        string MachineLocation { get; set; }
        /// <summary>
        /// 설비 유형
        /// </summary>
        string MachineType { get; set; }
        /// <summary>
        /// 설비 제작 버전
        /// </summary>
        string MachineVersion { get; set; }
    }
}

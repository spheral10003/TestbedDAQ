using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MachineInformation : IMachineInformation
    {
        private string _MachineName;            // 설비 명
        private string _MachineDescription;     // 설비 설명
        private string _MachineCode;            // 설비 모델 코드
        private string _MachineStandard;        // 설비 표준
        private string _MachineMakeDate;        // 제작 일자
        private string _MachineMaker;           // 제조사 명
        private string _MachineLocation;        // 설비 위치
        private string _MachineType;            // 설비 타입
        private string _MachineVersion;         // 설비 버전

        public string MachineName { get => _MachineName; set => _MachineName = value; }
        public string MachineDescription { get => _MachineDescription; set => _MachineDescription = value; }
        public string MachineCode { get => _MachineCode; set => _MachineCode = value; }
        public string MachineStandard { get => _MachineStandard; set => _MachineStandard = value; }
        public string MachineMakeDate { get => _MachineMakeDate; set => _MachineMakeDate = value; }
        public string MachineMaker { get => _MachineMaker; set => _MachineMaker = value; }
        public string MachineLocation { get => _MachineLocation; set => _MachineLocation = value; }
        public string MachineType { get => _MachineType; set => _MachineType = value; }
        public string MachineVersion { get => _MachineVersion; set => _MachineVersion = value; }


        public void Init()
        {
            _MachineName = string.Empty;            // 설비 명
            _MachineDescription = string.Empty;     // 설비 설명
            _MachineCode = string.Empty;            // 설비 모델 코드
            _MachineStandard = string.Empty;        // 설비 표준
            _MachineMakeDate = string.Empty;        // 제작 일자
            _MachineMaker = string.Empty;           // 제조사 명
            _MachineLocation = string.Empty;        // 설비 위치
            _MachineType = string.Empty;            // 설비 타입
            _MachineVersion = string.Empty;         // 설비 버전
        }
    }
}

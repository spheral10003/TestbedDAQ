using KwonLib;
using KwonLib.Extensions;
using KwonLib.Net;
using KwonLib.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library
{
    abstract class ThreadMelsecBase
    {
        public enum SOCK_CONN_STATE
        {
            Disconnect = 0,
            Connect,
            Error,
        }
        public enum SOCK_RUN_STATE
        {
            Read = 0,
            Write,
            Wait,
        }
        public enum DATA_TYPE : ushort
        {
            Bit = 0x0001,
            Word = 0x0000,
        }
        public enum COMMAND : ushort
        {
            Read = 0x0401,
            ReadAck = 0x00D0,
            Write = 0x1401,

        }
        public enum DEVICE_CODE : byte
        {
            InputRelay = 0x9C,      // Bit 단위로 데이터 가져옴
            OutputRelay = 0x9D,     // Bit 단위로 데이터 가져옴
            DataRegister = 0xA8,    // D영역 데이터
            FileRegister = 0xAF     // R 영역 데이터
        }
        public enum PLC_ERROR : ushort
        {
            [Description("정상")]
            Err0 = 0x0000,

            [Description("ᆞ초기화 처리시시에 Ethernet 모듈의 IP 어드레스 설정값에 오류가 있다.\n" +
                "ᆞ라우터 중계 기능 사용시, 서브 네트워크 마스크 필드의 설정값에 오류가 있다.\n" +
                "\n 에러 처리\n" +
                "ᆞIP 어드레스를 수정한다.\n클래스는 A / B / C로 한다.\n" +
                "ᆞ서브 네트워크 마스크를 수정 한다.")]
            Err1 = 0xC001,

            [Description("ᆞ초기화 처리시에 각종 타이머의 설정값 중에 허용 범위 이외의 설정값이 있다.\n" +
                "\n 에러 처리\n" +
                "ᆞ초기화 처리시의 각종 타이머 설정값을 확인하고, 수정한다.")]
            Err2 = 0xC002,

            [Description("ᆞ초기화 처리시에 자동 오픈 UDP 포트 번호의 설정값이 허용범위외 이다.\n" +
                "\n 에러 처리\n" +
                "ᆞ자동 오픈 UDP 포트 번호를 수정한다.")]
            Err3 = 0xC003,

            [Description("ᆞ서브 네트워크 마스크 필드의 설정값에 오류가 있다.\n" +
                "\n 에러 처리\n" +
                "ᆞ서브 네트워크 마스크를 수정 하여 초기화 처리를 다시 실행 한다.")]
            Err4 = 0xC004,

            [Description("ᆞ라우터 중계 기능용 디폴트 라우터 IP 어드레스의 설정 값에 오류가 있다.\n" +
                "ᆞ디폴트 라우터 IP 어드레스의 네트 ID(서브네트 마스크후의 네트 ID)가 자국 Ethernet 모듈의 IP 어드레스 네트 ID와 다르다.\n" +
                "\n 에러 처리\n" +
                "ᆞ디폴트 라우터 IP 어드레스를 수정하고, 초기화 처리를 다시 실행한다.\n" +
                "ᆞ자국 Ethernet 모듈의 IP 어드레스의 네트 ID와 동일하게 한다.")]
            Err5 = 0xC005,

            [Description("ᆞ라우터 중계 기능용 서브네트 어드레스의 설정값에 오류가 있다.\n" +
                "\n 에러 처리\n" +
                "ᆞ서브 네트 어드레스를 수정하고, 초기화 처리를 다시 실행한다.")]
            Err6 = 0xC006,

            [Description("ᆞ라우터 중계 기능용 라우터 IP 어드레스의 설정값에 오류가 있다.\n " +
                "ᆞ라우터 IP 어드레스의 네트ID(서브네트 마스크 후의 네트 ID)가 자국 Ethernet 모듈의 IP 어드레스의 네트 ID와 다르다.\n" +
                "\n 에러 처리\n" +
                "ᆞ라우터 IP 어드레스를 수정하고,초기화 처리를 다시 실행한다.\n" +
                "ᆞ자국 Ethernet 모듈의 IP 어드레스 네트 ID와 동일하게 한다")]
            Err7 = 0xC007,

            [Description("ᆞ오픈 처리시에 Ethernet 모듈의 포트 번호의 설정값에 오류가 있다.\n " +
                "\n 에러 처리\n" +
                "ᆞ포트 번호를 수정한다.")]
            Err10 = 0xC010,

            [Description("ᆞ오픈 처리시에 상대 기기 포트번호의 설정값에 오류가 있다.\n " +
                "\n 에러 처리\n" +
                "ᆞ포트 번호를 수정한다.")]
            Err11 = 0xC011,

            [Description("ᆞ이미 TCP/IP에서 오픈 완료한 커넥션에서 사용하고 있는 포트번호를 설정하려고 한다.\n " +
                "\n 에러 처리\n" +
                "ᆞEthernet 모듈 및 상대 기기의 포트 번호를 확인하고 수정한다.")]
            Err12 = 0xC012,

            [Description("ᆞ오픈 완료 커넥션에서 사용하고 있는 포트 번호를 UDP / IP의 오픈 처리시에 설정하려고 한다.\n" +
                "\n 에러 처리\n" +
                "ᆞEthernet 모듈의 포트 번호를 확인하고 수정한다.")]
            Err13 = 0xC013,

            [Description("ᆞEthernet 모듈의 초기화 처리, 오픈 처리가 완료되지 않는다.\n" +
                "\n 에러 처리\n" +
                "ᆞ초기화 처리, 오픈 처리를 실행한다.")]
            Err14 = 0xC014,

            [Description("ᆞ오픈 처리시의 상대 기기 IP 어드레스의 설정값에 오류가 있다.\n" +
                "\n 에러 처리\n" +
                "ᆞIP 어드레스를 수정한다.\n클래스는 A / B / C로 한다.")]
            Err15 = 0xC015,

            [Description("ᆞ페어링 오픈의 커넥션(또는 다음의 커넥션)은 이미 오픈 처리되어 있다\n" +
                "\n 에러 처리\n" +
                "ᆞ페어링 오픈의 대상 커넥션이 아무것도 처리하고 있지 않는지 확인한다.\n" +
                "ᆞ페어링 오픈의 조합을 수정한다.")]
            Err16 = 0xC016,

            [Description("ᆞTCP 커넥션의 오픈 처리에서 커넥션이 확립되지 않았다.\n" +
                "\n 에러 처리\n" +
                "ᆞ상대 기기의 작동을 확인한다.\n" +
                "ᆞ상대 기기의 오픈 처리를 확인한다.\n" +
                "ᆞ교신 파라미터의 오픈 설정을 수정 한다.\n" +
                "ᆞEthernet 모듈의 포트 번호, 상대기기의 IP 어드레스 / 포트 번호, 오픈방법을 수정한다.\n" +
                "ᆞ접속 케이블이 빠져 있지 않은지를 확인한다.\n" +
                "ᆞ트랜시버에 대한 접속, 터미네이터의 접속에 이상이 없는지를 확인한다.")]
            Err17 = 0xC017,

            [Description("ᆞ상대 기기측 IP 어드레스의 설정값에 오류가 있다.\n" +
                " * TCP 사용시는 IP 어드레스로서 FFFFFFFFH는 설정 불가\n" +
                "\n 에러 처리\n" +
                "ᆞIP 어드레스를 수정한다.")]
            Err18 = 0xC018,

            [Description("ᆞ데이터 길이가 허용 범위를 초과한다.\n" +
                "\n 에러 처리\n" +
                "ᆞ데이터 길이를 수정한다.\n" +
                "ᆞ송신하는 데이터의 양이 규정량을 초과할 때는 분할하여 송신한다.")]
            Err20 = 0xC020,

            [Description("ᆞ고정 버퍼에 의한 송신에 대해 이상 종료의 응답을 수신하였다.\n" +
                "\n 에러 처리\n" +
                "ᆞ응답의 종료 코드를 커넥션 종료 코드ᆞ에러 로그 영역에서 읽고, 대응 하는 처리를 실행한다.")]
            Err21 = 0xC021,

            [Description("ᆞ응답 감시 타이머값 이내에 응답을 수신 할 수 없다.\n" +
                "\n 에러 처리\n" +
                "ᆞ상대 기기의 작동을 확인한다.\n" +
                "ᆞ응답 감시 타이머값을 확인하고, 수정한다.")]
            Err22 = 0xC022,

            [Description("ᆞ해당 커넥션은 오픈 처리가 완료되지 않고 있다.\n" +
                "\n 에러 처리\n" +
                "ᆞ해당 커넥션의 오픈 처리를 실행한다.")]
            Err23 = 0xC023,

            [Description("ᆞ송신 에러가 발생하였다.\n" +
                "\n 에러 처리\n" +
                "ᆞ트랜시버, 상대 기기의 작동을 확인한다.\n" +
                "* 트랜시버는 SQE 테스트가 가능한 것을 사용한다.\n" +
                "ᆞ회선에서 패킷이 혼재되어 있는 경우가 있기 때문에, 임의의 시간 경과 후에 송신한다.\n" +
                "ᆞ접속 케이블이 빠져 있지 않은지를 확인한다.\n" +
                "ᆞ트랜시버에 대한 접속, 터미네이터의 접속에 이상이 없는지를 확인한다.\n" +
                "ᆞ자기진단 테스트를 실행하고, Ethernet 모듈에 이상이 없는지를 확인한다.")]
            Err30 = 0xC030,

            [Description("ᆞ송신 에러가 발생하였다.\n" +
                "\n 에러 처리\n" +
                "ᆞ트랜시버, 상대 기기의 작동을 확인한다.\n" +
                "* 트랜시버는 SQE 테스트가 가능한 것을 사용한다.\n" +
                "ᆞ회선에서 패킷이 혼재되어 있는 경우가 있기 때문에, 임의의 시간 경과 후에 송신한다.\n" +
                "ᆞ접속 케이블이 빠져 있지 않은지를 확인한다.\n" +
                "ᆞ트랜시버에 대한 접속, 터미네이터의 접속에 이상이 없는지를 확인한다.\n" +
                "ᆞ자기진단 테스트를 실행하고, Ethernet 모듈에 이상이 없는지를 확인한다.")]
            Err31 = 0xC031,

            [Description("ᆞTCP/IP 교신에서 TCP ULP 타임아웃 에러가 발생하였다.\n" +
                "(상대 기기에서 ACK가 회신되지 않는다.)\n" +
                "\n 에러 처리\n" +
                "ᆞ상대 기기의 작동을 확인한다.\n" +
                "ᆞTCP ULP 타임아웃값을 수정하고 초기화 처리를 다시 실행한다.\n" +
                "ᆞ회선에서 패킷이 혼재되어 있는 경우가 있기 때문에, 임의의 시간 경과 후에 송신한다.\n" +
                "ᆞ접속 케이블이 빠져 있지 않은지를 확인한다.\n" +
                "ᆞ트랜시버에 대한 접속, 터미네이터의 접속에 이상이 없는지를 확인한다.")]
            Err32 = 0xC032,

            [Description("ᆞ설정된 IP 어드레스의 상대 기기가 존재하지 않는다.\n" +
                "\n 에러 처리\n" +
                "ᆞ상대 기기의 IP 어드레스와 Ethernet 모듈을 확인하고, 수정한다.\n" +
                "ᆞ상대 기기에 ARP 기능이 있을 때는 디폴트값을, ARP 기능이 없을 때는 상대 기기의 Ethernet 어드레스를 설정한다.\n" +
                "ᆞ상대 기기의 작동을 확인한다.\n" +
                "ᆞ회선에서 패킷이 혼재하고 있는 경우가 있기 때문에 임의의 시간이 경과후에 송신한다.\n" +
                "ᆞ접속 케이블이 빠져 있지 않은지를 확인한다.\n" +
                "ᆞ트랜시버에 대한 접속, 터미네이터의 접속에 이상이 없는지를 확인한다.")]
            Err33 = 0xC033,

            [Description("ᆞ응답 감시 타이머값 이내에 상대 기기의 생존확인을 할 수 없다.\n" +
                "\n 에러 처리\n" +
                "ᆞ상대 기기의 작동을 확인한다.\n" +
                "ᆞ생존 확인용 각 설정값을 확인하고 수정한다.\n" +
                "ᆞ접속 케이블이 빠져 있지 않은지를 확인한다.\n" +
                "ᆞ트랜시버에 대한 접속, 터미네이터의 접속에 이상이 없는지를 확인한다.")]
            Err35 = 0xC035,
        }

        public class Head
        {
            private byte ENQ = 0x50;                                        // 서버 머리글 - 프레임 번호
            private byte StationNum = 0x00;                                 // 서버 머리글 - 스테이션 번호
            public byte NetworkNum = 0x00;                                 // 네트워크 번호
            public byte PLCNum = 0xFF;                                     // PLC 번호
            private ushort RequestIONum = 0x03ff;                           // 요구 상대 모듈 - I/O 번호
            private byte RequestStationNum = 0x00;                          // 요구 상대 모듈 - 스테이션(국) 번호
            public ushort Length = 0x0000;                                  // 데이터 길이
            private ushort CPUWatchDog = 0x0010;                            // CPU 감시 타이머 ( 읽기/쓰기 요구 후 결과가 올때까지의 대기시간 지정)
            public COMMAND Cmd = COMMAND.Read;                             // 명령어 ( 읽기 / 쓰기 구분 - 일괄 읽기 : 0x0104, 일괄 쓰기 : 0x0114)
            private DATA_TYPE SubCmd = DATA_TYPE.Word;                      // 서브 명령어 ( Bit / Word 구분 -  Word : 0x0000, Bit : 0x0001)
            public int DeviceStart = 0;                                    // 선두 디바이스
            public DEVICE_CODE DeviceCode = DEVICE_CODE.DataRegister;      // 디바이스 코드
            public ushort DeviceCount = 0;                                 // 디바이스 점수 (점수는 WORD 단위로 계산 할것)


            public List<byte> Header = new List<byte>();

            public void CreadHead()
            {

                Header.Clear();

                // Company Header
                Header.Add(ENQ);
                Header.Add(StationNum);
                Header.Add(NetworkNum);
                Header.Add(PLCNum);
                Header.AddRange(BitConverter.GetBytes(RequestIONum));
                Header.Add(RequestStationNum);
                Header.AddRange(BitConverter.GetBytes(Length));
                Header.AddRange(BitConverter.GetBytes(CPUWatchDog));
                Header.AddRange(BitConverter.GetBytes((ushort)Cmd));
                Header.AddRange(BitConverter.GetBytes((ushort)SubCmd));

                int Device = ((byte)DeviceCode << 24) + DeviceStart;

                Header.AddRange(BitConverter.GetBytes(Device));
                Header.AddRange(BitConverter.GetBytes(DeviceCount));
            }

        }

        public AsyncSocketClient _PlcSock = null;
        public Head _ReadHeader;
        public Head _WriteHeader;
        public LogManager _ErrLog;
        public LogManager _ActLog;
        public Stopwatch _DelayTimer = new Stopwatch();
        public Stopwatch _PCRunFlagTimer = new Stopwatch();
        public Stopwatch _PLCConnetTimer = new Stopwatch();
        public ConvDataType _ConvData = new ConvDataType();
        public Thread _Run;

        public const int _ThreadSleepTime = 500;
        public string _HostIP = "";
        public int _Port = 2004;
        public int _PLCIndex;
        public bool _KillThread = false;
        public bool _Suspend = false;
        public bool _IsConn;
        
        public PLC_ERROR PLCErr = PLC_ERROR.Err0;
        public SOCK_RUN_STATE SockRunState = SOCK_RUN_STATE.Read;
        public SOCK_CONN_STATE SockConnState = SOCK_CONN_STATE.Disconnect;

        public ushort ReadDataCount
        {
            set
            {
                _ReadHeader.DeviceCount = value;
                _ReadHeader.CreadHead();
            }
            get { return _ReadHeader.DeviceCount; }
        }
        public int ReadDataAddress
        {
            set
            {
                _ReadHeader.DeviceStart = value;
                _ReadHeader.CreadHead();
            }
            get { return _ReadHeader.DeviceStart; }
        }
        public ushort WriteDataCount
        {
            set
            {
                _WriteHeader.DeviceCount = value;
                _WriteHeader.Length = (ushort)(12 + (value * 2));
                _WriteHeader.CreadHead();
            }
            get { return _WriteHeader.DeviceCount; }
        }
        public int WriteDataAddress
        {
            set
            {
                _WriteHeader.DeviceStart = value;
                _WriteHeader.CreadHead();
            }
            get { return _WriteHeader.DeviceStart; }
        }

        /// <summary>
        /// 선언 변수 초기화
        /// </summary>
        public void Init()
        {
            this._PlcSock = new AsyncSocketClient(_PLCIndex);

            // 이벤트 핸들러 정의
            this._PlcSock.OnConnet += new AsyncSocketConnectEventHandler(OnConnet);
            this._PlcSock.OnClose += new AsyncSocketCloseEventHandler(OnClose);
            this._PlcSock.OnReceive += new AsyncSocketReceiveEventHandler(OnReceive);
            this._PlcSock.OnError += new AsyncSocketErrorEventHandler(OnError);

            this._ReadHeader = new Head();
            this._WriteHeader = new Head();
            this._ErrLog = new LogManager("Err_", null);
            this._ActLog = new LogManager("Log_", null);
            this._DelayTimer = new Stopwatch();
            this._PCRunFlagTimer = new Stopwatch();
            this._PLCConnetTimer = new Stopwatch();
            
            this._KillThread = false;
            this._Suspend = false;
        }
        /// <summary>
        /// PLC Ping Test
        /// </summary>
        /// <returns></returns>
        public bool ConnectTest()
        {
            bool result = false;
            Socket socket = null;

            try
            {
                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                socket.SetSocketOption(SocketOptionLevel.Socket,
                    SocketOptionName.DontLinger,
                    false);

                IAsyncResult ret = socket.BeginConnect(_HostIP, _Port, null, null);

                result = ret.AsyncWaitHandle.WaitOne(100, true);
            }
            catch
            {
            }
            finally
            {
                if (socket != null)
                {
                    socket.Close();
                }
            }
            return result;
        }
        /// <summary>
        /// PLC 연결 시도
        /// </summary>
        public void SetConnect()
        {
            if (string.IsNullOrEmpty(_HostIP) == false)
            {
                if (_PlcSock.Connection == null)
                {
                    _PlcSock.Connect(_HostIP, _Port);
                }
                else
                {
                    if (_PlcSock.Connection.Connected)
                    {
                        _PlcSock.Close();
                        Thread.Sleep(200);
                        _PlcSock.Connect(_HostIP, _Port);
                    }
                    else
                    {
                        _PlcSock.Connect(_HostIP, _Port);
                    }
                }

            }
        }
        /// <summary>
        /// Thread Start
        /// </summary>
        public void Start()
        {
            this._KillThread = false;
            this._Run = new Thread(new ThreadStart(Run));
            this._Run.IsBackground = true;
            this._Run.Start();
        }
        /// <summary>
        /// Thread Stop ( 종료 )
        /// </summary>
        public void Stop()
        {
            this._KillThread = true;
            this._Run.Abort();
        }
        /// <summary>
        /// Thread 일시 정지
        /// </summary>
        public void Suspend()
        {
            this._Suspend = true;
        }
        /// <summary>
        /// Thread 재시작
        /// </summary>
        public void Resume()
        {
            this._Suspend = false;
        }

        /// <summary>
        /// Thread 구동 Methord
        /// </summary>
        public abstract void Run();
        public abstract void OnConnet(object sender, AsyncSocketConnectionEventArgs e);
        public abstract void OnClose(object sender, AsyncSocketConnectionEventArgs e);
        public abstract void OnReceive(object sender, AsyncSocketReceiveEventArgs e);
        public abstract void OnError(object sender, AsyncSocketErrorEventArgs e);
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestbedDAQ.UseClass
{
    public class TestbedFTP
    {
        public string _host = "ftp://f1lab.co.kr";
        public string _path = @"ftp://f1lab.co.kr/wf_ftp_SJ_Testbed/img/mc/";
        public string _userId = "ftpUser";
        public string _password = "f1soft@95";

        //FTP내에서 폴더가 존재하는지 검사
        public bool DoesFtpDirectoryExist(string sDirPath)
        {
            bool isExist = false;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(sDirPath + "/");
                request.Credentials = new NetworkCredential(_userId, _password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    isExist = true;
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                }
            }
            return isExist;
        }

        //FTP내에서 폴더를 생성
        public bool CreateFolder(string sDirPath)
        {
            string sPath = sDirPath;
            bool IsCreated = true;
            try
            {
                WebRequest request = WebRequest.Create(sPath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(_userId, _password);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            }
            catch (Exception)
            {
                IsCreated = false;
            }
            return IsCreated;
        }

        //FTP내에서 파일을 업로드
        public void UploadFile(string _From, string _To)
        {
            string sFrom = _From;
            string sTo = _To;

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(_userId, _password);
                client.UploadFile(sTo, WebRequestMethods.Ftp.UploadFile, sFrom);
            }
        }
    }
}

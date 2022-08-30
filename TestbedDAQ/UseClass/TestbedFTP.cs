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
        public string _Host = "ftp://f1lab.co.kr";
        public string _Path = @"ftp://f1lab.co.kr/wf_ftp_SJ_Testbed/img/mc/";
        public string _UserId = "ftpUser";
        public string _Password = "f1soft@95";


        //FTP내에서 폴더가 존재하는지 검사
        public bool DoesFtpDirectoryExist(string sDirPath)
        {
            bool isExist = false;

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(sDirPath + "/");
                request.Credentials = new NetworkCredential(_UserId, _Password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    isExist = true;
                    response.Close();
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        response.Close();
                        return false; 
                    } 
                }
            }
            return isExist;
        }


        //FTP내에서 폴더를 생성
        public bool CreateFolder(string sDirPath)
        {
            bool IsCreated = true;
            try
            {
                WebRequest request = WebRequest.Create(sDirPath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(_UserId, _Password);
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                    resp.Close();
                }
            }
            catch (Exception)
            {
                
                IsCreated = false;
            }
            return IsCreated;
        }


        //FTP내에서 파일을 업로드
        public void UploadFile(string sFrom, string sTo)
        {
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(_UserId, _Password);
                client.UploadFile(sTo, WebRequestMethods.Ftp.UploadFile, sFrom);
                client.Dispose();
            }
        }
    }
}

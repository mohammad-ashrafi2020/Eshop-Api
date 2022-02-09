using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Common.Application.FileUtil;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.Application
{
    public static class FtpHelper
    {
        public static NetworkCredential CreateNetworkCredential()
        {
            return new NetworkCredential("pz12489", "pBJBoxtx");
        }

        public static async Task DeleteFileFromFtpServer(string path, string fileName)
        {
            try
            {
                string filePath = $"{Directories.FtpServer}{path}/{fileName}";
                var request = (FtpWebRequest)FtpWebRequest.Create(new Uri(filePath));
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = CreateNetworkCredential();
                var response = await request.GetResponseAsync();
                response.Close();
            }
            catch
            {
                //ignore
            }
        }
        public static async Task<FileStreamResult> DownloadFileFromFtp(string filePath)
        {
            var request = (FtpWebRequest)WebRequest.Create(new Uri(filePath));
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = CreateNetworkCredential();
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            var response = await request.GetResponseAsync();
            var stream = response.GetResponseStream();
            return new FileStreamResult(stream, "application/octet-stream");
        }
        public static async Task<Stream> DownloadFileStream(string filePath)
        {
            var request = (FtpWebRequest)FtpWebRequest.Create(new Uri(filePath));
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = CreateNetworkCredential();
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            var response = await request.GetResponseAsync();
            var stream = response.GetResponseStream();
            return stream;
        }

        public static async Task DeleteDirectoryFromFtpServer(string path)
        {
            try
            {
                string filePath = $"{Directories.FtpServer}{path}";
                var request1 = (FtpWebRequest)FtpWebRequest.Create(new Uri(filePath));
                request1.Method = WebRequestMethods.Ftp.RemoveDirectory;
                request1.Credentials = CreateNetworkCredential();
                var response1 = await request1.GetResponseAsync();
                response1.Close();
            }
            catch
            {
                //ignore
            }
        }
        public static async Task SaveFileToFtp(IFormFile inputTarget, string savePath, string fileName)
        {
            FtpWebRequest reqFTP;
            Stream ftpStream;

            var ftpAddress = Directories.FtpServer;
            string currentDir = ftpAddress;

            string[] subDirs = savePath.Split('/');

            foreach (var subDir in subDirs)
            {
                try
                {
                    currentDir = currentDir + "/" + subDir;
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(currentDir);
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.Credentials = CreateNetworkCredential();
                    FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                    ftpStream.Close();
                    response.Close();
                }
                catch
                {
                    //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
                }
            }

            long length = inputTarget.Length;
            if (length < 0)
                throw new Exception();

            await using (var stream = inputTarget.OpenReadStream())
            {
                //Read File
                byte[] bytes = new byte[length];
                await stream.ReadAsync(bytes, 0, (int)inputTarget.Length);
                //Save File
                WebClient request = new WebClient();
                request.Credentials = CreateNetworkCredential();
                var path = currentDir + "/" + fileName;
                await request.UploadDataTaskAsync(new Uri(path), bytes);
            }
        }
    }
}
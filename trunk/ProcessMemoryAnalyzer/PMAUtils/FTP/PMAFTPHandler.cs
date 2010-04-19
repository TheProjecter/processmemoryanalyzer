//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Net;
//using System.Collections;


//namespace  PMA.Utils.ftp
//{
//    public sealed class SCMFTPTransportHandler : ISCMTransportManager
//    {
      
//        FtpWebRequest request = null;

//        //-----------------------------------------------------------------------------------------------------------
//        /// <summary>
//        /// Sends the object. Implementation of ISCMTransportManager method
//        /// </summary>
//        /// <param name="files">The files.</param>
//        /// <param name="args">The args.</param>
//        public void SendObject(IList files, params object[] args)
//        {
//            SCMFTPInfo ftpFiles = null;

//            foreach (object file in files)
//            {
//                ftpFiles = (SCMFTPInfo)file;

//                CreateRecursiveFTPFolder(ftpFiles.FTPFolderPath);

//                Stream requestStream = UploadFile(ftpFiles);
//            }


//        }

//        private Stream UploadFile(SCMFTPInfo ftpFiles)
//        {
//            FtpWebRequest uploadRequest = null;
//            Stream requestStream = null;
//            FileStream fileStream = null;
//            int bytesRead = -1;
//            byte[] buffer = null;
//            string serverFolderToUpload = ServerName + "/" + ftpFiles.FTPFolderPath + "/" + Path.GetFileName(ftpFiles.LocalFileName);
//            try
//            {
//                if (serverFolderToUpload.Contains("#"))
//                    serverFolderToUpload = serverFolderToUpload.Replace("#", "%23");
//                uploadRequest = (FtpWebRequest)WebRequest.Create(serverFolderToUpload);
//                uploadRequest.Credentials = new NetworkCredential(UserName, Password);
//                uploadRequest.EnableSsl = false;
//                uploadRequest.Proxy = null;
//                uploadRequest.KeepAlive = false;
//                uploadRequest.UsePassive = false; ;
//                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
//                requestStream = uploadRequest.GetRequestStream();

//                fileStream = File.Open(ftpFiles.LocalFileName, FileMode.Open);
//                buffer = new byte[1024];
//                while (true)
//                {
//                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
//                    if (bytesRead == 0)
//                    {
//                        break;
//                    }
//                    requestStream.Write(buffer, 0, bytesRead);
//                }

//            }
//            catch (Exception rtEx)
//            {
//                throw rtEx;
//            }
//            finally
//            {
//                if (requestStream != null)
//                {
//                    requestStream.Close();
//                    requestStream.Dispose();
//                }
//                if (uploadRequest != null)
//                {
//                    uploadRequest = null;

//                }
//                if (fileStream != null)
//                {
//                    fileStream.Close();
//                    fileStream.Dispose();
//                }
//            }
//            return requestStream;
//        }

//        //-----------------------------------------------------------------------------------------------------------
//        /// <summary>
//        /// Folders the exists.
//        /// </summary>
//        /// <param name="FolderName">Name of the folder.</param>
//        /// <param name="serverFolderToCreate">The server folder to create.</param>
//        private void CreateRecursiveFTPFolder(string folderName)
//        {
//            folderName = folderName.Replace('\\', '/');
//            string[] folderHirarchy = folderName.Split('/');
//            FtpWebResponse response = null;
//            FtpWebRequest request = null;
//            List<string> fileNames = null;
//            string fullServerPath = string.Empty;
//            try
//            {
//                folderName = string.Empty;
//                foreach (string folder in folderHirarchy)
//                {
//                    fullServerPath = ServerName + "/" + folderName;
//                    fileNames = GetFileList(fullServerPath);
//                    if (!fileNames.Contains(folder.ToLower()))
//                    {
//                        request = (FtpWebRequest)FtpWebRequest.Create(fullServerPath + "/" + folder);
//                        request.KeepAlive = false;
//                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
//                        request.UseBinary = true;
//                        request.Proxy = null;
//                        request.UsePassive = false;
//                        request.Credentials = new NetworkCredential(UserName, Password);
//                        response = (FtpWebResponse)request.GetResponse();

//                        response.Close();
//                    }
//                    folderName = folderName + '/' + folder;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                if (request != null)
//                {
//                    //request.KeepAlive = false;
//                }
//                if (response != null)
//                {
//                    response.Close();
//                }
//            }
//        }


//        //-----------------------------------------------------------------------------------------------------------
//        /// <summary>
//        /// Gets the file list.
//        /// </summary>
//        /// <param name="path">The path.</param>
//        /// <returns></returns>
//        private List<string> GetFileList(string serverPath)
//        {
//            StringBuilder result = new StringBuilder();
//            WebResponse response = null;
//            StreamReader reader = null;
//            List<string> filesList = new List<string>();
//            try
//            {
//                FtpWebRequest reqFTP;
//                reqFTP = (FtpWebRequest)FtpWebRequest.Create(serverPath);
//                reqFTP.UseBinary = true;
//                reqFTP.Credentials = new NetworkCredential(UserName, Password);
//                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
//                reqFTP.Proxy = null;
//                reqFTP.KeepAlive = false;
//                reqFTP.UsePassive = false;
//                response = reqFTP.GetResponse();

//                reader = new StreamReader(response.GetResponseStream());
//                string line = reader.ReadLine();
//                while (line != null)
//                {
//                    filesList.Add(line.ToLower());
//                    line = reader.ReadLine();
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            finally
//            {
//                if (reader != null)
//                {
//                    reader.Close();
//                }
//                if (response != null)
//                {
//                    response.Close();
//                }
//            }
//            return filesList;
//        }

//        /// <summary>
//        /// Gets the object,Not Implemented here.
//        /// </summary>
//        /// <param name="objects">The objects.</param>
//        /// <param name="args">The args.</param>
//        public object ReceiveObject(IList objects, params object[] args)
//        {
//            throw new NotImplementedException();

//        }
        

//    }
//}

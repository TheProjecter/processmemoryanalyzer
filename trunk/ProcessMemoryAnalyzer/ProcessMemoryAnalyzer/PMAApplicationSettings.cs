using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PMA.ProcessMemoryAnalyzer
{
    public class PMAApplicationSettings
    {
        
        public static string PMAApplicationDirectory
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath); }
        }

        public static string PMAApplicationDirectoryConfig
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath)+"\\Config"; }
        }

        public static string PMAApplicationDirectoryMemLog
        {
            get 
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Memlog";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path; 
            }
        }
    }

}


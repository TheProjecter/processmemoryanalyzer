using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GetProcessMainWindowTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            int pid = 0;
            if (args.Length == 1)
            {
                pid = int.Parse(args[0]);
                Process p = Process.GetProcessById(pid);
                if (p.MainWindowTitle.Contains("COSMOS") || p.MainWindowTitle.Contains("Reconciliation Framework"))
                {
                    Environment.Exit(5);
                }
                else if (p.MainWindowTitle.Contains("Google"))
                {
                    Environment.Exit(5);
                }
                else Environment.Exit(2);
            }

        }
    }
}

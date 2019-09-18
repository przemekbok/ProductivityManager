using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlokerStron.Logic
{
    public class ProcessOperations
    {
        public void RestartProcesses()
        {
            KillProcesses("chrome.exe");
            KillProcesses("firefox.exe");
            KillProcesses("opera.exe");

            Process.Start(@"");//chrome
            Process.Start(@"");//firefox
            Process.Start(@"");//opera
        }

        public void KillProcesses(string processName)
        {
            if (!processName.Contains(".exe"))
            {
                Process[] processes = Process.GetProcessesByName(processName);

                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
        }
    }
}

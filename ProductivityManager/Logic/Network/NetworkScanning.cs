using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlokerStron.Logic
{
    public static class NetworkScanning
    {
        private const string NetworkScanningTool = "/C netstat";
        private const string Arguments = "/b -a -n -p TCP";
        private const string TerminalReference = "cmd.exe";

        public static List<string> ScanCurrentConnectionsforUsedIPAddresses()
        {
            Process cmd = new Process();
            ProcessStartInfo processParams = new ProcessStartInfo {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                UseShellExecute = false,
                FileName = TerminalReference,
                Arguments = NetworkScanningTool + Arguments
            };

            cmd.StartInfo = processParams;
            cmd.EnableRaisingEvents = true;
            cmd.Start();
            cmd.WaitForExit();
            string output = cmd.StandardOutput.ReadToEnd();

            return NetstatParser(output);
        }

        private static List<string> NetstatParser(string netstatResult)
        {
            string[] linesOfOutput = netstatResult.Split('\n');

            var filteredOutput = linesOfOutput
                .Where(line => line.Contains("TCP"))
                .Select(line =>  line.Split(null)
                .Where(part => !String.IsNullOrWhiteSpace(part))
                .ToArray()[1].Split(':')[0]);

            return filteredOutput.ToList();
        }
    }
}

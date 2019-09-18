using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlokerStron.Logic
{
    static public class OperationsOnHostFile
    {
        static private string Path = "C:\\Windows\\System32\\drivers\\etc\\hosts";
        static public void BlockHosts(List<string> positions)
        {
            string IPChoosenForBlocker = IPGenerator.GetValidLocalIPv4();
            positions = positions.Select(position => ("\t" + IPChoosenForBlocker+"\t\t" + position + "\t#TIMER!")).ToList();
            File.AppendAllLines(Path, positions);
        }

        static public void EnableHosts()
        {
            List<string> hosts = File.ReadAllLines(Path).ToList();
            hosts.RemoveAll(IsRowAddedByTimer);
            File.WriteAllLines(Path, hosts);
        }

        static private bool IsRowAddedByTimer(string line)
        {
            if (line.Contains("#TIMER!"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

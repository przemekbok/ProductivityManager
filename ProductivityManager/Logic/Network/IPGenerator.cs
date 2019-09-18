using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlokerStron.Logic
{
    public static class IPGenerator
    {
        public static string GetValidLocalIPv4()
        {
            string newIPAddress = "";
            int addressFamily = 127;

            List<string> usedAddresses = NetworkScanning.ScanCurrentConnectionsforUsedIPAddresses();

            do
            {
                newIPAddress = RollIPv4(addressFamily);
            } while (usedAddresses.Contains(newIPAddress));

            return newIPAddress;
        }

        private static string RollIPv4(int addressFamily)
        {
            Random randGenerator = new Random();

            string[] newIPAddress = new string[4];

            newIPAddress[0] = addressFamily.ToString();
            newIPAddress[1] = randGenerator.Next(0, 255).ToString();
            newIPAddress[2] = randGenerator.Next(0, 255).ToString();
            newIPAddress[3] = randGenerator.Next(0, 255).ToString();

            return String.Join(".",newIPAddress);
        }
    }
}

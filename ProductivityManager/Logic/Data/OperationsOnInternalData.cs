using BlokerStron.AdditionalWindows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BlokerStron.Logic
{
    public static class OperationsOnInternalData
    {
        private static string DataDirectory =  @"..\..\LocalData";

        public static void SaveBlackListToFile(List<string> positions)
        {
            EstabilishSeparateDirectoryForData(DataDirectory);
            string path = DataDirectory + @"\blacklist.txt";
            File.WriteAllLines(path, positions);
        }

        public static void SaveTimeSpanToFile(TimeSpan timeSpan)
        {
            EstabilishSeparateDirectoryForData(DataDirectory);
            string path = DataDirectory + @"\timespan.txt";
            File.WriteAllLines(path, new string[] { timeSpan.ToString() });
        }

        public static void InitializeBlackListItems(ListBox blackList)
        {
            EstabilishSeparateDirectoryForData(DataDirectory);
            string path = DataDirectory + @"\blacklist.txt";

            List<string> positionsOnList = new List<string>();

            if (File.Exists(path))
            {
                positionsOnList = File.ReadAllLines(path).ToList();
            }

            positionsOnList.ForEach(item => { blackList.Items.Add(item); });
        }

        public static void InitializeTimerTimeReadout(TimePicker timePicker)
        {
            EstabilishSeparateDirectoryForData(DataDirectory);
            string path = DataDirectory + @"\timespan.txt";
            TimeSpan time = new TimeSpan(0, 0, 0);

            if (File.Exists(path))
            {
                string timeAsString = File.ReadLines(path).ToArray()[0];
                string[] dispachedTimeSpan = timeAsString.Split(':');
                int[] dispachedTimeSpanAsInt = dispachedTimeSpan.ToList().Select(partOfTimespan => Convert.ToInt32(partOfTimespan)).ToArray();
                time = new TimeSpan(dispachedTimeSpanAsInt[0], dispachedTimeSpanAsInt[1], dispachedTimeSpanAsInt[2]);
            }

            timePicker.SetTimeSpan(time.Hours, time.Minutes, time.Seconds);
        }

        private static void EstabilishSeparateDirectoryForData(string UserDirectory)
        {
            if (!Directory.Exists(UserDirectory))
            {
                Directory.CreateDirectory(UserDirectory);
            }
        }
    }
}

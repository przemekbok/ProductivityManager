using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlokerStron.AppWindows.TimerWindowsAdditions
{
    public static class TimerWindowOperations
    {
        public static void PositionWindow(this Window window)
        {
            var width = SystemParameters.PrimaryScreenWidth;
            var height = SystemParameters.PrimaryScreenHeight;

            window.Left = width * 0.9 - window.Width;
            window.Top = height * 0.95 - window.Height;
        }
    }
}

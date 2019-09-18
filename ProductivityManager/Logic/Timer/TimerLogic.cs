using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using BlokerStron.Logic;

namespace BlokerStron.Logic
{
    public class TimerLogic
    {
        public TimeSpan TimeRemaining;
        public DispatcherTimer Timer = new DispatcherTimer();

        private HiddenWindow Parent;

        public TimerLogic(HiddenWindow parent)
        {
            Parent = parent;

            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeRemaining = TimeRemaining.Subtract(new TimeSpan(0, 0, 1));
            if (TimeRemaining.Ticks >= 0)
            {
                Parent.ChoosenTimeSpan = TimeRemaining;
            }
            else
            {
                Timer.Stop();
                SystemSounds.Exclamation.Play();
            }
        }

        public void StartTimer(TimeSpan timeSpan)
        {
            TimeRemaining = timeSpan;
            Timer.Start();
        }

        public void StopTimer()
        {
            Timer.Stop();
        }
    }
}

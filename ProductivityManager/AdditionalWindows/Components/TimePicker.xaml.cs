using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlokerStron.AdditionalWindows
{
    public partial class TimePicker : UserControl
    {
        public enum TimeUnit{ Hours, Minutes, Seconds}
        private int Hours;
        private int Minutes;
        private int Seconds;

        public TimePicker()
        {
            Hours = 0;
            Minutes = 0;
            Seconds = 0;
            InitializeComponent();
        }

        public void SetTimeSpan(int hours,int minutes,int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;

            HoursInput.Text = ConvertStringTotimeUnit(hours.ToString());
            MinutesInput.Text = ConvertStringTotimeUnit(minutes.ToString());
            SecondsInput.Text = ConvertStringTotimeUnit(seconds.ToString());
        }

        public void SetTimeSpan(TimeSpan timeSpan)
        {
            Hours = timeSpan.Hours;
            Minutes = timeSpan.Minutes;
            Seconds = timeSpan.Seconds;

            HoursInput.Text = ConvertStringTotimeUnit(timeSpan.Hours.ToString());
            MinutesInput.Text = ConvertStringTotimeUnit(timeSpan.Minutes.ToString());
            SecondsInput.Text = ConvertStringTotimeUnit(timeSpan.Seconds.ToString());
        }

        private void TimeInput_LostFocus(object sender, RoutedEventArgs e)
        {
            var senderObject = sender as TextBox;
            string text = senderObject.Text;
            string convertedText= ConvertStringTotimeUnit(text);
            senderObject.Text = convertedText;
        }

        private void TimeInput_KeyUp(object sender, KeyEventArgs e)
        {
            var senderObject = sender as TextBox;
            string text = senderObject.Text;
            int value = text == "" ? 0 : Convert.ToInt32(text);
            if (e.Key == Key.Up)
            {
                senderObject.Text = (++value).ToString();
            }
            if (e.Key == Key.Down)
            {
                senderObject.Text = (--value).ToString();
            }
        }

        private void Hour_Up(object sender, RoutedEventArgs e)
        {
            string text = HoursInput.Text;
            int value = Convert.ToInt32(text);
            value++;
            HoursInput.Text = ConvertStringTotimeUnit(value.ToString());
        }

        private void Hour_Down(object sender, RoutedEventArgs e)
        {
            string text = HoursInput.Text;
            int value = Convert.ToInt32(text);
            value--;
            HoursInput.Text = ConvertStringTotimeUnit(value.ToString());
        }

        private void Minute_Up(object sender, RoutedEventArgs e)
        {
            string text = MinutesInput.Text;
            int value = Convert.ToInt32(text);
            value++;
            MinutesInput.Text = ConvertStringTotimeUnit(value.ToString());
        }

        private void Minute_Down(object sender, RoutedEventArgs e)
        {
            string text = MinutesInput.Text;
            int value = Convert.ToInt32(text);
            value--;
            MinutesInput.Text = ConvertStringTotimeUnit(value.ToString());
        }

        private void Second_Up(object sender, RoutedEventArgs e)
        {
            string text = SecondsInput.Text;
            int value = Convert.ToInt32(text);
            value++;
            SecondsInput.Text = ConvertStringTotimeUnit(value.ToString());
        }

        private void Second_Down(object sender, RoutedEventArgs e)
        {
            string text = SecondsInput.Text;
            int value = Convert.ToInt32(text);
            value--;
            SecondsInput.Text = ConvertStringTotimeUnit(value.ToString());
        }

        public void ValidateTextBoxInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void ValidateAndModifyTextBoxValue(object sender, EventArgs e)
        {
            var senderObject = sender as TextBox;
            string text = senderObject.Text;
            if (text != "")
            {
                var value = Convert.ToInt32(text);
                if (0 > value)
                {
                    senderObject.Text = "00";
                }
                else if (60 < value)
                {
                    senderObject.Text = "60";
                }
            }
        }

        private string ConvertStringTotimeUnit(string value)
        {
            if(value.Length == 1)
            {
                return "0" + value;
            }
            else
            {
                return value;
            }
        }

        public void Increase(TimeUnit type)
        {
            switch (type)
            {
                case TimeUnit.Hours:
                    Hours++;
                    break;
                case TimeUnit.Minutes:
                    Minutes++;
                    break;
                case TimeUnit.Seconds:
                    Seconds++;
                    break;
            }
        }

        public void Decrease(TimeUnit type)
        {
            switch (type)
            {
                case TimeUnit.Hours:
                    if (Hours > 0) Hours--;
                    break;
                case TimeUnit.Minutes:
                    if (Minutes > 0) Minutes--;
                    break;
                case TimeUnit.Seconds:
                    if (Seconds > 0) Seconds--;
                    break;
            }
        }

        public void updateTimeSpanValues()
        {
            string hours = HoursInput.Text;
            string minutes = MinutesInput.Text;
            string seconds = SecondsInput.Text;
            Hours = Convert.ToInt32(hours);
            Minutes = Convert.ToInt32(minutes);
            Seconds = Convert.ToInt32(seconds);
        }

        public TimeSpan getDataFromTimePicker()
        {
            updateTimeSpanValues();
            TimeSpan timeFromTimer = new TimeSpan(Hours,Minutes,Seconds);

            return timeFromTimer;
        }
    }
}

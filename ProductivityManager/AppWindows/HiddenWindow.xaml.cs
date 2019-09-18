using BlokerStron.AdditionalWindows;
using BlokerStron.AppWindows;
using BlokerStron.AppWindows.TimerWindowsAdditions;
using BlokerStron.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlokerStron
{
    public partial class HiddenWindow : Window, INotifyPropertyChanged
    {
        //App's Windows
        public TimerLogic TimerLogic;
        public StartWindow StartWindow;
        public StopWindow StopWindow;
        private Options OptionsWindow;

        //Properties
        private TimeSpan choosenTimeSpan;
        public TimeSpan ChoosenTimeSpan
        {
            get { return choosenTimeSpan; }
            set
            {
                choosenTimeSpan = value;
                OnPropertyChanged();
            }
        }

        //Events
        public event PropertyChangedEventHandler PropertyChanged;

        public HiddenWindow()
        {
            TimerLogic = new TimerLogic(this);
            StartWindow = new StartWindow(this);
            StopWindow = new StopWindow(this);
            OptionsWindow = new Options();

            InitializeComponent();
        }

        public void ActivateTimer(object sender, RoutedEventArgs e)
        {
            TimerLogic.StartTimer(choosenTimeSpan);
            SwitchStartWindowToStop();

            var positionsToBlock = StartWindow.BlackList.Items.OfType<string>().ToList();
            OperationsOnHostFile.BlockHosts(positionsToBlock);
        }

        private void SwitchStartWindowToStop()
        {
            StartWindow.Hide();
            StopWindow.PositionWindow();
            StopWindow.Activate();
            StopWindow.Show();
        }

        public void DeactivateTimer(object sender, RoutedEventArgs e)
        {
            TimerLogic.StopTimer();
            SwitchStopWindowToStart();

            OperationsOnHostFile.EnableHosts();
        }

        private void SwitchStopWindowToStart()
        {
            StopWindow.Hide();
            StartWindow.PositionWindow();
            StopWindow.Activate();
            StartWindow.Show();
        }

        protected void OnPropertyChanged()
        {
            StopWindow.timerLabel.Content = ChoosenTimeSpan.ToString();

            if (ChoosenTimeSpan == new TimeSpan(0, 0, 0))
            {
                SwitchStopWindowToStart();
                OperationsOnHostFile.EnableHosts();
            }
        }
    }
}

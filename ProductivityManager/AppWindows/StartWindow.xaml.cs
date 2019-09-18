using BlokerStron.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;
using BlokerStron.Logic;

namespace BlokerStron
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private HiddenWindow Parent;

        public StartWindow(HiddenWindow parent)
        {
            Parent = parent;

            InitializeComponent();
            OperationsOnInternalData.InitializeBlackListItems(BlackList);
            OperationsOnInternalData.InitializeTimerTimeReadout(TimerComponent);

            StartButton.Click += StartTimer_Click;
            StartButton.Click += Parent.ActivateTimer;
            
            Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
        }

        private void GetPositionsFromBlackListAndSaveThemAsFile()
        {
            List<string> positionsFromList = new List<string>();
            positionsFromList.AddRange(BlackList.Items.OfType<string>());

            OperationsOnInternalData.SaveBlackListToFile(positionsFromList);
        }

        private TimeSpan GettimeSpanFromTimer()
        {
            var hours = Convert.ToInt32(TimerComponent.HoursInput.Text);
            var minutes = Convert.ToInt32(TimerComponent.MinutesInput.Text);
            var seconds = Convert.ToInt32(TimerComponent.SecondsInput.Text);

            var TimeSpan = new TimeSpan(hours, minutes, seconds);

            return TimeSpan;
        }

        //EVENTS

        private void OnTaskBarMenuItemExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAddresToBlackList(object sender, RoutedEventArgs e)
        {
            string text = BlackListInput.Text;
            if (BlackListInputValidation.ValidateAndAddAnInput(text, this))
            {
                BlackListInput.Text = "";
            }

            GetPositionsFromBlackListAndSaveThemAsFile();
        }

        private void Window_Minimize(object sender, CancelEventArgs e)
        {
            this.Hide();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            this.Hide();
        }
        public void StartTimer_Click(object sender, RoutedEventArgs e)
        {
            var timeSpan = GettimeSpanFromTimer();

            Parent.ChoosenTimeSpan = timeSpan;
            OperationsOnInternalData.SaveTimeSpanToFile(timeSpan);
        }

        private void RemoveItemFromList(object sender, RoutedEventArgs e)
        {
            var senderAsButton = (Button)sender;
            var senderAsStackPanel = (StackPanel)senderAsButton.Parent;
            var childrenTextBlock = senderAsStackPanel.Children.OfType<TextBlock>().First();

            BlackList.Items.Remove(childrenTextBlock.Text);

            GetPositionsFromBlackListAndSaveThemAsFile();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            OperationsOnInternalData.SaveTimeSpanToFile(GettimeSpanFromTimer());
            e.Cancel = true;
            this.Hide();
        }
    }
}

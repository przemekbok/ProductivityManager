using BlokerStron.AppWindows.TimerWindowsAdditions;
using BlokerStron.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BlokerStron
{
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new BlokerStron.HiddenWindow();
            MainWindow.Closing += MainWindow_Closing;

            _notifyIcon = new System.Windows.Forms.NotifyIcon();
            _notifyIcon.DoubleClick += (s, args) => ShowTimerWindow();
            _notifyIcon.Icon = new System.Drawing.Icon("../../Icons/notif.ico");
            _notifyIcon.Visible = true;

            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            _notifyIcon.ContextMenuStrip =
              new System.Windows.Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ExitApplication()
        {
            _isExit = true;
            MainWindow.Close();
            _notifyIcon.Dispose();
            _notifyIcon = null;
            OperationsOnHostFile.EnableHosts();
        }

        private void ShowTimerWindow()
        {
            if (((HiddenWindow)MainWindow).TimerLogic.Timer.IsEnabled)
            {
                ((HiddenWindow)MainWindow).StopWindow.PositionWindow();
                ((HiddenWindow)MainWindow).StopWindow.Show();
                ((HiddenWindow)MainWindow).StopWindow.Activate();
            }
            else
            {
                ((HiddenWindow)MainWindow).StartWindow.PositionWindow();
                ((HiddenWindow)MainWindow).StartWindow.Show();
                ((HiddenWindow)MainWindow).StartWindow.Activate();
            }
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!_isExit)
            {
                e.Cancel = true;
                MainWindow.Hide();
            }
        }
    }
}

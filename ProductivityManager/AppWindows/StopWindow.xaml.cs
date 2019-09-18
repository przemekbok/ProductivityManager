using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using BlokerStron.Logic;

namespace BlokerStron
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StopWindow : Window
    {
        private HiddenWindow Parent;
        public StopWindow(HiddenWindow parent)
        {
            Parent = parent;
            InitializeComponent();
            StopButton.Click += Parent.DeactivateTimer;
        }

        private void openOptionsWindow(object sender, RoutedEventArgs e)
        {
            //positionOptionsWindow();
            //OptionsWindow.Show();
        }

        protected override void OnDeactivated(EventArgs e)
        {
            base.OnDeactivated(e);
            this.Hide();
        }
    }
}

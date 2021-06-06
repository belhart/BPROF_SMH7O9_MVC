using F1Stats.Dekstop.UI;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace F1Stats.Dekstop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string token;
        public MainWindow()
        {
            this.token = string.Empty;
            this.InitializeComponent();
            this.Login();
            if (token == string.Empty) this.Close();
        }

        private async Task Login()
        {
            LoginWindow lw = new LoginWindow();
            if (lw.ShowDialog() == true)
            {
                this.token = lw.Token;
            }
        }
    }
}

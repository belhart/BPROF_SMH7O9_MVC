using F1Stats.Dekstop.UI;
using F1Stats.Dekstop.viewmodels;
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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (token == string.Empty) this.Close();
        }

        private async void Login()
        {
            LoginWindow lw = new LoginWindow();
            if (lw.ShowDialog() == true)
            {
                this.token = lw.Token;
            }
        }

        private void TeamView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new TeamViewModel(token);
        }

        private void RaceWeekendView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new RaceWeekendViewModel(token);
        }
    }
}

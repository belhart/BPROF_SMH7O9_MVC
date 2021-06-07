using F1Stats.Data.Models;
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

namespace F1Stats.Dekstop.views
{
    /// <summary>
    /// Interaction logic for RedView.xaml
    /// </summary>
    public partial class RaceWeekendView : UserControl
    {
        private string token;
        public RaceWeekendView()
        {
            InitializeComponent();
        }
        private async Task RefreshTeamList()
        {
            DGrid1.ItemsSource = null;
            RestService restService = new RestService("/Versenyhetvege", token);
            IEnumerable<Versenyhetvege> teamList = await restService.Get<Versenyhetvege>();
            DGrid1.ItemsSource = teamList;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.token = ((RaceWeekendViewModel)this.DataContext).TOKEN;
            this.RefreshTeamList();
        }
    }
}

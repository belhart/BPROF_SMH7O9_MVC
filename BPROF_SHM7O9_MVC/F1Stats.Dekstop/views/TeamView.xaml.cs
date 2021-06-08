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
    /// Interaction logic for BlueView.xaml
    /// </summary>
    public partial class TeamView : UserControl
    {
        private string token;
        IEnumerable<Csapat> cacheOfTeams;

        public TeamView()
        {
            InitializeComponent();
        }

        private async Task RefreshTeamList()
        {
            DGrid1.ItemsSource = null;
            RestService restService = new RestService("/Csapat", token);
            IEnumerable<Csapat> teamList = await restService.Get<Csapat>();
            this.cacheOfTeams = teamList;
            DGrid1.ItemsSource = teamList;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.token = ((TeamViewModel)this.DataContext).TOKEN;
            this.RefreshTeamList();
        }

        private void DGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Save Changes?", "Do you want to save the changes made", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var asd = e.Row.DataContext;
                return;
            }
            DGrid1.ItemsSource = null;
            DGrid1.ItemsSource = cacheOfTeams;
        }

        private void DGrid1_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete the item?", "Delete item", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        //This is the code which helps to show the data when the row is double clicked.
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        Csapat csapat = (Csapat)dgr.Item;
                        this.DeleteTeamFromList(csapat.csapat_nev);
                    }
                    return;
                }
            }
        }

        private void DeleteTeamFromList(string name)
        {
            RestService restService = new RestService("/Csapat", token);
            try
            {
                restService.Delete<string>(name);
                MessageBox.Show("Product successfully deleted");
            }
            catch
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}

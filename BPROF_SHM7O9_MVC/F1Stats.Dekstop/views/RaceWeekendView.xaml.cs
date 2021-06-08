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
        IEnumerable<Versenyhetvege> cacheRaceWeekendteamList;
        public RaceWeekendView()
        {
            InitializeComponent();
        }
        private async Task RefreshTeamList()
        {
            DGrid1.ItemsSource = null;
            RestService restService = new RestService("/Versenyhetvege", token);
            IEnumerable<Versenyhetvege> teamList = await restService.Get<Versenyhetvege>();
            this.cacheRaceWeekendteamList = teamList;
            DGrid1.ItemsSource = teamList;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.token = ((RaceWeekendViewModel)this.DataContext).TOKEN;
            this.RefreshTeamList();
        }

        private void DGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to save the changes made?", "Save changes", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var editedValue = (e.EditingElement as TextBox).Text;
                int raceWeekendNumber = (e.Row.DataContext as Versenyhetvege).VERSENYHETVEGE_SZAMA;
                Versenyhetvege newRaceWeekend = (e.Row.DataContext as Versenyhetvege);
                switch (e.Column.SortMemberPath)
                {
                    case "nev": newRaceWeekend.nev = editedValue; break;
                    case "VERSENYHETVEGE_SZAMA": newRaceWeekend.VERSENYHETVEGE_SZAMA = int.Parse(editedValue); break;
                    case "hossz": newRaceWeekend.hossz = int.Parse(editedValue); break;
                    case "kor": newRaceWeekend.kor = int.Parse(editedValue); break;
                    case "idopont": newRaceWeekend.idopont = DateTime.Parse(editedValue); break;
                    case "helyszin": newRaceWeekend.helyszin = editedValue; break;
                    default: MessageBox.Show("Something went wrong"); return;
                }
                this.UpdateTeamFromList(raceWeekendNumber, newRaceWeekend);
                return;
            }
            DGrid1.ItemsSource = null;
            DGrid1.ItemsSource = cacheRaceWeekendteamList;
        }

        private void DGrid1_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Right) return;
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete the item?", "Delete item", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult != MessageBoxResult.Yes) return;
            DataGrid grid = sender as DataGrid;
            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {
                DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                Versenyhetvege versenyhetvege = (Versenyhetvege)dgr.Item;
                this.DeleteTeamFromList(versenyhetvege.VERSENYHETVEGE_SZAMA);
            }
        }

        private void DeleteTeamFromList(int raceWeekendNumber)
        {
            RestService restService = new RestService("/Versenyhetvege", token);
            try
            {
                restService.Delete<int>(raceWeekendNumber);
                MessageBox.Show("Race weekend successfully deleted");
                this.RefreshTeamList();
            }
            catch
            {
                MessageBox.Show("Something went wrong or you dont have access to this action.");
            }
        }

        private void UpdateTeamFromList(int raceWeekendNumber, Versenyhetvege newRaceWeekend)
        {
            RestService restService = new RestService("/Versenyhetvege", token);
            try
            {
                restService.Put<int, Versenyhetvege>(raceWeekendNumber, newRaceWeekend);
            }
            catch
            {
                MessageBox.Show("Something went wrong or you dont have access to this action.");
            }
        }
    }
}

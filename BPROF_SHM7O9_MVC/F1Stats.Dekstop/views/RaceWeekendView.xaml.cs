using F1Stats.Data.Models;
using F1Stats.Dekstop.viewmodels;
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

namespace F1Stats.Dekstop.views
{
    /// <summary>
    /// Interaction logic for RedView.xaml
    /// </summary>
    public partial class RaceWeekendView : UserControl
    {
        private string token;
        IEnumerable<Versenyhetvege> cacheRaceWeekendList;
        public RaceWeekendView()
        {
            InitializeComponent();
        }
        private async Task ResreshRaceWeekendList()
        {
            DGrid1.ItemsSource = null;
            RestService restService = new RestService("/Versenyhetvege", token);
            IEnumerable<Versenyhetvege> raceWeekendList = await restService.Get<Versenyhetvege>();
            this.cacheRaceWeekendList = raceWeekendList;
            DGrid1.ItemsSource = raceWeekendList;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.token = ((RaceWeekendViewModel)this.DataContext).TOKEN;
            await this.ResreshRaceWeekendList();
        }

        private void DGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to save the changes made?", "Save changes", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var editedValue = (e.EditingElement as TextBox).Text;
                int raceWeekendNumber = (e.Row.DataContext as Versenyhetvege).VERSENYHETVEGE_SZAMA;
                Versenyhetvege newRaceWeekend = (e.Row.DataContext as Versenyhetvege);
                try
                {
                    switch (e.Column.SortMemberPath)
                    {
                        case "nev": newRaceWeekend.nev = editedValue; break;
                        case "hossz": newRaceWeekend.hossz = int.Parse(editedValue); break;
                        case "kor": newRaceWeekend.kor = int.Parse(editedValue); break;
                        case "idopont": newRaceWeekend.idopont = DateTime.Parse(editedValue); break;
                        case "helyszin": newRaceWeekend.helyszin = editedValue; break;
                        default: MessageBox.Show("Something went wrong"); return;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid input for cell");
                }
                this.UpdateRaceWeekendFromList(raceWeekendNumber, newRaceWeekend);
                return;
            }
            DGrid1.ItemsSource = null;
            DGrid1.ItemsSource = cacheRaceWeekendList;
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
                this.DeleteRaceWeekendFromList(versenyhetvege.VERSENYHETVEGE_SZAMA);
            }
        }

        private async  void DeleteRaceWeekendFromList(int raceWeekendNumber)
        {
            RestService restService = new RestService("/Versenyhetvege", token);
            try
            {
                await restService.Delete<int>(raceWeekendNumber);
                MessageBox.Show("Race weekend successfully deleted");
                await this.ResreshRaceWeekendList();
            }
            catch
            {
                MessageBox.Show("Something went wrong or you dont have access to this action.");
            }
        }

        private async void UpdateRaceWeekendFromList(int raceWeekendNumber, Versenyhetvege newRaceWeekend)
        {
            RestService restService = new RestService("/Versenyhetvege", token);
            try
            {
                await restService.Put<int, Versenyhetvege>(raceWeekendNumber, newRaceWeekend);
            }
            catch
            {
                MessageBox.Show("Something went wrong or you dont have access to this action.");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            this.ClearFields();
        }

        private async void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            if ((this.RwnTextBox.Text == "") || (this.LaTextBox.Text == "") || (this.LeTextBox.Text == "") || (this.DTextBox.Text == "") || (this.CTextBox.Text == "")) { MessageBox.Show("Some fields are empty"); return; }
            Versenyhetvege newRaceWeeekend = new Versenyhetvege()
            {
                nev = this.RwnTextBox.Text,
                helyszin = this.CTextBox.Text,
                kor = int.Parse(this.LaTextBox.Text),
                hossz = int.Parse(this.LeTextBox.Text),
                idopont = DateTime.Parse(this.DTextBox.Text)
            };
            RestService restService = new RestService("/Versenyhetvege", token);
            try
            {
                await restService.Post<Versenyhetvege>(newRaceWeeekend);
                this.ClearFields();
                await this.ResreshRaceWeekendList();
                MessageBox.Show("Race weekend added");
            }
            catch
            {
                MessageBox.Show("Something went wrong or you dont have access to this action.");
            }

        }

        private void ClearFields()
        {
            this.RwnTextBox.Text = "";
            this.CTextBox.Text = "";
            this.LaTextBox.Text = "";
            this.LeTextBox.Text = "";
            this.DTextBox.Text = "";
        }
    }
}

﻿using F1Stats.Data.Models;
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

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.token = ((TeamViewModel)this.DataContext).TOKEN;
            await this.RefreshTeamList();
        }

        private void DGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to save the changes made?", "Save changes", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var editedValue = (e.EditingElement as TextBox).Text;
                string teamName = (e.Row.DataContext as Csapat).csapat_nev;
                Csapat newTeam = (e.Row.DataContext as Csapat);
                try
                {
                    switch (e.Column.SortMemberPath)
                    {
                        case "motor": newTeam.motor = editedValue; break;
                        case "csapat_nev": newTeam.csapat_nev = editedValue; break;
                        case "gyozelmek": newTeam.gyozelmek = int.Parse(editedValue); break;
                        case "versenyek_szama": newTeam.versenyek_szama = int.Parse(editedValue); break;
                        default: MessageBox.Show("Something went wrong"); return;
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid input for cell");
                }

                this.UpdateTeamFromList(teamName, newTeam);
                return;
            }
            DGrid1.ItemsSource = null;
            DGrid1.ItemsSource = cacheOfTeams;
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
                Csapat csapat = (Csapat)dgr.Item;
                this.DeleteTeamFromList(csapat.csapat_nev);
            }
        }

        private async void DeleteTeamFromList(string name)
        {
            RestService restService = new RestService("/Csapat", token);
            try
            {
                await restService.Delete<string>(name);
                MessageBox.Show("Team successfully deleted");
                await this.RefreshTeamList();
            }
            catch
            {
                MessageBox.Show("Something went wrong or you dont have access to this action.");
            }
        }

        private async void UpdateTeamFromList(string oldName, Csapat newTeam)
        {
            RestService restService = new RestService("/Csapat", token);
            try
            {
                await restService.Put<string, Csapat>(oldName, newTeam);
            }
            catch
            {
                MessageBox.Show("Something went wrong or you dont have access to this action.");
                await this.RefreshTeamList();
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
            if ((this.EnTextBox.Text == "") || (this.NoRTextBox.Text == "") || (this.wTextBox.Text == "") || (this.tnTextBox.Text == "")) { MessageBox.Show("Some fields are empty"); return; }
            Csapat newTeam = new Csapat()
            {
                csapat_nev = this.tnTextBox.Text,
                motor = this.EnTextBox.Text,
                gyozelmek = int.Parse(this.wTextBox.Text),
                versenyek_szama = int.Parse(this.NoRTextBox.Text)
            };
            RestService restService = new RestService("/Csapat", token);
            try
            {
                await restService.Post<Csapat>(newTeam);
                this.ClearFields();
                await this.RefreshTeamList();
                MessageBox.Show("Team added");
            }
            catch
            {
                MessageBox.Show("Something went wrong or you dont have access to this action.");
            }

        }

        private void ClearFields()
        {
            this.tnTextBox.Text = "";
            this.wTextBox.Text = "";
            this.NoRTextBox.Text = "";
            this.EnTextBox.Text = "";
        }
    }
}

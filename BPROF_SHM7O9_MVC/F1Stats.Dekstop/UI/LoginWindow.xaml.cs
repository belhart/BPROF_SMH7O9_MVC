using F1Stats.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace F1Stats.Dekstop.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Token { get; private set; }
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            RestService restService = new RestService("https://pcwebshop.azurewebsites.net/", "/Auth");
            restService.Post<RegisterViewModel>(new RegisterViewModel()
            {
                Email = username.Text,
                Password = password.Password
            });

            MessageBox.Show("You can log in now.");
        }
    }
}

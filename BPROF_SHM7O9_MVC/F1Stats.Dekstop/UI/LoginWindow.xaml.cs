﻿using System;
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

        }
    }
}

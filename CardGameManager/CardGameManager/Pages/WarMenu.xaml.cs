﻿using System;
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

namespace CardGameManager.Pages
{
    /// <summary>
    /// Interaction logic for WarMenu.xaml
    /// </summary>
    public partial class WarMenu : Page
    {
        public WarMenu()
        {
            InitializeComponent();
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PVP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PVC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.NavigationService.Navigate(mainMenu);
        }
    }
}

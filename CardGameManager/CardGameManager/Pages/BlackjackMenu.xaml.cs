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
    /// Interaction logic for BlackjackMenu.xaml
    /// </summary>
    public partial class BlackjackMenu : Page
    {
        public BlackjackMenu()
        {
            InitializeComponent();
        }

        private void OnePlayer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TwoPlayer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ThreePlayer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FourPlayer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void FivePlayer_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.NavigationService.Navigate(mainMenu);
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            Instructions instructions = new Instructions("Placeholder");
            this.NavigationService.Navigate(instructions);
        }
    }
}

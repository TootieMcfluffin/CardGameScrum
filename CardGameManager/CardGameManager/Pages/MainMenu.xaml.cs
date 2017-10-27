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

namespace CardGameManager.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BlackjackButton_Click(object sender, RoutedEventArgs e)
        {
            BlackjackMenu blackjackMenu = new BlackjackMenu();
            this.NavigationService.Navigate(blackjackMenu);
        }

        private void Poker_Click(object sender, RoutedEventArgs e)
        {

        }

        private void War_Click(object sender, RoutedEventArgs e)
        {
            WarMenu warMenu = new WarMenu();
            this.NavigationService.Navigate(warMenu);
        }

        private void GoFish_Click(object sender, RoutedEventArgs e)
        {
            GoFishMenu goFishMenu = new GoFishMenu();
            this.NavigationService.Navigate(goFishMenu);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

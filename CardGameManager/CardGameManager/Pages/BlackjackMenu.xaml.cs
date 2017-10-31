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
            GameSetup setup = new GameSetup(1, "blackjack");
            this.NavigationService.Navigate(setup);
        }
        private void TwoPlayer_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(2, "blackjack");
            this.NavigationService.Navigate(setup);
        }
        private void ThreePlayer_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(3, "blackjack");
            this.NavigationService.Navigate(setup);
        }
        private void FourPlayer_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(4, "blackjack");
            this.NavigationService.Navigate(setup);
        }
        private void FivePlayer_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(5, "blackjack");
            this.NavigationService.Navigate(setup);
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.NavigationService.Navigate(mainMenu);
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            Instructions instructions = new Instructions("Every player will test their hand against the dealer to see if they can win at Blackjack." +
                "\nPlayers can hit to receive a new card for their hand, or stand to keep their current hand." +
                "\nPlayers may also split their hand if they have two cards of the same value in their opening hand. If a player splits their hand, they now have two hands with which to play against the dealer." +
                "\nTo beat the dealer, the player must have a higher value hand than the dealer. However, there is a maximum hand value of 21. If anyone goes over this value, they bust." +
                "\nIf a player gets 21 and the dealer doesn't, they receive 3x the amount they bet." +
                "\nA normal win will net the player 2x what they bet." +
                "\nThe player will receive what they bet if they end with the same hand value as the dealer." +
                "\nThe player may have up to a maximum of 5 cards in their hand. If the player doesn't bust on the fifth card, they have a Charlie." +
                "\nIf the player wins with a Charlie, they receive 4x what they bet." +
                "\nHave fun and do your best in Blackjack.");
            this.NavigationService.Navigate(instructions);
        }
    }
}

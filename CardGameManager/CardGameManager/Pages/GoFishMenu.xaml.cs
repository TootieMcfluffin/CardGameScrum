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
    /// Interaction logic for GoFishMenu.xaml
    /// </summary>
    public partial class GoFishMenu : Page
    {

        public GoFishMenu()
        {
            InitializeComponent();
        }

        private void TwoPLayer_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(2, "gofish");
            this.NavigationService.Navigate(setup);
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            Instructions instructions = new Instructions("Compete against your friends in the exciting game of Go Fish." +
                "\nEach player is dealt five cards. The rest of the cards are set in the center as the deck. They may play any pairs from their hand at this time." +
                "\nPairs are made by matching two cards of the same value. They do not have to have the same color." +
                "\nPlay moves clockwise from the first player." +
                "\nOn the player's turn, they ask another player for a card value. If the asked player has it, they give it to the questioning player." +
                "\nThe next player takes their turn after the previous player is told \'Go fish\', where they then draw one card from the deck." +
                "\nIf the player draws the card they asked for, their turn continues." +
                "\nIf a player runs out of cards in their hand at any time, they draw five cards from the deck, unless the deck is empty." +
                "\nThe game ends once all pairs have been made. Pairs are tallied at this time, and the player with the most pairs wins.");
            this.NavigationService.Navigate(instructions);
        }

        private void ThreePlayer_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(3, "gofish");
            this.NavigationService.Navigate(setup);
        }

        private void FourPlayer_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(4, "gofish");
            this.NavigationService.Navigate(setup);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.NavigationService.Navigate(mainMenu);
        }

		
    }
}

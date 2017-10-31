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
            Instructions instructions = new Instructions("Play against your friends in the everlasting game of War." +
                "\nBoth players receive 26 cards. This is their deck." +
                "\nThey will flip the top card of their deck at the same time." +
                "\nWhoever has the higher card gets both cards and puts them into their reserve deck." +
                "\nThe reserve deck is used when the player's main deck runs out of cards." +
                "\nIf both cards are the same value, the players go to war." +
                "\nWhen war occurs, both players put the top 3 cards of their deck face down, and then flip the top card of their deck face up." +
                "\nThe player with the highest value card wins all the cards sent to war." +
                "\nIf the cards are the same value again, the process of war will repeat." +
                "\nIf a player runs out of cards in their main deck before laying down all face down cards, the last card of their deck will be their face up card." +
                "\nA loser is decided when a player has 3 or less cards in their main deck, and 0 cards in their reserve deck.");
            this.NavigationService.Navigate(instructions);
        }

        private void PVP_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(2, "war");
            this.NavigationService.Navigate(setup);
        }

        private void PVC_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(1, "war");
            this.NavigationService.Navigate(setup);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.NavigationService.Navigate(mainMenu);
        }
    }
}

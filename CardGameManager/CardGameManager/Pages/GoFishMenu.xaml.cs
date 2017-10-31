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

		// Need to make GetCurrentPlayer() method.
		// Need to make GetPlayerAsked() method.
		// Need to make ChangePlayer() method.
		// Have kade teach me how all() of this navigation mumbo jumbo works.

        public GoFishMenu()
        {
            InitializeComponent();
        }

        private void TwoPLayer_Click(object sender, RoutedEventArgs e)
        {
            GameSetup setup = new GameSetup(2, "blackjack");
            this.NavigationService.Navigate(setup);
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            Instructions instructions = new Instructions("These are Go Fish Instructions");
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

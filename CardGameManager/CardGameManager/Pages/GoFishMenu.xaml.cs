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

        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ThreePlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FourPlayer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.NavigationService.Navigate(mainMenu);
        }
    }
}

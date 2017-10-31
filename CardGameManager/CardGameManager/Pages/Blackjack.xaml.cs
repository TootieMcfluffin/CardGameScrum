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
    /// Interaction logic for Blackjack.xaml
    /// </summary>
    public partial class Blackjack : Page
    {
        public Blackjack(List<string> names)
        {
            InitializeComponent();
            for(int i = 0; i < names.Count; i++)
            {
                if(i == 0)
                {
                    PlayerOneName.Content = names.ElementAt(i);
                }
                else if (i == 1)
                {
                    PlayerTwoName.Content = names.ElementAt(i);
                }
                else if (i == 2)
                {
                    PlayerThreeName.Content = names.ElementAt(i);
                }
                else if (i == 3)
                {
                    PlayerFourName.Content = names.ElementAt(i);
                }
                else if (i == 4)
                {
                    PlayerFiveName.Content = names.ElementAt(i);
                }
            }
            
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Split_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stay_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

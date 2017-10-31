using CardGameManager.Models;
using CardGameManager.GameProcesses;
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
        List<Player> players;
        BlackjackGame currentGame;
        public Blackjack(List<string> names)
        {
            InitializeComponent();

            List<Player> players = new List<Player>();

            for(int i = 0; i < names.Count; i++)
            {
                if(i == 0)
                {
                    PlayerOneName.Content = names.ElementAt(i);
                    Player p1 = new Player();
                    players.Add(p1);
                }
                else if (i == 1)
                {
                    PlayerTwoName.Content = names.ElementAt(i);
                    Player p2 = new Player();
                    players.Add(p2);
                }
                else if (i == 2)
                {
                    PlayerThreeName.Content = names.ElementAt(i);
                    Player p3 = new Player();
                    players.Add(p3);
                }
                else if (i == 3)
                {
                    PlayerFourName.Content = names.ElementAt(i);
                    Player p4 = new Player();
                    players.Add(p4);
                }
                else if (i == 4)
                {
                    PlayerFiveName.Content = names.ElementAt(i);
                    Player p5 = new Player();
                    players.Add(p5);
                }
            }

            currentGame = new BlackjackGame(players);
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

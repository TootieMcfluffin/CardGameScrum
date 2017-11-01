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
using CardGameManager.Converters;



//Turn logic is messy af. Please redo.


namespace CardGameManager.Pages
{
    /// <summary>
    /// Interaction logic for Blackjack.xaml
    /// </summary>
    public partial class Blackjack : Page
    {
        List<Player> players;
        //Player currentPlayer;
        BlackjackGame currentGame;
        ImageBrush cardBackBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\CARD_BACK.png", UriKind.RelativeOrAbsolute)));
        public Blackjack(List<string> names)
        {
            InitializeComponent();

            players = new List<Player>();

            for(int i = 0; i < names.Count; i++)
            {
                if(i == 0)
                {
                    PlayerOneName.Content = names.ElementAt(i);
                    Player p1 = new Player();
                    p1.playerID = i + 1;
                    players.Add(p1);
                }
                else if (i == 1)
                {
                    PlayerTwoName.Content = names.ElementAt(i);
                    Player p2 = new Player();
                    p2.playerID = i + 1;
                    players.Add(p2);
                }
                else if (i == 2)
                {
                    PlayerThreeName.Content = names.ElementAt(i);
                    Player p3 = new Player();
                    p3.playerID = i + 1;
                    players.Add(p3);
                }
                else if (i == 3)
                {
                    PlayerFourName.Content = names.ElementAt(i);
                    Player p4 = new Player();
                    p4.playerID = i + 1;
                    players.Add(p4);
                }
                else if (i == 4)
                {
                    PlayerFiveName.Content = names.ElementAt(i);
                    Player p5 = new Player();
                    p5.playerID = i + 1;
                    players.Add(p5);
                }
            }
            Player dealer = new Player();
            dealer.IsDealer = true;
            dealer.playerID = players.Count + 1;
            currentGame = new BlackjackGame(players);
            players.Add(dealer);
            Deal();
        }

        private void Deal()
        {
            int count = 0;
            currentGame.Deal();
            foreach  (Player p in currentGame.players)
            {
                //currentPlayer = p;
                currentGame.currentPlayer = p;
                currentGame.currentPlayer.Balance = 20;
                foreach (CardModel card in p.hand)
                {
                    AddCard(count);
                    count++;
                }
                count = 0;
            }
            currentGame.currentPlayer = currentGame.players[0];
        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            currentGame.Hit();
            currentGame.currentPlayer.hand.Add(currentGame.deck.DrawCard());
            AddCard();
            if (currentGame.currentPlayer.IsDealer)
            {
                MessageBox.Show("I'm the dealer!");
            }
            if (BlackjackRules.CheckForBust(currentGame.currentPlayer.hand))
            {
                MessageBox.Show("You busted!");
                currentGame.PlayerTurnEnd();
                
            }
        }

        private void Split_Click(object sender, RoutedEventArgs e)
        {
             BlackjackRules.CheckForSplit(currentGame.currentPlayer);
        }

        private void Stay_Click(object sender, RoutedEventArgs e)
        {
            currentGame.PlayerTurnEnd();
        }

        private void AddCard(int num)
        {
            Label newLabel = MakeRectangle();
            CardModel card = currentGame.currentPlayer.hand[num];
            newLabel.DataContext = card;
            Binding newBinding = new Binding();
            newBinding.Path = new PropertyPath("IsFlipped");
            BoolToImageConverter b2i = new BoolToImageConverter();
            b2i.CardBrush = new ImageBrush(new BitmapImage(new Uri(currentGame.currentPlayer.hand[num].ImagePath, UriKind.RelativeOrAbsolute)));
            b2i.CardBackBrush = cardBackBrush;
            newBinding.Converter = b2i;
            newBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(newLabel, Label.BackgroundProperty, newBinding);

            if (currentGame.currentPlayer.IsDealer)
            {
                HouseHand.Children.Add(newLabel);
            }
            else if (currentGame.currentPlayer.playerID == 1)
            {
                PlayerOneHand.Children.Add(newLabel);
            }
            else if (currentGame.currentPlayer.playerID == 2)
            {
                PlayerTwoHand.Children.Add(newLabel);
            }
            else if (currentGame.currentPlayer.playerID == 3)
            {
                PlayerThreeHand.Children.Add(newLabel);
            }
            else if (currentGame.currentPlayer.playerID == 4)
            {
                PlayerFourHand.Children.Add(newLabel);
            }
            else
            {
                PlayerFiveHand.Children.Add(newLabel);
            }

        }

        private void AddCard()
        {
            Label newLabel = MakeRectangle();
            CardModel card = currentGame.currentPlayer.hand.Last();
            newLabel.DataContext = card;
            Binding newBinding = new Binding();
            newBinding.Path = new PropertyPath("IsFlipped");
            BoolToImageConverter b2i = new BoolToImageConverter();
            b2i.CardBrush = new ImageBrush(new BitmapImage(new Uri(currentGame.currentPlayer.hand.Last().ImagePath, UriKind.RelativeOrAbsolute)));
            b2i.CardBackBrush = cardBackBrush;
            newBinding.Mode = BindingMode.OneWay;
            newBinding.Converter = b2i;
            newBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(newLabel, Label.BackgroundProperty, newBinding);

            if (currentGame.currentPlayer.IsDealer)
            {
                HouseHand.Children.Add(newLabel);
            }
            else if (currentGame.currentPlayer.playerID == 1)
            {
                PlayerOneHand.Children.Add(newLabel);
            }
            else if (currentGame.currentPlayer.playerID == 2)
            {
                PlayerTwoHand.Children.Add(newLabel);
            }
            else if (currentGame.currentPlayer.playerID == 3)
            {
                PlayerThreeHand.Children.Add(newLabel);
            }
            else if (currentGame.currentPlayer.playerID == 4)
            {
                PlayerFourHand.Children.Add(newLabel);
            }
            else
            {
                PlayerFiveHand.Children.Add(newLabel);
            }

        }

        /// <summary>
        /// Creates a label
        /// </summary>
        /// <returns>A Label</returns>
        private Label MakeRectangle()
        {

            SolidColorBrush shapeBrush = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255));
            SolidColorBrush shapeBrush2 = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            Thickness thicc = new Thickness(.5);
            Label rectangleLabel = new Label
            {
                Background = shapeBrush,
                BorderBrush = shapeBrush2,
                BorderThickness = thicc
            };
            return rectangleLabel;
        }

    }
}

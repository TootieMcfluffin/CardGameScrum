using CardGameManager.Converters;
using CardGameManager.GameProcesses;
using CardGameManager.Models;
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
    /// Interaction logic for War.xaml
    /// </summary>
    public partial class War : Page
    {
        public Player playerOne = new Player();
        public Player playerTwo = new Player();
        public CardModel pOneCurrentCard;
        public CardModel pTwoCurrentCard;
        public List<CardModel> warWinning = new List<CardModel>();
        public War(List<string> names)
        {
            InitializeComponent();
            if (names.Count == 1)
            {
                playerOne.Name = names.ElementAt(0);
                playerTwo.Name = "Computer";
            }
            else
            {
                playerOne.Name = names.ElementAt(0);
                playerTwo.Name = names.ElementAt(1);
            }
            PlayerOneName.Content = playerOne.Name;
            PlayerTwoName.Content = playerTwo.Name;
            PopulatePlayerHand();
            pOnePlayDeckCount.Content = $"Cards Remaining: {playerOne.hand.Count}";
            pTwoPlayDeckCount.Content = $"Cards Remaining: {playerTwo.hand.Count}";
        }

        public void PopulatePlayerHand()
        {
            DeckModel deck = new DeckModel();
            deck.Shuffle();
            bool playerOneCard = true;
            foreach (CardModel card in deck.Deck)
            {
                if (playerOneCard)
                {
                    playerOne.hand.Add(card);
                    playerOneCard = false;
                }
                else
                {
                    playerTwo.hand.Add(card);
                    playerOneCard = true;
                }
            }
        }

        /// <summary>
        /// Used to advance a turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Advance_Click(object sender, RoutedEventArgs e)
        {
            //Checks if player ones hand is empty
            if (playerOne.hand.Count == 0)
            {
                //Checks if the player has lost due to lack of cards
                if(WarRules.IsLoser(playerOne))
                {
                    //Displays a win message and navigates back to the war menu
                    MessageBox.Show($"{playerTwo.Name} is the winner! {playerOne.Name} is the loser...");
                    WarMenu war = new WarMenu();
                    this.NavigationService.Navigate(war);
                }
                //If they haven't lost the winning pile is shuffled into their hand
                playerOne.ShuffleSecondHand();
                playerOne.hand = playerOne.secondHand;
                //Resets the winnings pile
                playerOne.secondHand = new List<CardModel>();
                //Makes the winnings pile's background appear empty on the GUI
                PlayerOneWinnings.Background = Brushes.DarkGreen;
            }
            //Checks if player twos hand is empty
            if (playerTwo.hand.Count == 0)
            {
                //Checks if the player has lost due to lack of cards
                if (WarRules.IsLoser(playerTwo))
                {
                    //Displays a win message and navigates back to the war menu
                    MessageBox.Show($"{playerOne.Name} is the winner! {playerTwo.Name} is the loser...");
                    WarMenu war = new WarMenu();
                    this.NavigationService.Navigate(war);
                }
                //If they haven't lost the winning pile is shuffled into their hand
                playerTwo.ShuffleSecondHand();
                playerTwo.hand = playerTwo.secondHand;
                //Resets the winnings pile
                playerTwo.secondHand = new List<CardModel>();
                //Makes the winnings pile's background appear empty on the GUI
                PlayerTwoWinnings.Background = Brushes.DarkGreen;
            }

            //Makes the last cards won appear in the winnings pile of player one on the GUI
            if (playerOne.secondHand.Count != 0)
            {
                PlayerOneWinnings.Background = new ImageBrush(new BitmapImage(new Uri(pOneCurrentCard.ImagePath, UriKind.Relative)));
            }
            //If they just shuffled their winning into their hand the winnings pile appears empty
            else
            {
                PlayerOneWinnings.Background = Brushes.DarkGreen;
            }
            //Makes the last cards won appear in the winnings pile of player two on the GUI
            if (playerTwo.secondHand.Count != 0)
            {
                PlayerTwoWinnings.Background = new ImageBrush(new BitmapImage(new Uri(pTwoCurrentCard.ImagePath, UriKind.Relative)));
            }
            //If they just shuffled their winning into their hand the winnings pile appears empty
            else
            {
                PlayerTwoWinnings.Background = Brushes.DarkGreen;
            }

            //Draws a card for player one and makes it appear on the GUI
            pOneCurrentCard = playerOne.hand.Last();
            playerOne.hand.RemoveAt(playerOne.hand.Count - 1);
            PlayerOneCurrentCard.Background = new ImageBrush(new BitmapImage(new Uri(pOneCurrentCard.ImagePath, UriKind.Relative)));
            //Draws a card for player two and makes it appear on the GUI
            pTwoCurrentCard = playerTwo.hand.Last();
            playerTwo.hand.RemoveAt(playerTwo.hand.Count - 1);
            PlayerTwoCurrentCard.Background = new ImageBrush(new BitmapImage(new Uri(pTwoCurrentCard.ImagePath, UriKind.Relative)));

            //If player ones hand is empty, this makes it appear so on the GUI
            if (playerOne.hand.Count == 0)
            {
                PlayerOneDeck.Background = Brushes.DarkGreen;
            }
            //Otherwise the back of the cards is shown
            else
            {
                PlayerOneDeck.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
            }
            //If player twos hand is empty, this makes it appear so on the GUI
            if (playerTwo.hand.Count == 0)
            {
                PlayerTwoDeck.Background = Brushes.DarkGreen;
            }
            //Otherwise the back of the cards is shown
            else
            {
                PlayerTwoDeck.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
            }

            //Checks if player one has lost by going to war with nothing in hand
            if(WarRules.IsWar(pOneCurrentCard, pTwoCurrentCard) && playerOne.hand.Count == 0)
            {
                MessageBox.Show($"{playerTwo.Name} is the winner! {playerOne.Name} is the loser...");
                WarMenu war = new WarMenu();
                this.NavigationService.Navigate(war);
            }
            //Checks if player two has lost by going to war with nothing in hand
            else if (WarRules.IsWar(pOneCurrentCard, pTwoCurrentCard) && playerTwo.hand.Count == 0)
            {
                MessageBox.Show($"{playerOne.Name} is the winner! {playerTwo.Name} is the loser...");
                WarMenu war = new WarMenu();
                this.NavigationService.Navigate(war);
            }
            //Checks if a war is going to happen
            else if (WarRules.IsWar(pOneCurrentCard, pTwoCurrentCard))
            {
                //Iteration to place card backs to represent cards anted for war
                for(int i = 0; i < 3; i++)
                {
                    //Checks to make sure player one has cards to ante, and makes sure that at least on card is left in hand
                    if(playerOne.hand.Count > 1)
                    {
                        //Adds the cards placed face down to the ante pool and removes them from the players hand
                        warWinning.Add(playerOne.hand.Last());
                        playerOne.hand.RemoveAt(playerOne.hand.Count - 1);
                        if (i == 0)
                        {
                            pOneSlotOne.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
                        }
                        if (i == 1)
                        {
                            pOneSlotTwo.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
                        }
                        if (i == 2)
                        {
                            pOneSlotThree.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
                        }
                    }
                    //Checks to make sure player two has cards to ante, and makes sure that at least on card is left in hand
                    if (playerTwo.hand.Count > 1)
                    {
                        //Adds the cards placed face down to the ante pool and removes them from the players hand
                        warWinning.Add(playerTwo.hand.Last());
                        playerTwo.hand.RemoveAt(playerTwo.hand.Count - 1);
                        if (i == 0)
                        {
                            pTwoSlotOne.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
                        }
                        if (i == 1)
                        {
                            pTwoSlotTwo.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
                        }
                        if (i == 2)
                        {
                            pTwoSlotThree.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
                        }
                    }
                }
                //Adds the face up cards to the ante pool
                warWinning.Add(pOneCurrentCard);
                warWinning.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            //Checks if player one has won by getting an ace
            else if (pOneCurrentCard.CardValue == Enums.Value.ACE)
            {
                //If a war happened on the previous turn the ante pile is added to the players winnings
                if(warWinning.Count > 0)
                {
                    //Tells the player which cards they have won
                    string wins = $"{playerOne.Name} won: ";
                    foreach(CardModel card in warWinning)
                    {
                    //Tells the player which cards they have won
                        playerOne.secondHand.Add(card);
                        wins += $"{card.CardValuesString}   ";
                    }
                    pOneSlotOne.Background = Brushes.DarkGreen;
                    pOneSlotTwo.Background = Brushes.DarkGreen;
                    pOneSlotThree.Background = Brushes.DarkGreen;
                    pTwoSlotOne.Background = Brushes.DarkGreen;
                    pTwoSlotTwo.Background = Brushes.DarkGreen;
                    pTwoSlotThree.Background = Brushes.DarkGreen;
                    MessageBox.Show(wins);
                    warWinning = new List<CardModel>();
                }
                //Adds the cards won to the players winnings
                playerOne.secondHand.Add(pOneCurrentCard);
                playerOne.secondHand.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            //Checks if player two has won by getting an ace
            else if (pTwoCurrentCard.CardValue == Enums.Value.ACE)
            {
                //If a war happened on the previous turn the ante pile is added to the players winnings
                if (warWinning.Count > 0)
                {
                    //Tells the player which cards they have won
                    string wins = $"{playerTwo.Name} won: ";
                    foreach (CardModel card in warWinning)
                    {
                        playerTwo.secondHand.Add(card);
                        wins += $"{card.CardValuesString}   ";
                    }
                    pOneSlotOne.Background = Brushes.DarkGreen;
                    pOneSlotTwo.Background = Brushes.DarkGreen;
                    pOneSlotThree.Background = Brushes.DarkGreen;
                    pTwoSlotOne.Background = Brushes.DarkGreen;
                    pTwoSlotTwo.Background = Brushes.DarkGreen;
                    pTwoSlotThree.Background = Brushes.DarkGreen;
                    MessageBox.Show(wins);
                    warWinning = new List<CardModel>();
                }
                //Adds the cards won to the players winnings
                playerTwo.secondHand.Add(pOneCurrentCard);
                playerTwo.secondHand.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            //Checks if player one has won the round by getting high card
            else if (WarRules.PlayerOneWinsRound(pOneCurrentCard, pTwoCurrentCard))
            {
                //If a war happened on the previous turn the ante pile is added to the players winnings
                if (warWinning.Count > 0)
                {
                    //Tells the player which cards they have won
                    string wins = $"{playerOne.Name} won: ";
                    foreach (CardModel card in warWinning)
                    {
                        playerOne.secondHand.Add(card);
                        wins += $"{card.CardValuesString}   ";
                    }
                    pOneSlotOne.Background = Brushes.DarkGreen;
                    pOneSlotTwo.Background = Brushes.DarkGreen;
                    pOneSlotThree.Background = Brushes.DarkGreen;
                    pTwoSlotOne.Background = Brushes.DarkGreen;
                    pTwoSlotTwo.Background = Brushes.DarkGreen;
                    pTwoSlotThree.Background = Brushes.DarkGreen;
                    MessageBox.Show(wins);
                    warWinning = new List<CardModel>();
                }
                //Adds the cards won to the players winnings
                playerOne.secondHand.Add(pOneCurrentCard);
                playerOne.secondHand.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            //Checks if player Two has won the round by getting high card
            else if (!WarRules.PlayerOneWinsRound(pOneCurrentCard, pTwoCurrentCard))
            {
                //If a war happened on the previous turn the ante pile is added to the players winnings
                if (warWinning.Count > 0)
                {
                    //Tells the player which cards they have won
                    string wins = $"{playerTwo.Name} won: ";
                    foreach (CardModel card in warWinning)
                    {
                        playerTwo.secondHand.Add(card);
                        wins += $"{card.CardValuesString}   ";
                    }
                    pOneSlotOne.Background = Brushes.DarkGreen;
                    pOneSlotTwo.Background = Brushes.DarkGreen;
                    pOneSlotThree.Background = Brushes.DarkGreen;
                    pTwoSlotOne.Background = Brushes.DarkGreen;
                    pTwoSlotTwo.Background = Brushes.DarkGreen;
                    pTwoSlotThree.Background = Brushes.DarkGreen;
                    MessageBox.Show(wins);
                    warWinning = new List<CardModel>();
                }
                //Adds the cards won to the players winnings
                playerTwo.secondHand.Add(pOneCurrentCard);
                playerTwo.secondHand.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            pOnePlayDeckCount.Content = $"Cards Remaining: {playerOne.hand.Count}";
            pTwoPlayDeckCount.Content = $"Cards Remaining: {playerTwo.hand.Count}";
        }
    }
}

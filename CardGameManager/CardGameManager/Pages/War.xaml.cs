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

        private void Advance_Click(object sender, RoutedEventArgs e)
        {
            if (playerOne.hand.Count == 0)
            {
                if(WarRules.IsLoser(playerOne))
                {
                    MessageBox.Show($"{playerTwo.Name} is the winner! {playerOne.Name} is the loser...");
                    WarMenu war = new WarMenu();
                    this.NavigationService.Navigate(war);
                }
                playerOne.ShuffleSecondHand();
                playerOne.hand = playerOne.secondHand;
                playerOne.secondHand = new List<CardModel>();
                PlayerOneWinnings.Background = Brushes.DarkGreen;
            }
            if (playerTwo.hand.Count == 0)
            {
                if (WarRules.IsLoser(playerTwo))
                {
                    MessageBox.Show($"{playerOne.Name} is the winner! {playerTwo.Name} is the loser...");
                    WarMenu war = new WarMenu();
                    this.NavigationService.Navigate(war);
                }
                playerTwo.ShuffleSecondHand();
                playerTwo.hand = playerTwo.secondHand;
                playerTwo.secondHand = new List<CardModel>();
                PlayerTwoWinnings.Background = Brushes.DarkGreen;
            }
            if (playerOne.secondHand.Count != 0)
            {
                PlayerOneWinnings.Background = new ImageBrush(new BitmapImage(new Uri(pOneCurrentCard.ImagePath, UriKind.Relative)));
            }
            else
            {
                PlayerOneWinnings.Background = Brushes.DarkGreen;
            }
            if (playerTwo.secondHand.Count != 0)
            {
                PlayerTwoWinnings.Background = new ImageBrush(new BitmapImage(new Uri(pTwoCurrentCard.ImagePath, UriKind.Relative)));
            }
            else
            {
                PlayerTwoWinnings.Background = Brushes.DarkGreen;
            }
            //BoolToImageConverter converter = new BoolToImageConverter();
            pOneCurrentCard = playerOne.hand.Last();
            playerOne.hand.RemoveAt(playerOne.hand.Count - 1);
            PlayerOneCurrentCard.Background = new ImageBrush(new BitmapImage(new Uri(pOneCurrentCard.ImagePath, UriKind.Relative)));
            pTwoCurrentCard = playerTwo.hand.Last();
            playerTwo.hand.RemoveAt(playerTwo.hand.Count - 1);
            PlayerTwoCurrentCard.Background = new ImageBrush(new BitmapImage(new Uri(pTwoCurrentCard.ImagePath, UriKind.Relative)));
            if (playerOne.hand.Count == 0)
            {
                PlayerOneDeck.Background = Brushes.DarkGreen;
            }
            else
            {
                PlayerOneDeck.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
            }
            if (playerTwo.hand.Count == 0)
            {
                PlayerTwoDeck.Background = Brushes.DarkGreen;
            }
            else
            {
                PlayerTwoDeck.Background = new ImageBrush(new BitmapImage(new Uri("..\\..\\Images\\CARD_BACK.png", UriKind.Relative)));
            }
            if(WarRules.IsWar(pOneCurrentCard, pTwoCurrentCard) && playerOne.hand.Count == 0)
            {
                MessageBox.Show($"{playerTwo.Name} is the winner! {playerOne.Name} is the loser...");
                WarMenu war = new WarMenu();
                this.NavigationService.Navigate(war);
            }
            else if (WarRules.IsWar(pOneCurrentCard, pTwoCurrentCard) && playerTwo.hand.Count == 0)
            {
                MessageBox.Show($"{playerOne.Name} is the winner! {playerTwo.Name} is the loser...");
                WarMenu war = new WarMenu();
                this.NavigationService.Navigate(war);
            }
            else if (WarRules.IsWar(pOneCurrentCard, pTwoCurrentCard))
            {
                for(int i = 0; i < 3; i++)
                {
                    if(playerOne.hand.Count > 1)
                    {
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
                    if(playerTwo.hand.Count > 1)
                    {
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
                playerOne.secondHand.Add(pOneCurrentCard);
                playerTwo.secondHand.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            else if (pOneCurrentCard.CardValue == Enums.Value.ACE)
            {
                if(warWinning.Count > 0)
                {
                    string wins = $"{playerOne.Name} won: ";
                    foreach(CardModel card in warWinning)
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
                playerOne.secondHand.Add(pOneCurrentCard);
                playerOne.secondHand.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            else if (pTwoCurrentCard.CardValue == Enums.Value.ACE)
            {
                if (warWinning.Count > 0)
                {
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
                playerTwo.secondHand.Add(pOneCurrentCard);
                playerTwo.secondHand.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            else if (WarRules.PlayerOneWinsRound(pOneCurrentCard, pTwoCurrentCard))
            {
                if (warWinning.Count > 0)
                {
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
                playerOne.secondHand.Add(pOneCurrentCard);
                playerOne.secondHand.Add(pTwoCurrentCard);
                pOnePlayWinCount.Content = $"Cards Won: {playerOne.secondHand.Count}";
                pTwoPlayWinCount.Content = $"Cards Won: {playerTwo.secondHand.Count}";
            }
            else if (!WarRules.PlayerOneWinsRound(pOneCurrentCard, pTwoCurrentCard))
            {
                if (warWinning.Count > 0)
                {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameManager.Models;

namespace CardGameManager.GameProcesses
{
    public static class BlackjackRules
    {
        /// <summary>
        /// Returns a boolean that represents whether or not the player has busted or not.
        /// </summary>
        /// <param name="playerHand"> The cards currently in the player's hand.</param>
        /// <returns> true if the player has busted, false otherwise.</returns>
        public static bool CheckForBust(List<CardModel> playerHand)
        {

            int handValue = HandValue(playerHand);
            
            if (handValue > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the total value of the cards in a selected players hand.
        /// </summary>
        /// <param name="playerHand">A list of card objects representing a players hand. </param>
        /// <returns>The total card value of a player's hand. </returns>
        private static int HandValue(List<CardModel> playerHand)
        {
            int handValue = 0;
            int handSize = playerHand.Count;
            int cardCount = 0;
            foreach (CardModel card in playerHand)
            {
                cardCount++;
                if (card.CardValue == Enums.Value.ACE && handValue <= 10 && cardCount == handSize)
                {
                    handValue += 11;
                }
                else
                {
                    handValue += (int)card.CardValue;
                }
            }

            return handValue;
        }

        /// <summary>
        /// Checks if a player gets eliminated due to too much debt. ($500)
        /// </summary>
        /// <param name="playerMoney">Int that represents the player's current balance</param>
        /// <returns>A boolean that determines if the player will be eliminated.</returns>
        public static bool Elimination(int playerMoney)
        {
            if(playerMoney <= -50)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 

        /// <summary>
        /// Returns an enum representing the way the current player has won or if they have lost. This enum will then be used to determine the payout to the player.
        /// </summary>
        /// <param name="playerHand">The card list for the player</param>
        /// <param name="dealerHand">The card list for the dealer</param>
        /// <returns>Enum that represents if they lost or how they won.</returns>
        public static Enums.WinConditionBlackjack CheckWinCondition(List<CardModel> playerHand, List<CardModel> dealerHand)
        {
            int playerHandValue = HandValue(playerHand);
            int playerHandCount = playerHand.Count;
            int dealerHandValue = HandValue(dealerHand);
            int dealerHandCount = dealerHand.Count;

            Enums.WinConditionBlackjack condition = Enums.WinConditionBlackjack.NULL;

            if (playerHandCount == 5 && dealerHandCount == 5)
            {
                if (playerHandValue <= 21)
                {
                    if (playerHandValue == dealerHandValue)
                    {
                        condition = Enums.WinConditionBlackjack.NULL;
                    }
                    else if (playerHandValue == 21)
                    {
                        condition = Enums.WinConditionBlackjack.CHARLIE;
                    }
                    else if (playerHandValue > dealerHandValue)
                    {
                        condition = Enums.WinConditionBlackjack.CHARLIE;
                    }
                    else
                    {
                        condition = Enums.WinConditionBlackjack.LOST;
                    }
                }
            }
            else if (playerHandCount == 5)
            {
                condition = Enums.WinConditionBlackjack.CHARLIE;
            }
            else if (dealerHandCount == 5)
            {
                condition = Enums.WinConditionBlackjack.LOST;
            }
            else if (playerHandValue <= 21)
            {
                if (playerHandValue == dealerHandValue)
                {
                    condition = Enums.WinConditionBlackjack.NULL;
                }
                else if (playerHandValue == 21)
                {
                    condition = Enums.WinConditionBlackjack.BLACKJACK;
                }
                else if (playerHandValue > dealerHandValue)
                {
                    condition = Enums.WinConditionBlackjack.HOUSE;
                }
                else
                {
                    condition = Enums.WinConditionBlackjack.LOST;
                }
            }
            else
            {
                condition = Enums.WinConditionBlackjack.NULL;
            }

            return condition;
        }

        /// <summary>
        /// Manages player balance according to how the game ends.
        /// </summary>
        /// <param name="playerBoii"> Represents the current player from which we get the balance and bet amount</param>
        /// <param name="winCondition"> The result of the current game for this player.</param>
        public static void BankManager(Player playerBoii, Enums.WinConditionBlackjack winCondition)
        {
            if (winCondition == Enums.WinConditionBlackjack.LOST)
            {
                playerBoii.Balance -= playerBoii.BetAmount;
            }
            else if (winCondition == Enums.WinConditionBlackjack.HOUSE)
            {
                playerBoii.Balance += playerBoii.BetAmount * 2;
            }
            else if (winCondition == Enums.WinConditionBlackjack.BLACKJACK)
            {
                playerBoii.Balance += playerBoii.BetAmount * 3;
            }
            else if (winCondition == Enums.WinConditionBlackjack.CHARLIE)
            {
                playerBoii.Balance += playerBoii.BetAmount * 4;
            }
            else
            {
                playerBoii.Balance += playerBoii.BetAmount;
            }
        }

        /// <summary>
        /// Checks if the player has successfully split.
        /// </summary>
        /// <param name="player"> Represents the current player. We do this so we can access both hands at the same time.</param>
        /// <returns> A boolean letting us know if the split was successful.</returns>
        public static bool CheckForSplit(Player player)
        {
            if ((int)player.hand[0].CardValue == (int)player.hand[1].CardValue)
            {
                CardModel secondStart = player.hand[1];
                player.hand.RemoveAt(1);
                player.secondHand[0] = secondStart;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

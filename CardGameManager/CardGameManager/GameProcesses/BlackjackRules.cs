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
            if(playerMoney <= -500)
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
            return Enums.WinConditionBlackjack.LOST;
        }
    }
}

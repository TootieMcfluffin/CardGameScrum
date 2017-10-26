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

        public static Enums.WinConditionBlackjack CheckWinCondition(List<CardModel> playerHand, List<CardModel> dealerHand)
        {
            return Enums.WinConditionBlackjack.LOST;
        }
    }
}

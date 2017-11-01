using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameManager.Models;

namespace CardGameManager.GameProcesses
{
    public class WarRules
    {

        /// <summary>
        /// Determines if player one won the round.
        /// </summary>
        /// <param name="playerOneCard">The card that player one played.</param>
        /// <param name="playerTwoCard">The card that player two played.</param>
        /// <returns>If true, player one won the round. If false, player two won the round.</returns>
        public static bool PlayerOneWinsRound(CardModel playerOneCard, CardModel playerTwoCard)
        {
            return (int)playerOneCard.CardValue > (int)playerTwoCard.CardValue;
        }

        /// <summary>
        /// Determines if the player has lost
        /// </summary>
        /// <param name="player">The current player in question</param>
        /// <returns>If true, the player has lost. If false, the player can still play.</returns>
        public static bool IsLoser(Player player)
        {
            if (player.secondHand.Count <= 3)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if the players have to go to war.
        /// </summary>
        /// <param name="playerOneCard">The card that player one played.</param>
        /// <param name="playerTwoCard">The card that player two played.</param>
        /// <returns>If true, war will happen. If false, the cards are of two different values, and war will not occur.</returns>
        public static bool IsWar(CardModel playerOneCard, CardModel playerTwoCard)
        {
            return (int)playerOneCard.CardValue == (int)playerTwoCard.CardValue;
        }
    }
}

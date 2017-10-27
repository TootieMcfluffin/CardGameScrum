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

        public static bool PlayerOneWinsRound(CardModel playerOneCard, CardModel playerTwoCard)
        {
            return (int)playerOneCard.CardValue > (int)playerTwoCard.CardValue;
        }

        public static bool IsLoser(Player player)
        {
            if (player.hand.Count <= 3)
            {
                return true;
            }
            return false;
        }

        public static bool IsWar(CardModel playerOneCard, CardModel playerTwoCard)
        {
            return playerOneCard.CardValue == playerTwoCard.CardValue;
        }
    }
}

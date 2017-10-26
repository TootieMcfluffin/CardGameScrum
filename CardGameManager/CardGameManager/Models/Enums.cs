using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.Models
{
    public class Enums
    {
        public enum Suit
        {
            HEARTS,
            DIAMONDS,
            SPADES,
            CLUBS
        }

        public enum Value
        {
            ACE = 1,
            TWO = 2,
            THREE = 3,
            FOUR = 4,
            FIVE = 5,
            SIX = 6,
            SEVEN = 7,
            EIGHT = 8,
            NINE = 9,
            TEN = 10,
            JACK = 10,
            QUEEN = 10,
            KING = 10
        }

        public enum WinConditionBlackjack
        {
            NULL,
            HOUSE,
            BLACKJACK,
            CHARLIE,
            LOST
        }
    }
}

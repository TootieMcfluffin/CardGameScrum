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
            ACE,
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING
        }

        public enum WinConditionBlackjack
        {
            DRAW,
            HOUSE,
            BLACKJACK,
            CHARLIE,
            LOST
        }
    }
}

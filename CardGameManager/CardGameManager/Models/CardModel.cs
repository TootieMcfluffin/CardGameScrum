using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardGameManager.Models.Enums;

namespace CardGameManager.Models
{
    public class CardModel
    {
        public Suit CardSuit { get; set; }
        public Value CardValue { get; set; }
        public CardModel(Suit cardSuit, Value cardValue)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
        }
    }
}

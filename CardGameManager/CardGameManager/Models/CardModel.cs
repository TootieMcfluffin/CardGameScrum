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
        public bool IsFlipped { get; set; }
        public string CardValuesString { get; set; }
        public string ImagePath { get; set; }
        public CardModel(Suit cardSuit, Value cardValue)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
            CardValuesString = cardValue.ToString() + "_" + CardSuit.ToString();
            ImagePath = @"..\\..\\Images\\" + CardValuesString + ".png";
        }
    }
}

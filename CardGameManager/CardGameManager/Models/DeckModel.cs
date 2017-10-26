using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardGameManager.Models.Enums;

namespace CardGameManager.Models
{
    public class DeckModel
    {
        public List<CardModel> Deck { get; set; }

        public DeckModel()
        {
            Deck = new List<CardModel>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Deck.Add(new CardModel((Suit)i, (Value)j));
                }
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < Deck.Count; i++)
            {
                int randNum = rand.Next(i, 52);
                CardModel tempCard = Deck.ElementAt(randNum);
                Deck.Insert(randNum, Deck.ElementAt(i));
                Deck.RemoveAt(randNum + 1);
                Deck.RemoveAt(i);
                Deck.Insert(i, tempCard);
            }
        }
    }
}

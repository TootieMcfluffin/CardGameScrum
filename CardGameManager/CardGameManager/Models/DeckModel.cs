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

        /// <summary>
        /// A method used for shuffling the deck of cards
        /// Begins with the first card and the last card is reached
        /// Shuffles by taking the nth card and switching it with a random card
        /// that comes after it.
        /// </summary>
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

        /// <summary>
        /// Returns a card from the "top" of the deck. Removes that card from the list.
        /// </summary>
        /// <returns>Returns the top card of the deck.</returns>
        public CardModel DrawCard()
        {
            CardModel cardDrawn;
            cardDrawn = Deck[0];
            Deck.RemoveAt(0);
            return cardDrawn;
        }
    }
}

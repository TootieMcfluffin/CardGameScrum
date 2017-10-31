using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.Models
{
    public class Player
    {
        public string Name { get; set; }

        //Changed the List properties to normal lists because I couldn't get WarRules to work with list properties.
        public List<CardModel> hand = new List<CardModel>();
        public List<CardModel> secondHand = new List<CardModel>();

        public int Balance { get; set; }

        public int BetAmount { get; set; }

        public bool Bust { get; set; }

        public void ShuffleSecondHand()
        {
            Random rand = new Random();
            for (int i = 0; i < secondHand.Count; i++)
            {
                int randNum = rand.Next(i, secondHand.Count);
                CardModel tempCard = secondHand.ElementAt(randNum);
                secondHand.Insert(randNum, secondHand.ElementAt(i));
                secondHand.RemoveAt(randNum + 1);
                secondHand.RemoveAt(i);
                secondHand.Insert(i, tempCard);
            }
        }
    }
}

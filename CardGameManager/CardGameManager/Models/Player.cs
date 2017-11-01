using CardGameManager.GameProcesses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.Models
{
    public class Player : INotifyPropertyChanged
    {
        public bool IsDealer { get; set; } = false;
        public string Name { get; set; }

        //Changed the List properties to normal lists because I couldn't get WarRules to work with list properties.
        public List<CardModel> hand = new List<CardModel>();
        public List<CardModel> secondHand = new List<CardModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        private int balance;
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }
        private int betAmount;
        public int BetAmount
        {
            get
            {
                return betAmount;
            }
            set
            {
                betAmount = value;
                OnPropertyChanged("BetAmount");
            }
        }

        public bool Bust { get; set; }

        public int playerID { get; set; }

        /// <summary>
        /// Used in war to shuffle the pile of cards won into the players hand
        /// </summary>
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
			
        /// <summary>
        /// Returns true if dealer should hit and false if tey should stand.
        /// </summary>
        /// <returns> Boolean representing weather or not to hit.</returns>
        public bool DealerHitOrStand()
        {
            bool hit = false;
            if (BlackjackRules.HandValue(this.hand) < 17)
            {
                hit = true;
            }
            else
            {
                hit = false;
            }

            return hit;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

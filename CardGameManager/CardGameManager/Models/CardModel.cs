using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardGameManager.Models.Enums;

namespace CardGameManager.Models
{
    public class CardModel : INotifyPropertyChanged
    {
        public Suit CardSuit { get; set; }
        public Value CardValue { get; set; }
        //A bool to determine whether or not the cards face is shown
        bool isFlipped;
        public bool IsFlipped
        {
            get
            {
                return isFlipped;
            }
            set
            {
                isFlipped = value;
                OnPropertyChanged("IsFlipped");
            }
        }
        //A string used for determining the image to use for the card
        public string CardValuesString { get; set; }
        public string ImagePath { get; set; }
        public CardModel(Suit cardSuit, Value cardValue)
        {
            CardSuit = cardSuit;
            CardValue = cardValue;
            CardValuesString = CardValue.ToString() + "_" + CardSuit.ToString();
            ImagePath = @"..\\..\\Images\\" + CardValuesString + ".png";
            IsFlipped = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

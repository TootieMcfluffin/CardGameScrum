using CardGameManager.Models;
using CardGameManager.GameProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Turn logic is weird, but getting on track... REDO


namespace CardGameManager.GameProcesses
{
    public class BlackjackGame
    {
        public List<Player> players;
        public DeckModel deck;
        public Player currentPlayer;
        public bool next = false;
        public bool roundOver = false;

        public BlackjackGame(List<Player> playersList)
        {
            players = playersList;
            deck = new DeckModel();
            deck.Shuffle();
            currentPlayer = players[0];
            PlayerTurnBegin();
        }

        /// <summary>
        /// Deals two cards to each player. First faced down, second faced up.
        /// </summary>
        public void Deal()
        {
            foreach (Player p in players)
            {
                CardModel card1 = deck.DrawCard();
                card1.IsFlipped = true;
                p.hand.Add(card1);
                CardModel card2 = deck.DrawCard();
                card2.IsFlipped = false;
                p.hand.Add(card2);
            }
        }

        /// <summary>
        /// Calls the DrawCard method from the deck. Adds that card to the current player's hand.
        /// </summary>
        /// <param name="currentPlayer">The current player object</param>
        public void Hit()
        {
            currentPlayer.hand.Add(deck.DrawCard());
            if(BlackjackRules.CheckForBust(currentPlayer.hand) && currentPlayer.IsDealer)
            {
                PlayerTurnEnd();
            }
        }

        /// <summary>
        /// Returns true.
        /// </summary>
        /// <returns> Bool that equals true.</returns>
        public bool Stand()
        {
            return true;
        }
        private void PlayerTurnBegin()
        {
            foreach (CardModel card in currentPlayer.hand)
            {
                card.IsFlipped = false;
            }
            
                if (currentPlayer.IsDealer)
                {
                    while (currentPlayer.DealerHitOrStand())
                    {
                        Hit();
                    }
                }
            
        }
        public void PlayerTurnEnd()
        {
            foreach (CardModel card in currentPlayer.hand)
            {
                card.IsFlipped = true;
            }
            currentPlayer.hand[1].IsFlipped = false;

            if (currentPlayer.playerID == players.Count-1)
            {
            //    roundOver = true;
                currentPlayer = players[0];
            }
            else
            {
                currentPlayer = players[currentPlayer.playerID + 1];
                PlayerTurnBegin();
            }
        } 
    }
}

using CardGameManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.GameProcesses
{


	// The win condition is whoever has the greatest number of books 
	// Suits are not important, only the card number is relevent

	// Any player deals one card face up to each player.The player with
	// the lowest card is the dealer. The dealer shuffles the cards,
	// and the player on his right cuts them.

	// If two or three people are playing, each player receives seven cards.
	// If four or five people are playing, each receives 
	// five cards. The remainder of the pack is placed face down on the table to form the stock.


	//	The player to the left of the dealer looks directly at any opponent and says, for example, 
	//	"Give me your kings," usually addressing the opponent by name and specifying the rank he
	//	wants, from ace down to two.The player who is "fishing “must have at least one card of the
	//	rank he asked for in his hand. The player who is addressed must hand over all the cards 
	//	requested. If he has none, he says, "Go fish!" and the player who made the request draws 
	//	the top card of the stock and places it in his hand.

	//	If a player gets one or more cards of the named rank he asked for, he is entitled to ask the same or 
	//	another player for a card. He can ask for the same card or a different one. So long as he 
	//	succeeds in getting cards (makes a catch), his turn continues. If a player gets the fourth card of a book,
	//	he shows all four cards, places them on the table face up in front of him, and plays again.

	//	If the player goes fishing without "making a catch" (does not receive a card he asked for), the turn passes to his left.

	//	The game ends when all thirteen books have been won.The winner is the player with the most books. 
	//	During the game, if a player is left without cards, he may (when it's his turn to play), draw 
	//	from the stock and then ask for cards of that rank. If there are no cards left in the stock, he 
	//	is out of the game


	public class GoFishRules
	{

		// Occurs when the current player asks another player for cards,
		// And the asked player has at least one of the desired cards.
		public static void ExchangeCards(Player p1, CardModel desiredCard, Player p2)
		{
			foreach (CardModel card in p2.hand)
			{
				if(card.CardValue == desiredCard.CardValue)
				{
					p1.hand.Add(card);
					p2.hand.Remove(card);
				}
			}
		}



		// This Method will check the players hand for a book.
		// If this player has a book, then the cards will be 
		// removed from the players hand, and 1 will be added to
		// the players book count.
		public static void CheckForBook(GoFishPlayer p1)
		{
			CardModel tempCard = null;
			bool validRemoveCards = true;
			int cardCounter = 0;
			int cardTracker = 0;

			foreach (CardModel card in p1.hand)
			{
				for (int i = 0; i < p1.hand.Count; i++)
				{
					if(i != cardTracker && card.CardValue == p1.hand[i].CardValue)
					{
						cardCounter++;
					}
				}

				if (cardCounter == 4)
				{
					validRemoveCards = true;
					tempCard = new CardModel(card.CardSuit, card.CardValue);
					p1.BookCount += 1;
					break;
				}
				else
				{
					validRemoveCards = false;
				}

				cardTracker++;
			}

			if (validRemoveCards)
			{
				foreach (CardModel card in p1.hand)
				{
					if (card.CardValue == tempCard.CardValue)
					{
						p1.hand.Remove(card);
					}
				}
			}
		}



		public static bool CheckForWin(LinkedList<GoFishPlayer> players)
		{
			bool isValid = true;

			foreach (GoFishPlayer player in players)
			{
				if(player.BookCount >= 13)
				{
					isValid = true;
					break;
				}
				else
				{
					isValid = false;
				} 
			}
			return isValid;
		}
	}
}

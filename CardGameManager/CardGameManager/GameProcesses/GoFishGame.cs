using CardGameManager.Models;
using CardGameManager.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.GameProcesses
{
	public class GoFishGame
	{
		public List<GoFishPlayer> Players { get; set; }

		public GoFishGame(List<GoFishPlayer> players)
		{
			Players = players;
		}

		public void GamePlay()
		{
			bool keepgoing = true;
			int playerCounter = 0;
			
			do
			{
				GoFishPlayer currentPlayer = Players[playerCounter];

				// currentPlayer clicks on player display to ask that player for a card
				// currentPlayer is prompted for a desired card from the desired player

				// p becomes the player that the current player clicks on.
				GoFishPlayer chosenPlayer = Players[2];

				// This card should be desired card from the current player
				CardModel desiredCard = currentPlayer.hand[1];


				int cardsExchanged = GoFishRules.ExchangeCards(currentPlayer, desiredCard, chosenPlayer);

				if (cardsExchanged == 0)
				{
					// The current player goes Fish

				}
				else
				{
					// The current player has Hooked
				}

				if (GoFishRules.CheckForBook(currentPlayer))
				{
					// The current Player scored a book
				}
				else
				{
					// They didnt score a book
				}


				if (playerCounter < Players.Count)
				{
					playerCounter++;
				}
				else
				{
					playerCounter = 0;
				}

				// Checking for win
				keepgoing = GoFishRules.CheckForWin(Players);

				keepgoing = false;
			} while (keepgoing);
		}
	}
}

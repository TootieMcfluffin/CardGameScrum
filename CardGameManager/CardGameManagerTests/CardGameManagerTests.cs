using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGameManager.Models;
using CardGameManager.GameProcesses;
using System.Collections.Generic;

namespace CardGameManagerTests
{
    [TestClass]
    public class CardGameManagerTests
    {
        DeckModel deck = new DeckModel();
        Player playerOne = new Player();
        Player playerTwo = new Player();
        CardModel[] cards;
        [TestInitialize]
        public void SetUp()
        {
            cards = deck.Deck.ToArray();
        }


        [TestMethod]
        public void WarRulesTest_RoundWinner_ShouldReturnTrue()
        {
            foreach (var item in cards)
            {
                Console.WriteLine($"{item.CardValue} of {item.CardSuit}");
            }
        }
    }
}

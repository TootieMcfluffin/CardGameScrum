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
        static CardModel playerOneCardNine = new CardModel(Enums.Suit.CLUBS, Enums.Value.NINE);
        static CardModel playerOneCardFour = new CardModel(Enums.Suit.CLUBS, Enums.Value.FOUR);
        static CardModel playerTwoCardEight = new CardModel(Enums.Suit.CLUBS, Enums.Value.EIGHT);
        Player playerOne = new Player();
        Player playerTwo = new Player();
        [TestInitialize]
        public void SetUp()
        {
            playerOne.hand.Add(playerOneCardNine);
            playerOne.hand.Add(playerOneCardFour);

            playerTwo.hand.Add(playerTwoCardEight);
        }


        [TestMethod]
        public void WarRulesTest_PlayerOneWinsRound_ShouldReturnTrue()
        {
            Assert.IsTrue(WarRules.PlayerOneWinsRound(playerOne.hand[0], playerTwo.hand[0]));
        }

        [TestMethod]
        public void WarRulesTest_PlayerOneWinsRound_ShouldReturnFalse()
        {
            Assert.IsFalse(WarRules.PlayerOneWinsRound(playerOne.hand[1], playerTwo.hand[0]));
        }
    }
}

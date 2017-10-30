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
        static CardModel playerOneCardFive = new CardModel(Enums.Suit.DIAMONDS, Enums.Value.FIVE);        
        static CardModel playerOneCardSeven = new CardModel(Enums.Suit.HEARTS, Enums.Value.SEVEN);

        static CardModel playerTwoCardEight = new CardModel(Enums.Suit.CLUBS, Enums.Value.EIGHT);
        static CardModel playerTwoCardFour = new CardModel(Enums.Suit.HEARTS, Enums.Value.FOUR);

        Player playerOne = new Player();
        Player playerTwo = new Player();
        [TestInitialize]
        public void SetUp()
        {
            playerOne.hand.Add(playerOneCardNine);
            playerOne.hand.Add(playerOneCardFour);
            playerOne.hand.Add(playerOneCardSeven);
            playerOne.hand.Add(playerOneCardFive);

            playerTwo.hand.Add(playerTwoCardEight);
            playerTwo.hand.Add(playerTwoCardFour);
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

        [TestMethod]
        public void WarRulesTest_IsLoser_ShouldReturnFalse()
        {
            Assert.IsFalse(WarRules.IsLoser(playerOne));
        }

        [TestMethod]
        public void WarRulesTest_IsLoser_ShouldReturnTrue()
        {
            Assert.IsTrue(WarRules.IsLoser(playerTwo));
        }

        [TestMethod]
        public void WarRulesTest_IsWar_ShouldReturnTrue()
        {
            Assert.IsTrue(WarRules.IsWar(playerOne.hand[1], playerTwo.hand[1]));
        }

        [TestMethod]
        public void WarRulesTest_IsWar_ShouldReturnFalse()
        {
            Assert.IsFalse(WarRules.IsWar(playerOne.hand[2], playerTwo.hand[1]));
        }
    }
}

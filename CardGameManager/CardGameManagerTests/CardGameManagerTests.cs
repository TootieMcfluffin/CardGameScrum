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
        public void WarHand()
        {
            playerOne.hand.Add(playerOneCardNine);
            playerOne.hand.Add(playerOneCardFour);
            playerOne.hand.Add(playerOneCardSeven);
            playerOne.hand.Add(playerOneCardFive);

            playerTwo.hand.Add(playerTwoCardEight);
            playerTwo.hand.Add(playerTwoCardFour);
        }

        public void ClearHands()
        {
            playerOne.hand.Clear();
            playerTwo.hand.Clear();
        }

        [TestMethod]
        public void WarRulesTest_PlayerOneWinsRound_ShouldReturnTrue()
        {
            ClearHands();
            WarHand();
            Assert.IsTrue(WarRules.PlayerOneWinsRound(playerOne.hand[0], playerTwo.hand[0]));
        }

        [TestMethod]
        public void WarRulesTest_PlayerOneWinsRound_ShouldReturnFalse()
        {
            ClearHands();
            WarHand();
            Assert.IsFalse(WarRules.PlayerOneWinsRound(playerOne.hand[1], playerTwo.hand[0]));
        }

        [TestMethod]
        public void WarRulesTest_IsLoser_ShouldReturnFalse()
        {
            ClearHands();
            WarHand();
            Assert.IsFalse(WarRules.IsLoser(playerOne));
        }

        [TestMethod]
        public void WarRulesTest_IsLoser_ShouldReturnTrue()
        {
            ClearHands();
            WarHand();
            Assert.IsTrue(WarRules.IsLoser(playerTwo));
        }

        [TestMethod]
        public void WarRulesTest_IsWar_ShouldReturnTrue()
        {
            ClearHands();
            WarHand();
            Assert.IsTrue(WarRules.IsWar(playerOne.hand[1], playerTwo.hand[1]));
        }

        [TestMethod]
        public void WarRulesTest_IsWar_ShouldReturnFalse()
        {
            ClearHands();
            WarHand();
            Assert.IsFalse(WarRules.IsWar(playerOne.hand[2], playerTwo.hand[1]));
        }

        [TestMethod]
        public void BlackjackRulesTest_CheckBust_ShouldReturnFalse()
        {
            ClearHands();
            playerOne.hand.Add(new CardModel(Enums.Suit.CLUBS, Enums.Value.JACK));
            playerOne.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.JACK));
            Assert.IsFalse(BlackjackRules.CheckForBust(playerOne.hand));
        }

        public void BlackjackRulesTest_CheckBustWithHand21_ShouldReturnFalse()
        {
            ClearHands();
            playerOne.hand.Add(new CardModel(Enums.Suit.CLUBS, Enums.Value.JACK));
            playerOne.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.JACK));
            playerOne.hand.Add(new CardModel(Enums.Suit.DIAMONDS, Enums.Value.ACE));
            Assert.IsFalse(BlackjackRules.CheckForBust(playerOne.hand));
        }

        [TestMethod]
        public void BlackjackRulesTest_CheckBust_ShouldReturnTrue()
        {
            ClearHands();
            playerOne.hand.Add(new CardModel(Enums.Suit.CLUBS, Enums.Value.JACK));
            playerOne.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.JACK));
            playerOne.hand.Add(new CardModel(Enums.Suit.DIAMONDS, Enums.Value.EIGHT));
            Assert.IsTrue(BlackjackRules.CheckForBust(playerOne.hand));
        }

        [TestMethod]
        public void BlackjackRulesTest_Elimination_ShouldReturnFalse()
        {
            playerOne.Balance = 500;
            Assert.IsFalse(BlackjackRules.Elimination(playerOne.Balance));
        }

        [TestMethod]
        public void BlackjackRulesTest_Elimination_ShouldReturnTrue()
        {
            playerOne.Balance = -600;
            Assert.IsTrue(BlackjackRules.Elimination(playerOne.Balance));
        }
        
    }
}

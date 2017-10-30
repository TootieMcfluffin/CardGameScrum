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
        Player playerOne = new Player();
        Player playerTwo = new Player();
        [TestInitialize]
        public void WarHand()
        {
            playerOne.hand.Add(new CardModel(Enums.Suit.CLUBS, Enums.Value.NINE));
            playerOne.hand.Add(new CardModel(Enums.Suit.CLUBS, Enums.Value.FOUR));
            playerOne.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.SEVEN));
            playerOne.hand.Add(new CardModel(Enums.Suit.DIAMONDS, Enums.Value.FIVE));

            playerTwo.hand.Add(new CardModel(Enums.Suit.CLUBS, Enums.Value.EIGHT));
            playerTwo.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.FOUR));
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

        [TestMethod]
        public void BlackjackRulesTest_Elimination_ShouldReturnTrueWithBalanceNegativeFifty()
        {
            playerOne.Balance = -50;
            Assert.IsTrue(BlackjackRules.Elimination(playerOne.Balance));
        }

        [TestMethod]
        public void BlackjackRulesTest_CheckWinCondition_ShouldReturnNull()
        {
            Enums.WinConditionBlackjack expectedValue = Enums.WinConditionBlackjack.NULL;
            ClearHands();

            playerOne.hand.Add(new CardModel(Enums.Suit.CLUBS, Enums.Value.TWO));
            playerOne.hand.Add(new CardModel(Enums.Suit.DIAMONDS, Enums.Value.TWO));
            playerOne.hand.Add(new CardModel(Enums.Suit.CLUBS, Enums.Value.THREE));
            playerOne.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.FOUR));
            playerOne.hand.Add(new CardModel(Enums.Suit.SPADES, Enums.Value.FIVE));

            playerTwo.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.TWO));
            playerTwo.hand.Add(new CardModel(Enums.Suit.SPADES, Enums.Value.TWO));
            playerTwo.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.THREE));
            playerTwo.hand.Add(new CardModel(Enums.Suit.SPADES, Enums.Value.FOUR));
            playerTwo.hand.Add(new CardModel(Enums.Suit.HEARTS, Enums.Value.FIVE));

            Enums.WinConditionBlackjack actualValue = BlackjackRules.CheckWinCondition(playerOne.hand, playerTwo.hand);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}

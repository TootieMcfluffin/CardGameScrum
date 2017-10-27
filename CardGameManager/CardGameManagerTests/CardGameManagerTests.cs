using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGameManager.Models;
using CardGameManager.GameProcesses;

namespace CardGameManagerTests
{
    [TestClass]
    public class CardGameManagerTests
    {
        DeckModel deck = new DeckModel();
        Player playerOne = new Player();
        Player playerTwo = new Player();
        [TestInitialize]
        public void SetUp()
        {
            
        }


        [TestMethod]
        public void WarRulesTest_RoundWinner_ShouldReturnTrue()
        {

        }
    }
}

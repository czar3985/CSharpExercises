using HighestCardGame;
using HighestCardGameUnitTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighestCardGameUnitTests
{
    [TestClass]
    public class CardGameTests
    {
        private MockDeck _mockDeck;

        [TestInitialize]
        public void Initialize()
        {
            _mockDeck = new MockDeck();
            _mockDeck.CannedGetCardResult = new Card(CardNumber.Two, Suit.Heart);
        }

        [TestMethod]
        public void StartGameTests() {
            CardGame cardGame = new CardGame();
            cardGame.Deck = _mockDeck;

            Assert.AreEqual(0, _mockDeck.NumCalledShuffle);

            cardGame.StartGame();
            Assert.AreEqual(1, _mockDeck.NumCalledShuffle);

            Assert.AreEqual(cardGame.Players.Count, _mockDeck.NumCalledGetCard);
        }
    }
}

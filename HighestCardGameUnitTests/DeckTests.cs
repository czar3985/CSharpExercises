using System;
using System.Linq;
using HighestCardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HighestCardGameUnitTests
{
    [TestClass]
    public class DeckTests
    {
        private Deck _deck;

        [TestInitialize]
        public void Initialize()
        {
            _deck = new Deck();
        }

        [TestMethod]
        public void DeckInitializationTest()
        {
            CheckNumberOfCardsInDeck();
            CheckCardsAddedToDeck();
        }

        private void CheckCardsAddedToDeck()
        {
            var cardList = _deck.cards.AsEnumerable();

            foreach (CardNumber cardNumber in Enum.GetValues(typeof(CardNumber)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    var queryResult = cardList.Where(c => c.Name == cardNumber.ToString() + suit.ToString())
                        .ToList();
                    Assert.AreEqual(1, queryResult.Count);
                    Assert.AreEqual(((int)cardNumber * Card.numOfSuits) + (int)suit, queryResult[0].Rank);
                }
            }
        }

        [TestMethod]
        public void DeckShufflingTest()
        {
            _deck.Shuffle();
            CheckNumberOfCardsInDeck();
            CheckThatDeckIsShuffled();
        }

        private void CheckNumberOfCardsInDeck()
        {
            Assert.AreEqual(52, _deck.cards.Count);
        }

        private void CheckThatDeckIsShuffled()
        {
            int numOfTries = 3;

            for (int i = 0; i < numOfTries; i++)
            {
                if (_deck.cards[0].Name != "TwoClub")
                {
                    return;
                }
                _deck.Shuffle();
            }

            Assert.Fail();
        }
    }
}

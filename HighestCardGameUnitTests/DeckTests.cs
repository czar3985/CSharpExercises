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
            const int expectedNumberOfCards = 52;

            CheckNumberOfCardsInDeck(expectedNumberOfCards);
            CheckCardsAddedToDeck();
        }

        private void CheckCardsAddedToDeck()
        {
            var cardList = _deck.Cards.AsEnumerable();

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
            int expectedNumberOfCards = _deck.Cards.Count;
            _deck.Shuffle();
            CheckNumberOfCardsInDeck(expectedNumberOfCards);

            CheckThatDeckIsShuffled();
        }

        private void CheckNumberOfCardsInDeck(int expectedNumberOfCards)
        {
            Assert.AreEqual(expectedNumberOfCards, _deck.Cards.Count);
        }

        private void CheckThatDeckIsShuffled()
        {
            int numOfTries = 3;

            for (int i = 0; i < numOfTries; i++)
            {
                if (_deck.Cards[0].Name != "TwoClub")
                {
                    return;
                }
                _deck.Shuffle();
            }

            Assert.Fail();
        }

        [TestMethod]
        public void GettingACardFromDeckTest()
        {
            int initialNumberOfCards = _deck.Cards.Count;
            Card topCardInitially = _deck.Cards[0];

            Card cardPicked = _deck.GetCard();
            CheckNumberOfCardsInDeck(initialNumberOfCards-1);

            CheckCorrectCardIsReturned(topCardInitially, cardPicked);
        }

        private void CheckCorrectCardIsReturned(Card cardExpected, Card cardPicked)
        {
            Assert.AreEqual(cardExpected, cardPicked);
        }
    }
}

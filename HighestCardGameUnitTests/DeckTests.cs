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

        [TestMethod]
        public void DeckInitializationTest()
        {
            CreateANewDeck();
            CheckNumberOfCardsInDeck();
            CheckCardsAddedToDeck();
        }

        private void CreateANewDeck()
        {
            _deck = new Deck();
        }

        private void CheckNumberOfCardsInDeck()
        {
            Assert.AreEqual(52, _deck.cards.Count);
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
    }
}

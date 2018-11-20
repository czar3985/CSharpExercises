using System;
using System.Collections.Generic;
using System.Text;

namespace HighestCardGame
{
    interface IDeck
    {
        void Shuffle();
        Card GetCard();
    }

    class Deck : IDeck
    {
        public List<Card> cards { get; private set; }

        public Deck()
        {
            foreach (CardNumber cardNumber in Enum.GetValues(typeof(CardNumber)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    Card newCard = new Card(cardNumber, suit);
                    cards.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            // Fisher-Yates shuffle algorithm
            Random randomizer = new Random();
            Card tempCardHolder;
            int cardListCounter = cards.Count;
            int randomNumber;

            while (cardListCounter > 1)
            {
                cardListCounter--;
                randomNumber = randomizer.Next(cardListCounter + 1);
                tempCardHolder = cards[randomNumber];
                cards[randomNumber] = cards[cardListCounter];
                cards[cardListCounter] = tempCardHolder;
            }
        }

        public Card GetCard()
        {
            // return the top card in the deck
            return cards[0];
        }
    }
}

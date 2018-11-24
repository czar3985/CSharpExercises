using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        public List<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new List<Card>();

            foreach (CardNumber cardNumber in Enum.GetValues(typeof(CardNumber)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    Card newCard = new Card(cardNumber, suit);
                    Cards.Add(newCard);
                }
            }
        }

        public void Shuffle()
        {
            // Fisher-Yates shuffle algorithm
            Random randomizer = new Random();
            Card tempCardHolder;
            int cardListCounter = Cards.Count;
            int randomNumber;

            while (cardListCounter > 1)
            {
                cardListCounter--;
                randomNumber = randomizer.Next(cardListCounter + 1);
                tempCardHolder = Cards[randomNumber];
                Cards[randomNumber] = Cards[cardListCounter];
                Cards[cardListCounter] = tempCardHolder;
            }
        }

        public Card GetCard()
        {
            // return the top card in the deck and remove it from the deck
            Card cardToReturn = Cards[0];

            Cards.RemoveAt(0);

            return cardToReturn;
        }
    }
}

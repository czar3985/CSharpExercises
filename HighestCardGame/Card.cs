using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HighestCardGameUnitTests")]
namespace HighestCardGame
{
    public enum Suit
    {
        Club = 1,
        Diamond,
        Heart,
        Spade
    }

    public enum CardNumber
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    class Card
    {
        public const int numOfSuits = 4;

        public string Name { get; set; }
        public int Rank { get; set; }

        private CardNumber _cardNumber;
        private Suit _suit;

        public Card(CardNumber cardNumber, Suit suit)
        {
            _cardNumber = cardNumber;
            _suit = suit;

            Name = DetermineCardName();
            Rank = DetermineCardRank();
        }

        private string DetermineCardName()
        {
            return _cardNumber.ToString() + _suit.ToString();
        }

        private int DetermineCardRank()
        {
            // Ranking implemented: from high to low:
            // ace, king, queen, jack, 10, 9, 8, 7, 6, 5, 4, 3, 2
            // spades(highest), hearts, diamonds, clubs (lowest)
            return ((int)_cardNumber * numOfSuits) + (int)_suit;
        }
    }
}

using System.Collections.Generic;

namespace HighestCardGame
{
    interface ICardGame
    {
        void StartGame();
    }

    class CardGame : ICardGame
    {
        private IDeck _deck = null;
        public IDeck Deck {
            get {
                if (_deck == null)
                    _deck = new Deck();
                return _deck;
            }
            set {
                _deck = value;
            }
        }

        public List<Player> Players { get; private set; }

        public void StartGame()
        {
            PrepareDeck();
            IdentifyPlayers();
            DealCards();
        }

        private void PrepareDeck()
        {
            Deck.Shuffle();
        }

        private void IdentifyPlayers()
        {
            Players = new List<Player>();

            Player playerComputer = new Player { Name = "Computer" };
            Players.Add(playerComputer);

            Player playerUser = new Player { Name = "User" };
            Players.Add(playerUser);
        }

        private void DealCards()
        {
            foreach (var player in Players)
            {
                player.CardPicked = GetCardFromDeck();
            }
        }

        private Card GetCardFromDeck()
        {
            return Deck.GetCard();
        }
    }
}

using System.Collections.Generic;

namespace HighestCardGame
{
    interface ICardGame
    {
        void StartGame();
    }

    class CardGame : ICardGame
    {
        public Deck Deck { get; private set; }
        public List<Player> Players { get; private set; }
        public Player Winner { get; private set; }

        public void StartGame()
        {
            PrepareDeck();
            IdentifyPlayers();
            DealCards();
        }

        private void PrepareDeck()
        {
            Deck = new Deck();
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

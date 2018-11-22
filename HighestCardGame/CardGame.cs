using System;
using System.Collections.Generic;
using System.Text;

namespace HighestCardGame
{
    interface ICardGame
    {
        void StartGame();
    }

    class CardGame : ICardGame
    {
        public Deck Deck { get; set; }
        public List<Player> Players { get; set; }

        public void StartGame()
        {
            UserInteraction userInteraction = new UserInteraction();
            userInteraction.GetInput();

            Deck = new Deck();
            Deck.Shuffle();

            Players = new List<Player>();
            Player playerComputer = new Player { Name = "Computer", CardPicked = GetCardFromDeck() };
            Players.Add(playerComputer);
            Player playerUser = new Player { Name = "User", CardPicked = GetCardFromDeck() };
            Players.Add(playerUser);

            Player winner = DetermineWinner();

            userInteraction.ShowResult(Players, winner);
        }

        private Card GetCardFromDeck()
        {
            return Deck.GetCard();
        }

        private Player DetermineWinner()
        {
            Player winner = Players[0];

            for (int i = 1; i < Players.Count; i++)
            {
                if (Players[i].CardPicked.Rank > winner.CardPicked.Rank)
                    winner = Players[i];
            }

            return winner;
        }
    }
}

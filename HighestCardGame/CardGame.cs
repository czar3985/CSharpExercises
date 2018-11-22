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
        public Deck Deck { get; private set; }
        public List<Player> Players { get; private set; }
        public Player Winner { get; private set; }

        private UserInteraction _userInteraction;

        public void StartGame()
        {
            StartUI();
            PrepareDeck();
            IdentifyPlayers();
            DetermineWinner();
            _userInteraction.ShowResult(Players, Winner);
        }

        private void StartUI()
        {
            _userInteraction = new UserInteraction();
            _userInteraction.StartUI();
        }

        private void PrepareDeck()
        {
            Deck = new Deck();
            Deck.Shuffle();
        }

        private void IdentifyPlayers()
        {
            Players = new List<Player>();
            Player playerComputer = new Player { Name = "Computer", CardPicked = GetCardFromDeck() };
            Players.Add(playerComputer);
            Player playerUser = new Player { Name = "User", CardPicked = GetCardFromDeck() };
            Players.Add(playerUser);
        }

        private Card GetCardFromDeck()
        {
            return Deck.GetCard();
        }

        private void DetermineWinner()
        {
            Winner = Players[0];

            for (int i = 1; i < Players.Count; i++)
            {
                if (Players[i].CardPicked.Rank > Winner.CardPicked.Rank)
                    Winner = Players[i];
            }
        }
    }
}

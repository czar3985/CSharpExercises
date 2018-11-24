using System.Collections.Generic;

namespace HighestCardGame
{
    class CardGameRuleController
    {
        public Player DetermineWinner(List<Player> players)
        {
            Player winner = players[0];

            for (int i = 1; i < players.Count; i++)
            {
                if (players[i].CardPicked.Rank > winner.CardPicked.Rank)
                    winner = players[i];
            }

            return winner;
        }
    }
}

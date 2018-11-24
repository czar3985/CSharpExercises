using System;
using System.Collections.Generic;

namespace HighestCardGame
{
    class UserInteraction
    {
        public void StartUI()
        {
            Console.WriteLine("Play against the computer. Get the higher card in a " +
                "shuffled standard deck to win.");

            Console.WriteLine("Press Enter to pick a card...");
            Console.ReadLine();
        }

        public void ShowResult(List<Player> players, Player winner)
        {
            Console.WriteLine("User picked " + players[1].CardPicked.Name);
            Console.WriteLine("Computer picked " + players[0].CardPicked.Name);
            Console.WriteLine("");
            Console.WriteLine(winner.Name + " wins!!!");
            Console.ReadLine();
        }
    }
}

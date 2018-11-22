using System;
using System.Collections.Generic;
using System.Text;

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

        public void ShowResult(List<Player> Players, Player winner)
        {
            Console.WriteLine("User picked " + Players[1].CardPicked.Name);
            Console.WriteLine("Computer picked " + Players[0].CardPicked.Name);
            Console.WriteLine(winner.Name + " wins!!!");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HighestCardGame
{
    interface IPlayer
    {

    }

    class Player : IPlayer
    {
        public String Name { get; set; }
        public Card CardPicked { get; set; }

        public void PickACard()
        {

        }
    }
}

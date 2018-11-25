using HighestCardGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighestCardGameUnitTests.Mocks
{
    class MockDeck : IDeck
    {
        public int NumCalledShuffle { get; private set; } = 0;
        public int NumCalledGetCard { get; private set; } = 0;
        public Card CannedGetCardResult { get; set; }

        public Card GetCard()
        {
            NumCalledGetCard++;
            return CannedGetCardResult;
        }

        public void Shuffle()
        {
            NumCalledShuffle++;
        }
    }
}

using HighestCardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HighestCardGameUnitTests
{
    [TestClass]
    public class GameRuleTests
    {
        private List<Player> _mockPlayerList;

        [TestInitialize]
        public void Initialize()
        {
            _mockPlayerList = new List<Player>
            {
                new Player {Name = "Player1", CardPicked = new Card(CardNumber.Two,Suit.Club)},
                new Player {Name = "Player2", CardPicked = new Card(CardNumber.Three,Suit.Club)},
                new Player {Name = "Player3", CardPicked = new Card(CardNumber.Four,Suit.Spade)},
                new Player {Name = "Player4", CardPicked = new Card(CardNumber.King,Suit.Diamond)},
                new Player {Name = "Player5", CardPicked = new Card(CardNumber.Ace,Suit.Heart)},
            };
        }

        [TestMethod]
        public void DetermineWinnerTest()
        {
            int highestRankInPlayerList = _mockPlayerList.Max(p => p.CardPicked.Rank);
            Player playerWithHighestRank = _mockPlayerList.Find(p => p.CardPicked.Rank == highestRankInPlayerList);

            CardGameRuleController cardGameRuleController = new CardGameRuleController();
            Player winnerFound = cardGameRuleController.DetermineWinner(_mockPlayerList);

            Assert.AreEqual(playerWithHighestRank, winnerFound);
        }
    }
}

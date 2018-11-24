using HighestCardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HighestCardGameUnitTests
{
    [TestClass]
    public class CardTests
    {
        [DataTestMethod]
        [DataRow(CardNumber.Two, Suit.Club, "TwoClub", 1)]
        [DataRow(CardNumber.Two, Suit.Diamond, "TwoDiamond", 2)]
        [DataRow(CardNumber.Two, Suit.Heart, "TwoHeart", 3)]
        [DataRow(CardNumber.Two, Suit.Spade, "TwoSpade", 4)]
        [DataRow(CardNumber.Three, Suit.Club, "ThreeClub", 5)]
        [DataRow(CardNumber.Three, Suit.Diamond, "ThreeDiamond", 6)]
        [DataRow(CardNumber.Three, Suit.Heart, "ThreeHeart", 7)]
        [DataRow(CardNumber.Three, Suit.Spade, "ThreeSpade", 8)]
        [DataRow(CardNumber.Four, Suit.Club, "FourClub", 9)]
        [DataRow(CardNumber.Four, Suit.Diamond, "FourDiamond", 10)]
        [DataRow(CardNumber.Four, Suit.Heart, "FourHeart", 11)]
        [DataRow(CardNumber.Four, Suit.Spade, "FourSpade", 12)]
        [DataRow(CardNumber.Five, Suit.Club, "FiveClub", 13)]
        [DataRow(CardNumber.Five, Suit.Diamond, "FiveDiamond", 14)]
        [DataRow(CardNumber.Five, Suit.Heart, "FiveHeart", 15)]
        [DataRow(CardNumber.Five, Suit.Spade, "FiveSpade", 16)]
        [DataRow(CardNumber.Six, Suit.Club, "SixClub", 17)]
        [DataRow(CardNumber.Six, Suit.Diamond, "SixDiamond", 18)]
        [DataRow(CardNumber.Six, Suit.Heart, "SixHeart", 19)]
        [DataRow(CardNumber.Six, Suit.Spade, "SixSpade", 20)]
        [DataRow(CardNumber.Seven, Suit.Club, "SevenClub", 21)]
        [DataRow(CardNumber.Seven, Suit.Diamond, "SevenDiamond", 22)]
        [DataRow(CardNumber.Seven, Suit.Heart, "SevenHeart", 23)]
        [DataRow(CardNumber.Seven, Suit.Spade, "SevenSpade", 24)]
        [DataRow(CardNumber.Eight, Suit.Club, "EightClub", 25)]
        [DataRow(CardNumber.Eight, Suit.Diamond, "EightDiamond", 26)]
        [DataRow(CardNumber.Eight, Suit.Heart, "EightHeart", 27)]
        [DataRow(CardNumber.Eight, Suit.Spade, "EightSpade", 28)]
        [DataRow(CardNumber.Nine, Suit.Club, "NineClub", 29)]
        [DataRow(CardNumber.Nine, Suit.Diamond, "NineDiamond", 30)]
        [DataRow(CardNumber.Nine, Suit.Heart, "NineHeart", 31)]
        [DataRow(CardNumber.Nine, Suit.Spade, "NineSpade", 32)]
        [DataRow(CardNumber.Ten, Suit.Club, "TenClub", 33)]
        [DataRow(CardNumber.Ten, Suit.Diamond, "TenDiamond", 34)]
        [DataRow(CardNumber.Ten, Suit.Heart, "TenHeart", 35)]
        [DataRow(CardNumber.Ten, Suit.Spade, "TenSpade", 36)]
        [DataRow(CardNumber.Jack, Suit.Club, "JackClub", 37)]
        [DataRow(CardNumber.Jack, Suit.Diamond, "JackDiamond", 38)]
        [DataRow(CardNumber.Jack, Suit.Heart, "JackHeart", 39)]
        [DataRow(CardNumber.Jack, Suit.Spade, "JackSpade", 40)]
        [DataRow(CardNumber.Queen, Suit.Club, "QueenClub", 41)]
        [DataRow(CardNumber.Queen, Suit.Diamond, "QueenDiamond", 42)]
        [DataRow(CardNumber.Queen, Suit.Heart, "QueenHeart", 43)]
        [DataRow(CardNumber.Queen, Suit.Spade, "QueenSpade", 44)]
        [DataRow(CardNumber.King, Suit.Club, "KingClub", 45)]
        [DataRow(CardNumber.King, Suit.Diamond, "KingDiamond", 46)]
        [DataRow(CardNumber.King, Suit.Heart, "KingHeart", 47)]
        [DataRow(CardNumber.King, Suit.Spade, "KingSpade", 48)]
        [DataRow(CardNumber.Ace, Suit.Club, "AceClub", 49)]
        [DataRow(CardNumber.Ace, Suit.Diamond, "AceDiamond", 50)]
        [DataRow(CardNumber.Ace, Suit.Heart, "AceHeart", 51)]
        [DataRow(CardNumber.Ace, Suit.Spade, "AceSpade", 52)]
        public void CardPropertyTest(
            CardNumber cardNumber,
            Suit suit,
            string expectedName,
            int expectedRank)
        {
            Card card = new Card(cardNumber, suit);
            Assert.AreEqual(expectedRank, card.Rank);
            Assert.AreEqual(expectedName, card.Name);
        }
    }
}

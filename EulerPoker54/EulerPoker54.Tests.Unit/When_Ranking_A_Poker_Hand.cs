using EulerPoker54.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerPoker54.Tests.Unit
{
    [TestClass]
    public class When_Ranking_A_Poker_Hand
    {
        [TestMethod]
        public void A_Poker_Hand_With_No_Other_Ranking_Is_A_High_Card()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Clubs),
                                new Card(Value.Six, Suit.Diamonds),
                                new Card(Value.Seven, Suit.Hearts),
                                new Card(Value.Nine, Suit.Hearts),
                                new Card(Value.King, Suit.Hearts));

            Assert.AreEqual(Rank.HighCard, hand.Rank);
            Assert.AreEqual(Value.King, hand.RankHighCard);
        }

        [TestMethod]
        public void A_Poker_Hand_With_Two_Cards_Of_The_Same_Value_Is_A_Pair()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Clubs),
                                new Card(Value.Two, Suit.Diamonds),
                                new Card(Value.Seven, Suit.Hearts),
                                new Card(Value.Nine, Suit.Hearts),
                                new Card(Value.King, Suit.Hearts));

            Assert.AreEqual(Rank.OnePair, hand.Rank);
            Assert.AreEqual(Value.Two, hand.RankHighCard);
        }

        [TestMethod]
        public void A_Poker_Hand_With_Two_Pairs_Of_Cards_Of_The_Same_Value_Is_A_Two_Pair()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Clubs),
                                new Card(Value.Two, Suit.Diamonds),
                                new Card(Value.Seven, Suit.Hearts),
                                new Card(Value.Nine, Suit.Hearts),
                                new Card(Value.Nine, Suit.Clubs));

            Assert.AreEqual(hand.Rank, Rank.TwoPair);
            Assert.AreEqual(Value.Nine, hand.RankHighCard);
        }

        [TestMethod]
        public void A_Poker_Hand_With_Three_Cards_Of_The_Same_Value_Is_A_Three_Of_A_Kind()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Clubs),
                                new Card(Value.Two, Suit.Diamonds),
                                new Card(Value.Seven, Suit.Hearts),
                                new Card(Value.Two, Suit.Hearts),
                                new Card(Value.Nine, Suit.Clubs));

            Assert.AreEqual(Rank.ThreeOfAKind, hand.Rank);
            Assert.AreEqual(Value.Two, hand.RankHighCard);
        }

        [TestMethod]
        public void A_Poker_Hand_With_All_Consecutive_Values_Is_A_Straight()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Clubs),
                                new Card(Value.Three, Suit.Diamonds),
                                new Card(Value.Four, Suit.Hearts),
                                new Card(Value.Five, Suit.Hearts),
                                new Card(Value.Six, Suit.Clubs));

            Assert.AreEqual(Rank.Straight, hand.Rank);
            Assert.AreEqual(Value.Six, hand.RankHighCard);
        }

        [TestMethod]
        public void A_Poker_Hand_With_All_The_Same_Suits_Is_A_Flush()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Hearts),
                                new Card(Value.Three, Suit.Hearts),
                                new Card(Value.Four, Suit.Hearts),
                                new Card(Value.Five, Suit.Hearts),
                                new Card(Value.Seven, Suit.Hearts));

            Assert.AreEqual(Rank.Flush, hand.Rank);
            Assert.AreEqual(Value.Seven, hand.RankHighCard);
        }


        [TestMethod]
        public void A_Poker_Hand_With_Three_Of_A_Kind_And_A_Pair_Is_A_Full_House()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Hearts),
                                new Card(Value.Two, Suit.Clubs),
                                new Card(Value.Two, Suit.Diamonds),
                                new Card(Value.Three, Suit.Hearts),
                                new Card(Value.Three, Suit.Diamonds));

            Assert.AreEqual(Rank.FullHouse, hand.Rank);
            Assert.AreEqual(Value.Two, hand.RankHighCard);
        }

        [TestMethod]
        public void A_Poker_Hand_With_Four_Cards_Of_The_Same_Value_Is_A_Four_Of_A_Kind()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Hearts),
                                new Card(Value.Two, Suit.Clubs),
                                new Card(Value.Two, Suit.Diamonds),
                                new Card(Value.Two, Suit.Spades),
                                new Card(Value.Three, Suit.Diamonds));

            Assert.AreEqual(Rank.FourOfAKind, hand.Rank);
            Assert.AreEqual(Value.Two, hand.RankHighCard);
        }

        [TestMethod]
        public void A_Poker_Hand_With_All_Consecutive_Values_Of_The_Same_Suit_Is_A_Straight_Flush()
        {
            var hand = new Hand(new Card(Value.Two, Suit.Hearts),
                                new Card(Value.Three, Suit.Hearts),
                                new Card(Value.Four, Suit.Hearts),
                                new Card(Value.Five, Suit.Hearts),
                                new Card(Value.Six, Suit.Hearts));

            Assert.AreEqual(Rank.StraightFlush, hand.Rank);
            Assert.AreEqual(Value.Six, hand.RankHighCard);
        }

        [TestMethod]
        public void A_Poker_Hand_With_All_Consecutive_Values_Of_The_Same_Suit_And_Values_Are_Ten_Through_Ace_Then_It_Is_A_Royal_Flush()
        {
            var hand = new Hand(new Card(Value.Ten, Suit.Hearts),
                                new Card(Value.Jack, Suit.Hearts),
                                new Card(Value.King, Suit.Hearts),
                                new Card(Value.Queen, Suit.Hearts),
                                new Card(Value.Ace, Suit.Hearts));

            Assert.AreEqual(Rank.RoyalFlush, hand.Rank);
            Assert.AreEqual(Value.Ace, hand.RankHighCard);
        }
    }
}
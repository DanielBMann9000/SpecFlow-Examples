using EulerPoker54.Core;
using EulerPoker54.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerPoker54.Tests.Unit
{
    [TestClass]
    public class When_Comparing_Two_Hands
    {
        [TestMethod]
        public void One_Pair_Beats_A_High_Card()
        {
            var hand1 = HandRepository.HighCard;

            var hand2 = HandRepository.OnePair;
             
            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void Two_Pair_Beats_One_Pair()
        {
            var hand1 = HandRepository.OnePair;

            var hand2 = HandRepository.TwoPair;

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void Three_Of_A_Kind_Beats_Two_Pair()
        {
            var hand1 = HandRepository.TwoPair;

            var hand2 = HandRepository.ThreeOfAKind;

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void Straight_Beats_Three_Of_A_Kind()
        {
            var hand1 = HandRepository.ThreeOfAKind;

            var hand2 = HandRepository.Straight;

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void Flush_Beats_Straight()
        {
            var hand1 = HandRepository.Straight;

            var hand2 = HandRepository.Flush;

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void Full_House_Beats_Flush()
        {
            var hand1 = HandRepository.Flush;

            var hand2 = HandRepository.FullHouse;

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void Four_Of_A_Kind_Beats_Full_House()
        {
            var hand1 = HandRepository.FullHouse;

            var hand2 = HandRepository.FourOfAKind;

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void Straight_Flush_Beats_Four_Of_A_Kind()
        {
            var hand1 = HandRepository.FourOfAKind;

            var hand2 = HandRepository.StraightFlush;

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void Royal_Flush_Beats_Straight_Flush()
        {
            var hand1 = HandRepository.StraightFlush;

            var hand2 = HandRepository.RoyalFlush;

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void If_Two_Hands_Rank_As_High_Card_Then_Higher_Card_Wins()
        {
            var hand1 = new Hand(new Card(Value.Queen, Suit.Hearts),
                                 new Card(Value.Five, Suit.Clubs),
                                 new Card(Value.Six, Suit.Spades),
                                 new Card(Value.Seven, Suit.Spades),
                                 new Card(Value.King, Suit.Diamonds));

            var hand2 = new Hand(new Card(Value.Two, Suit.Clubs),
                                 new Card(Value.Three, Suit.Spades),
                                 new Card(Value.Eight, Suit.Spades),
                                 new Card(Value.Seven, Suit.Diamonds),
                                 new Card(Value.Ten, Suit.Diamonds));

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand1, winningHand);
        }

        [TestMethod]
        public void If_Two_Hands_Rank_As_One_Pair_Then_Higher_Rank_Card_Wins()
        {
            var hand1 = new Hand(new Card(Value.Five, Suit.Hearts),
                                 new Card(Value.Five, Suit.Clubs),
                                 new Card(Value.Six, Suit.Spades),
                                 new Card(Value.Seven, Suit.Spades),
                                 new Card(Value.King, Suit.Diamonds));

            var hand2 = new Hand(new Card(Value.Two, Suit.Clubs),
                                 new Card(Value.Three, Suit.Spades),
                                 new Card(Value.Eight, Suit.Spades),
                                 new Card(Value.Eight, Suit.Diamonds),
                                 new Card(Value.Ten, Suit.Diamonds));

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand2, winningHand);
        }

        [TestMethod]
        public void If_Two_Hands_Rank_As_One_Pair_With_Same_Rank_High_Card_Then_Highest_Card_In_Hand_Wins()
        {
            var hand1 = new Hand(new Card(Value.Five, Suit.Hearts),
                                 new Card(Value.Five, Suit.Clubs),
                                 new Card(Value.Six, Suit.Spades),
                                 new Card(Value.Seven, Suit.Spades),
                                 new Card(Value.King, Suit.Diamonds));

            var hand2 = new Hand(new Card(Value.Two, Suit.Clubs),
                                 new Card(Value.Three, Suit.Spades),
                                 new Card(Value.Five, Suit.Spades),
                                 new Card(Value.Five, Suit.Diamonds),
                                 new Card(Value.Ten, Suit.Diamonds));

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand1, winningHand);
        }

        [TestMethod]
        public void If_Two_Hands_Rank_As_A_Pair_With_Same_Rank_High_Card_And_The_Highest_Cards_Are_Equal_Value_Then_The_Next_Highest_Card_In_Hand_Wins()
        {
            var hand1 = new Hand(new Card(Value.Two, Suit.Hearts),
                                 new Card(Value.Two, Suit.Diamonds),
                                 new Card(Value.Five, Suit.Clubs),
                                 new Card(Value.Six, Suit.Spades),
                                 new Card(Value.Seven, Suit.Diamonds));

            var hand2 = new Hand(new Card(Value.Two, Suit.Clubs),
                                 new Card(Value.Two, Suit.Diamonds),
                                 new Card(Value.Four, Suit.Spades),
                                 new Card(Value.Five, Suit.Hearts),
                                 new Card(Value.Seven, Suit.Hearts));

            var winningHand = Poker.CompareHands(hand1, hand2);
            Assert.AreEqual(hand1, winningHand);
        }
    }
}
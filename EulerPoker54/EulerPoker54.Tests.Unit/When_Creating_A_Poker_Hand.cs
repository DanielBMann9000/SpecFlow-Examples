using System;
using EulerPoker54.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerPoker54.Tests.Unit
{
    [TestClass]
    public class When_Creating_A_Poker_Hand
    {
        [TestMethod]
        public void A_Hand_Consists_Of_Different_Five_Cards()
        {
            var hand = new Hand(new Card(Value.Ten, Suit.Hearts),
                new Card(Value.Two, Suit.Hearts),
                new Card(Value.Three, Suit.Hearts),
                new Card(Value.Four, Suit.Hearts),
                new Card(Value.Five, Suit.Hearts));
            Assert.IsNotNull(hand);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void A_Hand_With_A_Duplicate_Card_Throws_An_Exception()
        {
            var hand = new Hand(new Card(Value.Ten, Suit.Hearts),
                new Card(Value.Two, Suit.Hearts),
                new Card(Value.Three, Suit.Hearts),
                new Card(Value.Four, Suit.Hearts),
                new Card(Value.Ten, Suit.Hearts));
        }

        [TestMethod]
        public void Two_Cards_With_The_Same_Suit_And_value_Are_Equal()
        {
            var card1 = new Card(Value.Ten, Suit.Clubs);
            var card2 = new Card(Value.Ten, Suit.Clubs);
            Assert.AreEqual(card1, card2);
        }

        [TestMethod]
        public void Two_Hands_With_The_Same_Cards_Are_Equal()
        {
            var hand1 = new Hand(new Card(Value.Ten, Suit.Hearts),
                                new Card(Value.Jack, Suit.Hearts),
                                new Card(Value.King, Suit.Hearts),
                                new Card(Value.Queen, Suit.Hearts),
                                new Card(Value.Ace, Suit.Hearts));


            var hand2 = new Hand(new Card(Value.Ten, Suit.Hearts),
                    new Card(Value.Jack, Suit.Hearts),
                    new Card(Value.King, Suit.Hearts),
                    new Card(Value.Queen, Suit.Hearts),
                    new Card(Value.Ace, Suit.Hearts));

            Assert.AreEqual(hand1, hand2);
        }
    }
}


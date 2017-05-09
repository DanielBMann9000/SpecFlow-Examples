using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerPoker54.Core.Model;

namespace EulerPoker54.Tests.Unit
{
    internal static class HandRepository
    {
        internal static Hand HighCard
        {
            get
            {
                return new Hand(new Card(Value.Two, Suit.Hearts),
                                new Card(Value.Four, Suit.Clubs),
                                new Card(Value.Six, Suit.Diamonds),
                                new Card(Value.Eight, Suit.Clubs),
                                new Card(Value.Ten, Suit.Spades));
            }
        }

        internal static Hand OnePair
        {
            get
            {
                return new Hand(new Card(Value.Two, Suit.Clubs),
                                 new Card(Value.Two, Suit.Hearts),
                                 new Card(Value.Three, Suit.Clubs),
                                 new Card(Value.Five, Suit.Diamonds),
                                 new Card(Value.Six, Suit.Spades));
            }
        }

        internal static Hand TwoPair
        {
            get
            {
                return new Hand(new Card(Value.Two, Suit.Hearts),
                                 new Card(Value.Two, Suit.Clubs),
                                 new Card(Value.Six, Suit.Diamonds),
                                 new Card(Value.Eight, Suit.Clubs),
                                 new Card(Value.Eight, Suit.Spades));
            }
        }

        internal static Hand ThreeOfAKind
        {
            get
            {
                return new Hand(new Card(Value.Two, Suit.Clubs),
                                 new Card(Value.Two, Suit.Hearts),
                                 new Card(Value.Three, Suit.Clubs),
                                 new Card(Value.Five, Suit.Diamonds),
                                 new Card(Value.Two, Suit.Spades));
            }
        }

        internal static Hand Straight 
        {
            get
            {
                return new Hand(new Card(Value.Two, Suit.Hearts),
                               new Card(Value.Three, Suit.Clubs),
                               new Card(Value.Four, Suit.Diamonds),
                               new Card(Value.Five, Suit.Clubs),
                               new Card(Value.Six, Suit.Spades));
            }
        }
        internal static Hand Flush 
        {
            get
            {
                return new Hand(new Card(Value.Two, Suit.Clubs),
                               new Card(Value.Five, Suit.Clubs),
                               new Card(Value.Three, Suit.Clubs),
                               new Card(Value.Ten, Suit.Clubs),
                               new Card(Value.Queen, Suit.Clubs));
            }
        }

        internal static Hand FullHouse
        {
            get
            {
                return new Hand(new Card(Value.Two, Suit.Hearts),
                    new Card(Value.Two, Suit.Clubs),
                    new Card(Value.Two, Suit.Diamonds),
                    new Card(Value.Three, Suit.Clubs),
                    new Card(Value.Three, Suit.Spades));
            }
        }

        internal static Hand FourOfAKind
        {
            get
            {
                return new Hand(new Card(Value.Two, Suit.Clubs),
                                 new Card(Value.Two, Suit.Hearts),
                                 new Card(Value.Two, Suit.Diamonds),
                                 new Card(Value.Two, Suit.Spades),
                                 new Card(Value.Queen, Suit.Clubs));
            }
        }

        internal static Hand StraightFlush 
        { 
            get
            {
                return new Hand(new Card(Value.Two, Suit.Hearts),
                                 new Card(Value.Three, Suit.Hearts),
                                 new Card(Value.Four, Suit.Hearts),
                                 new Card(Value.Five, Suit.Hearts),
                                 new Card(Value.Six, Suit.Hearts));
            } 
        }
        
        internal static Hand RoyalFlush 
        { 
            get
            {
                return new Hand(new Card(Value.Ten, Suit.Clubs),
                                 new Card(Value.King, Suit.Clubs),
                                 new Card(Value.Queen, Suit.Clubs),
                                 new Card(Value.Jack, Suit.Clubs),
                                 new Card(Value.Ace, Suit.Clubs));
            } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using EulerPoker54.Core;
using EulerPoker54.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerPoker54.Tests.Unit
{
    [TestClass]
    public class When_Loading_Poker_Hands
    {
        [TestMethod]
        public void Can_Create_Poker_Loader()
        {
            var loader = new PokerLoader(new FakeFileSystem());
            Assert.IsNotNull(loader);
        }

        [TestMethod]
        public void Loader_Can_Load_Hands_When_Given_A_File_Name()
        {
            // Arrange
            var fs = new FakeFileSystem();
            fs.Files.Add("pokerhands.txt", "8C TS KC 9H 4S 7D 2S 5D 3S AC");
            var loader = new PokerLoader(fs);

            //Act 

            var actual = loader.LoadHands(@"pokerhands.txt");

            //Assert
            Assert.IsInstanceOfType(actual, typeof(IEnumerable<Tuple<Hand, Hand>>));
        }

        [TestMethod]
        public void Loader_Can_Load_A_Single_Set_Of_Hands()
        {
            var fs = new FakeFileSystem();
            fs.Files.Add("pokerhands.txt", "8C TS KC 9H 4S 7D 2S 5D 3S AC");
            var loader = new PokerLoader(fs);

            var actual = loader.LoadHands(@"pokerhands.txt");

            Assert.AreEqual(1, actual.Count());
        }

        [TestMethod]
        public void Loader_Can_Parse_A_Single_Set_Of_Hands()
        {
            var firstHand = new Hand(new Card(Value.Eight, Suit.Clubs),
                new Card(Value.Ten, Suit.Spades),
                new Card(Value.King, Suit.Clubs),
                new Card(Value.Nine, Suit.Hearts),
                new Card(Value.Four, Suit.Spades));

            var secondHand = new Hand(new Card(Value.Seven, Suit.Diamonds),
               new Card(Value.Two, Suit.Spades),
               new Card(Value.Five, Suit.Diamonds),
               new Card(Value.Three, Suit.Spades),
               new Card(Value.Ace, Suit.Clubs));

            var fs = new FakeFileSystem();
            fs.Files.Add("pokerhands.txt", "8C TS KC 9H 4S 7D 2S 5D 3S AC");
            var loader = new PokerLoader(fs);

            var actual = loader.LoadHands(@"pokerhands.txt");

            var hands = actual.First();
            Assert.AreEqual(firstHand, hands.Item1);
            Assert.AreEqual(secondHand, hands.Item2);
        }

        [ExpectedException(typeof (NotImplementedException))]
        [TestMethod]
        public void Throws_An_Exception_When_A_Card_With_An_Invalid_Value_Is_Provided()
        {
            var fs = new FakeFileSystem();
            fs.Files.Add("pokerhands.txt", "XC TS KC 9H 4S 7D 2S 5D 3S AC");
            var loader = new PokerLoader(fs);

            loader.LoadHands(@"pokerhands.txt");
        }

        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void Throws_An_Exception_When_A_Card_With_An_Invalid_Suit_Is_Provided()
        {
            var fs = new FakeFileSystem();
            fs.Files.Add("pokerhands.txt", "2X TS KC 9H 4S 7D 2S 5D 3S AC");
            var loader = new PokerLoader(fs);

            loader.LoadHands(@"pokerhands.txt");
        }

    }
}

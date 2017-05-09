using EulerPoker54.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerPoker54.Tests.Unit
{
    [TestClass]
    public class When_Creating_A_Poker_Card
    {
        [TestMethod]
        public void Can_Create_A_Poker_Card()
        {
            var card = new Card(Value.Ten, Suit.Hearts);
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void A_Card_Has_A_Suit_And_A_Value()
        {
            var card = new Card(Value.Ten, Suit.Hearts);
            Assert.AreEqual(Value.Ten, card.Value);
            Assert.AreEqual(Suit.Hearts, card.Suit);
        }
    }
}
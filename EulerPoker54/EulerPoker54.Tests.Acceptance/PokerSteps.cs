using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using EulerPoker54.Core;
using EulerPoker54.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EulerPoker54.Tests.Acceptance
{
    [Binding]
    public sealed class PokerSteps
    {
        private Dictionary<int, List<Card>> game;

        [Given("a new hand of poker")]
        public void GivenANewHandOfPoker()
        {
            game = new Dictionary<int, List<Card>> {
                {1, new List<Card>() },
                {2, new List<Card>() },
            };
        }

        [When(@"player (\d) has a hand with the card (.*) of (.*)")]
        public void WhenPlayerHasCard(int player, string value, string suit)
        {
            var parsedSuit = (Suit)Enum.Parse(typeof(Suit), suit);
            var parsedValue = (Value)Enum.Parse(typeof(Value), value);

            game[player].Add(new Card(parsedValue, parsedSuit));
        }

        [When(@"player (\d) has a hand with the cards")]
        public void WhenPlayerHasCards(int player, Table table)
        {
            foreach (var row in table.Rows)
            {
                WhenPlayerHasCard(player, row["Value"], row["Suit"]);
            }
            
        }

        [Then(@"player (\d) should win")]
        public void ThenPlayerShouldWin(int player)
        {
            var player1HandCards = game[1];
            var player2HandCards = game[2];

            var player1Hand = new Hand(player1HandCards[0],
                    player1HandCards[1],
                    player1HandCards[2],
                    player1HandCards[3],
                    player1HandCards[4]
                );

            var player2Hand = new Hand(player2HandCards[0],
                    player2HandCards[1],
                    player2HandCards[2],
                    player2HandCards[3],
                    player2HandCards[4]
                );

            var winner = Poker.CompareHands(player1Hand, player2Hand);
            var results = new Dictionary<int, bool> {
                {1,  player1Hand == winner},
                {2,  player2Hand == winner},
            };

            Assert.IsTrue(results[player]);
        }
    }
}

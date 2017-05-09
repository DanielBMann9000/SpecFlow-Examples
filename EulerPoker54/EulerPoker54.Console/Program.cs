using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerPoker54.Core;
using EulerPoker54.Core.Model;

namespace EulerPoker54.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokerLoader = new PokerLoader(new RealFileSystem());
            var hands = pokerLoader.LoadHands(@".\Hands.txt");

            var playerOneWins = 0;
            var playerTwoWins = 0;
            foreach (var hand in hands)
            {
                var winningHand = Poker.CompareHands(hand.Item1, hand.Item2);
                if (Equals(winningHand, hand.Item1)) playerOneWins++;
                if (Equals(winningHand, hand.Item2)) playerTwoWins++;
            }

            System.Console.WriteLine("Player 1 won {0} hands.", playerOneWins);
            System.Console.WriteLine("Player 2 won {0} hands.", playerTwoWins);

            System.Console.ReadLine();
        }
    }
}

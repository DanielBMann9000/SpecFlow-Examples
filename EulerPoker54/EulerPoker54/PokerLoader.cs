using System;
using System.Collections.Generic;
using System.Linq;
using EulerPoker54.Core.Model;

namespace EulerPoker54.Core
{
    public class PokerLoader
    {
        private readonly IFileSystem fs;
        public PokerLoader(IFileSystem fs)
        {
            this.fs = fs;
        }

        public IEnumerable<Tuple<Hand, Hand>> LoadHands(string pokerHandsFile)
        {
            var hands = new List<Tuple<Hand, Hand>>();
            var lines = fs.ReadAllLines(pokerHandsFile);

            foreach (var splitLines in lines.Select(line => line.Split(new []{" "}, StringSplitOptions.None)))
            {
                var hand1 = ParseHand(splitLines.Take(5));
                var hand2 = ParseHand(splitLines.Skip(5).Take(5));

                hands.Add(new Tuple<Hand, Hand>(hand1, hand2));
            }
            return hands;
        }

        private static Hand ParseHand(IEnumerable<string> cards)
        {
            var cardList = cards.Select(ParseCard).ToList();
            return new Hand(cardList[0], cardList[1], cardList[2], cardList[3], cardList[4]);
        }

        private static Card ParseCard(string card)
        {
            var val = ParseValue(card[0]);
            var suit = ParseSuit(card[1]);
            return new Card(val, suit);
        }

        private static Value ParseValue(char c)
        {
            if (c == '2') return Value.Two;
            if (c == '3') return Value.Three;
            if (c == '4') return Value.Four;
            if (c == '5') return Value.Five;
            if (c == '6') return Value.Six;
            if (c == '7') return Value.Seven;
            if (c == '8') return Value.Eight;
            if (c == '9') return Value.Nine;
            if (c == 'T') return Value.Ten;
            if (c == 'J') return Value.Jack;
            if (c == 'Q') return Value.Queen;
            if (c == 'K') return Value.King;
            if (c == 'A') return Value.Ace;

            throw new NotImplementedException();
        }

        private static Suit ParseSuit(char c)
        {
            if (c == 'C') return Suit.Clubs;
            if (c == 'D') return Suit.Diamonds;
            if (c == 'H') return Suit.Hearts;
            if (c == 'S') return Suit.Spades;

            throw new NotImplementedException();
        }
    }
}

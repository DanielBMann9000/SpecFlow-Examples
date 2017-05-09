using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EulerPoker54.Core.Model
{
    public class Hand
    {
        private readonly List<Card> cards = new List<Card>();
        public ReadOnlyCollection<Card> Cards {get{return new ReadOnlyCollection<Card>(cards);}}
        public Rank Rank { get; private set; }
        public Value? RankHighCard { get; private set; }
        public Hand(Card card, Card card1, Card card2, Card card3, Card card4)
        {
            cards.Add(card);
            cards.Add(card1);
            cards.Add(card2);
            cards.Add(card3);
            cards.Add(card4);

            if (cards.Distinct().Count() < 5)
            {
                throw new ArgumentException();
            }

            this.Rank = this.CalculateRank();
        }        

        private Rank CalculateRank()
        {
            var valueGroups = cards.GroupBy(c => c.Value);
            var valueGroupCount = valueGroups.Count();
            if (valueGroupCount == 4)
            {
                RankHighCard = valueGroups.First(vg => vg.Count() > 1).First().Value;
                return Rank.OnePair;
            }
            if (valueGroupCount == 3)
            {
                if (valueGroups.Count(vg => vg.Count() == 2) == 2)
                {
                    var groups = valueGroups.Where(vg => vg.Count() == 2);
                    RankHighCard = groups.Max(g => g.Key);
                    return Rank.TwoPair;
                }
                var threeOfAKindGroups = valueGroups.Where(vg => vg.Count() > 1);
                RankHighCard = threeOfAKindGroups.Max(g => g.Key);
                return Rank.ThreeOfAKind;
            }
            if (valueGroupCount == 2)
            {
                if (valueGroups.Count(gv => gv.Count() == 4) == 1)
                {
                    RankHighCard = valueGroups.First(gv => gv.Count() == 4).First().Value;
                    return Rank.FourOfAKind;
                }
                RankHighCard = valueGroups.First(gv => gv.Count() == 3).Max(g=>g.Value);
                return Rank.FullHouse;
            }

            this.RankHighCard = cards.Max(c => c.Value);
            var suitGroups = cards.GroupBy(c => c.Suit);
            var smallCard = cards.Min(c => c.Value);
            var straightValue = (int)smallCard + ((int)smallCard + 1) + ((int)smallCard + 2) + ((int)smallCard + 3) + ((int)smallCard + 4);
            var isFlush = false;
            var isStraight = false;

            if (suitGroups.Count() == 1)
            {
                isFlush = true;
            }
            if (straightValue == cards.Sum(c => (int) c.Value))
            {
                isStraight = true;
            }

            if (isFlush && isStraight && smallCard == Value.Ten)
            {
                return Rank.RoyalFlush;
            }
            if (isFlush && isStraight)
            {
                return Rank.StraightFlush;
            }
            
            if (isFlush)
            {
                return Rank.Flush;
            }

            if (isStraight)
            {
                return Rank.Straight;
            }

            return Rank.HighCard;
        }

        public Stack<Value> GetCardValues()
        {
            var values = this.cards.OrderBy(c => c.Value).Select(c => c.Value).Distinct();
            return new Stack<Value>(values);
        }

        public override bool Equals(object obj)
        {
            var otherHand = obj as Hand;
            return this.cards[0].Equals(otherHand.Cards[0])
                   && this.cards[1].Equals(otherHand.Cards[1])
                   && this.cards[2].Equals(otherHand.Cards[2])
                   && this.cards[3].Equals(otherHand.Cards[3])
                   && this.cards[4].Equals(otherHand.Cards[4]);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.cards[0].GetHashCode();
                hash = hash * 23 + this.cards[1].GetHashCode();
                hash = hash * 23 + this.cards[2].GetHashCode();
                hash = hash * 23 + this.cards[3].GetHashCode();
                hash = hash * 23 + this.cards[4].GetHashCode();
                return hash;
            }
        }
    }
}

using EulerPoker54.Core.Model;

namespace EulerPoker54.Core
{
    public static class Poker
    {
        public static Hand CompareHands(Hand hand1, Hand hand2)
        {
            if (hand1.Rank == hand2.Rank)
            {
                if (hand1.RankHighCard == hand2.RankHighCard)
                {
                    var hand1CardValues = hand1.GetCardValues();
                    var hand2CardValues = hand2.GetCardValues();
                    while (hand1CardValues.Count > 0 && hand2CardValues.Count > 0)
                    {
                        var curCard1 = hand1CardValues.Pop();
                        var curCard2 = hand2CardValues.Pop();
                        if (curCard1 == curCard2)
                        {
                            continue;
                        }
                        return curCard1 < curCard2 ? hand2 : hand1;
                    }
                }

                return hand1.RankHighCard < hand2.RankHighCard ? hand2 : hand1;
            }

            return hand1.Rank < hand2.Rank ? hand2 : hand1;
        }
    }
}

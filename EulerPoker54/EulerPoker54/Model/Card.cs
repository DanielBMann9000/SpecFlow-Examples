namespace EulerPoker54.Core.Model
{
    public struct Card
    {
        public readonly Value Value;
        public readonly Suit Suit;

        public Card(Value value, Suit suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public override bool Equals(object obj)
        {
            var otherCard = obj is Card ? (Card) obj : new Card();
            return this.Suit.Equals(otherCard.Suit) && this.Value.Equals(otherCard.Value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash*23 + this.Suit.GetHashCode();
                hash = hash*23 + this.Value.GetHashCode();
                return hash;
            }
            
        }
    }
}
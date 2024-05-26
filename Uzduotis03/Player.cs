namespace Uzduotis03
{
    internal class Player
    {
        public string Name { get; set; }
        public Card[] Hand { get; set; } = new Card[2];

        public Player(string name, Card[] hand)
        {
            Name = name;
            Hand = hand;
        }

        public override string ToString()
        {
            return $"{Name} with cards {Hand[0].ToString()} and {Hand[1].ToString()}";
        }

        public int CalculatePoints()
        {
            if (Hand.Length > 0)
            {
                return Hand[0].Value + Hand[1].Value;
            }
            else
            {
                Console.WriteLine("Hand is empty\n");
                return 0;
            }

        }
    }
}

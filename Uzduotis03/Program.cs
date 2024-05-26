using System.Linq;

namespace Uzduotis03
{
    // Sukurti klasę - Žaidėjas kuris turi kortų masyvą arba sąrašą (asmeninis pasirinkimas) (jame 2 kortos)
    // Sukurti funkcija kuri iš sugeneruotos kortų kaladės duoda dvi atsitiktines kortas Žaidėjui.
    // Sukurti du Žaidėjus pagal klasę Žaidėjas. Žaidėjams padalinti po dvi kortas
    // Sukurti funkcija, IšrinkLaimėtoją(Žaidėjas žaidėjas1, Žaidėjas žaidėjas2), kuri grąžina žaidėją, kuris laimėjo.
    // Išvesti laimėjusį žaidėją į ekraną

    internal class Program
    {
        public static void Main(string[] args)
        {
            Player player1 = new("Petras", DealHand());
            Player player2 = new("Jonas", DealHand());

            while (player2.Hand.Contains(player1.Hand[0]) || player2.Hand.Contains(player1.Hand[1]))
            {
                player2 = new("Jonas", DealHand());
            }

            Console.WriteLine("Player 1: " + player1.ToString());
            Console.WriteLine("Player 2: " + player2.ToString());

            SelectWinner(player1, player2);
        }

        public static Card? RandomCard()
        {
            Random random = new();

            int number = random.Next(4);
            string? face = Enum.GetName(typeof(Face), number);
            number = random.Next(1, 14);
            string? order = Enum.GetName(typeof(Order), number);

            if (face != null && order != null)
            {
                Card card = new(face, order);
                return card;
            }
            else
            {
                return null;
            }
        }

        public static Card[] DeckOf52Cards()
        {
            Card[] deck = new Card[52]; // Create a 52-card array
            int n = 0; // Index of card to create
            for (int i = 1; i < 14; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Card card = new(Enum.GetName(typeof(Face), j), Enum.GetName(typeof(Order), i));
                    deck[n] = card;
                    n++;
                }
            }
            return deck;
        }

        public static Card?[] ShuffleDeck(Card?[] deck)
        {
            Card?[] shuffledDeck = new Card?[deck.Length];
            Random random = new();
            int temp;

            for (int i = 0; i < deck.Length; i++)
            {
                do
                {
                    temp = random.Next(deck.Length);
                }
                while (deck[temp] == null);

                shuffledDeck[i] = deck[temp];
                deck[temp] = null;
            }

            return shuffledDeck;
        }

        public static void DisplayDeck(Card?[] deck)
        {
            if (deck.Length > 0)
            {
                for (int i = 0; i < deck.Length; i++)
                {
                    Console.WriteLine($"{deck[i].ToString()}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The deck is empty\n");
            }
        }

        public static Card[] DealHand()
        {
            Card?[] deck = DeckOf52Cards();
            Card?[] hand = new Card[2];

            Random random = new();
            int n = random.Next(52);
            hand[0] = deck[n];
            deck[n] = null;
            int m;

            do
            {
                m = random.Next(52);
            }
            while (m == n);

            hand[1] = deck[m];

            return hand;
        }

        public static Player? SelectWinner(Player player1, Player player2)
        {
            int player1Points = player1.CalculatePoints();
            int player2Points = player2.CalculatePoints();

            if (player1.CalculatePoints() > player2.CalculatePoints())
            {
                Console.WriteLine($"With {player1Points} points against {player2Points}, the winner is {player1.Name}\n");
                return player1;
            }
            else if (player2.CalculatePoints() > player1.CalculatePoints())
            {
                Console.WriteLine($"With {player2Points} points against {player1Points}, the winner is {player2.Name}\n");
                return player2;
            }
            else
            {
                Console.WriteLine($"It's a tie with {player1Points} against {player2Points} points\n");
                return null;
            }
        }
    }
}

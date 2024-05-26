namespace Uzduotis02
{
    // Sukurti klasę korta, kuri gali turėti 4 skirtingas reiksmes(string) clubs(:clubs:), diamonds(:diamonds:), hearts(:hearts:) and spades(:spades:)
    // Ir eilesNumeris(string)
    // (funkcijas kuriame pagrindineje programos klasėje, ne klasėje Korta)
    // Sukurti funkciją kuri sugeneruoja kortą.
    // Sukurti funkcija kuri sugeneruoja visa kortų kaladę(be džokerio) (kortos neturi kartotis). Išspausdinti visą kortų sąrašą.
    // Sukurti funkcija išmaišyti kortas kuri sumaišo kortas random būdu. Išspausdinti visą kortų sąrašą

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Display random card
            Console.WriteLine($"Random card: {RandomCard().ToString()}\n");

            // Display sorted deck
            DisplayDeck(DeckOf52Cards());

            // Display shuffled deck
            DisplayDeck(ShuffleDeck(DeckOf52Cards()));
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
    }
}
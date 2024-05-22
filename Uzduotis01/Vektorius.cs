namespace Uzduotis01
{
    // Sukurkite klasę Vektorius, kuri turės vienmatį masyvą ir metodą:
    // IsvestiVektoriu - išvesti vektorių į konsolę.

    internal class Vektorius
    {
        public int[] Masyvas { get; set; }

        public Vektorius(int[] masyvas)
        {
            Masyvas = masyvas;
        }

        public void IsvestiVektoriu()
        {
            if (Masyvas.Length == 0)
                return;

            Console.WriteLine("Vektorius:");

            for (int i = 0; i < Masyvas.Length; i++)
            {
                Console.Write($"{Masyvas[i]} ");
            }
            Console.WriteLine("\n");
        }
    }
}

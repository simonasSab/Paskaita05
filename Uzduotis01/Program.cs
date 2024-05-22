namespace Uzduotis01
{
    internal class Program
    {
        // Užduotis: Sukurkite programą, kuri atliks šias operacijas su matrica ir vektoriais:
        //  - išvesti vektorių į konsolę.
        //  - išvesti matricą į konsolę.
        //  - grąžina transponuotą matricą.
        //  - sudeda dvi matricas.
        //  - daugina matricą iš vektoriaus.

        public static void Main(string[] args)
        {
            Meniu();
        }

        private static void Meniu()
        {
            Console.WriteLine("MATRICU IR VEKTORIU MANIPULIACIJU PROGRAMA\n" +
                              "Skaiciai sugeneruojami atsitiktine tvarka nuo 0 iki 99\n");
            int selection;
            bool isInt;
            do
            {
                Console.WriteLine("1.Isvesti vektoriu i konsole" +
                                "\n2.Isvesti matrica i konsole" +
                                "\n3.Grazinti transponuota matrica" +
                                "\n4.Sudeti dvi matricas" +
                                "\n5.Dauginti matrica is vektoriaus" +
                                "\n           0. Baigti darba.\n");
                isInt = int.TryParse(Console.ReadLine(), out selection);
                Console.WriteLine();
            }
            while (!isInt || selection < 0 || selection > 5);

            switch (selection)
            {
                case 0:
                    Console.WriteLine($"Programa baigia darba.");
                    return;
                case 1:
                    NewVector().IsvestiVektoriu();
                    break;
                case 2:
                    NewMatrix().IsvestiMatrica();
                    break;
                case 3:
                    Matrica? matrica = NewMatrix();
                    matrica.IsvestiMatrica();
                    matrica = matrica.Transponuoti();
                    matrica.IsvestiMatrica();
                    break;
                case 4:
                    Matrica? matrica1 = NewMatrix();
                    matrica1.IsvestiMatrica();
                    Matrica? matrica2 = NewMatrix();
                    matrica2.IsvestiMatrica();
                    matrica1.Sudeti(matrica2);
                    matrica1.IsvestiMatrica();
                    break;
                case 5:
                    Matrica? matrica3 = NewMatrix();
                    matrica3.IsvestiMatrica();
                    Vektorius vektorius = NewVector();
                    vektorius.IsvestiVektoriu();
                    matrica3.DaugintiIsVektoriaus(vektorius);
                    matrica3.IsvestiMatrica(true);
                    break;
                default:
                    Console.WriteLine($"Ivyko nenumatyta klaida, programa baigia darba.");
                    return;
            }
            Meniu();
        }

        public static Vektorius NewVector()
        {
            Random random = new();
            // Get vector array length from user
            int vectorLength;
            bool isInt;
            do
            {
                Console.WriteLine("Irasykite vektoriaus masyvo ilgi.\n");
                isInt = int.TryParse(Console.ReadLine(), out vectorLength);
            }
            while (!isInt || vectorLength < 1);
            Console.WriteLine();

            // Populate array with random non-negative integers from 0 to 100
            int[] array = new int[vectorLength];
            for (int i = 0; i < vectorLength; i++)
            {
                array[i] = random.Next(0, 100);
            }
            // Create new vector
            Vektorius vektorius = new(array);
            return vektorius;
        }

        public static Matrica NewMatrix()
        {
            Random random = new();
            bool isInt;
            // Get matrix dimension X length from user
            int dimensionXLength;
            do
            {
                Console.WriteLine("Irasykite matricos X dimensijos ilgi.\n");
                isInt = int.TryParse(Console.ReadLine(), out dimensionXLength);
            }
            while (!isInt || dimensionXLength < 1);
            Console.WriteLine();

            // Get matrix dimension Y length from user
            int dimensionYLength;
            do
            {
                Console.WriteLine("Irasykite matricos Y dimensijos ilgi.\n");
                isInt = int.TryParse(Console.ReadLine(), out dimensionYLength);
            }
            while (!isInt || dimensionYLength < 1);
            Console.WriteLine();

            // Populate 2D array with random non-negative integers from 0 to 100
            int[,] array2D = new int[dimensionXLength, dimensionYLength];
            for (int i = 0; i < dimensionXLength; i++)
            {
                for (int j = 0; j < dimensionYLength; j++)
                {
                    array2D[i, j] = random.Next(0, 100);
                }
            }
            // Create new matrix
            Matrica matrica = new(array2D);
            return matrica;
        }
    }
}

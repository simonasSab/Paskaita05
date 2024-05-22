namespace Uzduotis01
{
    // Sukurkite klasę Matrica, kuri turės dvimatį masyvą ir metodus:
    // IsvestiMatrica - išvesti matricą į konsolę.
    // Transponuoti - grąžina transponuotą matricą.
    // Sudeti - sudeda dvi matricas.
    // Dauginti - daugina matricą iš vektoriaus.

    internal class Matrica
    {
        public int[,]? DvimatisMasyvas { get; set; }

        public Matrica(int[,] dvimatisMasyvas)
        {
            DvimatisMasyvas = dvimatisMasyvas;
        }

        public void IsvestiMatrica()
        {
            if (DvimatisMasyvas == null)
                return;

            Console.WriteLine("Matrica:");
            for (int i = 0; i < DvimatisMasyvas.GetLength(0); i++)
            {
                for (int j = 0; j < DvimatisMasyvas.GetLength(1); j++)
                {
                    if(DvimatisMasyvas[i, j] < 100)
                        Console.Write($"{DvimatisMasyvas[i,j]:00}  ");
                    else
                        Console.Write($"{DvimatisMasyvas[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void IsvestiMatrica(bool formatSpaces)
        {
            if (DvimatisMasyvas == null)
                return;

            Console.WriteLine("Matrica:");
            for (int i = 0; i < DvimatisMasyvas.GetLength(0); i++)
            {
                for (int j = 0; j < DvimatisMasyvas.GetLength(1); j++)
                {
                    if (DvimatisMasyvas[i, j] < 100)
                        Console.Write($"{DvimatisMasyvas[i, j]:00}   ");
                    else if (DvimatisMasyvas[i, j] < 1000)
                        Console.Write($"{DvimatisMasyvas[i, j]}  ");
                    else
                        Console.Write($"{DvimatisMasyvas[i, j]} ");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Matrica? Transponuoti()
        {
            if (this.DvimatisMasyvas != null)
            {
                int[,] masyvas2D = new int[this.DvimatisMasyvas.GetLength(1), this.DvimatisMasyvas.GetLength(0)];

                for (int i = 0; i < masyvas2D.GetLength(1); i++)
                {
                    for (int j = 0; j < masyvas2D.GetLength(0); j++)
                    {
                        masyvas2D[j, i] = this.DvimatisMasyvas[i, j];
                    }
                }
                return new(masyvas2D);
            }
            return null;
        }

        public void Sudeti(Matrica? antraMatrica)
        {
            if (this.DvimatisMasyvas != null && antraMatrica != null && antraMatrica.DvimatisMasyvas != null)
            {
                if (antraMatrica.DvimatisMasyvas.GetLength(0) == this.DvimatisMasyvas.GetLength(0) &&
                    antraMatrica.DvimatisMasyvas.GetLength(1) == this.DvimatisMasyvas.GetLength(1))
                {
                    for (int i = 0; i < antraMatrica.DvimatisMasyvas.GetLength(0); i++)
                    {
                        for (int j = 0; j < antraMatrica.DvimatisMasyvas.GetLength(1); j++)
                        {
                            this.DvimatisMasyvas[i, j] += antraMatrica.DvimatisMasyvas[i, j];
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sudetis negalima: matricu dimensijos nesutampa\n");
                }
            }
        }

        public void DaugintiIsVektoriaus(Vektorius? vektorius)
        {
            if (this.DvimatisMasyvas != null && vektorius != null && vektorius.Masyvas != null)
            {
                if (vektorius.Masyvas.Length == this.DvimatisMasyvas.GetLength(0))
                {
                    for (int j = 0; j < this.DvimatisMasyvas.GetLength(1); j++)
                    {
                        for (int i = 0; i < this.DvimatisMasyvas.GetLength(0); i++)
                        {
                            this.DvimatisMasyvas[i, j] *= vektorius.Masyvas[i];
                        }
                    }
                }
                else if(vektorius.Masyvas.Length == this.DvimatisMasyvas.GetLength(1))
                {
                    for (int i = 0; i < this.DvimatisMasyvas.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.DvimatisMasyvas.GetLength(1); j++)
                        {
                            this.DvimatisMasyvas[i, j] *= vektorius.Masyvas[j];
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Daugyba negalima: vektoriaus ilgis nesutampa su nei vienos matricos dimensijos ilgiu\n");
                }
            }
        }
    }
}

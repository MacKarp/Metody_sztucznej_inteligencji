// Karpiński Maciej, 39446

using System;

namespace Algorytm_genetyczny
{
    class Program
    {
        static void Main(string[] args)
        {

            string Cel = "Litwo! Ojczyzno moja!";
            int IloscPopulacji = 100;
            double SzansaMutacji = 0.01;

            Populacja populacja = new Populacja(Cel, SzansaMutacji, IloscPopulacji);

            while (!populacja.Ukonczono)
            {
                Console.SetCursorPosition(0, 0);
                Ewolucja(populacja);
                Wyswietl(populacja, IloscPopulacji, SzansaMutacji, Cel);
            }

        }

        private static void Ewolucja(Populacja pop)
        {
            pop.SelekcjaNaturalna();
            pop.NowaGeneracja();
            pop.ObliczDopasowanie();
            pop.Oszacowanie();
        }

        private static void Wyswietl(Populacja pop, int liczbaPop, double szansaMutacji, string cel)
        {
            string odpowiedz = pop.Najlepsze;
            Console.WriteLine("Cel dopasowania: " + cel);
            Console.WriteLine("Najlepsze dopasowanie: " + odpowiedz);
            Console.WriteLine("Wszystkich generacji: " + pop.Generacja);
            Console.WriteLine("Średnie dopasowanie: " + Math.Round(pop.SrednieDopasowanie() * 100, 2) + "%");
            Console.WriteLine("Całkowita populacja: " + liczbaPop);
            Console.WriteLine("Szansa mutacji: " + szansaMutacji * 100 + "%");
            Console.WriteLine("Losowy przedstawiciel populacji: \n" + pop.wszystkieFrazy());
        }
    }
}


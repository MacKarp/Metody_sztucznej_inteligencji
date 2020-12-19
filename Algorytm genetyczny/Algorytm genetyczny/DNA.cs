using System;

namespace Algorytm_genetyczny
{
    public class DNA
    {
        public double dopasowanie = 0;
        public char[] geny;
        private char[] _literki = new char[72]
        {
            'a', 'A', 'ą', 'Ą', 'b', 'B', 'c', 'C', 'ć', 'Ć', 'd', 'D',
            'e', 'E', 'ę', 'Ę', 'f', 'F', 'g', 'G', 'h', 'H', 'i', 'I',
            'j', 'J', 'k', 'K', 'l', 'L', 'ł', 'Ł', 'm', 'M', 'n', 'N',
            'ń', 'Ń', 'o', 'O', 'ó', 'Ó', 'p', 'P', 'q', 'Q', 'r', 'R',
            's', 'S', 'ś', 'Ś', 't', 'T', 'u', 'U', 'v', 'V', 'w', 'W',
            'x', 'X', 'y', 'Y', 'z', 'Z', 'ź', 'Ź', 'ż', 'Ż', ' ', '!'
        };


        public DNA(int dlugosc)
        {
            Random rnd = new Random();
            geny = new char[dlugosc];
            for (int i = 0; i < dlugosc; i++)
            {
                this.geny[i] = _literki[rnd.Next(0, _literki.Length - 1)];
            }
        }

        public override string ToString()
        {
            return new string(geny);
        }

        public void ObliczDopasowanie(String celDopasowania)
        {
            var cel = celDopasowania.ToCharArray();
            double punkty = 0;
            for (int i = 0; i < this.geny.Length; i++)
            {
                if (this.geny[i] == cel[i])
                {
                    punkty++;
                }
            }

            this.dopasowanie = punkty / cel.Length;
        }

        public DNA Krzyzowanie(DNA partner)
        {
            Random rnd = new Random();
            var dziecko = new DNA(this.geny.Length);
            var punkt = rnd.Next(0, this.geny.Length);
            for (int i = 0; i < this.geny.Length; i++)
            {
                if (i > punkt)
                {
                    dziecko.geny[i] = this.geny[i];
                }
                else
                {
                    dziecko.geny[i] = partner.geny[i];
                }
            }

            return dziecko;
        }

        public void Mutacja(double szansaMutacji)
        {
            Random rnd = new Random();
            for (int i = 0; i < this.geny.Length; i++)
            {
                if (rnd.NextDouble() < szansaMutacji)
                {
                    this.geny[i] = _literki[rnd.Next(0, _literki.Length)];
                }
            }
        }
    }
}
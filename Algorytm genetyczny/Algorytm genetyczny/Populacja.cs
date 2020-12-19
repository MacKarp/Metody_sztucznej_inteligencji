using System;
using System.Collections;

namespace Algorytm_genetyczny
{
    public class Populacja
    {
        public DNA[] PopulacjaDNA;
        public ArrayList Pokrycie = new ArrayList();
        public int Generacja = 0;
        public bool Ukonczono = false;
        public string Cel;
        public double SzansaMutacji;
        public double IdealnePunktacja = 1.0;
        public string Najlepsze = "";

        public Populacja(string cel, double szansaMutacji, int maxPopulacji)
        {
            Cel = cel;
            SzansaMutacji = szansaMutacji;

            PopulacjaDNA = new DNA[maxPopulacji];
            for (int i = 0; i < maxPopulacji; i++)
            {
                this.PopulacjaDNA[i] = new DNA(this.Cel.Length);
            }

            this.ObliczDopasowanie();
        }

        public void ObliczDopasowanie()
        {
            foreach (var dna in this.PopulacjaDNA)
            {
                dna.ObliczDopasowanie(Cel);
            }
        }

        public void SelekcjaNaturalna()
        {
            Pokrycie = new ArrayList();
            double najlepszeDopasowanie = 0;

            foreach (var dna in this.PopulacjaDNA)
            {
                if (dna.dopasowanie > najlepszeDopasowanie)
                {
                    najlepszeDopasowanie = dna.dopasowanie;
                }
            }

            double ratio = 1 / najlepszeDopasowanie;

            foreach (var dna in this.PopulacjaDNA)
            {
                double dopasowanie = dna.dopasowanie * ratio;
                var n = (int)Math.Floor(dopasowanie * 100);
                for (int j = 0; j < n; j++)
                {
                    this.Pokrycie.Add(dna);
                }
            }
        }

        public void NowaGeneracja()
        {
            Random rnd = new Random();
            for (int i = 0; i < this.PopulacjaDNA.Length; i++)
            {
                int a = rnd.Next(0, this.Pokrycie.Count);
                int b = rnd.Next(0, this.Pokrycie.Count);

                DNA partnerA = (DNA)this.Pokrycie[a];
                DNA partnerB = (DNA)this.Pokrycie[b];
                DNA dziecko = partnerA.Krzyzowanie(partnerB);
                dziecko.Mutacja(this.SzansaMutacji);
                this.PopulacjaDNA[i] = dziecko;
            }

            this.Generacja++;
        }

        public void Oszacowanie()
        {
            double rekord = 0.0;
            int indeks = 0;
            for (int i = 0; i < this.PopulacjaDNA.Length; i++)
            {
                if (!(this.PopulacjaDNA[i].dopasowanie > rekord)) continue;
                indeks = i;
                rekord = this.PopulacjaDNA[i].dopasowanie;
            }

            this.Najlepsze = this.PopulacjaDNA[indeks].ToString();
            if (rekord == this.IdealnePunktacja)
            {
                this.Ukonczono = true;
            }
        }

        public double SrednieDopasowanie()
        {
            double total = 0.0;
            foreach (var dna in this.PopulacjaDNA)
            {
                total += dna.dopasowanie;
            }

            return total / this.PopulacjaDNA.Length;
        }

        public string wszystkieFrazy()
        {
            string wszystkie = "";
            int limit = Math.Min(this.PopulacjaDNA.Length, 15);

            for (int i = 0; i < limit; i++)
            {
                wszystkie += this.PopulacjaDNA[i].ToString() + "\n";
            }

            return wszystkie;
        }
    }
}
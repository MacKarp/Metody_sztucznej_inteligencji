using System;

namespace System_ekspercki
{
    public class Wino : IComparable
    {
        public string NazwaWina = "";
        public string RodzajWina = "";
        public string RodzajWinaAlt = "";
        public string KolorWina = "";
        public string WagaWina = "";
        public string WagaWinaAlt = "";
        public int punktacja = 0;

        public int CompareTo(object? obj)
        {
            Wino inneWino = (Wino)obj;
            return this.punktacja.CompareTo(inneWino.punktacja);
        }
    }
}
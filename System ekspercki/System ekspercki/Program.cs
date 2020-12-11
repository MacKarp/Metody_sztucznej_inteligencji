using System;
using System.Collections.Generic;

namespace System_ekspercki
{
    class Program
    {
        static void Main(string[] args)
        {
            // baza danych win
            List<Wino> lista_win = new List<Wino>();
            lista_win.Add(new Wino()
            {
                NazwaWina = "Gamay",
                KolorWina = "czerwone",
                WagaWina = "średnie",
                RodzajWina = "półsłodkie",
                RodzajWinaAlt = "słodkie"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Chablis",
                KolorWina = "białe",
                WagaWina = "lekkie",
                RodzajWina = "wytrawne"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Sauvignon blanc",
                KolorWina = "białe",
                WagaWina = "średnie",
                RodzajWina = "wytrawne"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Chardonnay",
                KolorWina = "białe",
                WagaWina = "średnie",
                WagaWinaAlt = "ciężkie",
                RodzajWina = "średnie",
                RodzajWinaAlt = "wytrawne"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Saove",
                KolorWina = "białe",
                WagaWina = "lekkie",
                RodzajWina = "średnie",
                RodzajWinaAlt = "wytrawne"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Riesling",
                KolorWina = "białe",
                WagaWina = "lekkie",
                WagaWinaAlt = "średnie",
                RodzajWina = "półsłodkie",
                RodzajWinaAlt = "słodkie"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Gewurztraminer",
                KolorWina = "białe",
                WagaWina = "ciężkie"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Chenin Blanc",
                KolorWina = "białe",
                WagaWina = "lekkie",
                RodzajWina = "półsłodkie",
                RodzajWinaAlt = "słodkie"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Valpolicella",
                KolorWina = "czerwone",
                WagaWina = "lekkie",
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Cabernet Sauvignon",
                KolorWina = "czerwone",
                RodzajWina = "wytrawne",
                RodzajWinaAlt = "półsłodkie"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Zinfandel",
                KolorWina = "czerwone",
                RodzajWina = "wytrawne",
                RodzajWinaAlt = "półsłodkie"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Pinot noir",
                KolorWina = "czerwone",
                WagaWina = "średnie",
                RodzajWina = "półsłodkie"
            });

            lista_win.Add(new Wino()
            {
                NazwaWina = "Burgundy",
                KolorWina = "czerwone",
                WagaWina = "ciężkie",
                WagaWinaAlt = "średnie"
            });

            // zadawanie pytań
            Console.WriteLine("Witaj w systemie eksperckim, który pomoże dobrać Ci rodzaj wina do posiłku!");
            string rodzaj_wina = Rodzaj_wina();
            string kolor_wina = Kolor_wina();
            string waga_wina = Waga_wina();
            string smak_potrawy = Smak_potrawy();
            bool czy_ma_sos = Czy_ma_sos();
            string smak_sosu = "";
            if (czy_ma_sos)
            {
                smak_sosu = Smak_sosu();
            }
            string glowny_skladnik_dania = Glowny_skladnik_dania();
            bool czy_zawiera_indyka = false;
            if (glowny_skladnik_dania == "drób")
            {
                czy_zawiera_indyka = Czy_ma_indyka();

            }

            // obliczanie dopasowania
            if (czy_ma_sos)
            {
                switch (smak_sosu)
                {
                    case "ostry":
                        foreach (var wino in lista_win)
                        {
                            switch (wino.WagaWina)
                            {
                                case "ciężkie":
                                    wino.punktacja += 100;
                                    break;
                            }

                            switch (wino.WagaWinaAlt)
                            {
                                case "ciężkie":
                                    wino.punktacja += 100;
                                    break;
                            }
                        }
                        break;
                    case "śmietanowy":
                        foreach (var wino in lista_win)
                        {
                            switch (wino.WagaWina)
                            {
                                case "średnie":
                                    wino.punktacja += 40;
                                    break;
                                case "ciężkie":
                                    wino.punktacja += 60;
                                    break;
                            }

                            switch (wino.WagaWinaAlt)
                            {
                                case "średnie":
                                    wino.punktacja += 40;
                                    break;
                                case "ciężkie":
                                    wino.punktacja += 60;
                                    break;
                            }

                            switch (wino.KolorWina)
                            {
                                case "białe":
                                    wino.punktacja += 40;
                                    break;
                            }
                        }
                        break;
                    case "słodki":
                        foreach (var wino in lista_win)
                        {
                            switch (wino.RodzajWina)
                            {
                                case "słodkie":
                                    wino.punktacja += 90;
                                    break;
                                case "półsłodkie":
                                    wino.punktacja += 40;
                                    break;
                            }

                            switch (wino.RodzajWinaAlt)
                            {
                                case "słodkie":
                                    wino.punktacja += 90;
                                    break;
                                case "półsłodkie":
                                    wino.punktacja += 40;
                                    break;
                            }

                            switch (wino.KolorWina)
                            {
                                case "białe":
                                    wino.punktacja += 40;
                                    break;
                            }
                        }
                        break;
                }
            }

            switch (smak_potrawy)
            {
                case "delikatny":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.WagaWina)
                        {
                            case "lekkie":
                                wino.punktacja += 100;
                                break;
                        }

                        switch (wino.WagaWinaAlt)
                        {
                            case "lekkie":
                                wino.punktacja += 100;
                                break;
                        }
                    }
                    break;
                case "średni":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.WagaWina)
                        {
                            case "lekkie":
                                wino.punktacja += 30;
                                break;
                            case "średnie":
                                wino.punktacja += 60;
                                break;
                            case "ciężkie":
                                wino.punktacja += 30;
                                break;
                        }

                        switch (wino.WagaWinaAlt)
                        {
                            case "lekkie":
                                wino.punktacja += 30;
                                break;
                            case "średnie":
                                wino.punktacja += 60;
                                break;
                            case "ciężkie":
                                wino.punktacja += 30;
                                break;
                        }
                    }
                    break;
                case "mocny":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.WagaWina)
                        {
                            case "średnie":
                                wino.punktacja += 40;
                                break;
                            case "ciężkie":
                                wino.punktacja += 80;
                                break;
                        }
                        switch (wino.WagaWinaAlt)
                        {
                            case "średnie":
                                wino.punktacja += 40;
                                break;
                            case "ciężkie":
                                wino.punktacja += 80;
                                break;
                        }

                    }
                    break;
            }

            switch (waga_wina)
            {
                case "lekkie":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.WagaWina)
                        {
                            case "lekkie":
                                wino.punktacja += 40;
                                break;
                        }
                        switch (wino.WagaWinaAlt)
                        {
                            case "lekkie":
                                wino.punktacja += 40;
                                break;
                        }
                    }
                    break;
                case "średnie":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.WagaWina)
                        {
                            case "średnie":
                                wino.punktacja += 40;
                                break;
                        }
                        switch (wino.WagaWinaAlt)
                        {
                            case "średnie":
                                wino.punktacja += 40;
                                break;
                        }
                    }
                    break;
                case "ciężkie":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.WagaWina)
                        {
                            case "ciężkie":
                                wino.punktacja += 40;
                                break;
                        }
                        switch (wino.WagaWinaAlt)
                        {
                            case "ciężkie":
                                wino.punktacja += 40;
                                break;
                        }
                    }
                    break;
            }

            switch (glowny_skladnik_dania)
            {
                case "mięso":
                    if (smak_sosu == "pomidorowy")
                    {
                        foreach (var wino in lista_win)
                        {
                            switch (wino.KolorWina)
                            {
                                case "czerwone":
                                    wino.punktacja += 100;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var wino in lista_win)
                        {
                            switch (wino.KolorWina)
                            {
                                case "czerwone":
                                    wino.punktacja += 90;
                                    break;
                            }
                        }
                    }

                    break;
                case "ryba":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.KolorWina)
                        {
                            case "białe":
                                wino.punktacja += 100;
                                break;
                        }
                    }
                    break;
                case "drób":
                    if (smak_sosu == "pomidorowy")
                    {
                        foreach (var wino in lista_win)
                        {
                            switch (wino.KolorWina)
                            {
                                case "czerwone":
                                    wino.punktacja += 100;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (czy_zawiera_indyka)
                        {
                            foreach (var wino in lista_win)
                            {
                                switch (wino.KolorWina)
                                {
                                    case "czerwone":
                                        wino.punktacja += 80;
                                        break;
                                    case "białe":
                                        wino.punktacja += 50;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            foreach (var wino in lista_win)
                            {
                                switch (wino.KolorWina)
                                {
                                    case "czerwone":
                                        wino.punktacja += 90;
                                        break;
                                    case "białe":
                                        wino.punktacja += 30;
                                        break;
                                }
                            }
                        }
                    }

                    break;
            }

            switch (kolor_wina)
            {
                case "czerwone":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.KolorWina)
                        {
                            case "czerwone":
                                wino.punktacja += 40;
                                break;
                        }
                    }
                    break;
                case "białe":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.KolorWina)
                        {
                            case "białe":
                                wino.punktacja += 40;
                                break;
                        }
                    }
                    break;
            }

            switch (rodzaj_wina)
            {
                case "wytrawne":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.RodzajWina)
                        {
                            case "wytrawne":
                                wino.punktacja += 40;
                                break;
                        }
                        switch (wino.RodzajWinaAlt)
                        {
                            case "wytrawne":
                                wino.punktacja += 40;
                                break;
                        }
                    }
                    break;
                case "półsłodkie":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.RodzajWina)
                        {
                            case "półsłodkie":
                                wino.punktacja += 40;
                                break;
                        }
                        switch (wino.RodzajWinaAlt)
                        {
                            case "półsłodkie":
                                wino.punktacja += 40;
                                break;
                        }
                    }
                    break;
                case "słodkie":
                    foreach (var wino in lista_win)
                    {
                        switch (wino.RodzajWina)
                        {
                            case "słodkie":
                                wino.punktacja += 40;
                                break;
                        }
                        switch (wino.RodzajWinaAlt)
                        {
                            case "słodkie":
                                wino.punktacja += 40;
                                break;
                        }
                    }
                    break;
            }

            // wyswietlenie wynikow
            lista_win.Sort();
            lista_win.Reverse();
            Console.WriteLine("###############################");
            Console.WriteLine("#  {0,-20}  #", "Najlepiej dopasowane wina");
            Console.WriteLine("###############################"); ;
            foreach (var wino in lista_win)
            {
                int procent = (wino.punktacja * 100) / 300;
                Console.WriteLine("# {0,-20} {1,5}% #", wino.NazwaWina, procent);
            }
            Console.WriteLine("###############################");
        }

        private static string Rodzaj_wina()
        {
            string rodzaj_wina;
            bool poprawny_rodzaj_wina = false;
            do
            {
                Console.WriteLine("Preferujesz wino wytrawne, półsłodkie czy słodkie?");
                rodzaj_wina = Console.ReadLine();
                rodzaj_wina = rodzaj_wina.ToLower();
                switch (rodzaj_wina)
                {
                    case "wytrawne":
                        poprawny_rodzaj_wina = true;
                        break;
                    case "półsłodkie":
                        poprawny_rodzaj_wina = true;
                        break;
                    case "słodkie":
                        poprawny_rodzaj_wina = true;
                        break;
                    default:
                        poprawny_rodzaj_wina = false;
                        Console.WriteLine("Wybrałeś niepoprawnie, spróbuj jeszcze raz.");
                        break;
                }
                Console.WriteLine();
            } while (!poprawny_rodzaj_wina);

            return rodzaj_wina;
        }

        private static string Kolor_wina()
        {
            bool poprawny_kolor_wina = false;
            string kolor_wina;
            do
            {
                Console.WriteLine("Preferujesz wino czerwone czy białe?");
                kolor_wina = Console.ReadLine();
                kolor_wina = kolor_wina.ToLower();
                switch (kolor_wina)
                {
                    case "białe":
                        poprawny_kolor_wina = true;
                        break;
                    case "czerwone":
                        poprawny_kolor_wina = true;
                        break;
                    default:
                        poprawny_kolor_wina = false;
                        Console.WriteLine("Wybrałeś niepoprawnie, spróbuj jeszcze raz.");
                        break;
                }
                Console.WriteLine();
            } while (!poprawny_kolor_wina);

            return kolor_wina;
        }

        private static string Waga_wina()
        {
            string waga_wina;
            bool poprawna_waga_wina = false;
            do
            {
                Console.WriteLine("Preferujesz wino lekkie, średnie czy ciężkie?");
                waga_wina = Console.ReadLine();
                waga_wina = waga_wina.ToLower();
                switch (waga_wina)
                {
                    case "lekkie":
                        poprawna_waga_wina = true;
                        break;
                    case "średnie":
                        poprawna_waga_wina = true;
                        break;
                    case "ciężkie":
                        poprawna_waga_wina = true;
                        break;
                    default:
                        poprawna_waga_wina = false;
                        Console.WriteLine("Wybrałeś niepoprawnie, spróbuj jeszcze raz.");
                        break;
                }
                Console.WriteLine();
            } while (!poprawna_waga_wina);

            return waga_wina;
        }

        private static string Smak_potrawy()
        {
            string smak_potrawy;
            bool poprawny_smak_potrawy = false;
            do
            {
                Console.WriteLine("Czy smak potrawy jest delikatny, średni czy mocny?");
                smak_potrawy = Console.ReadLine();
                smak_potrawy = smak_potrawy.ToLower();
                switch (smak_potrawy)
                {
                    case "delikatny":
                        poprawny_smak_potrawy = true;
                        break;
                    case "średni":
                        poprawny_smak_potrawy = true;
                        break;
                    case "mocny":
                        poprawny_smak_potrawy = true;
                        break;
                    default:
                        poprawny_smak_potrawy = false;
                        Console.WriteLine("Wybrałeś niepoprawnie, spróbuj jeszcze raz.");
                        break;
                }
                Console.WriteLine();
            } while (!poprawny_smak_potrawy);

            return smak_potrawy;
        }

        private static bool Czy_ma_sos()
        {
            bool poprawny_sos = false;
            bool czy_ma_sos = false;
            do
            {
                Console.WriteLine("Czy potrawa ma sos?");
                string s = Console.ReadLine();
                s = s.ToLower();
                switch (s)
                {
                    case "tak":
                        czy_ma_sos = true;
                        poprawny_sos = true;
                        break;
                    case "nie":
                        czy_ma_sos = false;
                        poprawny_sos = true;
                        break;
                    default:
                        poprawny_sos = false;
                        Console.WriteLine("Wybrałeś niepoprawnie, spróbuj jeszcze raz.");
                        break;
                }
                Console.WriteLine();
            } while (!poprawny_sos);

            return czy_ma_sos;
        }

        private static string Smak_sosu()
        {
            bool poprawny_smak_sosu = false;
            string smak_sosu;
            do
            {
                Console.WriteLine("Czy sos do potrawy jest ostry, słodki, śmietanowy czy pomidorowy?");
                smak_sosu = Console.ReadLine();
                smak_sosu = smak_sosu.ToLower();
                switch (smak_sosu)
                {
                    case "ostry":
                        poprawny_smak_sosu = true;
                        break;
                    case "słodki":
                        poprawny_smak_sosu = true;
                        break;
                    case "śmietanowy":
                        poprawny_smak_sosu = true;
                        break;
                    case "pomidorowy":
                        poprawny_smak_sosu = true;
                        break;
                    default:
                        poprawny_smak_sosu = false;
                        Console.WriteLine("Wybrałeś niepoprawnie, spróbuj jeszcze raz.");
                        break;
                }
                Console.WriteLine();
            } while (!poprawny_smak_sosu);

            return smak_sosu;
        }

        private static string Glowny_skladnik_dania()
        {
            bool poprawny_glowny_skladnik = false;
            string glowny_skladnik_dania;
            do
            {
                Console.WriteLine("Głównym składnikiem jest mięso, ryba czy drób?");
                glowny_skladnik_dania = Console.ReadLine();
                glowny_skladnik_dania = glowny_skladnik_dania.ToLower();
                switch (glowny_skladnik_dania)
                {
                    case "mięso":
                        poprawny_glowny_skladnik = true;
                        break;
                    case "ryba":
                        poprawny_glowny_skladnik = true;
                        break;
                    case "drób":
                        poprawny_glowny_skladnik = true;
                        break;
                    default:
                        poprawny_glowny_skladnik = false;
                        Console.WriteLine("Wybrałeś niepoprawnie, spróbuj jeszcze raz.");
                        break;
                }
                Console.WriteLine();
            } while (!poprawny_glowny_skladnik);

            return glowny_skladnik_dania;
        }

        private static bool Czy_ma_indyka()
        {
            bool poprawna_odpowiedz = false;
            bool czy_ma_indyka = false;
            do
            {
                Console.WriteLine("Czy w potrawie jest indyk?");
                string s = Console.ReadLine();
                s = s.ToLower();
                switch (s)
                {
                    case "tak":
                        czy_ma_indyka = true;
                        poprawna_odpowiedz = true;
                        break;
                    case "nie":
                        czy_ma_indyka = false;
                        poprawna_odpowiedz = true;
                        break;
                    default:
                        poprawna_odpowiedz = false;
                        Console.WriteLine("Wybrałeś niepoprawnie, spróbuj jeszcze raz.");
                        break;
                }
                Console.WriteLine();
            } while (!poprawna_odpowiedz);

            return czy_ma_indyka;
        }
    }
}

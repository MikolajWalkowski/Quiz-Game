using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;
using System.Threading;
using System.Runtime.InteropServices;

namespace Quiz_Game
{
    internal class Program
    {
        public const string PYTANIA_NAUKA = "Pyt_nauka.txt";
        public const string PYTANIA_PROGRAM = "Pyt_program.txt";
        public const string PYTANIA_MUZYKA = "Pyt_muzyka.txt";
        public const string PLIKWYNIKI_NAUKA = "Wyniki_nauka.txt";
        public const string PLIKWYNIKI_PROGRAM = "Wyniki_program.txt";
        public const string PLIKWYNIKI_MUZYKA = "Wyniki_muzyka.txt";

        public static int Wprowadzint()
        {
            while (true)
            {

                string value = Console.ReadLine();
                int a;
                if (int.TryParse(value, out a))
                {
                    return a;
                }
                else
                {
                    Console.WriteLine("Podano złą wartość.");
                }
            }
        }

        public static void Menu()
        {

            bool CzyKoniec = false;
            while (CzyKoniec == false)
            {
                Console.Clear();
                Console.WriteLine("Witaj w Quiz Game!");
                Console.WriteLine();
                Console.WriteLine("1 - Rozpocznij Grę.");
                Console.WriteLine("2 - Pokaż wyniki.");
                Console.WriteLine("3 - Opcje.");
                Console.WriteLine("Esc - Zakończ program.");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Wyborkategorii();
                        break;

                    case ConsoleKey.D2:
                        PokazWyniki();
                        break;

                    case ConsoleKey.D3:
                        MenuOpcje();
                        break;

                    case ConsoleKey.Escape:
                        CzyKoniec = true;
                        break;

                }
            }

        }

        public static void PokazWyniki()
        {
            Console.Clear();
            Console.WriteLine("Dla jakiej kategorii?");
            Console.WriteLine("1 - Nauka i Wiedza ogólna");
            Console.WriteLine("2 - Technologia i Gry");
            //Console.WriteLine("3 - Muzyka.");
            Console.WriteLine("Esc - Cofnij.");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    WyswietlWynik(PLIKWYNIKI_NAUKA);
                    break;

                case ConsoleKey.D2:
                    WyswietlWynik(PLIKWYNIKI_PROGRAM);
                    break;

                // case ConsoleKey.D3:
                // WyswietlWynik(PLIKWYNIKI_MUZYKA);
                //break;  

                case ConsoleKey.Escape:
                    return;
            }
        }

        public static void WyswietlWynik(string NazwaPilku)
        {
                Console.WriteLine("".PadLeft(40, '='));
                using (StreamReader plik = new StreamReader(NazwaPilku))
                {
                    int a = 0;
                    string[] wyniki = new string[a];

                    while (plik.EndOfStream == false)
                    {
                        var linia = plik.ReadLine();
                        wyniki = linia.Split(';');
                        a++;

                        for (int i = 0; i < wyniki.Length; i++)
                        {
                            Console.WriteLine(wyniki[i]);
                        }
                    }
                    Console.Write("Enter, aby kontynuować ");
                    Console.ReadLine();
                }
            
        }

        public static void MenuOpcje()
        {
            Console.Clear();
            Console.WriteLine("1 - Dodaj Pytanie.");
            Console.WriteLine("Esc - Powrót.");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    MenuPytania();
                    break;

                case ConsoleKey.Escape:
                    return;


            }
        }

        public static void MenuPytania()
        {
            Console.Clear();
            Console.WriteLine("Dla jakiej kategorii?");
            Console.WriteLine("1 - Nauka i wiedza ogólna.");
            Console.WriteLine("2 - Technologia i gry.");
            Console.WriteLine("Esc - Powrót."); 

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    DodajPytanie(PYTANIA_NAUKA);
                    break;

                case ConsoleKey.D2:
                    DodajPytanie(PYTANIA_PROGRAM);
                    break;

                case ConsoleKey.Escape:
                    return;


            }
        }

        public static void DodajPytanie(string NazwaPliku)
        {
                Console.Clear();
                Console.Write("Podaj pytanie: ");
                string Pytanie = Console.ReadLine();
                Console.Write("Podaj możliwą odpowiedź 1): ");
                string Odpowiedz1 = Console.ReadLine();
                Console.Write("Podaj możliwą odpowiedź 2): ");
                string Odpowiedz2 = Console.ReadLine();
                Console.Write("Podaj możliwą odpowiedź 3): ");
                string Odpowiedz3 = Console.ReadLine();
                Console.Write("Podaj prawidłową odpowiedź: ");
                string OdpowiedzPrawidlowa = Console.ReadLine();

                using (StreamWriter plik = File.AppendText(NazwaPliku))
                {
                    plik.WriteLine(Pytanie + ";" + Odpowiedz1 + ";" + Odpowiedz2 + ";" + Odpowiedz3 + ";" + OdpowiedzPrawidlowa + ";");
                }
        }

        public static void Wyborkategorii()
        {
            Console.Clear();
            Console.WriteLine("Wybierz kategorię pytań:");
            Console.WriteLine("1 - Nauka i Wiedza ogólna");
            Console.WriteLine("2 - Technologia i Gry");
            // Console.WriteLine("3 - Muzyka");
            Console.WriteLine("0 - Zakończ program.");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:

                    ZapisPytania(PYTANIA_NAUKA, PLIKWYNIKI_NAUKA);

                    break;

                case ConsoleKey.D2:

                    ZapisPytania(PYTANIA_PROGRAM, PLIKWYNIKI_PROGRAM);

                    break;

                // case ConsoleKey.D3:

                // ZapisPytania(PYTANIA_MUZYKA, PLIKWYNIKI_MUZYKA);

                //  break;

                case ConsoleKey.Escape:
                    return;
            }
        }

        public static void LicznikCzasu()
        {
            for(int i =3; i>0; i--)
            {
                Console.Clear();
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }        
        }
        public static void Podsumowanie(int wynik, string PLIKWYNIKI)
        {
                Console.WriteLine();
                Console.WriteLine("Wynik twojego podejścia to: " + wynik);
                Console.Write("Podaj swój Nick: ");
                string name = Console.ReadLine();
                string data = DateTime.Now.ToString();
                using (StreamWriter plik = File.AppendText(PLIKWYNIKI))
                {
                    plik.WriteLine(name + " " + wynik + " " + data + ";");

                }
        }

        static void ZapisPytania(string nazwapliku, string Plik_wyniki)
        {
                LicznikCzasu();
                Console.Clear();

                using (StreamReader plik = new StreamReader(nazwapliku))
                {
                    int a = 0;
                    string[] Pytanie = new string[a];
                    Random random = new Random();

                    while (plik.EndOfStream == false)
                    {

                        var linia = plik.ReadLine();
                        Pytanie = linia.Split(';');
                        a++;
                    }

                    int score = 0;
                    int flaga = 1;

                    do // Pętla wyświetlająca pytanie z możliwymi odpowiedzi
                    {
                        int q = (random.Next(Pytanie.Length));
                        int i = q - q % 5;
                        for (int j = i; j < i + 4; j++)
                        {
                            Console.WriteLine(Pytanie[j]);
                        }
                        string odp = Console.ReadLine();
                        if (odp == Pytanie[i + 4])
                        {
                            Console.WriteLine();
                            Console.WriteLine("Odpowiedź prawidłowa!");
                            score++;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Błędna odpowiedź :(.");
                        }



                        Console.WriteLine();
                        Console.WriteLine("Twój wynik to: " + score);
                        Console.WriteLine("".PadLeft(40, '='));
                        flaga++;

                    } while (flaga < 6);
                    Podsumowanie(score, Plik_wyniki);
                }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}

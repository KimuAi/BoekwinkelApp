using System;
using BoekwinkelApp.Models;

namespace BoekwinkelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var boek1 = new Boek("123", "boek1", "TechPub", 25);
            var boek2 = new Boek("456", "boek2", "TechPub", 30);
            var tijdschrift1 = new Tijdschrift("789", "tijdschrift1", "MagPub", 10, Verschijningsperiode.Wekelijks);
            var tijdschrift2 = new Tijdschrift("101", "tijdschrift2", "NewsPub", 8, Verschijningsperiode.Dagelijks);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Boekwinkel Menu ---");
                Console.WriteLine("1. Boeken bekijken");
                Console.WriteLine("2. Tijdschriften bekijken");
                Console.WriteLine("3. Bestellen");
                Console.WriteLine("4. Exit");
                Console.Write("Kies een optie: ");
                string keuze = Console.ReadLine() ?? "";

                switch (keuze)
                {
                    case "1":
                        Console.WriteLine($"{boek1}\n{boek2}");
                        break;
                    case "2":
                        Console.WriteLine($"{tijdschrift1}\n{tijdschrift2}");
                        break;
                    case "3":
                        Console.WriteLine("Wat wil je bestellen? (1=boek1, 2=boek2, 3=tijdschrift1, 4=tijdschrift2)");
                        int itemKeuze = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("Aantal: ");
                        int aantal = int.Parse(Console.ReadLine() ?? "1");

                        switch (itemKeuze)
                        {
                            case 1:
                                PlaatsBestelling(boek1, aantal);
                                break;
                            case 2:
                                PlaatsBestelling(boek2, aantal);
                                break;
                            case 3:
                                PlaatsBestelling(tijdschrift1, aantal, tijdschrift1.Periode);
                                break;
                            case 4:
                                PlaatsBestelling(tijdschrift2, aantal, tijdschrift2.Periode);
                                break;
                        }
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ongeldige optie.");
                        break;
                }
            }
        }

        static void PlaatsBestelling<T>(T item, int aantal, Verschijningsperiode? periode = null) where T : Boek
        {
            var bestelling = new Bestelling<T>(item, aantal, periode);
            bestelling.BestellingPlaatsing += Console.WriteLine;
            var result = bestelling.Bestel();
            Console.WriteLine($"Besteld: ISBN={result.Item1}, Aantal={result.Item2}, Totaal=€{result.Item3}");
        }
    }
}

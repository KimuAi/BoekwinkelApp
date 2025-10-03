using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoekwinkelApp.Models
{
    public class Boek
    {
        public string Isbn { get; set; }
        public string Naam { get; set; }
        public string Uitgever { get; set; }

        private decimal prijs;
        public decimal Prijs
        {
            get => prijs;
            set
            {
                if (value < 5) prijs = 5;
                else if (value > 50) prijs = 50;
                else prijs = value;
            }
        }

        public Boek(string isbn, string naam, string uitgever, decimal prijs)
        {
            Isbn = isbn;
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs; 
        }

        
        public virtual void Lees()
        {
            Console.Write("ISBN: "); Isbn = Console.ReadLine();
            Console.Write("Naam: "); Naam = Console.ReadLine();
            Console.Write("Uitgever: "); Uitgever = Console.ReadLine();

            bool geldig = false;
            while (!geldig)
            {
                Console.Write("Prijs: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal p))
                {
                    Prijs = p; 
                    geldig = true;
                }
                else
                {
                    Console.WriteLine("Ongeldige invoer. Probeer opnieuw.");
                }
            }
        }

        public override string ToString()
        {
            return $"{Naam} ({Isbn}) - {Uitgever} - {Prijs:C}";
        }
    }
}

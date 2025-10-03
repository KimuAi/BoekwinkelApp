using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekwinkelApp.Models
{
    public class Bestelling<T> where T : Boek
    {
        private static int teller = 1;

        public int Id { get; private set; }
        public T Item { get; set; }
        public int Aantal { get; set; }
        public DateTime Datum { get; private set; }
        public Verschijningsperiode? Periode { get; set; } 

       
        public event Action<string>? BestellingPlaatsing;

        public Bestelling(T item, int aantal, Verschijningsperiode? periode = null)
        {
            Id = teller++;
            Item = item;
            Aantal = aantal;
            Periode = periode;
            Datum = DateTime.Now;
        }

        
        public Tuple<string, int, decimal> Bestel()
        {
            BestellingPlaatsing?.Invoke($"Bestelling {Id} geplaatst: {Aantal}x {Item.Naam}");

            decimal totaal = Item.Prijs * Aantal; 
            return Tuple.Create(Item.Isbn, Aantal, totaal);
        }
    }
}

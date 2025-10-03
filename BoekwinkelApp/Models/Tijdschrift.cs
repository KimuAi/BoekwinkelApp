using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoekwinkelApp.Models
{

    public enum Verschijningsperiode
    {
        Dagelijks,
        Wekelijks,
        Maandelijks
    }

    public class Tijdschrift : Boek
    {
        public Verschijningsperiode Periode { get; set; }

        public Tijdschrift(string isbn, string naam, string uitgever, decimal prijs, Verschijningsperiode periode)
            : base(isbn, naam, uitgever, prijs)
        {
            Periode = periode;
        }

        public override void Lees()
        {
            base.Lees();
            Console.WriteLine("Periode (Dagelijks/Wekelijks/Maandelijks): ");
            Periode = Enum.Parse<Verschijningsperiode>(Console.ReadLine(), true);
        }

        public override string ToString()
        {
            return base.ToString() + $" - {Periode}";
        }
    }
}


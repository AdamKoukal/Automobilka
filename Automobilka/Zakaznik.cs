using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Automobilka
{
    internal class Zakaznik
    {
        public int ID;
        public string Jmeno;
        public string Prijmeni;
        public DateOnly Datum; // 18 let
        public int Kontakt;
        public string RPrukaz;

        //konstruktor
        public Zakaznik(int id, string jmeno,string prijmeni, DateOnly datum, int kontakt,string rPrukaz)
        {
            ID = id;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Datum = datum;
            Kontakt = kontakt;
            RPrukaz = rPrukaz;

        }
        public void Vypis() // Vypsání všech ůdajů zákazníka
        {
            Console.WriteLine("ID: "+ID);
            Console.WriteLine("Jmeno: "+Jmeno);
            Console.WriteLine("Prijmeni: "+Prijmeni);
            Console.WriteLine("Datum narození: "+Datum);
            Console.WriteLine("Kontakt: "+Kontakt);
            Console.WriteLine("Řidičský průkaz: "+RPrukaz);
            Console.WriteLine();

        }

    }
}

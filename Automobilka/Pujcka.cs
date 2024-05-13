using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobilka
{
    internal class Pujcka
    {
        public string Jmeno;
        public DateOnly Vraceni;
        public Zakaznik Zakaznik;
        public Auto Auto;
        public Pujcka(DateOnly vraceni, Zakaznik zakaznik, Auto auto, string jmeno)
        {
            Vraceni = vraceni;
            Zakaznik = zakaznik;
            Auto = auto;
            Jmeno = jmeno;
        }
        public void Vypis() // Vypsání všech údajů půjčky
        {
            Console.WriteLine("Jméno: " + Jmeno);
            Console.WriteLine("Datum vrácení: " + Vraceni);
            Console.WriteLine("Držtel půjčky");
            Console.WriteLine();
            Zakaznik.Vypis();
            Console.WriteLine();
            Console.WriteLine("Auto k zapůjčení: ");
            Console.WriteLine();
            Auto.Vypis();
        }
        
    }
}

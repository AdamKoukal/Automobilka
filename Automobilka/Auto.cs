using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobilka
{
    internal class Auto
    {

        public string SPZ;
        public string Vyrobce;
        public string Model;
        public DateOnly RokVyroby;
        public int Cena;
        public int Dostupnost;
        public int Km;
        public int Mista;

        public Auto(string spz, string vyrobce, string model, DateOnly rokVyroby, int cena, int dostupnost, int km, int mista)
        {
            SPZ = spz;
            Vyrobce = vyrobce;
            Model = model;
            RokVyroby = rokVyroby;
            Cena = cena;
            Dostupnost = dostupnost;
            Km = km;
            Mista = mista;
        }
        public void Vypis() // Vypsání všech ůdajů auta
        {
            Console.WriteLine("SPZ: " + SPZ);
            Console.WriteLine("Vyrobce: " + Vyrobce);
            Console.WriteLine("Model: " + Model);
            Console.WriteLine("Rok Výroby: " + RokVyroby);
            Console.WriteLine("Cena: " + Cena);
            Console.WriteLine("Dostupnost: " + Dostupnost);
            Console.WriteLine("Počet najetých km: " + Km);
            Console.WriteLine("Počet míst: " + Mista);
            Console.WriteLine();
        }



    }
}

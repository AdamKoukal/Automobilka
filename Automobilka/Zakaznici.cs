using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Automobilka
{
    internal class Zakaznici
    {
        public List<Zakaznik> zakaznici;

        public Zakaznici()
        {
            zakaznici = new List<Zakaznik>();
        }
        public void Přidaní()
        {
            Console.WriteLine("Přidávání zákazníka");
            Console.WriteLine();
            Console.WriteLine("ID:");
            int id = 0;
            bool DifID = false;
            while (DifID == false)
            {
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Špatné zadání");
                }
                if (zakaznici.Count > 0)
                {
                    for (int i = 0; i < zakaznici.Count; i++)
                    {

                        if (zakaznici[i].ID == id)
                        {
                            
                            DifID = false;
                            break;

                        }
                        else
                        {
                            DifID = true;
                        }


                    }
                    if (DifID == false)
                    {
                        Console.WriteLine("Špatné zadání");
                    }
                }
                else
                {
                    DifID = true;
                }
                


            }
            
            Console.WriteLine("Jméno:");
            string jmeno = Console.ReadLine();
            Console.WriteLine("Příjmení:");
            string prijmeni = Console.ReadLine();
            Console.WriteLine("Datum narození:");
            DateOnly datum = DateOnly.Parse("31.12.9999");


            bool Narozeni = false;
            while (Narozeni == false)
            {
                while ((!DateOnly.TryParse(Console.ReadLine(), out datum)))
                {
                    Console.WriteLine("Špatné zadání");
                }
                if (DateTime.Now.Year - datum.Year > 18)
                {
                    Narozeni = true;
                }

                else if (DateTime.Now.Year - datum.Year == 18)
                {
                    if (datum.Month <= DateTime.Now.Month)
                    {
                        if (datum.Day <= DateTime.Now.Day)
                        {
                            Narozeni = true;
                        }
                        else
                        {
                            Console.WriteLine("Zákazníkovi není 18 let.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Zákazníkovi není 18 let.");
                    }
                }
                else
                {
                    Console.WriteLine("Zákazníkovi není 18 let.");
                }


            }
            int kontakt;
            Console.WriteLine("Kontakt:");
            while (!int.TryParse(Console.ReadLine(), out kontakt))
            {
                Console.WriteLine("Špatné zadání");
            }
            string rPrukaz = "";
            Console.WriteLine("Řidičský průkaz (A,B,C,D,T):");
            bool PrukazCheck = true;
            while(PrukazCheck==true)
            {
                rPrukaz = Console.ReadLine();
                if(rPrukaz.ToLower() == "a" || rPrukaz.ToLower() == "b" ||
                rPrukaz.ToLower() == "c" || rPrukaz.ToLower() == "d"
                || rPrukaz.ToLower() == "t")
                {
                    PrukazCheck = false;
                }
                else
                {
                    Console.WriteLine("Špatné zadání");
                }
            }

            Zakaznik zakaznik = new Zakaznik(id, jmeno, prijmeni, datum, kontakt,rPrukaz);
            zakaznici.Add(zakaznik);

        }// Možnost přidání zákazníka
        public void Odstraneni() // Možnost odstranění zákazníka
        {
            Console.WriteLine("Odstranění zákazníka");
            Console.WriteLine();
            Vypis();
            Console.WriteLine("Zadejte číslo zákazníka, kterého chcete odstranit");
            int Remove = 0;
            bool RealID = false;
            while (RealID == false)
            {
                int input = 0;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Špatné zadání");
                }
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    if (input == zakaznici[i].ID)
                    {
                        Remove = i;
                        RealID = true;
                    }
                }

                if (RealID == false)
                {
                    Console.WriteLine("Špatné zadání");
                }

            }
            zakaznici.RemoveAt(Remove);


        }
        public void ZmenaUdaju() // Možnost změnění údajů zákazníka
        {
            Console.WriteLine("Změna údajů zakazníka");
            Console.WriteLine();
            Vypis();
            Console.WriteLine("Zadejte ID zákazníka, kterého chcete odstranit");
            int input = 0;
            int Zmena = 0;
            bool RealID = false;
            while (RealID == false)
            {
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Špatné zadání");
                }
                for (int i = 0; i < zakaznici.Count; i++)
                {
                    if (input == zakaznici[i].ID)
                    {
                        Zmena = i;
                        RealID = true;
                        

                    }


                }

                if (RealID == false)
                {
                    Console.WriteLine("Špatné zadání");
                }

            }











            Console.WriteLine("Aktuání ID zákazníka je " + zakaznici[Zmena].ID + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                int id = int.Parse(Console.ReadLine());
                zakaznici[Zmena].ID = id;
            }
            Console.WriteLine("Aktuání jméno zákazníka je " + zakaznici[Zmena].Jmeno + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                string jmeno = Console.ReadLine();
                zakaznici[Zmena].Jmeno = jmeno;
            }
            Console.WriteLine("Aktuání příjmení zákazníka je " + zakaznici[Zmena].Prijmeni + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                string prijmeni = Console.ReadLine();
                zakaznici[Zmena].Prijmeni = prijmeni;
            }
            Console.WriteLine("Aktuání datum narození zákazníka je " + zakaznici[Zmena].Datum + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                DateOnly datum = DateOnly.Parse(Console.ReadLine());
                zakaznici[Zmena].Datum = datum;
            }
            Console.WriteLine("Aktuání kontakt na zákazníka je " + zakaznici[Zmena].Kontakt + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                int kontakt = int.Parse(Console.ReadLine());
                zakaznici[Zmena].Kontakt = kontakt;
            }



        }
        public void Vypis() // Vypsání všech zákazníků a jejich údajů
        {
            foreach(Zakaznik zakaznik in zakaznici)
            {
                zakaznik.Vypis();
            }

        }
        public void Uložení(string adresa) // Uloží všechny zákazníků do předem vytvořeného souboru
        {
            using (StreamWriter wr = new StreamWriter(adresa))
            {
                foreach (Zakaznik zakaznik in zakaznici)
                {
                    wr.WriteLine(zakaznik.ID+"|"+ zakaznik.Jmeno + "|"+ zakaznik.Prijmeni + "|"+ zakaznik.Datum + "|"+
                    zakaznik.Kontakt + "|"+ zakaznik.RPrukaz + "|");
                }
            }
            
        }
        public void Načtení(string adresa) // Načte všechny zákazníky z předem vytvořeného souboru
        {

            if (File.Exists(adresa))
            {
                zakaznici.Clear();
                using (StreamReader reader = new StreamReader(adresa))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 7)
                        {
                            int id = int.Parse(parts[0]);
                            string jmeno = parts[1];
                            string prijmeni = parts[2];
                            DateOnly datum = DateOnly.Parse(parts[3]);
                            int kontakt = int.Parse(parts[4]);
                            string rPrukaz = parts[5];
                            Zakaznik zakaznik = new Zakaznik(id,jmeno,prijmeni,datum,kontakt,rPrukaz);
                            zakaznici.Add(zakaznik);
                        }
                    }
                }
                Console.WriteLine("Zakaznici byli úspěšně načteni ze souboru.");

            }
            else
            {
                Console.WriteLine("Nepodařila se nahrát záloha.");
            }

        }
        

    }
}

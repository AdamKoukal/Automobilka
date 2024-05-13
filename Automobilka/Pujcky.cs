using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Automobilka
{
    internal class Pujcky
    {

        private List<Pujcka> pujcky;
        public Auta auta;
        public Zakaznici zakaznici;


        public Pujcky()
        {
            pujcky = new List<Pujcka>();
            
        }
        public void Přidání()
        {


            Console.WriteLine("Přídávání půjčky");
            Console.WriteLine();
            Console.WriteLine("Jmeno půjčky");
            string jmeno = Console.ReadLine();




            Console.WriteLine("Auto k půjčení (SPZ)");
            Console.WriteLine();
            auta.Vypis(2);
            string spz = "";
            int input = 0;
            bool RealSPZ = false;
            

            while (RealSPZ == false)
            {
                spz = Console.ReadLine().ToUpper();
                for (int i = 0; i < auta.auta.Count; i++)
                {
                    if (spz == auta.auta[i].SPZ && auta.auta[i].Dostupnost == 1)
                    {
                        input = i;
                        RealSPZ = true;
                    }


                }
                if (RealSPZ == false)
                {
                    Console.WriteLine("Špatné zadání");
                }

            }
            


            Auto auto = auta.auta[input];
            auto.Dostupnost=0;


            Console.WriteLine();
            Console.WriteLine("Půjčovatel (ID)");
            Console.WriteLine();
            zakaznici.Vypis();
            bool Opravneni = false;
            int input2 = 0;
            bool RealID = false;
            int id = 0;
            while (RealID==false||Opravneni==false)
            {
                while(!int.TryParse(Console.ReadLine(),out id))
                {
                    Console.WriteLine("Špatné zadání");
                }
                for (int i = 0; i < zakaznici.zakaznici.Count; i++)
                {
                    if (id == zakaznici.zakaznici[i].ID)
                    {
                        input2 = i;
                        RealID = true;
                        if (zakaznici.zakaznici[input2].RPrukaz == "a")
                        {
                            Console.WriteLine("Půjčovatel nemá oprávnění řídit toto vozidlo.");

                            Console.WriteLine("Zadejte znovu ID půjčovatele: ");

                        }
                        else 
                        {
                            Opravneni = true;
                        }
                        
                    }


                }

                if (RealID == false||Opravneni==false)
                {
                    Console.WriteLine("Špatné zadání");
                }

            }
            
            Zakaznik zakaznik = zakaznici.zakaznici[input2];
            Console.WriteLine();
            Console.WriteLine("Datum vrácení auta");
            Console.WriteLine();
            DateOnly datum = DateOnly.Parse("31.12.9999");
            while(!DateOnly.TryParse(Console.ReadLine(), out datum))
            {
                Console.WriteLine("Špatné zadání");
            }
            Pujcka pujcka = new Pujcka(datum, zakaznik, auto, jmeno);
            pujcky.Add(pujcka);
        }// Přidaní půjčky
        public void Odstranění() // Odstranění půjčky
        {
            Console.WriteLine("Odstranění půjčky");
            Console.WriteLine();
            Vypis();
            int Remove = 0;
            bool RealJmeno = false;
            string input = "";
            while (RealJmeno == false)
            {
                Console.WriteLine("Zadejte jméno půjčky, kterou chcete odstranit");
                input = Console.ReadLine();
                for (int i = 0; i < pujcky.Count; i++)
                {
                    if (input == pujcky[i].Jmeno)
                    {
                        Remove = i;
                        RealJmeno = true;
                    }
                }

                if (RealJmeno == false)
                {
                    Console.WriteLine("Špatné zadání");
                }

            }
            pujcky[Remove].Auto.Dostupnost = 1;
            pujcky.RemoveAt(Remove);
            
        }
        public void ZměnaÚdajů() // Změna údajů půjčky
        {
            Console.WriteLine("Změna údajů půjček");
            Console.WriteLine();
            Vypis();


            int Zmena = 0;
            bool RealJmeno = false;
            while (RealJmeno == false)
            {
                Console.WriteLine("Zadejte jméno půjčky, které chcete změnit údaje");
                string input = Console.ReadLine().ToUpper();
                for (int i = 0; i < pujcky.Count; i++)
                {
                    if (input == pujcky[i].Jmeno)
                    {
                        Zmena = i;
                        RealJmeno = true;
                    }
                }

                if (RealJmeno == false)
                {
                    Console.WriteLine("Špatné zadání");
                }

            }

            Console.WriteLine("Aktuání jméno půjčky je " + pujcky[Zmena].Jmeno + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno půjčky.");
                string Jmeno = Console.ReadLine();
                pujcky[Zmena].Jmeno = Jmeno;
            }

            Console.WriteLine("Aktuální půjčené auto je ");
            Console.WriteLine();
            pujcky[Zmena].Auto.Vypis();
            Console.WriteLine("Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte SPZ nového auta.");
                auta.Vypis(2);
                string spz = Console.ReadLine();
                pujcky[Zmena].Auto = auta.auta[Input(spz)];
            }
            Console.WriteLine("Aktuální půjčovatel je ");
            pujcky[Zmena].Zakaznik.Vypis();
            Console.WriteLine("Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte ID nového jméno zákazníka.");
                int ID = int.Parse(Console.ReadLine());
                pujcky[Zmena].Zakaznik = zakaznici.zakaznici[Input2(ID)];
            }
            Console.WriteLine("Aktuání datum ukončení půjčky je " + pujcky[Zmena].Vraceni + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové datum ukončení půjčky.");
                DateOnly vraceni = DateOnly.Parse(Console.ReadLine());
                pujcky[Zmena].Vraceni = vraceni;
            }


        }
        public void Vypis()
        {
            Console.WriteLine("Seznam půjček");
            Console.WriteLine();
            foreach(Pujcka pujcka in pujcky)
            {
                pujcka.Vypis();
            }

        } // Vypsání všech půjček a jejich údajů
        public void Uložení(string adresa) // Uloží všechny půjčky do předem vytvořeného souboru
        {
            using (StreamWriter wr = new StreamWriter(adresa))
            {
                foreach (Pujcka pujcka in pujcky)
                {
                    wr.WriteLine(pujcka.Jmeno+"|"+pujcka.Vraceni+"|"+ Input2(pujcka.Zakaznik.ID) + "|"+ Input(pujcka.Auto.SPZ) + "|");
                    
                }
                
            }
        }
        public void Načtení(string adresa) // Načte všechny půjčky z předem vytvořeného souboru
        {

            if (File.Exists(adresa))
            {
                pujcky.Clear();
                using (StreamReader reader = new StreamReader(adresa))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        
                        if (parts.Length == 5)
                        {
                            string jmeno = parts[0];
                            DateOnly vraceni = DateOnly.Parse(parts[1]);
                            int ZakaznikPoradi = int.Parse(parts[2]);
                            int AutoPoradi = int.Parse(parts[3]);
                            Zakaznik zakaznik = zakaznici.zakaznici[ZakaznikPoradi];
                            Auto auto = auta.auta[AutoPoradi];
                            Pujcka pujcka = new Pujcka(vraceni, zakaznik, auto,jmeno);
                            pujcky.Add(pujcka);

                        }
                    }
                }
                
                Console.WriteLine("Pujcky byly úspěšně načteny ze souboru");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nepodařila se nahrát záloha.");
            }

        }
        public int Input(string spz)
        {
            int input = 0;
                
            for (int i = 0; i < auta.auta.Count; i++)
            {
                if (spz == auta.auta[i].SPZ)
                {
                    input = i;
                }
            }
            
            return (input);
        } // Vratí na jakém místě v listu je auto s konkrétní SPZ
        public int Input2(int id)
        {
            int input2 = 0;
            for (int i = 0; i < zakaznici.zakaznici.Count; i++)
            {
                if (id == zakaznici.zakaznici[i].ID)
                {
                    input2 = i;

                }


            }
            return (input2);
        } // Vratí na jakém místě v listu je zákazník s konkrétním ID

    }
}   

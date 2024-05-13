using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Automobilka
{
    internal class Auta
    {
        public List<Auto> auta;

        public Auta()
        {
            auta = new List<Auto>();
        }
        public void Přidaní() // Přidání auta do seznamu aut k půjčení
        {
            
            Console.WriteLine("Přidávání Auta");
            Console.WriteLine();
            Console.WriteLine("SPZ:");
            string SPZ = "";
            bool cislo = false;
            bool bpismena = false;
            bool DifSPZ = false;
            string cisla = "0123456789";
            string pismena = "GOQW";
            while (SPZ.Length<7||SPZ.Length>8||cislo==false||bpismena==false||DifSPZ==false) //Ošetření délky SPZ, aby splňovala normu. Aspoň jedno číslo a aby neobsahovala G, O, Q nebo W.
            {
                SPZ = Console.ReadLine().ToUpper();

                for (int i = 0; i < SPZ.Length; i++)
                {
                    for(int j = 0; j < cisla.Length; j++)
                    {
                        if (SPZ[i] == cisla[j])
                        {
                            cislo = true;
                            
                        }
                    }
                }
                bool help = true;
                bpismena = true;
                for (int i = 0; i < SPZ.Length; i++)
                {
                    for (int j = 0; j < pismena.Length; j++)
                    {
                        
                        if (SPZ[i] != pismena[j])
                        {
                            
                            if (SPZ[i] == 'C')
                            {
                                if(SPZ.Length>i+1)
                                {
                                    if (SPZ[i+1] == 'H')
                                    {
                                        bpismena = false;
                                        help = false;
                                    }
                                    else
                                    {
                                        bpismena = true;
                                    }
                                    
                                }
                                
                            }
                            else if(help==true)
                            {
                                bpismena = true;
                            }
                            
                        }
                        else
                        {

                            bpismena = false;
                            help = false;
                        }

                    }
                }
                if (auta.Count > 0)
                {
                    for (int i = 0; i < auta.Count; i++)
                    {
                        if (auta[i].SPZ == SPZ)
                        {
                            DifSPZ = false;
                            break;

                        }
                        else
                        {
                            DifSPZ = true;
                        }
                    }
                }
                else
                {
                    DifSPZ = true;
                }
                if (SPZ.Length < 7 || SPZ.Length > 8 || cislo ==false||bpismena==false||DifSPZ==false)
                {
                    Console.WriteLine("Špatné zadání");
                }

                
            }
            
            
            
            Console.WriteLine("Výrobce:");
            string vyrobce = Console.ReadLine();
            Console.WriteLine("Model:");
            string model = Console.ReadLine();
            Console.WriteLine("Datum výroby:");
            DateOnly rokVyroby;
            while (!DateOnly.TryParse(Console.ReadLine(), out rokVyroby))
            {
                Console.WriteLine("Špatné zadání");
            }
            int cena;
            Console.WriteLine("Cena:");
            while (!int.TryParse(Console.ReadLine(), out cena))
            {
                Console.WriteLine("Špatné zadání");
            }
            int dostupnost;
            Console.WriteLine("Je dostupné? (0-Ne/1-Ano)");
            while (!int.TryParse(Console.ReadLine(), out dostupnost))
            {
                Console.WriteLine("Špatné zadání");
            }
            if (dostupnost > 1)
            {
                dostupnost = 1;
            }
            Console.WriteLine("Najeté Km.");
            int km;
            while (!int.TryParse(Console.ReadLine(), out km))
            {
                Console.WriteLine("Špatné zadání");
            }
            Console.WriteLine("Počet míst.");
            int mista;
            while (!int.TryParse(Console.ReadLine(), out mista))
            {
                Console.WriteLine("Špatné zadání");
            }


            Auto auto = new Auto(SPZ, vyrobce, model, rokVyroby, cena, dostupnost, km, mista);
            auta.Add(auto);

        }
        public void Odstraneni() // Odstranění auta ze seznamu aut k půjčení
        {
            Console.WriteLine("Odstranění auta");
            Console.WriteLine();
            Vypis(1);
            int Remove = 0;
            bool RealSPZ = false;
            while (RealSPZ == false)
            {
                Console.WriteLine("Zadejte SPZ auta, které chcete odstranit");
                string input = Console.ReadLine().ToUpper();
                for (int i = 0; i < auta.Count; i++)
                {
                    if (input == auta[i].SPZ)
                    {
                        Remove = i;
                        RealSPZ = true;
                    }
                }

                if (RealSPZ == false)
                {
                    Console.WriteLine("Špatné zadání");
                }

            }
            auta.RemoveAt(Remove);


        }
        public void ZmenaUdaju() // Změna údajů auta
        {
            Console.WriteLine("Změna údajů auta");
            Console.WriteLine();
            Vypis(1);
            
            
            int Zmena = 0;
            bool RealSPZ = false;
            while (RealSPZ == false)
            {
                Console.WriteLine("Zadejte SPZ auta, kterému chcete změnit údaje");
                string input = Console.ReadLine().ToUpper();
                for (int i = 0; i < auta.Count; i++)
                {
                    if (input == auta[i].SPZ)
                    {
                        Zmena = i;
                        RealSPZ = true;
                    }
                }

                if (RealSPZ == false)
                {
                    Console.WriteLine("Špatné zadání");
                }

            }
            Console.WriteLine("Aktuání SPZ auta je " + auta[Zmena].SPZ + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte novou SPZ Auta.");
                string SPZ = Console.ReadLine();
                auta[Zmena].SPZ = SPZ;
            }
            Console.WriteLine("Aktuání Výrobce auta je " + auta[Zmena].Vyrobce + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                string vyrobce = Console.ReadLine();
                auta[Zmena].Vyrobce = vyrobce;
            }
            Console.WriteLine("Aktuání model auta je " + auta[Zmena].Model + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                string model = Console.ReadLine();
                auta[Zmena].Model = model;
            }
            Console.WriteLine("Aktuání rok výroby auta je " + auta[Zmena].RokVyroby + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                DateOnly rokVyroby = DateOnly.Parse(Console.ReadLine());
                auta[Zmena].RokVyroby = rokVyroby;
            }
            Console.WriteLine("Aktuání cena auta je " + auta[Zmena].Cena + ". Chcete ho změnit? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                int cena = int.Parse(Console.ReadLine());
                auta[Zmena].Cena = cena;
            }
            Console.WriteLine("Aktuání stav dostupnosti auta je " + auta[Zmena].Dostupnost + ". Chcete ho změnit? (Y/N)"); ;
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                int dostupnost = int.Parse(Console.ReadLine());
                auta[Zmena].Dostupnost = dostupnost;
            }
            Console.WriteLine("Aktuání počet najetých km auta je " + auta[Zmena].Km + ". Chcete ho změnit? (Y/N)"); ;
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                int km = int.Parse(Console.ReadLine());
                auta[Zmena].Km = km;
            }
            Console.WriteLine("Aktuání počet míst v autě je " + auta[Zmena].Mista + ". Chcete ho změnit? (Y/N)"); ;
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Console.WriteLine("Zadejte nové jméno zákazníka.");
                int mista = int.Parse(Console.ReadLine());
                auta[Zmena].Mista = mista;
            }



        }
        public void Vypis(int i) // Vypsání všech aut a jejich údajů
        {
            foreach (Auto auto in auta)
            {
                if (i == 1)
                {
                    
                        auto.Vypis();
                    
                }
                else
                {
                    if (auto.Dostupnost == 1)
                    {
                        auto.Vypis();
                    }
                }
                
               
            }
        }
        public void Uložení(string adresa) // Uloží všechny auta do předem vytvořeného souboru
        {
            using (StreamWriter wr = new StreamWriter(adresa))
            {
                foreach (Auto auto in auta)
                {
                    wr.WriteLine(auto.SPZ + "|" + auto.Vyrobce + "|" + auto.Model + "|" + auto.RokVyroby + "|" +
                    auto.Cena + "|" + auto.Dostupnost + "|" + auto.Km + "|" + auto.Mista + "|");
                }
            }

        }
        public void Načtení(string adresa) // Načte všechny auta z předem vytvořeného souboru
        {

            if (File.Exists(adresa))
            {
                auta.Clear();
                using (StreamReader reader = new StreamReader(adresa))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 9)
                        {
                            string spz= parts[0];
                            string vyrobce = parts[1];
                            string model = parts[2];
                            DateOnly rokVyroby = DateOnly.Parse(parts[3]);
                            int cena = int.Parse(parts[4]);
                            int dostupnost = int.Parse(parts[5]);
                            int km = int.Parse(parts[6]);
                            int mista = int.Parse(parts[7]);
                            Auto auto = new Auto(spz,vyrobce,model,rokVyroby,cena,dostupnost,km,mista);
                            auta.Add(auto);
                        }
                    }
                }
                Console.WriteLine("Auta byla úspěšně načtena ze souboru.");

            }
            else
            {
                Console.WriteLine("Nepodařila se nahrát záloha.");
            }

        }

    }
}

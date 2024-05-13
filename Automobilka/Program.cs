using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace Automobilka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zakaznici zakaznici = new Zakaznici();
            Auta auta = new Auta();
            Pujcky pujcky = new Pujcky();
            bool aplikace = true;
            Načtení();
            
            
            if (Directory.Exists("C:\\ProgramData\\Automobilka") == false) // Vytvoření složky pro ukládání souborů, pokud už složka neexistuje
            {
                Directory.CreateDirectory("C:\\ProgramData\\Automobilka");
                File.Create("C:\\ProgramData\\Automobilka\\Auta.txt");
                File.Create("C:\\ProgramData\\Automobilka\\Zakaznici.txt");
                File.Create("C:\\ProgramData\\Automobilka\\Pujcky.txt");
                Console.WriteLine("Prosím restartujte aplikaci");
                aplikace = false;
            }

            while (aplikace==true)
            {
                pujcky.auta = auta;
                pujcky.zakaznici = zakaznici;
                Console.WriteLine(" 1. Přidat auto");
                Console.WriteLine(" 2. Seznam aut");
                Console.WriteLine(" 3. Změna údajů aut");
                Console.WriteLine(" 4. Odstranění aut");
                Console.WriteLine(" 5. Přidat zákazníka");
                Console.WriteLine(" 6. Seznam zákazíků");
                Console.WriteLine(" 7. Změna údajů zákazíků");
                Console.WriteLine(" 8. Odtranění zákazníka");
                Console.WriteLine(" 9. Přidat půjčku");
                Console.WriteLine("10. Seznam půjček");
                Console.WriteLine("11. Změna údajů půjček");
                Console.WriteLine("12. Odstranění půjček");
                
                int input;
                while(!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Špatné zadání");
                }
                if (input == 1)
                {
                    auta.Přidaní();
                }
                else if (input == 2)
                {
                    auta.Vypis(1);
                }
                else if (input == 3)
                {
                    auta.ZmenaUdaju();
                }
                else if (input == 4)
                {
                    auta.Odstraneni();
                }
                else if (input == 5)
                {
                    zakaznici.Přidaní();
                }
                else if (input == 6)
                {
                    zakaznici.Vypis();
                }
                else if (input == 7)
                {
                    zakaznici.ZmenaUdaju();
                }
                else if (input == 8)
                {
                    zakaznici.Odstraneni();
                }
                else if (input == 9)
                {
                    if(DostupnostAuta() == true&& PovoleniZakaznika()==true)
                    {
                        if (zakaznici.zakaznici.Count > 0)
                        {
                            pujcky.Přidání();
                        }
                        
                    }
                    else if(DostupnostAuta() == true && PovoleniZakaznika() == false)
                    {
                        Console.WriteLine("Není dostupný žádný zákazník");
                    }
                    else if(DostupnostAuta() == false && PovoleniZakaznika() == true)
                    {
                        Console.WriteLine("Žadné auto není dostupné");
                    }
                    else
                    {
                        Console.WriteLine("Není dostupný žádný zákazník a ani žádné auto");
                    }
                    
                    
                }
                else if (input == 10)
                {
                    pujcky.Vypis();
                }
                else if (input == 11)
                {
                    pujcky.ZměnaÚdajů();
                }
                else if (input == 12)
                {
                    pujcky.Odstranění();
                }
                Uložení();
                
                
            }
            void Uložení() // Uložení seznamu aut, zákazníků a půjček
            {
                zakaznici.Uložení("C:\\ProgramData\\Automobilka\\Zakaznici.txt");
                auta.Uložení("C:\\ProgramData\\Automobilka\\Auta.txt");
                pujcky.Uložení("C:\\ProgramData\\Automobilka\\Pujcky.txt");
                Console.WriteLine("Data byla úspěšně uložena do souboru.");
            }
            void Načtení() // Načte automaticky z vytvořené šložky uložený seznam aut, zákazníků a půjček
            {
                zakaznici.Načtení("C:\\ProgramData\\Automobilka\\Zakaznici.txt");
                auta.Načtení("C:\\ProgramData\\Automobilka\\Auta.txt");
                pujcky.auta = auta;
                pujcky.zakaznici = zakaznici;
                pujcky.Načtení("C:\\ProgramData\\Automobilka\\Pujcky.txt");
            }
            bool DostupnostAuta() // Zkontroluje jestli je v seznamu aut nějáke auto a jestli je nějáké dostupné
            {
                bool Dostupnost = false;
                int i = 0;
                while (Dostupnost == false&&i<auta.auta.Count)
                {
                    if (auta.auta[i].Dostupnost == 1)
                    {
                        Dostupnost = true;
                    }
                    i++;
                }
                return (Dostupnost);
            }
            bool PovoleniZakaznika() // Zkontroluje jestli je v seznamu zákazníků nějáký zákazník a jestli má některý z nich oprávnění řídit auto
            {
                bool Opravneni = false;
                int i = 0;
                while (Opravneni == false && i < zakaznici.zakaznici.Count)
                {
                    if (zakaznici.zakaznici[i].RPrukaz !="a")
                    {
                        Opravneni = true;
                    }
                    i++;
                }
                return (Opravneni);

            }

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace L0002B_INL_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Rebecka Klausen,rebkla-1, L0002b
            List<sales> salesMen = new List<sales>();

            bool a = true;
            while (a)
            {
                Console.WriteLine("Add=Lägg till ny säljare & Sort=Sortera säljare");
                string commando = Console.ReadLine();
                switch (commando)
                {
                    case "Add": //Användare lägger till uppgifter om säljare i listan 
                        Console.Clear();
                        Console.WriteLine("Namn, personnummer, distrikt & antal sålda produkter");
                        // Här matar användaren in informationen
                        salesMen.Add(new sales()
                        {
                           name = Console.ReadLine(),
                           pnr = Console.ReadLine(),
                           dist = Console.ReadLine(),
                           sold = int.Parse(Console.ReadLine()),
                        }) ;; ;

                        Console.Clear();

                        Console.WriteLine("Säljare tillagd :)");
                        break;
                    
                    case "Sort": //I denna del sorteras säljarna efter hur många produkter som har sålts samt kategoriseras efter vilken försäljningsnivå de ligger på
                        Console.Clear();

                        List<sales> Under50 = salesMen.FindAll(x => x.sold < 50);
                        Console.WriteLine($"{Under50.Count} säljare har nått nivå 1: 50 ");
                        List<sales> Between50_100 = salesMen.FindAll(x => x.sold >= 50 && x.sold <= 99);
                        Console.WriteLine($"{Between50_100.Count} säljare har nått nivå 2: mellan 50 och 100 ");
                        List<sales> Between100_200 = salesMen.FindAll(x => x.sold >= 100 && x.sold <= 199);
                        Console.WriteLine($"{Between100_200.Count} säljare har nått nivå 3: mellan 100 och 200 ");
                        List<sales> Between200_299 = salesMen.FindAll(x => x.sold >= 200);
                        Console.WriteLine($"{Between200_299.Count} säljare har nått nivå 4: över 200");
                        Console.WriteLine("Säljare sorterade efter antal sålda produkter");

                        salesMen.Sort((x, y) => x.sold.CompareTo(y.sold));
                        foreach (sales b in salesMen)
                        {
                            Console.WriteLine($"{b.name} {b.pnr} {b.dist} {b.sold} ");
                            
                        }
                        
                        break;  

                }
                
            }
        }
            
        static string GetLevel(int sold)
        {
            if (sold < 50)
            {
                Console.WriteLine("FörsäljningsniAvå 1: <50 artiklar");
                return "1";
            }
            if (sold >= 50 && sold < 100)
            {
                Console.WriteLine("Försäljningsnivå 2: 50-99 artiklar.");
                return "2";
            }
            if (sold >= 100 && sold < 200)
            {
                Console.WriteLine("Försäljningsnivå 3: 100-199 artiklar.");
                return "3";
            }
            if (sold > 200)
            {
                Console.WriteLine("Försäljningsnivå 3: 100 - 199 artiklar.");
                return "4";
            }
            else
                return "5";

        }
    }
}
public class sales
{
    public string name { get; set; }
    public string pnr { get; set; }
    public string dist { get; set; }
    public int sold { get; set; }
    public int salarylvl { get; set; }
}

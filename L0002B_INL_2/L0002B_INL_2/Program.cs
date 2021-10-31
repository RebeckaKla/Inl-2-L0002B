using System;
using System.IO;
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
                        }) ;

                        Console.Clear();

                        Console.WriteLine("Säljare tillagd :)");
                        break;
                    
                    case "Sort": //I denna del sorteras säljarna efter hur många produkter som har sålts samt kategoriseras efter vilken försäljningsnivå de ligger på
                        Console.Clear();

                        salesMen.Sort((x, y) => x.sold.CompareTo(y.sold));
                        TextWriter tw = new StreamWriter("C:\\Resultat.txt");

                        int under50 = salesMen.FindAll(x => x.sold < 50).Count();
                        foreach (var c in salesMen.FindAll(x => x.sold < 50))
                        {
                            Console.WriteLine($"{c.name} {c.pnr} {c.dist} {c.sold}");
                            tw.WriteLine($"{c.name} {c.pnr} {c.dist} {c.sold}");
                        }
                        Console.WriteLine(under50 + " säljare har nått nivå 1: under 50 ");
                        tw.WriteLine(under50 + " säljare har nått nivå 1: under 50 ");

                        int Between50_100 = salesMen.FindAll(x => x.sold >= 50 && x.sold <= 99).Count();
                        foreach (var c in salesMen.FindAll(x => x.sold >= 50 && x.sold <= 99))
                        {
                            Console.WriteLine($"{c.name} {c.pnr} {c.dist} {c.sold}");
                            tw.WriteLine($"{c.name} {c.pnr} {c.dist} {c.sold}");
                        }
                        Console.WriteLine(Between50_100 + " säljare har nått nivå 2: mellan 50 och 100 ");
                        tw.WriteLine(Between50_100 + " säljare har nått nivå 2: mellan 50 och 100 ");

                        int Between100_200 = salesMen.FindAll(x => x.sold >= 100 && x.sold <= 199).Count();
                        foreach (var c in salesMen.FindAll(x => x.sold >= 100 && x.sold <= 199))
                        {
                            Console.WriteLine($"{c.name} {c.pnr} {c.dist} {c.sold}");
                            tw.WriteLine($"{c.name} {c.pnr} {c.dist} {c.sold}");
                        }
                        Console.WriteLine(Between100_200 + " säljare har nått nivå 3: mellan 100 och 200 ");
                        tw.WriteLine(Between100_200 + " säljare har nått nivå 3: mellan 100 och 200 ");

                        int Over200 = salesMen.FindAll(x => x.sold > 200).Count();
                        foreach (var c in salesMen.FindAll(x => x.sold >= 200))
                        {
                            Console.WriteLine($"{c.name} {c.pnr} {c.dist} {c.sold}");
                            tw.WriteLine($"{c.name} {c.pnr} {c.dist} {c.sold}");
                        }
                        Console.WriteLine(Over200 + " säljare har nått nivå 4: över 200");
                        tw.WriteLine(Over200 + " säljare har nått nivå 4: över 200");

                        tw.Close();
                        break;

                }

            }
        }
            
    }
}
public class sales
{
    public string name { get; set; }
    public string pnr { get; set; }
    public string dist { get; set; }
    public int sold { get; set; }
}

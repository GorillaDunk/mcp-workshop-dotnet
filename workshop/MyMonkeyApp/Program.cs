using System;
using MyMonkeyApp.Models;
using MyMonkeyApp.Helpers;

namespace MyMonkeyApp;

internal class Program
{
    /// <summary>
    /// Entry point for the Monkey Console Application.
    /// </summary>
    private static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("🐒 Monkey Console Application 🐒");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey by name");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit app");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Select an option (1-4): ");
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ListAllMonkeys();
                    break;
                case "2":
                    GetMonkeyByName();
                    break;
                case "3":
                    GetRandomMonkey();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    private static void ListAllMonkeys()
    {
        var monkeys = MonkeyHelper.GetMonkeys();
        Console.WriteLine("\nAvailable Monkeys:");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"{"Name",-15} {"Location",-20} {"Population",10}");
        Console.WriteLine("---------------------------------------------");
        foreach (var monkey in monkeys)
        {
            Console.WriteLine($"{monkey.Name,-15} {monkey.Location,-20} {monkey.Population,10}");
        }
        Console.WriteLine("---------------------------------------------");
    }

    private static void GetMonkeyByName()
    {
        Console.Write("\nEnter monkey name: ");
        var name = Console.ReadLine() ?? string.Empty;
        var selectedMonkey = MonkeyHelper.GetMonkeyByName(name);

        if (selectedMonkey is not null)
        {
            DisplayMonkeyDetails(selectedMonkey);
        }
        else
        {
            Console.WriteLine("Monkey not found.");
        }
    }

    private static void GetRandomMonkey()
    {
        var randomMonkey = MonkeyHelper.GetRandomMonkey();
        DisplayMonkeyDetails(randomMonkey);
        Console.WriteLine($"Random monkey accessed {MonkeyHelper.GetRandomMonkeyAccessCount()} times.");
    }

    private static void DisplayMonkeyDetails(Monkey monkey)
    {
        Console.WriteLine("\nMonkey Details:");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"Name      : {monkey.Name}");
        Console.WriteLine($"Location  : {monkey.Location}");
        Console.WriteLine($"Population: {monkey.Population}");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine(GetRandomAsciiArt());
    }

    private static string GetRandomAsciiArt()
    {
        var asciiArtList = new[]
        {
            @"  w  c( ..)o   (
   \__(<   )    )
      ''  ''---''",
            @"   _._     _,-'""-._
  (,-.`._,'(       |\`-/|
      `-.-' \ )-`( , o o)
            `-    \`_`""'-",
            @"  (\__/)
  (•ㅅ•)
  / 　 づ",
            @"  //\  //\
 ( o.o) ( o.o )
  > ^ <  > ^ <"
        };
        var random = new Random();
        return asciiArtList[random.Next(asciiArtList.Length)];
    }
}

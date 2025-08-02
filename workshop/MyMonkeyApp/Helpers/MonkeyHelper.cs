using System;
using System.Collections.Generic;
using System.Linq;
using MyMonkeyApp.Models;

namespace MyMonkeyApp.Helpers;

/// <summary>
/// Provides helper methods for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static readonly List<Monkey> monkeys = new()
    {
        new Monkey { Name = "Capuchin", Location = "Central America", Population = 50000 },
        new Monkey { Name = "Mandrill", Location = "West Africa", Population = 12000 },
        new Monkey { Name = "Howler", Location = "South America", Population = 30000 },
        new Monkey { Name = "Macaque", Location = "Asia", Population = 100000 },
        new Monkey { Name = "Spider Monkey", Location = "South America", Population = 25000 }
    };

    private static int randomMonkeyAccessCount = 0;

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    public static IReadOnlyList<Monkey> GetMonkeys() => monkeys;

    /// <summary>
    /// Gets a random monkey and tracks access count.
    /// </summary>
    public static Monkey GetRandomMonkey()
    {
        var random = new Random();
        randomMonkeyAccessCount++;
        return monkeys[random.Next(monkeys.Count)];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive).
    /// </summary>
    /// <param name="name">The name of the monkey to find.</param>
    /// <returns>The matching Monkey, or null if not found.</returns>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys.FirstOrDefault(m => string.Equals(m.Name, name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been accessed.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;
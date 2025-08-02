namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey species with relevant details.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the primary location of the monkey species.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the estimated population of the monkey species.
    /// </summary>
    public int Population { get; set; }
}
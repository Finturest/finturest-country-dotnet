using System.ComponentModel;

namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Represents a geopolitical or economic regional block, such as the European Union or African Union.
/// </summary>
public record RegionalBlockModel
{
    /// <summary>
    /// A required short identifier for the regional block, typically an official abbreviation (e.g., EU, EFTA).
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Code { get; init; }
#else
    public string Code { get; set; } = null!;
#endif

    /// <summary>
    /// A required full name of the regional block, such as "European Union" or "African Union".
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Name { get; init; }
#else
    public string Name { get; set; } = null!;
#endif

    /// <summary>
    /// An optional field providing additional information about the nature, goals, or scope of the regional block.
    /// </summary>
#if NET7_0_OR_GREATER
    public string? Description { get; init; }
#else
    public string? Description { get; set; }
#endif
}

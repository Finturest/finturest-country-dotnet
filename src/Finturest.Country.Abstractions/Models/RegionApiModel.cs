namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Represents a regional block based on the UN M49 standard used for statistical and classification purposes.
/// </summary>
public record RegionApiModel
{
    /// <summary>
    /// A required identifier for the regional block, as defined by the UN M49 standard.
    /// This code is typically used for classification and reference in international statistical datasets.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Code { get; init; }
#else
    public string Code { get; set; } = null!;
#endif

    /// <summary>
    /// A required name of the regional block according to the UN M49 standard.
    /// This provides the official designation used in UN documentation.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Name { get; init; }
#else
    public string Name { get; set; } = null!;
#endif
}
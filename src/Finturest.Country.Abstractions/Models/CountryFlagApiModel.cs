namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Represents a collection of flag image files for a specific country, provided in various formats.
/// </summary>
public record CountryFlagApiModel
{
    /// <summary>
    /// A list of file objects representing the country's flag in various formats (e.g., SVG, PNG).
    /// </summary>
#if NET7_0_OR_GREATER
    public required IReadOnlyList<FileApiModel> Images { get; init; } = [];
#else
    public IReadOnlyList<FileApiModel> Images { get; set; } = [];
#endif
}

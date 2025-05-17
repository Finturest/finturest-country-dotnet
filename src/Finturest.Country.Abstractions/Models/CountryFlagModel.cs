namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Represents a collection of flag image files for a specific country, provided in various formats.
/// </summary>
public record CountryFlagModel
{
    /// <summary>
    /// A list of file objects representing the country's flag in various formats (e.g., SVG, PNG).
    /// </summary>
#if NET7_0_OR_GREATER
    public required IReadOnlyList<FileModel> Images { get; init; } = [];
#else
    public IReadOnlyList<FileModel> Images { get; set; } = [];
#endif
}

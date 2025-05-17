using Finturest.Country.Abstractions.Models.Enums;

namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Represents metadata for a downloadable or accessible file, including its format and URL.
/// </summary>
public record FileApiModel
{
    /// <summary>
    /// An enumeration representing the file format (e.g., SVG, PNG).
    /// </summary>
#if NET7_0_OR_GREATER
    public required ApiFileFormat Format { get; init; }
#else
    public ApiFileFormat Format { get; set; }
#endif

    /// <summary>
    /// A URL string providing the location where the file can be accessed or downloaded.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Url { get; init; }
#else
    public string Url { get; set; } = null!;
#endif
}
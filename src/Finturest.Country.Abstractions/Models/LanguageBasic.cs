namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Represents basic identifying information for a language, including its English and native names, and ISO codes.
/// </summary>
public record LanguageBasic
{
    /// <summary>
    /// The English name of the language (e.g., "Spanish", "French").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Name { get; init; }
#else
    public string Name { get; set; } = null!;
#endif

    /// <summary>
    /// The name of the language in its native form or script (e.g., "Español", "Français").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string LocalName { get; init; }
#else
    public string LocalName { get; set; } = null!;
#endif

    /// <summary>
    /// A two-letter language code defined by ISO 639-1 (e.g., "es" for Spanish, "fr" for French).
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Iso6391Code { get; init; }
#else
    public string Iso6391Code { get; set; } = null!;
#endif

    /// <summary>
    /// A three-letter language code defined by ISO 639-2 (e.g., "spa" for Spanish, "fra" for French).
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Iso6392Code { get; init; }
#else
    public string Iso6392Code { get; set; } = null!;
#endif
}

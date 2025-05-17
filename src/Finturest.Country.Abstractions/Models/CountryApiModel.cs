namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Country in ISO 3166 standard.
/// </summary>
public record CountryApiModel
{
    /// <summary>
    /// The official country name as defined by ISO 3166-1.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Name { get; init; }
#else
    public string Name { get; set; } = null!;
#endif

    /// <summary>
    /// The country's name in its native language or script.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string LocalName { get; set; }
#else
    public string LocalName { get; set; } = null!;
#endif

    /// <summary>
    /// Two-character country code compliant with ISO 3166-1 alpha-2 (e.g., "US", "DE").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Alpha2Code { get; init; }
#else
    public string Alpha2Code { get; set; } = null!;
#endif

    /// <summary>
    /// Three-character country code compliant with ISO 3166-1 alpha-3 (e.g., "USA", "DEU").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Alpha3Code { get; init; }
#else
    public string Alpha3Code { get; set; } = null!;
#endif

    /// <summary>
    /// Three-digit numeric country code as per ISO 3166-1 (e.g., "840", "276").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string NumericCode { get; init; }
#else
    public string NumericCode { get; set; } = null!;
#endif

    /// <summary>
    /// Indicates whether the country is recognized as independent.
    /// </summary>
#if NET7_0_OR_GREATER
    public required bool Independent { get; init; }
#else
    public bool Independent { get; set; }
#endif

    /// <summary>
    /// The total land area of the country in square kilometers, if available.
    /// </summary>
#if NET7_0_OR_GREATER
    public decimal? Area { get; init; }
#else
    public decimal? Area { get; set; }
#endif

    /// <summary>
    /// The total population of the country, if available.
    /// </summary>
#if NET7_0_OR_GREATER
    public int? Population { get; init; }
#else
    public int? Population { get; set; }
#endif

    /// <summary>
    /// The macro geographical (continental) region as classified by UN M49, if available.
    /// </summary>
#if NET7_0_OR_GREATER
    public RegionApiModel? Region { get; init; }
#else
    public RegionApiModel? Region { get; set; }
#endif

    /// <summary>
    /// The subregional classification from UN M49, if available.
    /// </summary>
#if NET7_0_OR_GREATER
    public RegionApiModel? Subregion { get; init; }
#else
    public RegionApiModel? Subregion { get; set; }
#endif

    /// <summary>
    /// The intermediate region classification from UN M49, if applicable.
    /// </summary>
#if NET7_0_OR_GREATER
    public RegionApiModel? IntermediateRegion { get; init; }
#else
    public RegionApiModel? IntermediateRegion { get; set; }
#endif

    /// <summary>
    /// A list of international telephone calling codes for the country.
    /// </summary>
    public IReadOnlyList<string> CallingCodes { get; set; } = [];

    /// <summary>
    /// A list of official capital cities for the country.
    /// </summary>
    public IReadOnlyList<string> Capitals { get; set; } = [];

    /// <summary>
    /// A list of currencies officially used in the country.
    /// </summary>
#if NET7_0_OR_GREATER
    public IReadOnlyList<CurrencyBasicApiModel> Currencies { get; init; } = [];
#else
    public IReadOnlyList<CurrencyBasicApiModel> Currencies { get; set; } = [];
#endif

    /// <summary>
    /// Contains URLs to the country’s official flag images in SVG and PNG formats.
    /// </summary>
#if NET7_0_OR_GREATER
    public required CountryFlagApiModel Flag { get; init; }
#else
    public CountryFlagApiModel Flag { get; set; } = null!;
#endif

    /// <summary>
    /// A list of languages officially or commonly spoken in the country.
    /// </summary>
    public IReadOnlyList<LanguageBasicApiModel> Languages { get; set; } = [];

    /// <summary>
    /// A list of IANA timezones applicable to the country.
    /// </summary>
    public IReadOnlyList<string> Timezones { get; set; } = [];

    /// <summary>
    /// A list of top-level internet domains associated with the country (e.g., ".us", ".de").
    /// </summary>
    public IReadOnlyList<string> TopLevelDomains { get; set; } = [];
}

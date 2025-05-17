namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Currency in ISO 4217 standard.
/// </summary>
public record CurrencyBasicApiModel
{
    /// <summary>
    /// The alphabetic code is based on another ISO standard, ISO 3166, which lists the codes for country names.
    /// The first two letters of the ISO 4217 three-letter code are the same as the code for the country name,
    /// and, where possible, the third letter corresponds to the first letter of the currency name.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Code { get; init; }
#else
    public string Code { get; set; } = null!;
#endif

    /// <summary>
    /// The full name of the currency (e.g., "United States Dollar").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Name { get; init; }
#else
    public string Name { get; set; } = null!;
#endif

    /// <summary>
    /// The three-digit numeric code is useful when currency codes need to be understood in countries that do not use Latin scripts
    /// and for computerized systems. Where possible, the three-digit numeric code is the same as the numeric country code.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string NumericCode { get; init; }
#else
    public string NumericCode { get; set; } = null!;
#endif

    /// <summary>
    /// The symbol commonly used to represent the currency (e.g., "$", "€", "¥").
    /// </summary>
#if NET7_0_OR_GREATER
    public string? Symbol { get; init; }
#else
    public string? Symbol { get; set; }
#endif

    /// <summary>
    /// Unit of recorded value (i.e. as recorded by banks) which is a division of the respective unit of currency or fund.
    /// </summary>
#if NET7_0_OR_GREATER
    public int? MinorUnit { get; init; }
#else
    public int? MinorUnit { get; set; }
#endif
}

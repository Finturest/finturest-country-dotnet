namespace Finturest.Country.Abstractions.Models;

/// <summary>
/// Represents a currency in compliance with the ISO 4217 standard.
/// </summary>
public record CurrencyModel
{
    /// <summary>
    /// A required three-letter alphabetic currency code defined by ISO 4217.
    /// The first two letters are derived from the country code (ISO 3166), 
    /// and the third letter corresponds to the initial of the currency name, where possible.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Code { get; init; }
#else
    public string Code { get; set; } = null!;
#endif

    /// <summary>
    /// The full name of the currency (e.g., "Euro", "United States Dollar").
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Name { get; init; }
#else
    public string Name { get; set; } = null!;
#endif

    /// <summary>
    /// A required three-digit numeric code defined by ISO 4217.
    /// It is particularly useful in systems that do not use Latin scripts or where numeric representation is preferred.
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

    /// <summary>
    /// A list of associated countries where the currency is used.
    /// </summary>
    public IReadOnlyList<CountryBasicModel> Countries { get; set; } = [];
}

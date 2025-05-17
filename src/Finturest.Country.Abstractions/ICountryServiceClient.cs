using Finturest.Country.Abstractions.Models;

namespace Finturest.Country.Abstractions;

/// <summary>
/// Provides methods for sending requests to and receiving responses from the Finturest Country API.
/// </summary>
public interface ICountryServiceClient
{
    /// <summary>
    /// Get countries
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ArgumentNullException">The request model was null.</exception>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<CountryModel>> GetCountriesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get currencies
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ArgumentNullException">The request model was null.</exception>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<CurrencyModel>> GetCurrenciesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get languages
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ArgumentNullException">The request model was null.</exception>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<LanguageModel>> GetLanguagesAsync(CancellationToken cancellationToken = default);
}

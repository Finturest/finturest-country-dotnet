using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using Finturest.Country.Abstractions;
using Finturest.Country.Abstractions.Models;
using Finturest.Country.Constants;

namespace Finturest.Country;

public class CountryServiceClient : ICountryServiceClient
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public CountryServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }

    public async Task<IReadOnlyList<CountryModel>> GetCountriesAsync(CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Countries}";

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<CountryModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    public async Task<IReadOnlyList<CurrencyModel>> GetCurrenciesAsync(CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Currencies}";

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<CurrencyModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    public async Task<IReadOnlyList<LanguageModel>> GetLanguagesAsync(CancellationToken cancellationToken = default)
    {
        var uri = $"{RouteConstants.V1}/{RouteConstants.Languages}";

        var response = await _httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IReadOnlyList<LanguageModel>>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }
}

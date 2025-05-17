using System.Net;
using System.Net.Http;

using Finturest.Country.Abstractions;
using Finturest.Country.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finturest.Country.IntegrationTests;

/// <summary>
/// Integration tests for <see cref="ICountryServiceClient"/>
/// </summary>
public partial class CountryServiceClientIntegrationTests
{
    private readonly ICountryServiceClient _sut;

    public CountryServiceClientIntegrationTests()
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
#if DEBUG
            .AddUserSecrets<CountryServiceClientIntegrationTests>()
#endif
            .Build();

        var apiKey = configuration["Country:ApiKey"] ?? throw new InvalidOperationException("Finturest Country API key must be set in environment or user secrets.");

        _sut = BuildClient(apiKey);
    }

    [Fact]
    public async Task SendRequestAsync_ApiKeyIsNotValid_EnsureUnauthorizedStatusCode()
    {
        // Act
        Func<Task> action = async () => await BuildClient(apiKey: "invalid-api-key").GetCountriesAsync().ConfigureAwait(false);

        // Assert
#if NET5_0_OR_GREATER
        var assertion = await action.ShouldThrowAsync<HttpRequestException>();

        assertion.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
#else
        await action.ShouldThrowAsync<HttpRequestException>();
#endif
    }

    private static ICountryServiceClient BuildClient(string apiKey)
    {
        var services = new ServiceCollection();

        services.AddFinturestCountry(options =>
        {
            options.ApiKey = apiKey;
        });

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider.GetRequiredService<ICountryServiceClient>();
    }
}

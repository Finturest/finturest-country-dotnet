using System.Net;
using System.Net.Http;

using Finturest.Country.Abstractions;
using Finturest.Country.Abstractions.Models.Enums;
using Finturest.Country.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finturest.Country.IntegrationTests;

/// <summary>
/// Integration tests for <see cref="ICountryServiceClient"/>
/// </summary>
public class CountryServiceClientIntegrationTests
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
    public async Task GetCountriesAsync_ApiKeyIsNotValid_EnsureUnauthorizedStatusCode()
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

    [Fact]
    public async Task GetCountriesAsync_RequestIsValid_ReturnCorrectResult()
    {
        // Act
        var result = await _sut.GetCountriesAsync();

        // Assert
        result.ShouldNotBeEmpty();

        result.Count.ShouldBe(249);

        foreach (var country in result)
        {
            country.Name.ShouldNotBeNullOrEmpty();
            country.LocalName.ShouldNotBeNullOrEmpty();
            country.Alpha2Code.ShouldNotBeNullOrEmpty();
            country.Alpha3Code.ShouldNotBeNullOrEmpty();
            country.NumericCode.ShouldNotBeNullOrEmpty();

            if (country.Region is not null)
            {
                country.Region.Code.ShouldNotBeNullOrEmpty();
                country.Region.Name.ShouldNotBeNullOrEmpty();
            }

            if (country.Subregion is not null)
            {
                country.Subregion.Code.ShouldNotBeNullOrEmpty();
                country.Subregion.Name.ShouldNotBeNullOrEmpty();
            }

            if (country.IntermediateRegion is not null)
            {
                country.IntermediateRegion.Code.ShouldNotBeNullOrEmpty();
                country.IntermediateRegion.Name.ShouldNotBeNullOrEmpty();
            }

            foreach (var currency in country.Currencies)
            {
                currency.Code.ShouldNotBeNullOrEmpty();
                currency.Name.ShouldNotBeNullOrEmpty();
                currency.NumericCode.ShouldNotBeNullOrEmpty();
            }

            country.Flag.ShouldNotBeNull();

            country.Flag.Images.ShouldNotBeEmpty();
            country.Flag.Images.Count.ShouldBe(2);

            country.Flag.Images[0].Format.ShouldBe(ApiFileFormat.SVG);
            country.Flag.Images[0].Url.ShouldNotBeNullOrEmpty();

            country.Flag.Images[1].Format.ShouldBe(ApiFileFormat.PNG);
            country.Flag.Images[1].Url.ShouldNotBeNullOrEmpty();

            foreach (var language in country.Languages)
            {
                language.Name.ShouldNotBeNullOrEmpty();
                language.LocalName.ShouldNotBeNullOrEmpty();
                language.Iso6391Code.ShouldNotBeNullOrEmpty();
                language.Iso6392Code.ShouldNotBeNullOrEmpty();
            }
        }
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

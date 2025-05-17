using Finturest.Country.Abstractions.Models.Enums;

namespace Finturest.Country.IntegrationTests;

public partial class CountryServiceClientIntegrationTests
{
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

            country.Flag.Images[0].Format.ShouldBe(FileFormat.SVG);
            country.Flag.Images[0].Url.ShouldNotBeNullOrEmpty();

            country.Flag.Images[1].Format.ShouldBe(FileFormat.PNG);
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
}

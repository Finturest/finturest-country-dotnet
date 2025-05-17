namespace Finturest.Country.IntegrationTests;

public partial class CountryServiceClientIntegrationTests
{
    [Fact]
    public async Task GetLanguagesAsync_RequestIsValid_ReturnCorrectResult()
    {
        // Act
        var result = await _sut.GetLanguagesAsync();

        // Assert
        result.ShouldNotBeEmpty();

        foreach (var language in result)
        {
            language.Name.ShouldNotBeNullOrEmpty();
            language.LocalName.ShouldNotBeNullOrEmpty();
            language.Iso6391Code.ShouldNotBeNullOrEmpty();
            language.Iso6392Code.ShouldNotBeNullOrEmpty();

            foreach (var country in language.Countries)
            {
                country.Name.ShouldNotBeNullOrEmpty();
                country.Alpha2Code.ShouldNotBeNullOrEmpty();
                country.Alpha3Code.ShouldNotBeNullOrEmpty();
                country.NumericCode.ShouldNotBeNullOrEmpty();
            }
        }
    }
}

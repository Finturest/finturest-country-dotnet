namespace Finturest.Country.IntegrationTests;

public partial class CountryServiceClientIntegrationTests
{
    [Fact]
    public async Task GetCurrenciesAsync_RequestIsValid_ReturnCorrectResult()
    {
        // Act
        var result = await _sut.GetCurrenciesAsync();

        // Assert
        result.ShouldNotBeEmpty();

        foreach (var currency in result)
        {
            currency.Code.ShouldNotBeNullOrEmpty();
            currency.Name.ShouldNotBeNullOrEmpty();
            currency.NumericCode.ShouldNotBeNullOrEmpty();

            foreach (var country in currency.Countries)
            {
                country.Name.ShouldNotBeNullOrEmpty();
                country.Alpha2Code.ShouldNotBeNullOrEmpty();
                country.Alpha3Code.ShouldNotBeNullOrEmpty();
                country.NumericCode.ShouldNotBeNullOrEmpty();
            }
        }
    }
}

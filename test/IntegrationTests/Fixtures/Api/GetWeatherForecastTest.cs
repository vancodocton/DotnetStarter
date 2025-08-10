using System.Net.Http.Json;

using WebApi;

namespace IntegrationTests.Fixtures.Api;

public class GetWeatherForecastTest
: IClassFixture<WebApiFactory>
{
    private readonly WebApiFactory _factory;

    public GetWeatherForecastTest(WebApiFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetWeatherForecast_ReturnsSuccess()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var weatherForecasts = await client.GetFromJsonAsync<List<WeatherForecast>>("/weatherforecast", TestContext.Current.CancellationToken);

        // Assert
        Assert.NotNull(weatherForecasts);
        Assert.NotEmpty(weatherForecasts);
    }
}

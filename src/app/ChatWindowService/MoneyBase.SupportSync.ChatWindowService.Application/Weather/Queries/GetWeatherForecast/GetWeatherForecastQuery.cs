using MoneyBase.SupportSync.ChatWindowService.Application.Dtos;

namespace MoneyBase.SupportSync.ChatWindowService.Application.Weather.Queries.GetWeatherForecast;

public record GetWeatherForecastQuery(string location)
    : IQuery<GetWeatherForecastResult>;

public record GetWeatherForecastResult(IEnumerable<OrderDto> Orders);

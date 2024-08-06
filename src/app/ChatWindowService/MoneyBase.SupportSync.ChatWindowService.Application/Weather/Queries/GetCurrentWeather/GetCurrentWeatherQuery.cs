using MoneyBase.SupportSync.Core.Pagination;
using MoneyBase.SupportSync.ChatWindowService.Application.Dtos;

namespace MoneyBase.SupportSync.ChatWindowService.Application.Weather.Queries.GetCurrentWeather;

public record GetCurrentWeatherQuery(string location)
    : IQuery<GetCurrentWeatherResult>;

public record GetCurrentWeatherResult(PaginatedResult<OrderDto> Orders);
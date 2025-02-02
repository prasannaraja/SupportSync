﻿using MoneyBase.SupportSync.ChatWindowService.Application.Data;
using MoneyBase.SupportSync.ChatWindowService.Domain.ValueObjects;

namespace MoneyBase.SupportSync.ChatWindowService.Application.Weather.Queries.GetWeatherForecast;
public class GetWeatherForecastHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetWeatherForecastQuery, GetWeatherForecastResult>
{
    public async Task<GetWeatherForecastResult> Handle(GetWeatherForecastQuery query, CancellationToken cancellationToken)
    {
        // get orders by customer using dbContext
        // return result

        //var orders = await dbContext.Orders
        //                .Include(o => o.OrderItems)
        //                .AsNoTracking()
        //                .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
        //                .OrderBy(o => o.OrderName.Value)
        //                .ToListAsync(cancellationToken);

        //return new GetWeatherForecastResult(orders.ToOrderDtoList());
        return default;
    }
}

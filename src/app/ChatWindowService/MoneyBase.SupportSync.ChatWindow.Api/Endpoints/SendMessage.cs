﻿namespace MoneyBase.SupportSync.ChatWindow.Api.Endpoints
{
    public class SendMessage : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var summaries = new[]
             {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            app.MapPost("/send-message", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        summaries[Random.Shared.Next(summaries.Length)]
                    ))
                    .ToArray();
                return forecast;
            })
            .WithName("PostSendMessage")
            .WithOpenApi();
        }
    }
}

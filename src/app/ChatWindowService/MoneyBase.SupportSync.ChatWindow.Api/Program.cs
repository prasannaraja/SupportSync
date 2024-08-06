using MoneyBase.SupportSync.ChatWindow.Api;
using MoneyBase.SupportSync.ChatWindowService.Application;
using MoneyBase.SupportSync.ChatWindowService.Infrastructure;
using MoneyBase.SupportSync.ChatWindowService.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //await app.InitialiseDatabaseAsync();
}

app.UseHttpsRedirection();
app.Run();
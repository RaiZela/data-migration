using BuildingBlocks;
using client_infrastructure.Data.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5100);
});


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//TODO Add MassTransit

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices()
      .AddMessaging(builder.Configuration);

//TODO: Add logging

//TODO: Authorization & Authentication



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();

//TODO Authorization & Authentication Pipeline

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.Run();

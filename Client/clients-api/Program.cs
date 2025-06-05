using client_infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//TODO Add MassTransit

builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

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

app.UseHttpLogging();

app.Run();

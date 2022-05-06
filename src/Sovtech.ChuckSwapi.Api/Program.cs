using Sovtech.ChuckSwapi.ApplicationCore.ApiClients;
using Sovtech.ChuckSwapi.ApplicationCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddHttpClient<IChuckApiClient, ChuckApiClient>(c =>
c.BaseAddress = new Uri(configuration.GetValue<string>("ApiClients:ChuckApiUrl")));

builder.Services.AddHttpClient<ISwapiApiClient, SwapiApiClient>(c => 
c.BaseAddress = new Uri(configuration.GetValue<string>("ApiClients:SwapApiUrl")));

builder.Services.AddSingleton<IChuckService, ChuckService>();
builder.Services.AddSingleton<ISwapiService, SwapiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

 
using pharmacy.Services;
//using Serilog;
//using Serilog.Sinks.Elasticsearch;
using System;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//To integrate with Reactjs(FrontEnd). To allow api Calls from 3000 while the backend is hosted on 5001
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

//Add Logging Providers
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddSingleton<ILogger>(sp =>
{
    var factory = sp.GetRequiredService<ILoggerFactory>();
    return factory.CreateLogger("Default Logger");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowReact");    //To allow Reactjs
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

using pharmacy.Services;
using Serilog;
using Serilog.Sinks.Elasticsearch;
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

//Add the Logging Sinks(Serilog) - Configure Serilog as provider for Microsoft.Extensions.Logging[Console, file, MSSqlServer, Elasticsearch]
Log.Logger = new LoggerConfiguration()
            // .WriteTo.Console()
             .WriteTo.File(
                       path: "Logs/log-.txt",
                       rollingInterval: RollingInterval.Day,
                       retainedFileCountLimit: 7,
                       rollOnFileSizeLimit: true,
                       outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            /* .WriteTo.MSSqlServer(
                connectionString: "Server=.;Database=LogsTEMP;User ID=sa;Password=SqlServer@0526;Encrypt=True;TrustServerCertificate=True;",
                sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
                {
                    TableName = "Logs",
                    AutoCreateSqlTable = true
                })*/
             .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("https://localhost:9200"))
             {
                 AutoRegisterTemplate = true,
                 IndexFormat = $"logs-app-{DateTime.UtcNow:yyyy.MM.dd}",
                 ModifyConnectionSettings = x => x
                    .BasicAuthentication(
                        "elastic",
                        "M6COuqBBAk5YgV+_PhOp")
                    .ServerCertificateValidationCallback(
                        (o, cert, chain, errors) => true)
             })
             .CreateLogger();

//Add Logging Providers
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);

//builder.Services.AddSingleton<ILogger>(sp =>
//{
//    var factory = sp.GetRequiredService<ILoggerFactory>();
//    return factory.CreateLogger("Default Logger");
//});

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

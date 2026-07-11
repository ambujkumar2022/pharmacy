using System.Text;
using System.Text.Json;

namespace pharmacy.Services
{
    public class JobSchedulerService : BackgroundService
    {
        private readonly ILogger<JobSchedulerService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public JobSchedulerService(ILogger<JobSchedulerService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Example: run indefinitely
            while (!stoppingToken.IsCancellationRequested)
            {
                await RunJobAsync("SampleJob", "Payload data", stoppingToken);

                // Change interval here: 10min, 30min, hourly, weekly, monthly
                await Task.Delay(TimeSpan.FromMinutes(3), stoppingToken);
            }
        }

        private async Task RunJobAsync(string jobName, string payload, CancellationToken token)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var dto = new { JobName = jobName, Payload = payload };
                var json = JsonSerializer.Serialize(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:5001/api/job/execute", content, token);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Job '{jobName}' executed successfully at {DateTime.UtcNow}");
                }
                else
                {
                    _logger.LogError($"Job '{jobName}' failed with status {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error executing job '{jobName}'");
            }
        }
    }

}

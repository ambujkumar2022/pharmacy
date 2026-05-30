using Microsoft.Extensions.Logging;

namespace pharmacy.Services
{
    public interface ILoggingService
    {
        void LogInfo(string message);
        void LogError(Exception ex,string message);
    }
    public class LoggingService                        //: ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;
        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }
        public void LogInfo(string message) 
        {
            _logger.LogInformation(message);
        }
        public void LogError(Exception ex, string message) 
        { 
            _logger.LogError(ex, message);
        }
    }
}

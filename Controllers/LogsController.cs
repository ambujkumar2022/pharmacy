using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pharmacy.Models;
using pharmacy.Services;

namespace pharmacy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILoggingService _loggingService;

        public LogsController(ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        //POST: api/logs
        [HttpPost]
        public IActionResult PostLog([FromBody] LogEntry log)
        {
            if(log!=null || string.IsNullOrWhiteSpace(log.Message)) 
                return BadRequest("Invalid log data");

            try
            {
                switch (log.Level.ToLower())
                {
                    case "info":
                        _loggingService.LogInfo(log.Message);
                        break;
                    //case "warning":
                    //    _loggingService.LogWarning(log.Message);
                      //  break;
                    case "error":
                        _loggingService.LogError(new Exception(log.Exception ?? ""), log.Message);
                        break;
                    default:
                        _loggingService.LogInfo($"[UNKNOWN LEVEL] {log.Message}");
                        break;
                }

                return Ok(new { status = "Logged successfully" });
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex, "Failed to log message");
                return StatusCode(500, "Internal server error");
            }

        }
    }

    public class LogEntry
    {
        public string Level { get; set; } = "info";
        public string Message { get; set; } = string.Empty;
        public string? Exception { get; set; }
    }

}

namespace Shared.ErrorLogger.Models
{
    public class LogRequest
    {
        public string LogType { get; set; } = string.Empty;
        public string LoggedFrom { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}

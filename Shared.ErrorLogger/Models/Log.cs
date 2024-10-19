namespace Shared.ErrorLogger.Models
{
    public class Log
    {
        public LogType LogType { get; set; }
        public string Message { get; set; } = string.Empty;
        public string LoggedFrom { get; set; } = string.Empty;
    }

    public enum LogType
    {
        Error,
        Warning,
        Information
    }
}

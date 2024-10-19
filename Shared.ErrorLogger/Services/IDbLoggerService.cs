using Shared.ErrorLogger.Models;

namespace Shared.ErrorLogger.Services
{
    public interface IDbLoggerService
    {
        Task LogToDatabase(LogRequest logRequest);
    }
}

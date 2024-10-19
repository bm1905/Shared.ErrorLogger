using Shared.ErrorLogger.Models;

namespace Shared.ErrorLogger.Repository
{
    public interface IDbLoggerRepository
    {
        Task LogToDatabase(Log log);
    }
}

using Shared.ErrorLogger.Models;
using Shared.ErrorLogger.Repository;

namespace Shared.ErrorLogger.Services
{
    public class DbLoggerService : IDbLoggerService
    {
        private readonly IDbLoggerRepository _dbLoggerRepository;

        public DbLoggerService(IDbLoggerRepository dbLoggerRepository)
        {
            _dbLoggerRepository = dbLoggerRepository;
        }

        public async Task LogToDatabase(LogRequest logRequest)
        {
            Log log = new()
            {
                LogType = Enum.TryParse(logRequest.LogType, true, out LogType logType) ? logType : LogType.Information,
                LoggedFrom = logRequest.LoggedFrom,
                Message = logRequest.Message
            };

            await _dbLoggerRepository.LogToDatabase(log);
        }
    }
}

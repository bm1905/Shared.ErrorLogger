using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Shared.ErrorLogger.Models;
using Shared.ErrorLogger.Options;

namespace Shared.ErrorLogger.Repository
{
    public class DbLoggerRepository : IDbLoggerRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public DbLoggerRepository(IOptions<DatabaseConfig> databaseConfig)
        {
            _databaseConfig = databaseConfig.Value;
        }

        public async Task LogToDatabase(Log log)
        {
            string conString = _databaseConfig.ConnectionString;
            const string commandText = "usp_InsertToQuotesSenderLog";
            await using SqlConnection sqlConnection = new(conString);
            await using SqlCommand command = new(commandText, sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@LogType", SqlDbType.VarChar, 50).Value = log.LogType;
            command.Parameters.Add("@Message", SqlDbType.VarChar, -1).Value = log.Message;
            command.Parameters.Add("@LoggedFrom", SqlDbType.VarChar, 1000).Value = log.LoggedFrom;

            await sqlConnection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}

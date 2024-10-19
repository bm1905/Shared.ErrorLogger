using Microsoft.Data.SqlClient;

namespace Shared.ErrorLogger.Extensions
{
    public static class SqlDataReaderExtension
    {

        public static T? ReadValueAs<T>(this SqlDataReader reader, string columnName)
        {
            T? converted;
            try
            {
                int ordinal = reader.GetOrdinal(columnName);
                if (reader.IsDBNull(ordinal)) return default;
                object val = reader.GetValue(ordinal);
                if (val is T value)
                {
                    converted = value;
                }
                else if ((typeof(T) == typeof(bool)) && val is int v)
                {
                    return (T)Convert.ChangeType(v != 0, typeof(T));
                }
                else
                {
                    converted = (T)Convert.ChangeType(val, typeof(T));
                }
            }
            catch (Exception )
            {
                converted = default;
            }

            return converted;
        }
    }
}

using System.Data;
using System.Threading.Tasks;
using Dapper;

public static class DapperExtensions
{
    public static async Task<bool> ExecuteAndReturnBoolAsync(this IDbConnection connection, string sql, object param = null, IDbTransaction transaction = null)
    {
        try
        {
            var affectedRows = await connection.ExecuteAsync(sql, param, transaction);
            return affectedRows > 0;
        }
        catch
        {
            return false;
        }
    }
}

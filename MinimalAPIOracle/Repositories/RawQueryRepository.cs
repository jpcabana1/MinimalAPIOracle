using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace MinimalAPIOracle.Repositories
{
    public class RawQueryRepository
    {
        private readonly ModelContext _modelContext;
        public RawQueryRepository(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<ICollection<T>> ExecuteRawQuery<T>(string query, Func<DbDataReader, T> map, Dictionary<string, object> parameters = null)
        {
            using (var command = _modelContext.Database.GetDbConnection().CreateCommand())
            {

                command.CommandText = query;
                command.CommandType = CommandType.Text;

                if(parameters != null)
                {
                    foreach (var par in parameters)
                    {
                        var p = new OracleParameter();
                        p.OracleDbType = OracleDbType.Long;
                        p.ParameterName = par.Key;
                        p.Value = par.Value;
                        command.Parameters.Add(p);
                    }
                }
                
                await _modelContext.Database.OpenConnectionAsync();
                using (var result = await command.ExecuteReaderAsync())
                {
                    var resultQuery = new List<T>();
                    while (result.Read())
                    {
                        resultQuery.Add(map(result));
                    }
                    return resultQuery;
                }
            }
        }
    }
}
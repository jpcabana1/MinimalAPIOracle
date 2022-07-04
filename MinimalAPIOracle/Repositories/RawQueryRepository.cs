using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using System.Data;
using System.Data.Common;

namespace MinimalAPIOracle.Repositories
{
    public class RawQueryRepository
    {
        private readonly ModelContext _modelContext;
        public RawQueryRepository(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<ICollection<T>> ExecuteRawQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using (var command = _modelContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
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
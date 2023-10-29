using Dapper;
using Npgsql;
using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public class ArtistRepository : IArtistRepository, IDisposable
    {
        private readonly NpgsqlConnection _connection;

        public ArtistRepository(IConfiguration configuration)
        {
            _connection = new NpgsqlConnection(configuration.GetConnectionString("DB"));
            _connection.Open();
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            var commandText = "SELECT * FROM \"Artist\"";
            return await _connection.QueryAsync<Artist>(commandText);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _connection.Close();
        }

    }
}

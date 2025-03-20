using System.Data;
using Dapper;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class ColaboradorRepository
    {
        private readonly IDbConnection _connection;

        public ColaboradorRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Colaborador>> GetAllAsync()
        {
            var sql = "SELECT * FROM colaboradores;";
            var result = await _connection.QueryAsync<Colaborador>(sql);
            return result;
        }

        public async Task<int> InsertAsync(Colaborador colaborador)
        {
            var sql = "INSERT INTO colaboradores VALUES (@Nombre)" +
                "SELECT SCOPE_IDENTITY()";
            var id = await _connection.ExecuteScalarAsync<int>(sql, colaborador);
            return id;
        }
        public async Task<Colaborador> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM colaboradores WHERE ID = @Id;";
            var result = await _connection.QueryFirstOrDefaultAsync<Colaborador>(sql, new { Id = id });
            return result;
        }
    }
}

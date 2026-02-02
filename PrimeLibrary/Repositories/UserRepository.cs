using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Prime.Library.Domain.Exceptions;
using Prime.Library.Repositories.Database;
using Prime.Models;

namespace Prime.Library.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel?> GetByUsernamePassword(string username, string password);
        Task<IEnumerable<UserModel>> GetUsers();
    }

    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _database;

        public UserRepository(IConfiguration config)
        {
            var providerName = config.GetSection("DatabaseProvider").Value ?? throw new DatabaseException("Provider name has not been defined in configuration.");
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new DatabaseException("Connection string has not been defined in configuration.");
            _database = DbFactory.CreateConnection(providerName: providerName, connectionString);
        }

        public async Task<UserModel?> GetByUsernamePassword(string username, string password)
        {
            var query = "SELECT * FROM [dbo].[user] WHERE username = @Username AND password = @Password";
            return await _database.QueryFirstOrDefaultAsync<UserModel>(query, new { Username = username, Password = password });
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var data = await _database.QueryAsync<UserModel>("SELECT * FROM user");
            return data;
        }
    }
}

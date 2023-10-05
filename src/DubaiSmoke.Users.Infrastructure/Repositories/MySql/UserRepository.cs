using Dapper;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Infrastructure.Repositories.MySql
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration Configuration;
        private string ConnectionString;
        public UserRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DubaiSmokeDb");
        }

        public async Task<bool> DeleteAsync(long id)
        {
            string sql = @"UPDATE users SET
                           DT_DELETED = @DeletedAt
                           WHERE ID = @Id;";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    await connection.ExecuteAsync(sql, new { DeletedAt = DateTime.Now, Id = id });
                }
                finally
                {
                    connection.Close();
                }
                return true;
            }
        }

        public async Task<long> InsertAsync(UserEntity item)
        {
            var hash = Guid.NewGuid();
            string sql = @"INSERT INTO users (NM_USER, DT_BIRTH, TXT_LOGIN, TXT_PWD, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                            Values (@Name, @BirthDay, @Login, @Password, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                                SELECT ID FROM users WHERE HASH_CODE = @HashCode";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                long id = default;
                try
                {
                    connection.Open();
                    item.HashCode = hash.ToString();
                    var response = await connection.QueryAsync<long>(sql, item);
                    id = response.FirstOrDefault();
                }
                finally
                {
                    connection.Close();
                }
                return id;
            }
        }

        public async Task<bool> LoginAsync(UserEntity user)
        {
            string sql = @"SELECT HASH_CODE FROM users WHERE TXT_LOGIN = @email AND TXT_PWD = @password";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    await connection.QuerySingleAsync<UserEntity>(sql, new { email = user.Login, password = user.Password });
                    return true;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<UserEntity> SelectAsync(long id)
        {
            string sql = @"SELECT * FROM users WHERE id = @Id;";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    return await connection.QueryFirstOrDefaultAsync<UserEntity>(sql, new { id });
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<UserEntity> UpdateAsync(UserEntity item)
        {
            string sql = @"UPDATE users SET
                           NM_USER = @Name,
                           DT_BIRTH = @BirthDay, 
                           TXT_LOGIN = @Login,
                           TXT_PWD = @Password,
                           DT_UPDATED = @UpdatedAt
                           WHERE ID = @Id;";

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    item.UpdatedAt = DateTime.Now;
                    connection.Open();
                    await connection.ExecuteAsync(sql, item);
                }
                finally
                {
                    connection.Close();
                }
                return item;
            }
        }
    }
}

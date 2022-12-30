using Dapper;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Infrastructure.Repositories.MySql
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IConfiguration Configuration;
        private string ConnectionString;
        public AddressRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DubaiSmokeDb");
        }

        public async Task<bool> DeleteAsync(long id)
        {
            string sql = @"UPDATE address SET
                           DT_DELETED = @DeletedAt
                           WHERE ID = @Id";

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

        public async Task<List<AddressEntity>> GetAddressByUserId(long userId)
        {
            string sql = @"SELECT ad.*, u.*  FROM address AS ad
                            JOIN users u ON u.ID = ad.ID_USERS
                            WHERE ad.ID_USERS = @userId";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    var result = await connection.QueryAsync<AddressEntity, UserEntity, AddressEntity>(sql,
                        map: (a, u) =>
                        {
                            a.User = u;
                            return a;
                        },
                        splitOn: "ID",
                        param: new { userId = userId });
                    return result.ToList();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<long> InsertAsync(AddressEntity item)
        {
            var hash = Guid.NewGuid();
            string sql = @"INSERT INTO address (ID_USERS, TXT_ADDRESS, NR_ADDRESS, TXT_COMPLEMENT, TXT_POSTAL_CODE, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                            Values (@UserId, @AddressName, @AddressNumber, @AddressComplement,@PostalCode, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                                SELECT ID FROM address WHERE HASH_CODE = @HashCode";
            using var connection = new MySqlConnection(ConnectionString);
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

        public async Task<AddressEntity> SelectAsync(long id)
        {
            string sql = @"SELECT * FROM address WHERE id = @Id;";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    return await connection.QuerySingleAsync<AddressEntity>(sql, new { id = id });
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<AddressEntity> UpdateAsync(AddressEntity item)
        {
            string sql = @"UPDATE address SET
                           TXT_ADDRESS = @AddressName,
                           NR_ADDRESS = @AddressNumber, 
                           TXT_COMPLEMENT = @AddressComplement,
                           TXT_POSTAL_CODE = @PostalCode,
                           DT_UPDATED = @UpdatedAt
                           WHERE ID_USER = @UserId;";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    item.UpdatedAt = DateTime.Now;
                    connection.Open();
                    await connection.ExecuteAsync(sql, item);
                    return item;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

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
    public class ContactRepository : IContactRepository
    {
        private readonly IConfiguration Configuration;
        private string ConnectionString;
        public ContactRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DubaiSmokeDb");
        }

        public async Task<bool> DeleteAsync(long id)
        {
            string sql = @"UPDATE contacts SET
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

        public async Task<long> InsertAsync(ContactEntity item)
        {
            var hash = Guid.NewGuid();
            string sql = @"INSERT INTO contacts (ID_USER, ID_TYPE, TXT_VALUE, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                            Values (@UserId, @TypeId, @Value, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                                SELECT ID FROM contacts WHERE HASH_CODE = @HashCode";
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
        public async Task<ContactEntity> SelectAsync(long id)
        {
            string sql = @"SELECT * FROM contacts WHERE id = @id;";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    return await connection.QuerySingleAsync<ContactEntity>(sql, new { id = id });
                }
                finally 
                {
                    connection.Close();
                }
            }
        }

        public async Task<ContactEntity> UpdateAsync(ContactEntity item)
        {
            string sql = @"UPDATE contacts SET
                           ID_TYPE = @TypeId,
                           TXT_VALUE = @Value,
                           DT_UPDATED = @UpdatedAt
                           WHERE ID_USER = @UserId;";

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

        public async Task<List<ContactEntity>> SelectByUserIdAsync(long userId)
        {
            string sql = @"SELECT c.* , ct.* , u.* FROM contacts c 
                            JOIN contacts_type ct ON ct.ID = c.ID_TYPE
                            JOIN users u ON u.ID = c.ID_USER
                            WHERE c.ID_USER = @userId";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    var result = await connection.QueryAsync<ContactEntity, ContactTypeEntity, UserEntity, ContactEntity>(sql,
                        map: (c, ct, u) =>
                         {
                             c.ContactType = ct;
                             c.User = u;
                             return c;
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
    }
}

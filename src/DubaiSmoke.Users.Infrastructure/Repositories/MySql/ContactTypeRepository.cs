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
    public class ContactTypeRepository : IContactTypeRepository
    {
        private readonly IConfiguration Configuration;
        private string ConnectionString;
        public ContactTypeRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DubaiSmokeDb");
        }

        public async Task<bool> DeleteAsync(long id)
        {
            string sql = @"UPDATE contacts_type SET
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

        public async Task<long> InsertAsync(ContactTypeEntity item)
        {
            var hash = Guid.NewGuid();
            string sql = @"INSERT INTO contacts_type (TXT_NAME, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                            Values (@Name, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                                SELECT ID FROM contacts_type WHERE HASH_CODE = @HashCode";
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

        public async Task<ContactTypeEntity> SelectAsync(long id)
        {
            string sql = @"SELECT * FROM contacts_type WHERE id = @Id;";
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    return await connection.QuerySingleAsync<ContactTypeEntity>(sql, new { id = id });
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public async Task<ContactTypeEntity> UpdateAsync(ContactTypeEntity item)
        {
            string sql = @"UPDATE contacts_type SET
                           TXT_NAME = @Name,
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

using Dapper;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Infrastructure.Repositories.MySql
{
    public class UserRepository : IUserRepository
    {
        readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            string sql = @"UPDATE users SET
                           DT_DELETED = @DeletedAt
                           WHERE ID = @Id;";

            return await _unitOfWork.Connection.ExecuteAndReturnBoolAsync(sql, new { DeletedAt = DateTime.Now, Id = id });
        }

        public async Task<long> InsertAsync(UserEntity item)
        {
            string sql = @"INSERT INTO users (NM_USER, DT_BIRTH, TXT_LOGIN, TXT_PWD, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                            Values (@Name, @BirthDay, @Login, @Password, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                                SELECT ID FROM users WHERE HASH_CODE = @HashCode";

            item.HashCode = Guid.NewGuid().ToString();
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<long>(sql, item);
        }

        public async Task<bool> LoginAsync(UserEntity user)
        {
            string sql = @"SELECT HASH_CODE FROM users WHERE TXT_LOGIN = @email AND TXT_PWD = @password";

            if (await _unitOfWork.Connection.QueryFirstOrDefaultAsync(sql, new { email = user.Login, password = user.Password }) is null)
                return false;

            return true;
        }

        public async Task<UserEntity> SelectAsync(long id)
        {
            string sql = @"SELECT * FROM users WHERE ID = @id;";

            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<UserEntity>(sql, new { id });
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

            item.UpdatedAt = DateTime.Now;
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<UserEntity>(sql, item);
        }
    }
}

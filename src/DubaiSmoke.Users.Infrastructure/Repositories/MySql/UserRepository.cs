using Dapper;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using Repositories.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Infrastructure.Repositories.MySql
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {
        readonly IUnitOfWork _unitOfWork;

        public UserRepository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> DeleteAsync(long id) => await _unitOfWork.Connection.ExecuteAndReturnBoolAsync(
                @"DELETE FROM users WHERE ID = @Id;", new { id });

        public async Task<long> InsertAsync(UserEntity item) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<long>(
                @"INSERT INTO users (NM_USER, DT_BIRTH, TXT_LOGIN, TXT_PWD, DT_CREATED, DT_UPDATED, HASH_CODE)
                  VALUES (@Name, @BirthDay, @Login, @Password, @CreatedAt, @UpdatedAt, @HashCode);
                  SELECT ID FROM users WHERE HASH_CODE = @HashCode", item);

        public async Task<bool> LoginAsync(UserEntity user)
        {
            if (await _unitOfWork.Connection.QueryFirstOrDefaultAsync(@"SELECT ID FROM users WHERE TXT_LOGIN = @email AND TXT_PWD = @password",
                new { email = user.Login, password = user.Password }) is null) return false;

            return true;
        }

        public async Task<UserEntity> SelectAsync(long id) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<UserEntity>(
                @"SELECT * FROM users WHERE ID = @id;", new { id });

        public async Task<bool> UpdateAsync(UserEntity item) => await _unitOfWork.Connection.ExecuteAndReturnBoolAsync(
                @"UPDATE users SET NM_USER = @Name, DT_BIRTH = @BirthDay, TXT_LOGIN = @Login, TXT_PWD = @Password, DT_UPDATED = @UpdatedAt
                  WHERE ID = @Id; SELECT * FROM users WHERE ID = @id; ", item);
    }
}

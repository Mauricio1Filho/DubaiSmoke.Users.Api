using Dapper;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Infrastructure.Repositories.MySql
{
    [ExcludeFromCodeCoverage]
    public class AddressRepository : IAddressRepository
    {
        readonly IUnitOfWork _unitOfWork;

        public AddressRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            string sql = @"UPDATE address SET
                           DT_DELETED = @DeletedAt
                           WHERE ID = @Id";

            return await _unitOfWork.Connection.ExecuteAndReturnBoolAsync(sql, new { DeletedAt = DateTime.Now, Id = id });
        }

        public async Task<List<AddressEntity>> GetAddressByUserId(long userId)
        {
            string sql = @"SELECT ad.*, u.*  FROM address AS ad
                            JOIN users u ON u.ID = ad.ID_USERS
                            WHERE ad.ID_USERS = @userId";

            var result = await _unitOfWork.Connection.QueryAsync<AddressEntity, UserEntity, AddressEntity>(sql,
                map: (a, u) =>
                {
                    a.User = u;
                    return a;
                },
                splitOn: "ID",
                param: new { userId });
            return result.ToList();
        }

        public async Task<long> InsertAsync(AddressEntity item)
        {
            string sql = @"INSERT INTO address (ID_USERS, TXT_ADDRESS, NR_ADDRESS, TXT_COMPLEMENT, TXT_POSTAL_CODE, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                            Values (@UserId, @AddressName, @AddressNumber, @AddressComplement,@PostalCode, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                                SELECT ID FROM address WHERE HASH_CODE = @HashCode";

            item.HashCode = Guid.NewGuid().ToString();
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<long>(sql, item);
        }

        public async Task<AddressEntity> SelectAsync(long id)
        {
            string sql = @"SELECT * FROM address WHERE id = @Id;";

            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<AddressEntity>(sql, new { id });
        }

        public async Task<AddressEntity> UpdateAsync(AddressEntity item)
        {
            string sql = @"UPDATE address SET
                           TXT_ADDRESS = @AddressName,
                           NR_ADDRESS = @AddressNumber, 
                           TXT_COMPLEMENT = @AddressComplement,
                           TXT_POSTAL_CODE = @PostalCode,
                           DT_UPDATED = @UpdatedAt
                           WHERE ID_USERS = @UserId;";

            item.UpdatedAt = DateTime.Now;
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<AddressEntity>(sql, item);
        }
    }
}

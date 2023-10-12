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

        public AddressRepository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> DeleteAsync(long id) => await _unitOfWork.Connection.ExecuteAndReturnBoolAsync(
                @"UPDATE address SET DT_DELETED = @DeletedAt WHERE ID = @Id", new { DeletedAt = DateTime.Now, Id = id });

        public async Task<List<AddressEntity>> GetAddressByUserId(long userId) => (await _unitOfWork.Connection.QueryAsync<AddressEntity, UserEntity, AddressEntity>(
                @"SELECT ad.*, u.*  FROM address AS ad JOIN users u ON u.ID = ad.ID_USER WHERE ad.ID_USER = @userId",
                  map: (a, u) => { a.User = u; return a; }, splitOn: "ID", param: new { userId })).ToList();

        public async Task<long> InsertAsync(AddressEntity item) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<long>(
                @"INSERT INTO address (ID_USER, TXT_ADDRESS, NR_ADDRESS, TXT_COMPLEMENT, TXT_POSTAL_CODE, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                  Values (@UserId, @AddressName, @AddressNumber, @AddressComplement,@PostalCode, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                  SELECT ID FROM address WHERE HASH_CODE = @HashCode", item);

        public async Task<AddressEntity> SelectAsync(long id) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<AddressEntity>(
                @"SELECT * FROM address WHERE id = @Id;", new { id });

        public async Task<AddressEntity> UpdateAsync(AddressEntity item) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<AddressEntity>(
                @"UPDATE address SET TXT_ADDRESS = @AddressName, NR_ADDRESS = @AddressNumber, TXT_COMPLEMENT = @AddressComplement,
                  TXT_POSTAL_CODE = @PostalCode, DT_UPDATED = @UpdatedAt WHERE ID_USER = @UserId; SELECT * FROM address WHERE ID_USER = @UserId;", item);
    }
}

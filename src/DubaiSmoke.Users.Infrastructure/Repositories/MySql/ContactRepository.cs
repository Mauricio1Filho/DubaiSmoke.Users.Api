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
    public class ContactRepository : IContactRepository
    {
        readonly IUnitOfWork _unitOfWork;

        public ContactRepository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> DeleteAsync(long id) => await _unitOfWork.Connection.ExecuteAndReturnBoolAsync(
                @"UPDATE contacts SET DT_DELETED = @DeletedAt WHERE ID = @Id;", new { DeletedAt = DateTime.Now, Id = id });

        public async Task<long> InsertAsync(ContactEntity item) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<long>(
                @"INSERT INTO contacts (ID_USER, ID_TYPE, TXT_VALUE, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                  Values (@UserId, @TypeId, @Value, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                  SELECT ID FROM contacts WHERE HASH_CODE = @HashCode", item);

        public async Task<ContactEntity> SelectAsync(long id) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ContactEntity>(
                @"SELECT * FROM contacts WHERE id = @id;", new { id });

        public async Task<ContactEntity> UpdateAsync(ContactEntity item) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ContactEntity>(
                @"UPDATE contacts SET ID_TYPE = @TypeId, TXT_VALUE = @Value, DT_UPDATED = @UpdatedAt
                  WHERE ID_USER = @UserId; SELECT * FROM contacts WHERE ID_USER = @UserId;", item);

        public async Task<List<ContactEntity>> SelectByUserIdAsync(long userId) => (await _unitOfWork.Connection.QueryAsync<ContactEntity, ContactTypeEntity, UserEntity, ContactEntity>(
                @"SELECT c.* , ct.* , u.* FROM contacts c JOIN contacts_type ct ON ct.ID = c.ID_TYPE JOIN users u ON u.ID = c.ID_USER
                  WHERE c.ID_USER = @userId", map: (c, ct, u) => { c.ContactType = ct; c.User = u; return c; }, splitOn: "ID", param: new { userId })).ToList();
    }
}

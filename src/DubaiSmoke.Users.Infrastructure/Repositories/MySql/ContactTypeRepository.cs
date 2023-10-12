using Dapper;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using Repositories.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Infrastructure.Repositories.MySql
{
    [ExcludeFromCodeCoverage]
    public class ContactTypeRepository : IContactTypeRepository
    {
        readonly IUnitOfWork _unitOfWork;

        public ContactTypeRepository(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<bool> DeleteAsync(long id) => await _unitOfWork.Connection.ExecuteAndReturnBoolAsync(
                @"UPDATE contacts_type SET DT_DELETED = @DeletedAt WHERE ID = @Id;", new { DeletedAt = DateTime.Now, Id = id });

        public async Task<long> InsertAsync(ContactTypeEntity item) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<long>(
                @"INSERT INTO contacts_type (TXT_NAME, DT_CREATED, DT_UPDATED, DT_DELETED, HASH_CODE)
                  VALUES (@Name, @CreatedAt, @UpdatedAt, @DeletedAt, @HashCode);
                  SELECT ID FROM contacts_type WHERE HASH_CODE = @HashCode", item);

        public async Task<ContactTypeEntity> SelectAsync(long id) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ContactTypeEntity>(
                @"SELECT * FROM contacts_type WHERE id = @Id;", new { id });

        public async Task<ContactTypeEntity> UpdateAsync(ContactTypeEntity item) => await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ContactTypeEntity>(
                @"UPDATE contacts_type SET TXT_NAME = @Name, DT_UPDATED = @UpdatedAt WHERE ID = @Id; SELECT * FROM contacts_type WHERE id = @Id;", item);
    }
}

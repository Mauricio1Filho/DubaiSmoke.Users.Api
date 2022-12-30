using DubaiSmoke.Users.Domain.Aggregates;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Infrastructure.Repositories.Mongo
{
    //public class UserAggregateRepository : IUserAggregateRepository
    //{
    //    private readonly IMongoDatabase _mongoDataBase;
    //    const string collectionName = "users";
    //    public UserAggregateRepository(IMongoConfigSettings mongoConfigSettings)
    //    {
    //        _mongoDataBase  =  mongoConfigSettings.GetDatabase();
    //    }

    //    public async Task<string> InsertAsync(UserAggregate user)
    //    {
    //        await _mongoDataBase.GetCollection<UserAggregate>(collectionName).InsertOneAsync(user);
    //        return string.Empty;
           
    //    }     
    //}
}

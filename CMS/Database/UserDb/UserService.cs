using CMS.Models.User;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Database.UserDb
{
    /// <summary>
    /// userservice 
    /// </summary>
    public interface IUserService
    {

    }
    public class UserService : IUserService
    {


        private readonly IMongoCollection<UserMain> _userCollection;

        /// <summary>
        /// instance is retrieved from DI via constructor injection. 
        /// </summary>
        /// <param name="UserDbSettings"></param>
        public UserService(
            IOptions<UserDbSettings> userDbSettings)
        {
            var mongoClient = new MongoClient(
                userDbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                userDbSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<UserMain>(
                userDbSettings.Value.CollectionName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserMain>> GetAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<UserMain> GetAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserMain newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, UserMain updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task RemoveAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}

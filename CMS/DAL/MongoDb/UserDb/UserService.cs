using CMS.DAL.MongoDb;
using CMS.Models.User;
using Microsoft.AspNetCore.Mvc;
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


        public readonly IMongoCollection<User> _userCollection;

        /// <summary>
        /// instance is retrieved from DI via constructor injection. 
        /// </summary>
        /// <param name="UserDbSettings"></param>
        public UserService(
           DbInitialization dbInit)
        {
         _userCollection = dbInit._userCollection;
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAsync() =>
            await _userCollection.Find(_ => true).ToListAsync();

        public async Task<UserMain> GetAsync(string id) =>
            await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<User> GetMail(string email) =>
            await _userCollection.Find(x => x.EmailAddress == email).FirstOrDefaultAsync();
            
        public async Task CreateAsync(User newUser) =>
            await _userCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, User updatedUser) =>
            await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task RemoveAsync(string id) =>
            await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}

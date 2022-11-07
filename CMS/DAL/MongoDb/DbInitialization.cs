using CMS.Database.CMSDb;
using CMS.Models.DbModels;
using CMS.Models.Application;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Data.Common;
using System.Runtime;
using CMS.Database.UserDb;
using CMS.Models.User;

namespace CMS.DAL.MongoDb
{
    public class DbInitialization
    {
        public IMongoCollection<UserReq> _csrCollection;
        public IMongoCollection<User> _userCollection;

        public DbInitialization(IOptions<DatabaseSettings> DbSettings) {

            var mongoClient = new MongoClient(
                   DbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                DbSettings.Value.DatabaseName);

            _csrCollection = mongoDatabase.GetCollection<UserReq>(
               DbSettings.Value.CSRCollection);

            //User
            var mongoDatabase1 = mongoClient.GetDatabase(
               DbSettings.Value.UDatabaseName);

            _userCollection = mongoDatabase1.GetCollection<User>(
                DbSettings.Value.CollectionName);
        }
       
    }
}

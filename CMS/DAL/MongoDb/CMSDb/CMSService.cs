using CMS.DAL.MongoDb;
using CMS.Database.UserDb;
using CMS.Models;
using CMS.Models.Application;
using CMS.Models.User;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Database.CMSDb
{
    public class CMSService
    {
        private IMongoCollection<UserReq> _csrCollection;
        
        /// <summary>
        /// Constructor for CSRDatabase & Data Access
        /// </summary>
        /// <param name="dbInit">
        /// MongoDb connection instance
        /// </param>
        public CMSService(DbInitialization dbInit)
        {


            _csrCollection = dbInit._csrCollection;


        }
        public async Task<List<UserReq>> GetAsync() =>
            await _csrCollection.Find(_ => true).ToListAsync();

        public async Task<UserReq> GetAsync(string id) =>
            await _csrCollection.Find(x => x.userId == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserReq newCSR) =>
           await _csrCollection.InsertOneAsync(newCSR);



    }
}

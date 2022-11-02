using CMS.Database.UserDb;
using CMS.Models.CMS;
using CMS.Models.User;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CMS.Database.CMSDb
{
    public class CMSService
    {
        private IMongoCollection<CSR> _csrCollection;

        public CMSService(IOptions<DatabaseSettings> cmsDbSettings)
        {
            var mongoClient = new MongoClient(
               cmsDbSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                cmsDbSettings.Value.DatabaseName);

            _csrCollection = mongoDatabase.GetCollection<CSR>(
                cmsDbSettings.Value.CSRCollection);


        }
    }
}

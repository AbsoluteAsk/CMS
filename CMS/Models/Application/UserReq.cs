using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Security.Policy;

namespace CMS.Models.Application
{
    public class UserReq
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string userId { get; set; } = string.Empty;


        public string[] ECUIdentifier { get; set; }


        public bool has_gen_req { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace CMS.Models.CMS
{
    public class CSR
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("ecuIdentifier")]
        public string ECUIdentifier { get; set; } = String.Empty;

        [BsonElement("orgId")]
        public string OrgId { get; set; } = String.Empty;
    }
}

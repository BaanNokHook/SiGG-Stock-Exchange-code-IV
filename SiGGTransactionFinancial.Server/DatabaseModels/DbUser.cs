using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SiGGTransactionFinancial.Server.DatabaseModels
{
    public class DbUser
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string HashedEmail { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string HashedPassword { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string EncryptedData { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Created { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Updated { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? Confirmed { get; set; }

        public List<string> Roles { get; set; } = new List<string>();

        public Dictionary<string, string> Claims { get; set; } = new Dictionary<string, string>();

    }
}
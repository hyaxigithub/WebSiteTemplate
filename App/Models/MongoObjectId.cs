using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Models
{
    public class MongoObjectId
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string ObjectId { get; set; }
    }
}
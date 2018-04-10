

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Models
{
    public partial class AspNetRolesMongo
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        public object _id { get; set; }
       
        public int CustomerId { get; set; }
        public string Name { get; set; }
        
    }
}

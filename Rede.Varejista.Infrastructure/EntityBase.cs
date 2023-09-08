using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rede.Varejista.Infrastructure
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
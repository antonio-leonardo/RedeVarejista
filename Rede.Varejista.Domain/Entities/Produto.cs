using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rede.Varejista.Infrastructure;

namespace Rede.Varejista.Domain.Entities
{
    public class Produto : IEntity
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NomeProduto { get; set; }

        public Produto()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
    }
}

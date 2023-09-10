using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rede.Varejista.Infrastructure;

namespace Rede.Varejista.Domain.Entities
{
    public class Categoria : IEntity
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NomeCategoria { get; set; }

        public List<Produto> Produtos { get; set; }

        public Categoria()
        {
            this.Id = ObjectId.GenerateNewId().ToString();        
        }
    }
}

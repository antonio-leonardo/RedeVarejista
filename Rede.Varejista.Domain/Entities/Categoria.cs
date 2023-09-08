using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rede.Varejista.Infrastructure;

namespace Rede.Varejista.Domain.Entities
{
    public class Categoria : EntityBase
    {

        public string NomeCategoria { get; set; }

        public IList<Produto> Produtos { get; set; }
    }
}

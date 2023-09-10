using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Infrastructure;
using Rede.Varejista.Repository.CQRS;

namespace Rede.Varejista.Domain.Services.Facade
{
    public class CategoriaCommandServiceFacade : CommandRepository<Categoria>
    {
        public CategoriaCommandServiceFacade(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
        {
        }

        public void AdicionarProdutoNumaCategoria(string id, Produto produto)
        {
            var filter = Builders<Categoria>.Filter.Eq(x => x.Id, id);
            var insert = Builders<Categoria>.Update.AddToSet(c => c.Produtos, produto);
            this._entityCollection.UpdateOne(filter, insert);
        }

        public void AlterarProdutoNumaCategoria(string id, Produto produto)
        {
            var filter = Builders<Categoria>.Filter.Eq(x => x.Id, id)
                        & Builders<Categoria>.Filter.ElemMatch(e => e.Produtos, p => p.Id == produto.Id);
            var update = Builders<Categoria>.Update.Set("Produtos.$.NomeProduto", produto.NomeProduto);
            this._entityCollection.UpdateOne(filter, update);
        }
    }
}
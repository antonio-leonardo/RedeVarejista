using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Infrastructure;
using Rede.Varejista.Repository.CQRS;

namespace Rede.Varejista.Domain.Services.Facade
{
    public class CategoriaQueryServiceFacade : QueryRepository<Categoria>
    {
        public CategoriaQueryServiceFacade(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
        {
        }

        public void DeletarUmProdutoDeUmaCategoria(string idCategoria, Produto produto)
        {
            var filter = Builders<Categoria>.Filter.Eq(c => c.Id, idCategoria);
            var update = Builders<Categoria>.Update.PullFilter(p => p.Produtos, prod => prod.Id == produto.Id);
            UpdateResult updateResult = this._entityCollection.UpdateOne(filter, update);
        }
    }
}
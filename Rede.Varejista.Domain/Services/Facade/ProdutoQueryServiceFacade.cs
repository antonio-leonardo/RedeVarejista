using Microsoft.Extensions.Options;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Infrastructure;
using Rede.Varejista.Repository;

namespace Rede.Varejista.Domain.Services.Facade
{
    public class ProdutoQueryServiceFacade : QueryRepository<Produto>
    {
        public ProdutoQueryServiceFacade(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
        {
        }
    }
}
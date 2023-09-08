using Microsoft.Extensions.Options;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Infrastructure;
using Rede.Varejista.Repository;

namespace Rede.Varejista.Domain.Services.Facade
{
    public class CategoriaQueryServiceFacade : QueryRepository<Categoria>
    {
        public CategoriaQueryServiceFacade(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
        {
        }
    }
}
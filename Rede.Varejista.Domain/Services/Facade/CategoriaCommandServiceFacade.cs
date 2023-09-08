using Microsoft.Extensions.Options;
using Rede.Varejista.Domain.Entities;
using Rede.Varejista.Infrastructure;
using Rede.Varejista.Repository;

namespace Rede.Varejista.Domain.Services.Facade
{
    public class CategoriaCommandServiceFacade : CommandRepository<Categoria>
    {
        public CategoriaCommandServiceFacade(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
        {
        }
    }
}
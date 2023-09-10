using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rede.Varejista.Infrastructure;
using Rede.Varejista.Repository.CQRS.Interface;

namespace Rede.Varejista.Repository.CQRS
{
    public class QueryRepository<TEntity> : Repository<TEntity>, IQueryRepository<TEntity>
        where TEntity : IEntity
    {
        public QueryRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
        {
        }

        public void Deletar(string id)
        {
            _entityCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq(x => x.Id, id)).GetAwaiter().GetResult();
        }

        public List<TEntity> Listar()
        {
            return _entityCollection.Find(Builders<TEntity>.Filter.Empty).ToList();
        }

        public TEntity Obter(string id)
        {
            return _entityCollection.Find(Builders<TEntity>.Filter.Eq(x => x.Id, id)).FirstOrDefault();
        }
    }
}
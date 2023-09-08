using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rede.Varejista.Infrastructure;

namespace Rede.Varejista.Repository
{
    public class Repository<TEntity>
        where TEntity : EntityBase
    {
        protected internal readonly IMongoCollection<TEntity> _entityCollection;
        public Repository(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _entityCollection = mongoDatabase.GetCollection<TEntity>(
                databaseSettings.Value.CollectionName);
        }
    }
}
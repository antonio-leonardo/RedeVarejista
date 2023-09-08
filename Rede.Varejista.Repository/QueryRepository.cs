using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rede.Varejista.Infrastructure;
using Rede.Varejista.Repository.CQRS;

namespace Rede.Varejista.Repository
{
    public class QueryRepository<TEntity> : Repository<TEntity>, IQueryRepository<TEntity>
        where TEntity : EntityBase
    {
        public QueryRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
        {
        }

        public void Deletar(string id)
        {
            this._entityCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq(x => x.Id, id)).GetAwaiter().GetResult();
        }

        public List<TEntity> Listar()
        {
            return this._entityCollection.Find(_ => true).ToList();
        }

        public TEntity Obter(string id)
        {
            return this._entityCollection.Find(Builders<TEntity>.Filter.Eq(x => x.Id, id)).FirstOrDefault();
        }
    }
}
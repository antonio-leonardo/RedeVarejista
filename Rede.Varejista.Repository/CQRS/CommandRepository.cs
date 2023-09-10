using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rede.Varejista.Infrastructure;
using Rede.Varejista.Repository.CQRS.Interface;

namespace Rede.Varejista.Repository.CQRS
{
    public class CommandRepository<TEntity> : Repository<TEntity>, ICommandRepository<TEntity>
        where TEntity : IEntity
    {
        public CommandRepository(IOptions<DatabaseSettings> databaseSettings) : base(databaseSettings)
        {
        }

        public void Adicionar(TEntity entity)
        {
            _entityCollection.InsertOne(entity);
        }

        public void Atualizar(string id, TEntity entity)
        {
            _entityCollection.ReplaceOne(Builders<TEntity>.Filter.Eq(x => x.Id, id), entity);
        }
    }
}
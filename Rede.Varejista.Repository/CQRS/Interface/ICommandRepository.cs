using Rede.Varejista.Infrastructure;

namespace Rede.Varejista.Repository.CQRS.Interface
{
    public interface ICommandRepository<TEntity>
        where TEntity : IEntity //EntityBase
    {
        void Adicionar(TEntity entity);
        void Atualizar(string id, TEntity entity);
    }
}
using Rede.Varejista.Infrastructure;

namespace Rede.Varejista.Repository.CQRS
{
    public interface ICommandRepository<TEntity>
        where TEntity : EntityBase
    {
        void Adicionar(TEntity entity);
        void Atualizar(string id, TEntity entity);
    }
}
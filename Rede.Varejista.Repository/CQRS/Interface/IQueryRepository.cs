using Rede.Varejista.Infrastructure;

namespace Rede.Varejista.Repository.CQRS.Interface
{
    public interface IQueryRepository<TEntity>
        where TEntity : IEntity //EntityBase
    {
        TEntity Obter(string id);

        List<TEntity> Listar();

        void Deletar(string id);
    }
}
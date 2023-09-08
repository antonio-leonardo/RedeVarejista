using Rede.Varejista.Infrastructure;

namespace Rede.Varejista.Repository.CQRS
{
    public interface IQueryRepository<TEntity>
        where TEntity : EntityBase
    {
        TEntity Obter(string id);

        List<TEntity> Listar();

        void Deletar(string id);
    }
}
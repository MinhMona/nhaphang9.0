using Domain.Entities.DomainEntities;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IDomainRepository<E> Repository<E>() where E : BaseEntity;
        //IQueryRepository QueryRepository();
        Task<bool> Complete();
    }
}

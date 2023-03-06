using DataAccess.Repo.BaseRepository.CommandRepository;
using DataAccess.Repo.BaseRepository.QueryableRepository;
using Entities.Base;

namespace DataAccess.Repo.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<IQueryableRepository<T>> QueryableRepositories<T>() where T : BaseEntity<Guid>;
        Task<ICommandRepository<T>> CommandRepositories<T>() where T : BaseEntity<Guid>;
        Task SaveChangesAsync();
        void Dispose();
    }
}
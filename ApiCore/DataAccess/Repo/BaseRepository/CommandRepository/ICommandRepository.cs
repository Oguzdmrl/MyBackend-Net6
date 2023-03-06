using Core.Results;
using Entities.Base;

namespace DataAccess.Repo.BaseRepository.CommandRepository
{
    public interface ICommandRepository<T> where T : BaseEntity<Guid>
    {
        Task<ResponseDataResult<T>> Insert(T entity);
        Task<ResponseDataResult<T>> Update(T entity);
        Task<ResponseDataResult<T>> Delete(T entity);
    }
}
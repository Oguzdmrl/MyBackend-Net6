using Core.Results;
using Entities.Base;

namespace DataAccess.Repo.BaseRepository.CommandRepository
{
    public interface ICommandRepository<T> where T : BaseEntity<Guid>
    {
        Task<ResponseDataResult<T>> InsertAsync(T entity);
        Task<ResponseDataResult<T>> UpdateAsync(T entity);
        Task<ResponseDataResult<T>> DeleteAsync(T entity);
    }
}
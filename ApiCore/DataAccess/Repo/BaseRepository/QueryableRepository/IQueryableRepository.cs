using Core.Results;
using Entities.Base;
using System.Linq.Expressions;

namespace DataAccess.Repo.BaseRepository.QueryableRepository
{
    public interface IQueryableRepository<T> where T : BaseEntity<Guid>
    {
        Task<ResponseDataResult<T>> GetAsync(Guid ID);
        Task<ResponseDataResult<T>> GetAllAsync();
        Task<ResponseDataResult<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<ResponseDataResult<T>> GetAllInculudeAsync(Expression<Func<T, object>>[] Parametre);
        Task<ResponseDataResult<T>> GetAllInculudeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] Parametre);
    }
}
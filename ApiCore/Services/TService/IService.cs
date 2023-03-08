using Core.Results;
using System.Linq.Expressions;

namespace Business.TService
{
    public interface IService<T>
    {
        Task<ResponseDataResult<T>> GetAsync(Guid ID);
        Task<ResponseDataResult<T>> GetAllAsync();
        Task<ResponseDataResult<T>> GetAllAsync(Expression<Func<T, bool>> parametre);
        Task<ResponseDataResult<T>> GetAllInculudeAsync(params Expression<Func<T, object>>[] Parametre);
        Task<ResponseDataResult<T>> GetAllInculudeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] Parametre);
        Task<ResponseDataResult<T>> InsertAsync(T entity);
        Task<ResponseDataResult<T>> UpdateAsync(T entity);
        Task<ResponseDataResult<T>> DeleteAsync(T entity);
    }
}
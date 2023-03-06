using Core.Results;
using System.Linq.Expressions;

namespace Services.TService
{
    public interface IService<T>
    {
        Task<ResponseDataResult<T>> Get(Guid ID);
        Task<ResponseDataResult<T>> GetAll();
        Task<ResponseDataResult<T>> GetAll(Expression<Func<T, bool>> parametre);
        Task<ResponseDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre);
        Task<ResponseDataResult<T>> Insert(T entity);
        Task<ResponseDataResult<T>> Update(T entity);
        Task<ResponseDataResult<T>> Delete(T entity);
    }
}
using Core.Results;
using Entities.Base;
using System.Linq.Expressions;

namespace DataAccess.Repo.BaseRepository.QueryableRepository
{
    public interface IQueryableRepository<T> where T : BaseEntity<Guid>
    {
        Task<ResponseDataResult<T>> Get(Guid ID);
        Task<ResponseDataResult<T>> GetAll();
        Task<ResponseDataResult<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<ResponseDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre);
    }
}
using Core.Results;
using DataAccess.Repo.UnitOfWorks;
using Entities.Base;
using System.Linq.Expressions;

namespace Business.TService
{
    public class Service<T> : IService<T> where T : BaseEntity<Guid>
    {
        private readonly IUnitOfWork _uow;
        public Service(IUnitOfWork uow) => _uow = uow;

        public async Task<ResponseDataResult<T>> DeleteAsync(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.DeleteAsync(entity));
        public async Task<ResponseDataResult<T>> GetAsync(Guid ID) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAsync(ID));
        public async Task<ResponseDataResult<T>> GetAllAsync() => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAllAsync());
        public async Task<ResponseDataResult<T>> GetAllAsync(Expression<Func<T, bool>> parametre) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAllAsync(parametre));
        public async Task<ResponseDataResult<T>> GetAllInculudeAsync(params Expression<Func<T, object>>[] Parametre) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAllInculudeAsync(Parametre));
        public async Task<ResponseDataResult<T>> GetAllInculudeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] Parametre) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAllInculudeAsync(predicate, Parametre));
        public async Task<ResponseDataResult<T>> InsertAsync(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.InsertAsync(entity));
        public async Task<ResponseDataResult<T>> UpdateAsync(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.UpdateAsync(entity));
    }
}
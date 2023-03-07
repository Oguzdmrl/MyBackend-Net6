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

        public async Task<ResponseDataResult<T>> Delete(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.Delete(entity));
        public async Task<ResponseDataResult<T>> Get(Guid ID) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.Get(ID));
        public async Task<ResponseDataResult<T>> GetAll() => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAll());
        public async Task<ResponseDataResult<T>> GetAll(Expression<Func<T, bool>> parametre) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAll(parametre));
        public async Task<ResponseDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre) => await Task.FromResult(await _uow.QueryableRepositories<T>().Result.GetAllInculude(Parametre));
        public async Task<ResponseDataResult<T>> Insert(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.Insert(entity));
        public async Task<ResponseDataResult<T>> Update(T entity) => await Task.FromResult(await _uow.CommandRepositories<T>().Result.Update(entity));
    }
}
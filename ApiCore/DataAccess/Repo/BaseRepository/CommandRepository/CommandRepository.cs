using Core.Results;
using DataAccess.Repo.UnitOfWorks;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repo.BaseRepository.CommandRepository
{
    public partial class CommandRepository<T> : ICommandRepository<T> where T : BaseEntity<Guid>
    {
        protected AppDBContext _context;
        private readonly UnitOfWork _uow;
        public CommandRepository(AppDBContext context)
        {
            _context = context;
            _uow = new(context);
        }
        public virtual async Task<ResponseDataResult<T>> InsertAsync(T entity)
        {
            EntityEntry<T> result = await _context.Set<T>().AddAsync(entity);
            await _uow.SaveChangesAsync();
            return await Task.FromResult(new ResponseDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Ekleme İşlemi Başarılı." });
        }
        public virtual async Task<ResponseDataResult<T>> UpdateAsync(T entity)
        {
            EntityEntry<T> result = _context.Entry(entity);
            result.State = EntityState.Modified;
            await _uow.SaveChangesAsync();
            return await Task.FromResult(new ResponseDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Güncelleme İşlemi Başarılı." });
        }
        public virtual async Task<ResponseDataResult<T>> DeleteAsync(T entity)
        {
            EntityEntry<T> result = _context.Set<T>().Remove(entity);
            await _uow.SaveChangesAsync();
            return await Task.FromResult(new ResponseDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Silme İşlemi Başarılı." });
        }
    }
}
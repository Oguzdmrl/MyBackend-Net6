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
            try
            {
                EntityEntry<T> result = await _context.Set<T>().AddAsync(entity);
                await _uow.SaveChangesAsync();
                return await Task.FromResult(new ResponseDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Kayıt İşlemi Başarılı." });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseDataResult<T>() { Status = false, Message = $"Hata. {ex}" });
            }
        }
        public virtual async Task<ResponseDataResult<T>> UpdateAsync(T entity)
        {
            try
            {
                EntityEntry<T> result = _context.Entry(entity);
                result.State = EntityState.Modified;
                await _uow.SaveChangesAsync();
                return await Task.FromResult(new ResponseDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Güncelleme İşlemi Başarılı." });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseDataResult<T>() { Status = false, Message = $"Hata. {ex}" });
            }
        }
        public virtual async Task<ResponseDataResult<T>> DeleteAsync(T entity)
        {
            try
            {
                EntityEntry<T> result = _context.Set<T>().Remove(entity);
                await _uow.SaveChangesAsync();
                return await Task.FromResult(new ResponseDataResult<T>() { ResponseModel = result.Entity, Status = true, Message = "Silme İşlemi Başarılı." });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseDataResult<T>() { Status = false, Message = $"Hata. {ex}" });
            }
        }
      
        #region RangeAsync
        public virtual async Task<ResponseDataResult<T>> BulkInsertAsync(IEnumerable<T> entity)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entity);
                await _uow.SaveChangesAsync();
                return await Task.FromResult(new ResponseDataResult<T>() { Status = true, Message = "Toplu Kayıt İşlemi Başarılı." });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseDataResult<T>() { Status = false, Message = $"Hata. {ex}" });
            }
        }
        public virtual async Task<ResponseDataResult<T>> RemoveRangeAsync(IEnumerable<T> entity)
        {
            try
            {
                _context.Set<T>().RemoveRange(entity);
                await _uow.SaveChangesAsync();
                return await Task.FromResult(new ResponseDataResult<T>() { Status = true, Message = "Toplu Silme İşlemi Başarılı." });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseDataResult<T>() { Status = false, Message = $"Hata. {ex}" });
            }
        }
        public virtual async Task<ResponseDataResult<T>> UpdateRangeAsync(IEnumerable<T> entity)
        {
            try
            {
                _context.Set<T>().UpdateRange(entity);
                await _uow.SaveChangesAsync();
                return await Task.FromResult(new ResponseDataResult<T>() { Status = true, Message = "Toplu Güncelleme İşlemi Başarılı." });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new ResponseDataResult<T>() { Status = false, Message = $"Hata. {ex}" });
            }
        }
        #endregion

    }
}
using Core.Results;
using Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repo.BaseRepository.QueryableRepository
{
    public partial class QueryableRepository<T> : IQueryableRepository<T> where T : BaseEntity<Guid>
    {
        private ResponseDataResult<T> _response;
        private DbSet<T> Table;

        protected AppDBContext _context;
        public QueryableRepository(AppDBContext context)
        {
            _context = context;
            Table ??= _context.Set<T>();
            _response = new(false, "Veri bulunamadı");
        }

        public virtual async Task<ResponseDataResult<T>> Get(Guid ID)
        {
            return await Task.FromResult(new ResponseDataResult<T>() { ResponseModel = await _context.Set<T>().FirstOrDefaultAsync(p => p.ID == ID), Status = true, Message = "Listeleme İşlemi Başarılı." });
        }
        public virtual async Task<ResponseDataResult<T>> GetAll()
        {
            IEnumerable<T> Model = await _context.Set<T>().ToListAsync();
            if (Model.Count() == 0) return await Task.FromResult(_response);

            return await Task.FromResult(new ResponseDataResult<T>()
            {
                ListResponseModel = Model,
                Status = true,
                Message = "Listeleme İşlemi Başarılı.",
                ModelCount = Model.ToList().Count,
            });
        }
        public virtual async Task<ResponseDataResult<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> Model = await Table.Where(predicate).ToListAsync();

            if (Model.Count() == 0) return await Task.FromResult(_response);

            return await Task.FromResult(new ResponseDataResult<T>()
            {
                ListResponseModel = Model,
                Status = true,
                ModelCount = Model.ToList().Count,
                Message = $"Listeleme İşlemi Başarılı : [{Model.ToList().Count}] Adet Veri Çekildi"
            });
        }
        public async Task<ResponseDataResult<T>> GetAllInculude(params Expression<Func<T, object>>[] Parametre)
        {
            Parametre.ToList().ForEach(x => Table.Include(x).LoadAsync());
            IEnumerable<T> Model = Table;

            if (Model.Count() == 0) return await Task.FromResult(_response);

            return await Task.FromResult(new ResponseDataResult<T>()
            {
                ListResponseModel = Model,
                Status = true,
                ModelCount = Model.ToList().Count,
                Message = $"Listeleme İşlemi Başarılı : [{Model.ToList().Count}] Adet Veri Çekildi"
            });
        }
    }

}
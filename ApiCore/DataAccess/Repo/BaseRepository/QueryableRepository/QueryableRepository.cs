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
            _response = new(false, "İçerik boş");
        }
        public async Task<ResponseDataResult<T>> GetAsync(Guid ID)
        {
            return await Task.FromResult(new ResponseDataResult<T>() { ResponseModel = await Table.FindAsync(ID), Status = true, Message = "Listeleme İşlemi Başarılı." });
        }
        public async Task<ResponseDataResult<T>> GetAllAsync()
        {
            IEnumerable<T> Model = await Table.ToListAsync();
            if (Model.Count() == 0) return await Task.FromResult(_response);

            return await Task.FromResult(new ResponseDataResult<T>()
            {
                ListResponseModel = Model,
                Status = true,
                Message = "Listeleme İşlemi Başarılı.",
                ModelCount = Model.ToList().Count,
            });
        }
        public async Task<ResponseDataResult<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
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
        public async Task<ResponseDataResult<T>> GetAllInculudeAsync(params Expression<Func<T, object>>[] Parametre)
        {
            Parametre.ToList().ForEach(x => Table.Include(x).Load());
            IEnumerable<T> Model = Table;

            if (Model.Count() == 0)
                return await Task.FromResult(_response);

            return await Task.FromResult(new ResponseDataResult<T>()
            {
                ListResponseModel = Model,
                Status = true,
                ModelCount = Model.ToList().Count,
                Message = $"Listeleme İşlemi Başarılı : [{Model.ToList().Count}] Adet Veri Çekildi"
            });
        }

        public async Task<ResponseDataResult<T>> GetAllInculudeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] Parametre)
        {
            Parametre.ToList().ForEach(x => Table.Include(x).Load());
            IEnumerable<T> Model = Table.Where(predicate);
            if (Model.Count() == 0)
                return await Task.FromResult(_response);

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
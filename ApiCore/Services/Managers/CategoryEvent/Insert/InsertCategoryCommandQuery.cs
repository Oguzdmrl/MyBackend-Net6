using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.CategoryEvent.Insert
{
    public partial class InsertCategoryCommandQuery : IRequest<ResponseDataResult<Category>>
    {
        public string Name { get; set; }
    }
}
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.CategoryEvent.Select
{
    public partial class GetCategoryQuery : IRequest<ResponseDataResult<Category>>
    {
    }
    public partial class GetCategoryIDQuery : IRequest<ResponseDataResult<Category>>
    {
        public Guid CategoryID { get; set; }
    }
}
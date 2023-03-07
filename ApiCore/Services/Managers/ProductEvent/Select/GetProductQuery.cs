using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.ProductEvent.Select
{
    public partial class GetProductQuery : IRequest<ResponseDataResult<Product>>
    {
    }
    public partial class GetProductIDQuery : IRequest<ResponseDataResult<Product>>
    {
        public Guid ProductID { get; set; }
    }
}
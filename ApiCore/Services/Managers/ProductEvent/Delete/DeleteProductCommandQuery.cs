using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.ProductEvent.Delete
{
    public partial class DeleteProductCommandQuery : IRequest<ResponseDataResult<Product>>
    {
        public Guid ProductID { get; set; }
    }
}
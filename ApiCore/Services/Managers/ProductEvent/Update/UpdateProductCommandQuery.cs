using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.ProductEvent.Update
{
    public partial class UpdateProductCommandQuery : IRequest<ResponseDataResult<Product>>
    {
        public Guid ProductID { get; set; }
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
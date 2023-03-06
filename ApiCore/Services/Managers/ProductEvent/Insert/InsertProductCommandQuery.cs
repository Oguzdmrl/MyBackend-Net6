using Core.Results;
using Entities;
using MediatR;

namespace Services.Managers.ProductEvent.Insert
{
    public partial class InsertProductCommandQuery : IRequest<ResponseDataResult<Product>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
    }
}
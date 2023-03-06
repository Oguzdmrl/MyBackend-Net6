using Core.Results;
using Entities;
using MediatR;
using Services.TService;

namespace Services.Managers.ProductEvent.Insert
{
    public partial class InsertProductCommandHandler : IRequestHandler<InsertProductCommandQuery, ResponseDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public InsertProductCommandHandler(IService<Product> service) => _service = service;
        public async Task<ResponseDataResult<Product>> Handle(InsertProductCommandQuery request, CancellationToken cancellationToken)
        {
            Product _Product = new()
            {
                Name = request.Name,
                Description = request.Description,
                CategoryID = request.CategoryID
            };
            return await Task.FromResult(await _service.Insert(_Product));
        }
    }
}
using Core.Results;
using Entities;
using MediatR;
using Business.TService;

namespace Business.Managers.ProductEvent.Delete
{
    public partial class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandQuery, ResponseDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public DeleteProductCommandHandler(IService<Product> service) => _service = service;
        public async Task<ResponseDataResult<Product>> Handle(DeleteProductCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.Delete(new Product() { ID = request.ProductID }));
        }
    }
}
using Core.Results;
using Entities;
using MediatR;
using Business.TService;

namespace Business.Managers.ProductEvent.Select
{
    public partial class GetProductHandler : IRequestHandler<GetProductQuery, ResponseDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public GetProductHandler(IService<Product> service) => _service = service;

        public async Task<ResponseDataResult<Product>> Handle(GetProductQuery request, CancellationToken cancellation)
        {
            return await Task.FromResult(await _service.GetAllInculudeAsync(x => x.Category));
        }
    }
    public partial class GetProductIDHandler : IRequestHandler<GetProductIDQuery, ResponseDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public GetProductIDHandler(IService<Product> service) => _service = service;
        public async Task<ResponseDataResult<Product>> Handle(GetProductIDQuery request, CancellationToken cancellation)
        {
            return await Task.FromResult(await _service.GetAllAsync(x => x.ID == request.ProductID));
        }
    }
}
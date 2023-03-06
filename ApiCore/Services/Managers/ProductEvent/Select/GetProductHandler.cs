using Core.Results;
using Entities;
using MediatR;
using Services.TService;

namespace Services.Managers.ProductEvent.Select
{
    public partial class GetProductHandler : IRequestHandler<GetProductQuery, ResponseDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public GetProductHandler(IService<Product> service) => _service = service;

        public async Task<ResponseDataResult<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAllInculude(x=>x.Category));
        }
    }
    public partial class GetProductIDHandler : IRequestHandler<GetProductIDQuery, ResponseDataResult<Product>>
    {
        private readonly IService<Product> _service;
        public GetProductIDHandler(IService<Product> service) => _service = service;
        public async Task<ResponseDataResult<Product>> Handle(GetProductIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll(x => x.ID == request.ProductID));
        }
    }
}
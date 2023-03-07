using Core.Results;
using Entities;
using MediatR;
using Business.TService;

namespace Business.Managers.CategoryEvent.Select
{
    public partial class GetCategoryHandler : IRequestHandler<GetCategoryQuery, ResponseDataResult<Category>>
    {
        private readonly IService<Category> _service;
        public GetCategoryHandler(IService<Category> service) => _service = service;
        public async Task<ResponseDataResult<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll());
        }
    }
    public partial class GetCategoryIDHandler : IRequestHandler<GetCategoryIDQuery, ResponseDataResult<Category>>
    {
        private readonly IService<Category> _service;
        public GetCategoryIDHandler(IService<Category> service) => _service = service;
        public async Task<ResponseDataResult<Category>> Handle(GetCategoryIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll(x => x.ID == request.CategoryID));
        }
    }
}
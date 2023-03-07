using Core.Results;
using Entities;
using MediatR;
using Business.TService;

namespace Business.Managers.CategoryEvent.Insert
{
    public partial class InsertCategoryCommandHandler : IRequestHandler<InsertCategoryCommandQuery, ResponseDataResult<Category>>
    {
        private readonly IService<Category> _service;
        public InsertCategoryCommandHandler(Service<Category> service) => _service = service;
        public async Task<ResponseDataResult<Category>> Handle(InsertCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            Category _Category = new() { Name = request.Name };
            return await Task.FromResult(await _service.Insert(_Category));
        }
    }
}
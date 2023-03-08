using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.RoleEvent.Insert
{
    public partial class InsertRoleCommandHandler : IRequestHandler<InsertRoleCommandQuery, ResponseDataResult<Role>>
    {
        private readonly IService<Role> _service;
        public InsertRoleCommandHandler(IService<Role> service) => _service = service;
        public async Task<ResponseDataResult<Role>> Handle(InsertRoleCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.Insert(new Role() { Name = request.Name, Description = request.Description }));
        }
    }
}
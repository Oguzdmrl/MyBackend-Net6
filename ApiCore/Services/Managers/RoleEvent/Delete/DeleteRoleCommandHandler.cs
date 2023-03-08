using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.RoleEvent.Delete
{
    public partial class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandQuery, ResponseDataResult<Role>>
    {
        private readonly IService<Role> _service;
        public DeleteRoleCommandHandler(IService<Role> service) => _service = service;
        public async Task<ResponseDataResult<Role>> Handle(DeleteRoleCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.DeleteAsync(new Role() { ID = request.RoleID }));
        }
    }
}
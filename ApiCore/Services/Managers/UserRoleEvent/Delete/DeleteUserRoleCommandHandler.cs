using Business.Managers.UserRoleEvent.Delete;
using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserRoleEvent.Delete
{
    public partial class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommandQuery, ResponseDataResult<UserRole>>
    {
        private readonly IService<UserRole> _service;
        public DeleteUserRoleCommandHandler(IService<UserRole> service) => _service = service;
        public async Task<ResponseDataResult<UserRole>> Handle(DeleteUserRoleCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.Delete(new UserRole() { ID = request.UserRoleID }));
        }
    }
}
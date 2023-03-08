using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserRoleEvent.Insert
{
    public partial class InsertUserRoleCommandHandler : IRequestHandler<InsertUserRoleCommandQuery, ResponseDataResult<UserRole>>
    {
        private readonly IService<UserRole> _service;
        public InsertUserRoleCommandHandler(IService<UserRole> service) => _service = service;
        public async Task<ResponseDataResult<UserRole>> Handle(InsertUserRoleCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.Insert(new UserRole() { UserId = request.UserId, RoleId = request.RoleId }));
        }
    }
}
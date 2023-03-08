using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserRoleEvent.Select
{
    public partial class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, ResponseDataResult<UserRole>>
    {
        private readonly IService<UserRole> _service;
        public GetUserRoleHandler(IService<UserRole> service) => _service = service;
        public async Task<ResponseDataResult<UserRole>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll());
        }
    }
    public partial class GetUserRoleIDHandler : IRequestHandler<GetUserRoleIDQuery, ResponseDataResult<UserRole>>
    {
        private readonly IService<UserRole> _service;
        public GetUserRoleIDHandler(IService<UserRole> service) => _service = service;
        public async Task<ResponseDataResult<UserRole>> Handle(GetUserRoleIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll(x => x.ID == request.UserRoleID));
        }
    }
}
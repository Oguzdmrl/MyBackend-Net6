using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.RoleEvent.Select
{
    public partial class GetRoleHandler : IRequestHandler<GetRoleQuery, ResponseDataResult<Role>>
    {
        private readonly IService<Role> _service;
        public GetRoleHandler(IService<Role> service) => _service = service;
        public async Task<ResponseDataResult<Role>> Handle(GetRoleQuery request, CancellationToken cancellation)
        {
            return await Task.FromResult(await _service.GetAllAsync());
        }
    }
    public partial class GetRoleIDHandler : IRequestHandler<GetRoleIDQuery, ResponseDataResult<Role>>
    {
        private readonly IService<Role> _service;
        public GetRoleIDHandler(IService<Role> service) => _service = service;
        public async Task<ResponseDataResult<Role>> Handle(GetRoleIDQuery request, CancellationToken cancellation)
        {
            return await Task.FromResult(await _service.GetAllAsync(x => x.ID == request.RoleID));
        }
    }
}
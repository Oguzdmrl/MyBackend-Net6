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
        public async Task<ResponseDataResult<Role>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll());
        }
    }
    public partial class GetRoleIDHandler : IRequestHandler<GetRoleIDQuery, ResponseDataResult<Role>>
    {
        private readonly IService<Role> _service;
        public GetRoleIDHandler(IService<Role> service) => _service = service;
        public async Task<ResponseDataResult<Role>> Handle(GetRoleIDQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.GetAll(x => x.ID == request.RoleID));
        }
    }
}
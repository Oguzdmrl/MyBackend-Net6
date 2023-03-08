using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.RoleEvent.Update
{
    public partial class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandQuery, ResponseDataResult<Role>>
    {
        private readonly IService<Role> _service;
        public UpdateRoleCommandHandler(IService<Role> service) => _service = service;
        public async Task<ResponseDataResult<Role>> Handle(UpdateRoleCommandQuery request, CancellationToken cancellationToken)
        {
            var GetModel = await _service.GetAll(x => x.ID == request.RoleID);
            if (GetModel.ModelCount > 0)
            {
                GetModel.ListResponseModel.FirstOrDefault().Name = request.Name;
                GetModel.ListResponseModel.FirstOrDefault().Description = request.Description;
                GetModel.ListResponseModel.FirstOrDefault().Updated_Date = DateTime.Now;
            }
            return await Task.FromResult(await _service.Update(GetModel.ListResponseModel.FirstOrDefault()));
        }
    }
}
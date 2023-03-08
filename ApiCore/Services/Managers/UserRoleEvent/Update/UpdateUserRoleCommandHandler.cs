using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserRoleEvent.Update
{
    public partial class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandQuery, ResponseDataResult<UserRole>>
    {
        private readonly IService<UserRole> _service;
        public UpdateUserRoleCommandHandler(IService<UserRole> service) => _service = service;
        public async Task<ResponseDataResult<UserRole>> Handle(UpdateUserRoleCommandQuery request, CancellationToken cancellationToken)
        {
            var GetModel = await _service.GetAllAsync(x => x.ID == request.UserRoleID);
            if (GetModel.ModelCount > 0)
            {
                GetModel.ListResponseModel.FirstOrDefault().UserId = request.UserID;
                GetModel.ListResponseModel.FirstOrDefault().RoleId = request.RoleID;
                GetModel.ListResponseModel.FirstOrDefault().Updated_Date = DateTime.Now;
            }
            return await Task.FromResult(await _service.UpdateAsync(GetModel.ListResponseModel.FirstOrDefault()));
        }
    }
}
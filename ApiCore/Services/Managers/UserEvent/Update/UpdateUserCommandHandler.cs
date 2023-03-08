using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserEvent.Update
{
    public partial class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandQuery, ResponseDataResult<User>>
    {
        private readonly IService<User> _service;
        public UpdateUserCommandHandler(IService<User> service) => _service = service;
        public async Task<ResponseDataResult<User>> Handle(UpdateUserCommandQuery request, CancellationToken cancellationToken)
        {
            var GetModel = await _service.GetAll(x => x.ID == request.UserID);
            if (GetModel.ModelCount > 0)
            {
                GetModel.ListResponseModel.FirstOrDefault().Name = request.Name;
                GetModel.ListResponseModel.FirstOrDefault().Surname = request.Surname;
                GetModel.ListResponseModel.FirstOrDefault().Username = request.Username;
                GetModel.ListResponseModel.FirstOrDefault().Password = request.Password;
                GetModel.ListResponseModel.FirstOrDefault().Email = request.Email;
                GetModel.ListResponseModel.FirstOrDefault().Updated_Date = DateTime.Now;
            }
            return await Task.FromResult(await _service.Update(GetModel.ListResponseModel.FirstOrDefault()));
        }
    }
}
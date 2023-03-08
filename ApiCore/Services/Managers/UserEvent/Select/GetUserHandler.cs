using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserEvent.Select
{
    public partial class GetUserHandler : IRequestHandler<GetUserQuery, ResponseDataResult<User>>
    {
        private readonly IService<User> _service;
        public GetUserHandler(IService<User> service) => _service = service;
        public async Task<ResponseDataResult<User>> Handle(GetUserQuery request, CancellationToken cancellation)
        {
            return await Task.FromResult(await _service.GetAllAsync());
        }
    }
    public partial class GetUserIDHandler : IRequestHandler<GetUserIDQuery, ResponseDataResult<User>>
    {
        private readonly IService<User> _service;
        public GetUserIDHandler(IService<User> service) => _service = service;
        public async Task<ResponseDataResult<User>> Handle(GetUserIDQuery request, CancellationToken cancellation)
        {
            return await Task.FromResult(await _service.GetAllAsync(x => x.ID == request.UserID));
        }
    }
}
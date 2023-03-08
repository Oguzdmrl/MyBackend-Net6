using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserEvent.Delete
{
    public partial class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandQuery, ResponseDataResult<User>>
    {
        private readonly IService<User> _service;
        public DeleteUserCommandHandler(IService<User> service) => _service = service;
        public async Task<ResponseDataResult<User>> Handle(DeleteUserCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.DeleteAsync(new User() { ID = request.UserID }));
        }
    }
}
using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserEvent.Insert
{
    public partial class InsertUserCommandHandler : IRequestHandler<InsertUserCommandQuery, ResponseDataResult<User>>
    {
        private readonly IService<User> _service;
        public InsertUserCommandHandler(IService<User> service) => _service = service;
        public async Task<ResponseDataResult<User>> Handle(InsertUserCommandQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.Insert(new User()
            {
                Name = request.Name,
                Surname = request.Surname,
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            }));
        }
    }
}
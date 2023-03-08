using Business.TService;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.AuthEvent.Register
{
    public partial class InsertRegisterHandler : IRequestHandler<RegisterQuery, ResponseDataResult<User>>
    {
        private readonly IService<User> _service;
        public InsertRegisterHandler(IService<User> service) => _service = service;
        public async Task<ResponseDataResult<User>> Handle(RegisterQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _service.InsertAsync(new User()
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
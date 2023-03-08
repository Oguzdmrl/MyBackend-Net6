using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserEvent.Select
{
    public partial class GetUserQuery : IRequest<ResponseDataResult<User>>
    {
    }
    public partial class GetUserIDQuery : IRequest<ResponseDataResult<User>>
    {
        public Guid UserID { get; set; }
    }
}
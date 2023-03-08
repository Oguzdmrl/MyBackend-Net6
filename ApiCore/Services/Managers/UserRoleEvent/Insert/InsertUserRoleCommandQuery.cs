using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.UserRoleEvent.Insert
{
    public partial class InsertUserRoleCommandQuery : IRequest<ResponseDataResult<UserRole>>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
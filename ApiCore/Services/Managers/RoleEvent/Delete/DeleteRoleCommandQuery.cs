﻿using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.RoleEvent.Delete
{
    public partial class DeleteRoleCommandQuery : IRequest<ResponseDataResult<Role>>
    {
        public Guid RoleID { get; set; }
    }
}
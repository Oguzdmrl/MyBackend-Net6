﻿using Business.Managers.ProductEvent.Insert;
using Core.Results;
using Entities;
using MediatR;

namespace Business.Managers.RoleEvent.Insert
{
    public partial class InsertRoleCommandQuery : IRequest<ResponseDataResult<Role>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
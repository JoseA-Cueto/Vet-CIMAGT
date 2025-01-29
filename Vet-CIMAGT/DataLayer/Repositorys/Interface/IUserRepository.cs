﻿using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.DataLayer.Interface;

namespace Vet_CIMAGT.DataLayer.Repositorys.Interface
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}


﻿using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IPersonalTrainerStudentRepository : IAsyncRepository<PersonalTrainerStudent>, IRepository<PersonalTrainerStudent>
    {
    }
}

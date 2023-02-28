using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.MappingEntities;

namespace Application.Services.Repositories
{
    public interface ICompanyRepository: IAsyncRepository<Company>, IRepository<Company>
    {
    }
}

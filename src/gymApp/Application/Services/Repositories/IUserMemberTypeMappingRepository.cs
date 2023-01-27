using Core.Persistence.Repositories;
using Domain.MappingEntities;

namespace Application.Services.Repositories
{
    public interface IUserMemberTypeMappingRepository: IAsyncRepository<UserMemberTypeMapping>, IRepository<UserMemberTypeMapping>
    {
    }
}

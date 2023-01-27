using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;
using Domain.MappingEntities;

namespace Application.Features.UserMemberTypeMappings.Rules
{
    public class UserMemberTypeMappingBusinessRules
    {
        private readonly IUserMemberTypeMappingRepository _userMemberTypeMappingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMemberTypeRepository _memberTypeRepository;
        public UserMemberTypeMappingBusinessRules(IUserMemberTypeMappingRepository userMemberTypeMappingRepository, IUserRepository userRepository, IMemberTypeRepository memberTypeRepository)
        {
            _userMemberTypeMappingRepository = userMemberTypeMappingRepository;
            _userRepository = userRepository;
            _memberTypeRepository = memberTypeRepository;
        }

        public async Task UserMemberTypeMappingNotExists(int id)
        {
            UserMemberTypeMapping? userMemberTypeMapping = await _userMemberTypeMappingRepository.GetAsync(x => x.Id == id);

            if (userMemberTypeMapping == null) throw new BusinessException("User Member Type not exists");
        }

        public async Task UserIdNotExists(int userId)
        {
            User? user = await _userRepository.GetAsync(x => x.Id == userId);

            if (user == null) throw new BusinessException("User not exists");
        }

        public async Task MemberTypeNotExists(int memberTypeId)
        {
            MemberType? memberType = await _memberTypeRepository.GetAsync(x => x.Id == memberTypeId);

            if (memberType == null) throw new BusinessException("Member type not exists");
        }
    }
}

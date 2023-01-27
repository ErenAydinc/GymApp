using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.MemberTypes.Rules
{
    public class MemberTypeBusinessRules
    {
        private readonly IMemberTypeRepository _memberTypeRepository;
        public MemberTypeBusinessRules(IMemberTypeRepository memberTypeRepository)
        {
            _memberTypeRepository = memberTypeRepository;
        }

        public async Task MemberTypeNotExists(int memberTypeId)
        {
            MemberType? memberType = await _memberTypeRepository.GetAsync(x => x.Id == memberTypeId);

            if (memberType == null) throw new BusinessException("Member type not exists");
        }

        public async Task MemberTypeNameExists(string name)
        {
            MemberType? memberType= await _memberTypeRepository.GetAsync(x => x.Name == name);

            if (memberType != null) throw new BusinessException("Member type name already exists");
        }
    }
}

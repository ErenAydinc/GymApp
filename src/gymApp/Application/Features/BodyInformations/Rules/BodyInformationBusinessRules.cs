using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Rules
{
    public class BodyInformationBusinessRules
    {
        private readonly IBodyInformationRepository _bodyInformationRepository;

        public BodyInformationBusinessRules(IBodyInformationRepository bodyInformationRepository)
        {
            _bodyInformationRepository = bodyInformationRepository;
        }

        public async Task UserIdAlreadyExists(int userId)
        {
            BodyInformation? bodyInformation = await _bodyInformationRepository.GetAsync(x => x.UserId == userId);

            if (bodyInformation != null) throw new BusinessException("User id already exists");
        }

        public async Task IdNotExists(int id)
        {
            BodyInformation? bodyInformation = await _bodyInformationRepository.GetAsync(x => x.Id == id);

            if (bodyInformation == null) throw new BusinessException("Id not exists");
        }
    }
}

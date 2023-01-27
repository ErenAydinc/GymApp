using Application.Features.BodyInformations.Commands.CreateBodyInformation;
using Application.Features.BodyInformations.Commands.DeleteBodyInformation;
using Application.Features.BodyInformations.Commands.UpdateBodyInformation;
using Application.Features.BodyInformations.Dtos;
using Application.Features.BodyInformations.Models;
using Application.Features.BodyInformations.Queries.GetBodyInformationById;
using Application.Features.BodyInformations.Queries.GetBodyInformationList;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BodyInformations.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<BodyInformation, CreateBodyInformationDto>().ReverseMap();
            CreateMap<BodyInformation, CreateBodyInformationCommand>().ReverseMap();

            CreateMap<BodyInformation, UpdateBodyInformationDto>().ReverseMap();
            CreateMap<BodyInformation, UpdateBodyInformationCommand>().ReverseMap();

            CreateMap<BodyInformation, DeleteBodyInformationDto>().ReverseMap();
            CreateMap<BodyInformation, DeleteBodyInformationCommand>().ReverseMap();

            CreateMap<BodyInformation,GetBodyInformationByIdDto>().ReverseMap();
            CreateMap<BodyInformation, GetBodyInformationByIdQuery>().ReverseMap();

            CreateMap<IPaginate<BodyInformation>, BodyInformationListModel>().ReverseMap();
            CreateMap<IPaginate<BodyInformation>, GetBodyInformationListQuery>().ReverseMap();

            CreateMap<BodyInformation, GetBodyInformationListDto>().ReverseMap();
        }
    }
}

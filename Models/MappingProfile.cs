using System;
using AutoMapper;
using HypertropeCore.DataTransferObjects;
using HypertropeCore.DataTransferObjects.Request;
using HypertropeCore.DataTransferObjects.Response;
using HypertropeCore.Domain;

namespace HypertropeCore.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Client to Server
            CreateMap<UserRegistrationDto, User>();
            
            CreateMap<CreateMeditationLogDto, MeditationLog>()
                .ForMember(dest => dest.Created, 
                    opt => opt.NullSubstitute(DateTime.Now))
                .ForMember(dest => dest.MeditationLogId, 
                    opt => opt.NullSubstitute(Guid.NewGuid()));

            CreateMap<CreateQuoteCategoryDto, QuoteCategory>()
                .ForMember(dest => dest.QuoteCategoryId, 
                    opt => opt.NullSubstitute(Guid.NewGuid()));
            
            

            // Server to Client
            CreateMap<MeditationLog, MeditationLogResponseDto>();
            
            CreateMap<QuoteCategory, QuoteCategoryResponseDto>();
        }
    }
}
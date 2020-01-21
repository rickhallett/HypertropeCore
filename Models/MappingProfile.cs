using AutoMapper;
using HypertropeCore.DataTransferObjects;
using HypertropeCore.Domain;

namespace HypertropeCore.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationDto, User>();
        }
    }
}
using AutoMapper;
using HypertropeCore.DataTransferObjects;

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
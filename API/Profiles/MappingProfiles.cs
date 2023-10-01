using AutoMapper;
using Domain.Entities;
using API.Dtos;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Person,PersonDto>().ReverseMap();
    }
}

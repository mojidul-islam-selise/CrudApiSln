using AutoMapper;
using CrudApiSln.DTOs;
using CrudApiSln.Models;

namespace CrudApiSln.Repositories
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentDto, Student>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            //.ForMember(dest => dest.age, opt => opt.Ignore())

            CreateMap<Student, StudentDto>();
        }
    }
}

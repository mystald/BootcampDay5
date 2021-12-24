using AutoMapper;

namespace BootcampDay5.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Models.Author, Dtos.AuthorDto>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dst => dst.Age, opt => opt.MapFrom(src => System.DateTime.Today.Year - src.DateOfBirth.Year));

            CreateMap<Models.Author, Dtos.AuthorWithCourseDto>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dst => dst.Age, opt => opt.MapFrom(src => System.DateTime.Today.Year - src.DateOfBirth.Year))
                .ForMember(dst => dst.Courses, opt => opt.MapFrom(src => src.Courses));

            CreateMap<Dtos.AuthorInsertDto, Models.Author>();
        
        }
    }
}

using AutoMapper;

namespace BootcampDay5.Profiles
{
    public class AuthorCoursesProfile : Profile
    {
        public AuthorCoursesProfile()
        {
            CreateMap<Dtos.AuthorCourseInsertDto, Models.Author>();

            CreateMap<Dtos.AuthorCourseInsertDto, Models.Course>();

        }
    }
}

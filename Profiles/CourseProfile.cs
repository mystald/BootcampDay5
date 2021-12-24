using AutoMapper;

namespace BootcampDay5.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Models.Course, Dtos.CourseDto>();

            CreateMap<Dtos.CourseInsertDto, Models.Course>();

        }
    }
}

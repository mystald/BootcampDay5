namespace BootcampDay5.Dtos
{
    public class AuthorWithCourseDto
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string MainCategory { get; set; }
        public Models.Course Courses { get; set; }
    }
}

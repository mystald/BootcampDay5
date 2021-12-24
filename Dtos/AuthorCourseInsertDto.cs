using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BootcampDay5.Dtos
{
    public class AuthorCourseInsertDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public System.DateTime? DateOfBirth { get; set; }

        [Required, StringLength(50)]
        public string MainCategory { get; set; }

        [Required]
        public IEnumerable<CourseWithoutAuthorIdDto> Courses { get; set; }

    }
}

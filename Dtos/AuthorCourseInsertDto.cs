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

        [Required, StringLength(100)]
        public string Title { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace BootcampDay5.Dtos
{
    public class CourseInsertDto
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        [Required]
        public int? AuthorID { get; set; }

    }
}

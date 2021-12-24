using System.ComponentModel.DataAnnotations;

namespace BootcampDay5.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        public int AuthorID { get; set; }

        public Author Author { get; set; }
    }
}

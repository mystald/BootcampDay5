using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BootcampDay5.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required,StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public System.DateTime DateOfBirth { get; set; }

        [Required, StringLength(50)]
        public string MainCategory { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}

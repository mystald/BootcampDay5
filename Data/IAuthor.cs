using BootcampDay5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampDay5.Data
{
    public interface IAuthor : ICrud<Author>
    {
        Task<IEnumerable<Course>> GetCourses(int id);
        Task<(Author, IEnumerable<Course>)> InsertAuthorWithCourse(Author author, IEnumerable<Course> course);
    }
}

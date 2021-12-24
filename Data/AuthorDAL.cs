using BootcampDay5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BootcampDay5.Dtos;

namespace BootcampDay5.Data
{
    public class AuthorDAL : IAuthor
    {
        private ApplicationDbContext _db;

        public AuthorDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var result = await (
                from author in _db.Authors.Include("Courses")
                select author).ToListAsync();

            return result;
        }

        public async Task<Author> GetById(int id)
        {
            var result = await (
                from author in _db.Authors
                where author.AuthorID == id
                select author).SingleAsync();

            if (result == null) throw new System.Exception("Author not found");

            return result;
        }

        public async Task<IEnumerable<Author>> GetByName(string name)
        {
            var result = await (
                from Author in _db.Authors
                where Author.FirstName.ToLower().Contains(name.ToLower()) || 
                Author.LastName.ToLower().Contains(name.ToLower())
                select Author).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Course>> GetCourses(int id)
        {
            var result = await (
                from course in _db.Courses
                where course.AuthorID == id
                select course).ToListAsync();

            return result;
        }

        public async Task<Author> Insert(Author obj)
        {
            try
            {
                var result = await _db.Authors.AddAsync(obj);
                await _db.SaveChangesAsync();

                return obj;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public async Task<Author> Update(int id, Author obj)
        {
            try
            {
                var oldAuthor = await GetById(id);
                if (obj.FirstName != null) oldAuthor.FirstName = obj.FirstName;
                if (obj.LastName != null) oldAuthor.LastName = obj.LastName;
                if (obj.DateOfBirth != default(System.DateTime)) oldAuthor.DateOfBirth = obj.DateOfBirth;
                if (obj.MainCategory != null) oldAuthor.MainCategory = obj.MainCategory;

                await _db.SaveChangesAsync();

                return oldAuthor;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public async Task<Author> Delete(int id)
        {
            var oldAuthor = await GetById(id);
            if (oldAuthor == null) throw new System.Exception("Author not found");

            try
            {
                _db.Authors.Remove(oldAuthor);
                await _db.SaveChangesAsync();

                return oldAuthor;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public async Task<(Author, IEnumerable<Course>)> InsertAuthorWithCourse(Author author, IEnumerable<Course> courses)
        {
            try
            {
                author = await Insert(author);

                foreach (var course in courses) {
                    course.AuthorID = author.AuthorID;

                    await _db.Courses.AddAsync(course);
                    await _db.SaveChangesAsync();
                }

                return (author, courses);
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }
    }
}

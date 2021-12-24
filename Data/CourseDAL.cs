using BootcampDay5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BootcampDay5.Data
{
    public class CourseDAL : ICourse
    {
        private ApplicationDbContext _db;

        public CourseDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var result = await(
                from course in _db.Courses
                select course).ToListAsync();

            return result;
        }

        public async Task<Course> GetById(int id)
        {
            var result = await(
                from course in _db.Courses
                where course.CourseID == id
                select course).SingleAsync();

            if (result == null) throw new System.Exception("Author not found");

            return result;
        }

        public async Task<IEnumerable<Course>> GetByName(string name)
        {
            var result = await (
                from course in _db.Courses
                where course.Title.ToLower().Contains(name.ToLower())
                select course).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Course>> GetByAuthorID(int id)
        {
            var result = await (
                from course in _db.Courses
                where course.AuthorID == id
                select course).ToListAsync();

            return result;
        }

        public async Task<Course> Insert(Course obj)
        {
            try
            {
                var result = await _db.Courses.AddAsync(obj);
                await _db.SaveChangesAsync();

                return obj;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public async Task<Course> Update(int id, Course obj)
        {
            try
            {
                var oldCourse = await GetById(id);
                if (obj.Title != null) oldCourse.Title = obj.Title;
                if (obj.Description != null) oldCourse.Description = obj.Description;
                oldCourse.AuthorID = obj.AuthorID;

                await _db.SaveChangesAsync();

                return oldCourse;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }
        public async Task<Course> Delete(int id)
        {
            var oldCourse = await GetById(id);
            if (oldCourse == null) throw new System.Exception("Course not found");

            try
            {
                _db.Courses.Remove(oldCourse);
                await _db.SaveChangesAsync();

                return oldCourse;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }
    }
}

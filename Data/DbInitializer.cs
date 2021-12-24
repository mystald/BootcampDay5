using System.Linq;
using BootcampDay5.Models;

namespace BootcampDay5.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Authors.Any())
            {
                context.Authors.Add(new Author
                {
                    FirstName = "Hilman",
                    LastName = "Abdan",
                    DateOfBirth = System.DateTime.Today,
                    MainCategory = "Random",
                });

                context.Authors.Add(new Author
                {
                    FirstName = "Ghofar",
                    LastName = "Hilman",
                    DateOfBirth = System.DateTime.Today,
                    MainCategory = "Outlier",
                });

                context.Authors.Add(new Author
                {
                    FirstName = "Brad",
                    LastName = "Abdan",
                    DateOfBirth = System.DateTime.Today,
                    MainCategory = "Meong",
                });

                context.SaveChanges();

            }

            if (!context.Courses.Any())
            {
                context.Courses.Add(new Course
                {
                    Title = "The First Course",
                    Description = "First Course is a First Course is a First Course is a First Course",
                    AuthorID = 1,
                });

                context.Courses.Add(new Course
                {
                    Title = "Course not Course",
                    Description = "Course not",
                    AuthorID = 2,
                });

                context.Courses.Add(new Course
                {
                    Title = "Calculus",
                    Description = "Because why not",
                    AuthorID = 1,
                });

                context.Courses.Add(new Course
                {
                    Title = "Food Course",
                    Description = "Hungee",
                    AuthorID = 1,
                });

                context.SaveChanges();

            }

        }
    }
}

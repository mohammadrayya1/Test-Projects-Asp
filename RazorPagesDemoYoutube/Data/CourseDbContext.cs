using Microsoft.EntityFrameworkCore;
using RazorPagesDemoYoutube.Pages.Models;

namespace RazorPagesDemoYoutube.Data
{
    public class CourseDbContext : DbContext
    {

        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {


        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}

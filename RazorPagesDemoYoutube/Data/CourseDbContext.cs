using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemoYoutube.Pages.Models;

namespace RazorPagesDemoYoutube.Data
{
	public class CourseDbContext : IdentityDbContext
	{

		public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
		{


		}

		public DbSet<Course> Courses { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<AppUser> appUser { get; set; }

	}
}

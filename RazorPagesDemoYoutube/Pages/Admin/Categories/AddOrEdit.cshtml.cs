using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.Pages.Models;

namespace RazorPagesDemoYoutube.Pages.Admin.Categories
{
    public class AddOrEditModel : PageModel
    {
        public readonly CourseDbContext _db;
        [BindProperty]
        public Category category { set; get; }
            

        public AddOrEditModel(CourseDbContext db)
        {
            this._db = db;
        }
        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            if (ModelState.IsValid) {
				if (category != null)

				{
					await this._db.AddAsync(category);
					await this._db.SaveChangesAsync();
				}

			}
           

		}
    }
}

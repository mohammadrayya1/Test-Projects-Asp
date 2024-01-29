using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.Pages.Models;

namespace RazorPagesDemoYoutube.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {

        public readonly CourseDbContext _db;

        public IEnumerable<Category> CategiresList { get; set; }
        public IndexModel(CourseDbContext db)
        {
            this._db = db;
        }
        public async Task OnGet()
        {
            CategiresList= await this._db.Category.OrderBy(c=>c.OrderDispay ).ToListAsync();

        }
    }
}

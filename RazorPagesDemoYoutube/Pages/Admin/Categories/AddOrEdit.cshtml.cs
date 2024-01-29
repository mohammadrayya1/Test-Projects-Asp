using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.Pages.Models;
using RazorPagesDemoYoutube.ViewModels;

namespace RazorPagesDemoYoutube.Pages.Admin.Categories
{
	public class AddOrEditModel : PageModel
	{
		public readonly CourseDbContext _db;
		public readonly IMapper mapper;
		public readonly IToastNotification _notify;
		[BindProperty]
		public CategoryViewModel categoryViewModel { set; get; }


		public AddOrEditModel(CourseDbContext db,IMapper mapper,IToastNotification notify)
		{
			this._db = db;
			this.mapper = mapper;
			this._notify = notify;
			categoryViewModel = new CategoryViewModel();
		}
		public async Task OnGet( String? CategoryId)
		{
			if(CategoryId != null)
			{
				Category? catg = await this._db.Category.FirstOrDefaultAsync(x => x.CategoryId.ToString() == CategoryId);
				if(catg != null)
				{
					categoryViewModel = this.mapper.Map<CategoryViewModel>(catg);


                }

			}

		}

		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid )
			{
			
	

					Category category = this.mapper.Map<Category>(categoryViewModel);

				if (category.CategoryId ==null)
				{
                    await this._db.AddAsync(category);
                    var res = await this._db.SaveChangesAsync();
                    if (res > 0)
                    {
                        this._notify.AddSuccessToastMessage("Category is created Successfully");
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        this._notify.AddErrorToastMessage("Category is not created Successfully");
                    }
				}
				else
				{
					this._db.Category.Update(category);
                    await this._db.SaveChangesAsync();
                    this._notify.AddSuccessToastMessage("Category is updated Successfully");
                    return RedirectToPage("Index");
                }
				

			
			}
            return Page();

        }

		public async Task<IActionResult> OnGetDelete(String CategoryId)
		{
			using ( var contect = this._db )
			{
                Category? category = await contect.Category.FirstOrDefaultAsync(c => c.CategoryId.ToString() == CategoryId);

                if (category != null)
                {
                    contect.Category.Remove(category);
					await contect.SaveChangesAsync();

                    this._notify.AddSuccessToastMessage("Category is removed Successfully");
                    return RedirectToPage("Index");

                }
                else
                {
                    this._notify.AddErrorToastMessage("Category is not removed Successfully");
                }

            }
			return Page();
		}
	}
}

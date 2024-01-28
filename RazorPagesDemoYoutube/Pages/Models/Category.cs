using System.ComponentModel.DataAnnotations;

namespace RazorPagesDemoYoutube.Pages.Models
{
    public class Category
    {
        [Key]
        public Guid? CategoryId { get; set; }

        [Display(Name="Category Name")]
        [Required(ErrorMessage ="Category Name is Required")]
        [StringLength(maximumLength:30,MinimumLength =3,ErrorMessage ="Category Name must be between 3 and 30")]
        public  string? Name { get; set; }


		[Display(Name = "Order Display")]
		[Required(ErrorMessage = "Order Display is Required")]
		[Range( 0,  50, ErrorMessage = "Price  must be between 50 and 0")]
		public int? OrderDispay { get; set; }
    }
}

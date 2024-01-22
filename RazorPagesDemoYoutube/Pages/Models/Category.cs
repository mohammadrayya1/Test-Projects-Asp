using System.ComponentModel.DataAnnotations;

namespace RazorPagesDemoYoutube.Pages.Models
{
    public class Category
    {
        [Key]
        public Guid? CategoryId { get; set; }
        public  string Name { get; set; }
        public int OrderDispay { get; set; }
    }
}

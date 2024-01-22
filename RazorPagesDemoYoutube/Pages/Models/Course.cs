using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesDemoYoutube.Pages.Models
{
    public class Course
    {

        [Key]
        public Guid? CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { set; get; }
        public DateTime PublishDate { get; set; }
        public string ImageUrl { get; set; }

        public Guid? CategoryId { get; set; }

        [ForeignKey ("CategoryId")]
        public  Category Category {  get; set; }    
    }
}

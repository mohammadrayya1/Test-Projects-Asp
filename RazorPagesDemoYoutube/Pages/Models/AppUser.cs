using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesDemoYoutube.Pages.Models
{
	public class AppUser : IdentityUser
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }	

		public bool IsAuthor { get; set; }
		[NotMapped]
		public string FullName => FirstName + " " + LastName;
	}
}

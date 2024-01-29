using AutoMapper;
using RazorPagesDemoYoutube.Pages.Models;
using RazorPagesDemoYoutube.ViewModels;

namespace RazorPagesDemoYoutube.Utilities
{
	public class MappingProfile :Profile
	{


        public MappingProfile( )
        {
            CreateMap<Category,CategoryViewModel>().ReverseMap();
        }
    }
}

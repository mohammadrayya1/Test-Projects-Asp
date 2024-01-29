using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPagesDemoYoutube.Data;
using RazorPagesDemoYoutube.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

string strcon = builder.Configuration.GetConnectionString("Dbcourse");
builder.Services.AddDbContext<CourseDbContext>(options => options.UseSqlServer(strcon));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
{

	ProgressBar = true,
	PositionClass=ToastPositions.TopRight,
	PreventDuplicates=true,
	CloseButton=true
	
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

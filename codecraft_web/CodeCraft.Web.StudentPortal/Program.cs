using CodeCraft.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<CodeCraftDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CodeCraftDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}"
);

app.MapControllerRoute(
    name: "MyCourses",
    pattern: "MyCourses",
    defaults: new { controller = "Courses", action = "Index" }
);

app.MapControllerRoute(
    name: "CourseOverview",
    pattern: "MyCourses/CourseOverview/{id?}",
    defaults: new { controller = "CourseOverview", action = "Index" }
);

app.MapControllerRoute(
    name: "Assignments",
    pattern: "Assignments",
    defaults: new { controller = "Assignments", action = "Index" }
);

app.MapControllerRoute(
    name: "Libraries",
    pattern: "Libraries",
    defaults: new { controller = "Libraries", action = "Index" }
);

app.MapControllerRoute(
    name: "CourseMaterials",
    pattern: "Libraries/CourseMaterials",
    defaults: new { controller = "CourseMaterials", action = "Index" }
);

app.MapControllerRoute(
    name: "VideoLectures",
    pattern: "Libraries/VideoLectures",
    defaults: new { controller = "VideoLectures", action = "Index" }
);

app.MapControllerRoute(
    name: "ProfileManagement",
    pattern: "ProfileManagement",
    defaults: new { controller = "ProfileManagement", action = "Index" }
);

app.MapRazorPages();

app.Run();

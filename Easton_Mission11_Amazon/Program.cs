using Easton_Mission11_Amazon.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:AmazonConnection"]);
});

builder.Services.AddScoped<IAmazonRepository, EFAmazonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(name: "default", pattern: "Books/{pageNum}", defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute("pagination", "Books/{pageNum}", new { Controller = "Home", action = "Index" });
app.MapDefaultControllerRoute();

app.Run();

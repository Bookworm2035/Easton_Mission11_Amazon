using Easton_Mission11_Amazon.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:AmazonConnection"]);
});

builder.Services.AddScoped<IAmazonRepository, EFAmazonRepository>();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

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

app.MapControllerRoute(name: "default", pattern: "Books/{pageNum}", defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute("pagenumandtype", "{bookType}/{pageNum}", new { Controller = "Home", action = "Index" });
app.MapControllerRoute("bookType", "{bookType}", new { Controller = "Home", action = "Index", pageNum = 1 });
app.MapControllerRoute("pagination", "Books/{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1 });

app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();

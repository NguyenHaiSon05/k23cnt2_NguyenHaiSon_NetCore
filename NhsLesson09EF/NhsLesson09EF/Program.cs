using Microsoft.EntityFrameworkCore;
using NhsLesson09EF.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("NhsBookStore");
builder.Services.AddDbContext<NhsBookStoreContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/NhsHome/NhsError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.Use(async (context, next) =>
{
	var path = context.Request.Path.Value;
	if (!string.IsNullOrEmpty(path) && path.Contains("//"))
	{
		var fixedPath = path.Replace("//", "/");
		var newUrl = $"{context.Request.Scheme}://{context.Request.Host}{fixedPath}{context.Request.QueryString}";
		context.Response.Redirect(newUrl, permanent: true);
		return;
	}
	await next();
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NhsHome}/{action=NhsIndex}/{nhsid?}");

app.Run();

using Finances.BusinessLayer.Abstract;
using Finances.BusinessLayer.Concrete;
using Finances.DataAccessLayer.Abstract;
using Finances.DataAccessLayer.Concrete;
using Finances.DataAccessLayer.EntityFramework;
using Finances.DataAccessLayer.UnitOfWork;
using Finances.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

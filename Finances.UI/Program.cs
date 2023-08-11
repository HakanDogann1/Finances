using Finances.BusinessLayer.Abstract;
using Finances.BusinessLayer.Concrete;
using Finances.BusinessLayer.Validations.FluentValidation;
using Finances.DataAccessLayer.Abstract;
using Finances.DataAccessLayer.Concrete;
using Finances.DataAccessLayer.EntityFramework;
using Finances.DataAccessLayer.UnitOfWork;
using Finances.DtoLayer.DTOs.AboutUs;
using Finances.EntityLayer.Concrete;
using Finances.UI.ClaimProvider;
using Finances.UI.Models.Errors;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IClaimsTransformation,UserClaimProvider>();

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<RegisterErrorViewModel>();
builder.Services.AddScoped<IAboutUsDal, EfAboutUsDal>();
builder.Services.AddScoped<IAboutUsServiceDal, EfAboutUsServiceDal>();
builder.Services.AddScoped<IAccountDal, EfAccountDal>();
builder.Services.AddScoped<IBlogDal, EfBlogDal>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IGalleryDal, EfGalleryDal>();
builder.Services.AddScoped<IContactUsDal, EfContactUsDal>();
builder.Services.AddScoped<IHappyCustomerDal, EfHappCustomerDal>();
builder.Services.AddScoped<IHeaderDal, EfHeaderDal>();
builder.Services.AddScoped<IHowItWorksDal, EfHowItWorksDal>();
builder.Services.AddScoped<IQuestionDal, EfQuestionDal>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<IUowDal, UowDal>();
builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IAboutUsService, AboutUsManager>();
builder.Services.AddScoped<IAboutUsServiceService, AboutUsServiceManager>();
builder.Services.AddScoped<IAccountService, AccountManager>();
builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IGalleryService, GalleryManager>();
builder.Services.AddScoped<IContactUsService, ContactUsManager>();
builder.Services.AddScoped<IHappyCustomerService, HappyCustomerManager>();
builder.Services.AddScoped<IHeaderService, HeaderManager>();
builder.Services.AddScoped<IHowItWorksService, HowItWorksManager>();
builder.Services.AddScoped<IQuestionService, QuestionManager>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<SecurityStampValidatorOptions>(opt =>
{
    opt.ValidationInterval = TimeSpan.FromMinutes(30);
});
builder.Services.AddMvc(op =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

    op.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath =new PathString("/Login/Index/");
    options.LogoutPath =new PathString("/Logout/Index/");
    var cookie = new CookieBuilder
    {
        Name = "appcookie",
        HttpOnly = false,
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.Always

    };
});
var lockoutOptions = new LockoutOptions
{
    AllowedForNewUsers = true,
    DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5),
    MaxFailedAccessAttempts = 5
};
builder.Services.AddSingleton<AboutUsValidator>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();

using Finances.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NOMRM5V\\SQLEXPRESS;initial catalog=DbFinances;integrated security=true;");
        }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<AboutUsService> AboutUsServices { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<HappyCustomer> HappyCustomers{ get; set; }
        public DbSet<Header> Headers{ get; set; }
        public DbSet<HowItWorks> HowItWorks{ get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<Team> Teams{ get; set; }
    }
}

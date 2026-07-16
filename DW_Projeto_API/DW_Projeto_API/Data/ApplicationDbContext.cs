using DW_Projeto_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DW_Projeto_API.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<MyUser> AppUsers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}

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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Result> Results { get; set; }

        /// <summary>
        /// Configuração do modelo de dados usando a Fluent API
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1 jogo só pode ter 1 resultado, e cada resultado pertence a 1 jogo
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Match)
                .WithOne(m => m.Result)
                .HasForeignKey<Result>(r => r.MatchFK);
        }

    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Data
{
    public class AppDbContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {
        }

        public DbSet<Product> Produts { get; set; }

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }
    }
    //public class MyDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    //{
    //    AppDbContext IDesignTimeDbContextFactory<AppDbContext>.CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var builder = new DbContextOptionsBuilder<AppDbContext>();
    //        var connectionString = configuration.GetConnectionString("SqlServer");

    //        builder.UseSqlServer(connectionString);

    //        return new AppDbContext(builder.Options);
    //    }
    //}
}

using Microsoft.EntityFrameworkCore;
using UdemyJwt.Back.Core.Domain;
using UdemyJwt.Back.Persistance.Configurations;

namespace UdemyJwt.Back.Persistance.Context
{
    public class UdemyJwtContext:DbContext
    {
        public UdemyJwtContext(DbContextOptions<UdemyJwtContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

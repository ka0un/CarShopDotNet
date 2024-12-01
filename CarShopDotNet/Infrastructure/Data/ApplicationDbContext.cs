using CarShopDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarShopDotNet.Infrastructure.Data
{
    
    // DbContext is a class provided by Entity Framework Core that represents a session with the database.
    
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        // DbSet is a property that represents a collection of entities in the context.
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }

        // OnModelCreating is a method that is called when the model for a context is being created.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Owner)
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Car>()
                .Property(c => c.VIN)
                .IsRequired()
                .HasMaxLength(17);

            modelBuilder.Entity<Owner>()
                .Property(o => o.Email)
                .IsRequired();
        }
    }
}
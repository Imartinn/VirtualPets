using Microsoft.EntityFrameworkCore;
using VirtualPets.Logic.Models;

namespace VirtualPets.Logic.Data
{
    public class VirtualPetsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public VirtualPetsDbContext(DbContextOptions<VirtualPetsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()                
                .HasIndex(u => u.Name)
                .IsUnique();
            modelBuilder.Entity<User>()
               .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Pets)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.OwnerId);
            
            modelBuilder.Entity<Animal>()
               .HasKey(u => u.Id);
            modelBuilder.Entity<Animal>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Dog>().HasBaseType<Animal>();
            modelBuilder.Entity<Bear>().HasBaseType<Animal>();
            modelBuilder.Entity<Parrot>().HasBaseType<Animal>();
            modelBuilder.Entity<Cat>().HasBaseType<Animal>();
        }
    }
}
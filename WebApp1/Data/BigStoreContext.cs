using Microsoft.EntityFrameworkCore;

namespace WebApp1.Data
{

    public class BigStoreContext : DbContext
    {
        public BigStoreContext(DbContextOptions options) : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>()
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder.Entity<Category>()
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            modelBuilder.Entity<Brand>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(x => new { x.CategoryId, x.Name })
                .IsUnique();


            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cpu" },
                new Category { Id = 2, Name = "Ram" },
                new Category { Id = 3, Name = "Hdd" },
                new Category { Id = 4, Name = "Sdd" });

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Asus" },
                new Brand { Id = 2, Name = "HP" },
                new Brand { Id = 3, Name = "IBM" },
                new Brand { Id = 4, Name = "Kinston" },
                new Brand { Id = 5, Name = "Casper" },
                new Brand { Id = 6, Name = "Corsair" });

        }
    }
}

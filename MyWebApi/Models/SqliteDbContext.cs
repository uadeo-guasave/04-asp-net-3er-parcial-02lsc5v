using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Models
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Db/libros.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(cat => 
            {
                cat.Property(c => c.Id).HasColumnName("id");
                cat.Property(c => c.Name).HasColumnName("name");

                cat.HasMany(c => c.Books).WithOne(b => b.Category);
            });

            modelBuilder.Entity<Book>(book =>
            {
                book.HasKey(b => b.AmazonId);
                book.Property(b => b.AmazonId).HasColumnName("amazon_id");
                book.Property(b => b.FileName).HasColumnName("filename");
                book.Property(b => b.ImageUrl).HasColumnName("image_url");
                book.Property(b => b.Title).HasColumnName("title");
                book.Property(b => b.Author).HasColumnName("author");
                book.Property(b => b.CategoryId).HasColumnName("category_id");

                book.HasOne(b => b.Category).WithMany(c => c.Books);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
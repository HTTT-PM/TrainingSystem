using BookManager.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Data
{
    public partial class ModelContext: DbContext{
        public ModelContext(DbContextOptions<ModelContext> options) : base(options){}

        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Author>().ToTable("Author");
        }
    }
}

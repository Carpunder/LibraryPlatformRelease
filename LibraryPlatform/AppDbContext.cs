using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LibraryPlatform.Models;

namespace LibraryPlatform
{
    public class AppDbContext : DbContext
    {
        public DbSet<Publisher> Publishers { get; set; }
         public DbSet<Book> Books { get; set; }
         public DbSet<LibraryStock> LibraryStocks { get; set; }
         public DbSet<User> Users { get; set; }
         public DbSet<Library> Libraries { get; set; }
         public DbSet<Copy> Copies { get; set; }
         public DbSet<LibraryCard> LibraryCards { get; set; }
         public DbSet<BookCard> BookCards { get; set; }

        public AppDbContext() : base("MyConnection"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
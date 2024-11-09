using Microsoft.EntityFrameworkCore;
namespace DbOperationsWithEFCoreApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, currency = "Inr", Description = "Indian Rupee" },
                new Currency() { Id = 2, currency = "Dollar", Description = "Dollar" },
                new Currency() { Id = 3, currency = "Euro", Description = "Euro" },
                new Currency() { Id = 4, currency = "Dinar", Description = "Dinar" }
                );

            modelBuilder.Entity<Language>().HasData(
               new Language() { Id = 1, Title = "Hindi", Description = "Hindi" },
               new Language() { Id = 2, Title = "Tamil", Description = "Tamil" },
               new Language() { Id = 3, Title = "Telugu", Description = "Telugu" },
               new Language() { Id = 4, Title = "Odia", Description = "Odia" }
               );
        }



        public DbSet<Book> Book { get; set; }
        public DbSet<Language> Language { get; set; }

        public DbSet<BookPrice> BookPrice { get; set; }
        public DbSet<Currency> Currency { get; set; }
    }
}

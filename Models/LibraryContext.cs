using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<Publication> Publications { get; set; }

        // Seed initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt and David Thomas",
                    ISBN = "978-0201616224",
                    PublishedDate = new DateTime(2021, 10, 30),
                    IsAvailable = true
                },
                new Book
                {
                    BookId = 2,
                    Title = "Design Pattern using C#",
                    Author = "Robert C. Martin",
                    ISBN = "978-0132350884",
                    PublishedDate = new DateTime(2023, 8, 1),
                    IsAvailable = true
                },
                new Book
                {
                    BookId = 3,
                    Title = "Mastering ASP.NET Core",
                    Author = "Pranaya Kumar Rout",
                    ISBN = "978-0451616235",
                    PublishedDate = new DateTime(2022, 11, 22),
                    IsAvailable = true
                },
                new Book
                {
                    BookId = 4,
                    Title = "SQL Server with DBA",
                    Author = "Rakesh Kumat",
                    ISBN = "978-4562350123",
                    PublishedDate = new DateTime(2020, 8, 15),
                    IsAvailable = true
                }
            );

            modelBuilder.Entity<Publication>().HasData(
                new Publication { Id = 1, Title = "The Daily Times", Publisher = "Global Media Group", PublishedDate = new DateTime(2026, 7, 22), Type = PublicationType.Newspaper, IsAvailable = true },
                new Publication { Id = 2, Title = "Financial Chronicle", Publisher = "WallSt Press", PublishedDate = new DateTime(2026, 7, 21), Type = PublicationType.Newspaper, IsAvailable = true },
                new Publication { Id = 3, Title = "Tech Weekly News", Publisher = "Silicon Valley Pubs", PublishedDate = new DateTime(2026, 7, 20), Type = PublicationType.Newspaper, IsAvailable = true },
                new Publication { Id = 4, Title = "Metro Morning Post", Publisher = "City Press House", PublishedDate = new DateTime(2026, 7, 22), Type = PublicationType.Newspaper, IsAvailable = true },
                new Publication { Id = 5, Title = "Saturday Sports Herald", Publisher = "Global Media Group", PublishedDate = new DateTime(2026, 7, 18), Type = PublicationType.Newspaper, IsAvailable = false },
                new Publication { Id = 6, Title = "National Geographic Vol 45", Publisher = "NatGeo Society", PublishedDate = new DateTime(2026, 7, 1), Type = PublicationType.Magazine, IsAvailable = true },
                new Publication { Id = 7, Title = "Vogue Fashion Summer", Publisher = "Conde Nast", PublishedDate = new DateTime(2026, 6, 15), Type = PublicationType.Magazine, IsAvailable = true },
                new Publication { Id = 8, Title = "Forbes Business 30 Under 30", Publisher = "Forbes Media", PublishedDate = new DateTime(2026, 7, 10), Type = PublicationType.Magazine, IsAvailable = false },
                new Publication { Id = 9, Title = "PC Gamer Ultimate", Publisher = "Future US", PublishedDate = new DateTime(2026, 7, 5), Type = PublicationType.Magazine, IsAvailable = true },
                new Publication { Id = 10, Title = "Scientific American", Publisher = "Springer Nature", PublishedDate = new DateTime(2026, 6, 28), Type = PublicationType.Magazine, IsAvailable = true }
            );
        }
    }
}

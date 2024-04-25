using LibraryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend
{
    public class BooksContext : DbContext, IBookContext
    {
        public BooksContext(DbContextOptions<BooksContext> options): base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<BorrowBook> BorrowBooks { get; set; } = null!;

    }
}

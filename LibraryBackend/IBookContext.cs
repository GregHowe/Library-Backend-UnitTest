using LibraryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryBackend
{
    public interface IBookContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<BorrowBook> BorrowBooks { get; set; }
    }
}

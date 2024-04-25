using LibraryBackend.Enumerations;
using LibraryBackend.Models;
using LibraryBackend.TDO;
using Microsoft.EntityFrameworkCore;


namespace LibraryBackend.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly BooksContext _context;

        public LibraryRepository(BooksContext context)
        {
            _context = context;
        }

        private bool BookStockIsNotZero(Book book)
        {
            return book.stock > 0;
        }


        public async Task<EnumTypeResult> BorrowBook(long idBook, int idUser)
        {
            var book = await GetBookById(idBook);

            if (!BookStockIsNotZero(book)) return EnumTypeResult.Stock0;

            var _BorrowBookUSer = await _context.BorrowBooks.Where(x => x.IdBook == idBook && x.IdUser == idUser && x.Flag == true).SingleOrDefaultAsync();
            if (_BorrowBookUSer != null) return EnumTypeResult.YaPrestado;

            _context.Entry(book).State = EntityState.Modified;
            book.stock = book.stock - 1;

            var _BorrowBook = new BorrowBook();
            _BorrowBook = new BorrowBook() { IdBook = idBook, IdUser = idUser, Flag = true, Date = DateTime.Now };
            _context.BorrowBooks.Add(_BorrowBook);

            await _context.SaveChangesAsync();

            return EnumTypeResult.Success;
        }

        public async Task<Book> GetBook(long id)
        {
            return await GetBookById(id);
        }
        public async Task<Book> GetBookByName(string name)
        {
            return await _context.Books.Where(x => x.Name == name.Trim()).FirstOrDefaultAsync();
        }


        public async Task<Book> GetBookById(long id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<BorrowBookTDO>> getBorrowBook(int idUser)
        {
            var query = (from brr in _context.BorrowBooks
                         join book in _context.Books on brr.IdBook equals book.Id
                         where brr.IdUser == idUser && brr.Flag == true
                         select new BorrowBookTDO
                         {
                             Id = brr.Id,
                             IdBook = book.Id,
                             IdUser = brr.IdUser,
                             NameBook = book.Name,
                             Date = brr.Date
                         });
            var list = await query.ToListAsync();
            return list;
        }

        public async Task<List<BorrowBookTDO>> getBorrowBookHistory(int idUser)
        {
            var query = (from brr in _context.BorrowBooks
                         join book in _context.Books on brr.IdBook equals book.Id
                         where brr.IdUser == idUser
                         select new BorrowBookTDO
                         {
                             Id = brr.Id,
                             IdBook = book.Id,
                             IdUser = brr.IdUser,
                             NameBook = book.Name,
                             Date = brr.Date,
                             Estado = brr.Flag ? "Prestado" : "Devuelto"
                         }).OrderBy(x => x.Date);

            var list = await query.ToListAsync();
            return list;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Book> PostBook(Book book)
        {
            var nameBook = await GetBookByName(book.Name);

            if (nameBook != null)
            {
                throw new Exception("Nombre de Libro ya registrado. Utilice otro nombre");
            }

            book.Name = book.Name.Trim();
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }


        public async Task ReturnBook(BorrowBook borrowBook)
        {
            var book = await GetBookById(borrowBook.IdBook);
            
            _context.Entry(book).State = EntityState.Modified;
            book.stock = book.stock + 1;

            var _borrowBook = await _context.BorrowBooks.FindAsync(borrowBook.Id);
            _context.Entry(_borrowBook).State = EntityState.Modified;
            _borrowBook.Flag = false;

            await _context.SaveChangesAsync();
            
        }

        public async Task<EnumTypeResult> DeleteLibrary(long id)
        {
            var book = await GetBookById(id);
            if (book == null) return EnumTypeResult.NoExiste;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return EnumTypeResult.Success;

        }
    }
}

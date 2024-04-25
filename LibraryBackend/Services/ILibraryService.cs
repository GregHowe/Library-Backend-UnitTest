using LibraryBackend.Enumerations;
using LibraryBackend.Models;
using LibraryBackend.TDO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Services
{
    public interface ILibraryService
    {
        
        public Task<EnumTypeResult> BorrowBook(long idBook, int idUser);

        public Task<List<Book>> GetBooks();
        public Task<Book> GetBookById(long id);

        public  Task<List<BorrowBookTDO>> getBorrowBook(int idUser);

        public Task<List<BorrowBookTDO>> getBorrowBookHistory(int idUser);

        public Task<Book> PostBook(Book book);

        public Task ReturnBook(BorrowBook borrowBook);

        public Task<EnumTypeResult> DeleteLibrary(long id);

    }
}

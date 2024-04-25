using LibraryBackend.Enumerations;
using LibraryBackend.Models;
using LibraryBackend.TDO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBackend.Repository
{
    public interface ILibraryRepository
    {
        Task<List<Book>> GetBooks();

        Task<Book> PostBook(Book library);

        Task<EnumTypeResult> BorrowBook(long idBook, int idUser);

        Task<List<BorrowBookTDO>> getBorrowBookHistory(int idUser);

        Task<List<BorrowBookTDO>> getBorrowBook(int idUser);

        Task ReturnBook(BorrowBook borrowBook);

        Task<Book> GetBookById(long id);

        Task<EnumTypeResult> DeleteLibrary(long id);

    }
}

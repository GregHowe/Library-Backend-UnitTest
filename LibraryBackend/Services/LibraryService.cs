using LibraryBackend.Enumerations;
using LibraryBackend.Models;
using LibraryBackend.Repository;
using LibraryBackend.TDO;

namespace LibraryBackend.Services
{
    public class LibraryService: ILibraryService
    {
       private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository) {
            _libraryRepository = libraryRepository;
        }

        public async Task<EnumTypeResult> BorrowBook(long idBook, int idUser)
        {
            return await _libraryRepository.BorrowBook(idBook, idUser);
        }

        public  async Task<EnumTypeResult> DeleteLibrary(long id)
        {
           return  await _libraryRepository.DeleteLibrary(id);
        }

        public async Task<Book> GetBookById(long id)
        {
            return await _libraryRepository.GetBookById(id);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _libraryRepository.GetBooks();
        }

        public async Task<List<BorrowBookTDO>> getBorrowBook(int idUser)
        {
            return await _libraryRepository.getBorrowBook(idUser);
        }

        public async Task<List<BorrowBookTDO>> getBorrowBookHistory(int idUser)
        {
            return  await _libraryRepository.getBorrowBookHistory(idUser);
        }

        public async Task<Book> PostBook(Book book)
        {
            return await _libraryRepository.PostBook(book);
        }

        public async Task ReturnBook(BorrowBook borrowBook)
        {
            await _libraryRepository.ReturnBook(borrowBook);
        }
    }
}

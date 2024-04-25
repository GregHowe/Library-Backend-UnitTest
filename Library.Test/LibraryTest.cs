using LibraryBackend.Enumerations;
using LibraryBackend.Models;
using LibraryBackend.Repository;
using LibraryBackend.Services;
using Moq;

namespace Library.Test
{
    public class LibraryTest
    {
        private readonly LibraryService _service;
        private readonly Mock<ILibraryRepository> _libraryRepositoryMock = new Mock<ILibraryRepository>();

        public LibraryTest()
        {
            _service = new LibraryService(_libraryRepositoryMock.Object);
        }

        [Fact]
        public async Task GetBooks_ShouldReturnBook_WhenBooksExists()
        {
            //Arrange
            var listBooks = new List<Book>();
            listBooks.Add(new Book { Id = new Random().NextInt64(), Name = "Book1" });
            listBooks.Add(new Book { Id = new Random().NextInt64(), Name = "Book2" });
            listBooks.Add(new Book { Id = new Random().NextInt64(), Name = "Book3" });

            _libraryRepositoryMock.Setup(x => x.GetBooks()).ReturnsAsync(listBooks);

            //Act
            var Books = await _service.GetBooks();

            //Assert
            Assert.NotNull(Books);
            Assert.Equal(3, Books.Count);
        }


        [Fact]
        public async Task GetBooks_ShouldReturnNothing_WhenBooksDoesntExists()
        {
            //Arrange
            _libraryRepositoryMock.Setup(x => x.GetBooks()).ReturnsAsync(() => null);

            //Act
            var Books = await _service.GetBooks();

            //Assert
            Assert.Null(Books);
        }


        [Fact]
        public async Task GetBookById_ShouldReturnBook_WhenBooksExists()
        {
            //Arrange
            long id = new Random().NextInt64();
            string name = "book test";
            var bookDto = new Book() {  Id= id, Name = name };
            _libraryRepositoryMock.Setup(x => x.GetBookById(id)).ReturnsAsync(bookDto);
            
            //Act
            var Book = await _service.GetBookById(id);

            //Assert
            Assert.Equal(id, Book.Id);
            Assert.Equal(name, Book.Name);
        }

        [Fact]
        public async Task GetBookById_ShouldReturnNothing_WhenBooksDoesNotExists()
        {
            //Arrange
            _libraryRepositoryMock.Setup(x => x.GetBookById(It.IsAny<long>())).ReturnsAsync(() => null);

            //Act
            var Book = await _service.GetBookById(new Random().NextInt64());

            //Assert
            Assert.Null(Book);
        }


        [Fact]
        public async Task PostBook_ShouldReturnBook_WhenBookIsInserted()
        {
            //Arrange
            long id = new Random().NextInt64();
            string name = "book test";
            var bookDto = new Book() {  Id = id, Name = name, stock = 2 };
            _libraryRepositoryMock.Setup(x => x.PostBook(bookDto)).ReturnsAsync(bookDto);

            //Act
            var Book = await _service.PostBook(bookDto);

            //Assert
            Assert.NotNull(Book);
            Assert.Equal(Book.Id, id);
            
        }

        [Fact]
        public async Task DeleteLibrary_ShouldReturnDoesnExist_WhenSendIdBookThatDoesnExist()
        {
            //Arrange
            long id = new Random().NextInt64();
     
            _libraryRepositoryMock.Setup(x => x.DeleteLibrary(id)).ReturnsAsync(EnumTypeResult.NoExiste);

            //Act
            var result = await _service.DeleteLibrary(1);

            //Assert
            Assert.Equal(result, EnumTypeResult.NoExiste);

        }


        [Fact]
        public async Task PostBook_ThrowException_WhenNameBookAlreadyExist()
        {
            //Arrange
            long id = new Random().NextInt64();
            string name = "book test";
            var bookDto = new Book() { Id = id, Name = name, stock = 2 };

            _libraryRepositoryMock.Setup(p => p.PostBook(bookDto)).ThrowsAsync(new Exception("Nombre de Libro ya registrado"));

            //Act and assert
            Exception ex = await Assert.ThrowsAsync<Exception>(async () => await _service.PostBook(bookDto));

        }



    }
}
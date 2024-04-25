using Microsoft.AspNetCore.Mvc;
using LibraryBackend.Models;
using Microsoft.AspNetCore.Authorization;
using LibraryBackend.TDO;
using LibraryBackend.Services;
using LibraryBackend.Enumerations;


namespace LibraryBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksContext _context;
        private readonly ILibraryService _IlibraryService;

        public BooksController(ILibraryService IlibraryService)
        {
            _IlibraryService = IlibraryService;

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _IlibraryService.GetBooks();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(long id)
        {
            return await _IlibraryService.GetBookById(id);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            try
            {
                book = await _IlibraryService.PostBook(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(long id)
        {
            var result = await _IlibraryService.DeleteLibrary(id);
            if (result == EnumTypeResult.NoExiste) return NotFound("Libro no existe");
            return Ok();
        }


        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("BorrowBook/{idBook}/{idUser}")]
        public async Task<IActionResult> BorrowBook(long idBook, int idUser)
        {
            try
            {
                var result = await _IlibraryService.BorrowBook(idBook, idUser);
                if (result == EnumTypeResult.Stock0) return NotFound("Libro con stock 0");
                if (result == EnumTypeResult.YaPrestado) return BadRequest("El Libro ya fue prestado al usuario seleccionado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("GetBorrowBookHistory/{idUser}")]
        public async Task<ActionResult<IEnumerable<BorrowBookTDO>>> getBorrowBookHistory(int idUser)
        {
            return await _IlibraryService.getBorrowBookHistory(idUser);
        }


        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("GetBorrowBook/{idUser}")]
        public async Task<ActionResult<IEnumerable<BorrowBookTDO>>> getBorrowBook(int idUser)
        {
            return await _IlibraryService.getBorrowBook(idUser);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("ReturnBook")]
        public async Task<IActionResult> ReturnBook(BorrowBook borrowBook)
        {
            try
            {
                await _IlibraryService.ReturnBook(borrowBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}

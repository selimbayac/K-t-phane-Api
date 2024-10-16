using Business.IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using DTOs;

namespace KutuphaneApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {

        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("purchase")]
        public async Task<IActionResult> PurchaseBook(int bookId, int userId)
        {
            try
            {
                await _bookService.PurchaseBookAsync(bookId, userId);
                return Ok("Kitap başarıyla satın alındı.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) return NotFound();

            // JSON ayarları
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true // İsteğe bağlı olarak daha okunabilir hale getirmek için
            };

            var json = JsonSerializer.Serialize(book, options);
            return Content(json, "application/json");
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {

            var books = await _bookService.GetAllBookAsync();

            // JSON ayarları
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true // İsteğe bağlı olarak daha okunabilir hale getirmek için
            };

            var json = JsonSerializer.Serialize(books, options);
            return Content(json, "application/json");
        }

        [HttpPost]
        public async Task<IActionResult> PostBook(BookDTO bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = new Book
            {
                KitapAdi = bookDto.KitapAdi,
                SayfaSayisi = bookDto.SayfaSayisi,
                Fiyat = bookDto.Fiyat,
                Adet = bookDto.Adet,
                YayinEviId = bookDto.YayinEviId,
                YazarId = bookDto.YazarId,
                KategoriId = bookDto.KategoriId
            };

            await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDTO bookDto)
        {
            var book = new Book
            {
                KitapAdi = bookDto.KitapAdi,
                SayfaSayisi = bookDto.SayfaSayisi,
                Fiyat = bookDto.Fiyat,
                Adet = bookDto.Adet,
                YayinEviId = bookDto.YayinEviId,
                YazarId = bookDto.YazarId,
                KategoriId = bookDto.KategoriId
            };

            if (id != book.Id) return BadRequest();
            await _bookService.UpdateBookAsync(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
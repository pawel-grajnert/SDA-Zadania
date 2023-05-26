using BookRecord.Domain.Interfaces.Logic;
using BookRecord.Domain.Model;
using BookRecord.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookRecord.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class BookRecord : ControllerBase
    {
        private readonly ILogger<BookRecord> _logger;
        private readonly IBookService _bookService;

        public BookRecord(ILogger<BookRecord> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetAll()
        {
            var books = (await _bookService.GetAllAsync()).Select(b => new BookListItemDto(b));
            return Ok(books);
        }

        [HttpGet]
        [Route("books/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.GetAsync(id);
            return Ok(book);
        }

        [HttpPost]
        [Route("books")]
        public async Task<IActionResult> Add(Book book)
        {
            await _bookService.AddAsync(book);
            return Ok();
        }

        [HttpDelete]
        [Route("books")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("books")]
        public async Task<IActionResult> Edit(BookEditDto bookEdit)
        {
            await _bookService.EditAsync(bookEdit.AsBook());
            return Ok();
        }
    }
}
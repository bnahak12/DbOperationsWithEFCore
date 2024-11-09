using DbOperationsWithEFCoreApp.Data;
using DbOperationsWithEFCoreApp.DTO;
using Microsoft.AspNetCore.Mvc;
namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(AppDbContext appDbContext) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] BookDto bookDto)
        {

            var newBook = new Book
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                NoOfPages = bookDto.NoOfPages,
                IsActive = bookDto.IsActive,
                CreatedOn = DateTime.Now,
                LanguageId = bookDto.LanguageId,
                BookPrice = bookDto.BookPrices.Select(bp => new BookPrice
                {
                    Amount = bp.Amount,
                    CurrencyId = bp.CurrencyId
                }).ToList()
            };
            appDbContext.Book.Add(newBook);
            await appDbContext.SaveChangesAsync();
            return Ok(newBook);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> AddNewBookBulk([FromBody] IEnumerable<BookDto> bookDtos)
        {

            var newBooks = bookDtos.Select(dto => new Book
            {
                Title = dto.Title,
                Description = dto.Description,
                NoOfPages = dto.NoOfPages,
                IsActive = dto.IsActive,
                CreatedOn = DateTime.Now,
                LanguageId = dto.LanguageId,
                BookPrice = dto.BookPrices.Select(bp => new BookPrice
                {
                    Amount = bp.Amount,
                    CurrencyId = bp.CurrencyId
                }).ToList()
            }).ToList();
            appDbContext.Book.AddRange(newBooks);
            await appDbContext.SaveChangesAsync();

            return Ok(bookDtos);
        }
    }
}

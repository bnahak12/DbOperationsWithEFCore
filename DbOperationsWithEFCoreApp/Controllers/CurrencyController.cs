using DbOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Controllers
{
    [Route("api/currency")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CurrencyController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var result = await (from currencies in _appDbContext.Currency select currencies).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCurrencyById([FromRoute] int id)
        {
            //var result = await (from currencies in _appDbContext.Currency
            //                    where currencies.Id == id
            //                    select currencies).ToListAsync();

            var result = await _appDbContext.Currency.FindAsync(id);
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCurrencyByName([FromRoute] string name, [FromQuery] string? desc)
        {
            // var result = await _appDbContext.Currency.Where(x => x.currency == name).SingleOrDefaultAsync(); -- Will filter based on where then return single element
            //var result = await _appDbContext.Currency.FirstOrDefaultAsync(
            //    x => x.currency == name
            //    && (string.IsNullOrEmpty(desc) || x.Description == desc)); // -- Will return the Single element found at first and return instead of going for other data.


            var result = await _appDbContext.Currency.Where(x => x.currency == name && (string.IsNullOrEmpty(desc) || x.Description == desc)).ToListAsync();
            return Ok(result);
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetCurrencyNameById([FromBody] List<int> usrdefndIds)
        {
            var result = await _appDbContext.Currency.Where(x => usrdefndIds.Contains(x.Id)).Select(x => new Currency() { Id = x.Id, currency = x.currency }).ToListAsync();
            return Ok(result);
        }
    }
}

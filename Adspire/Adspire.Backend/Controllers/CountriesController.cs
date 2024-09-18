using Adspire.Backend.Data;
using Adspire.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adspire.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CountriesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _dataContext.Add(country);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dataContext.Countries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _dataContext.Countries.FindAsync(id);
            if (country == null) { return NotFound(); }
            return Ok(await _dataContext.Countries.ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            var currentcountry = await _dataContext.Countries.FindAsync(country.Id);
            if (currentcountry == null) { return NotFound(); }
            _dataContext.Update(currentcountry);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var currentcountry = await _dataContext.Countries.FindAsync(id);
            if (currentcountry == null) { return NotFound(); }
            _dataContext.Remove(currentcountry);
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
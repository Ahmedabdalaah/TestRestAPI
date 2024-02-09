using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestRestAPI.Data;
using TestRestAPI.Models;

namespace TestRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public CategoriesController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;
        [HttpGet]
        public async Task <IActionResult> GetCategories()
        {
            var categ = await _db.categories.ToListAsync();
            return Ok(categ);
        }
        [HttpPost]
        public async Task <ActionResult> AddCategory(string category)
        {
            Category cat = new()
            {
                Name = category
            };
            await _db.categories.AddAsync(cat);
            _db.SaveChanges();
            return Ok(cat);
        }
        [HttpPut]
        public async Task <ActionResult> UpdateCategory(Category category)
        {
            var cat = await _db.categories.SingleOrDefaultAsync(x => x.Id == category.Id);
            if(cat== null)
            {
                return NotFound($"Catorgey : {category.Id} Not found ");
            }
            cat.Name = category.Name;
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete ("{id}")]
        public async Task <ActionResult> DeleteCatById(int id)
        {
            var cat = await _db.categories.SingleOrDefaultAsync(x => x.Id == id);
            if (cat == null)
            {
                return NotFound($"Catorgey : {id} Not found ");
            }
            _db.categories.Remove(cat);
            _db.SaveChanges();
            return Ok();

        }
    }
}

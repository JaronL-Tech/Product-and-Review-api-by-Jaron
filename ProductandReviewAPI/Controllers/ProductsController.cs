using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductandReviewAPI.Data;
using ProductandReviewAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductandReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }




        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult GetMaxPrice([FromQuery] string? category, [FromQuery] string? sort)
        {
            if (category != null)
            {
                Console.WriteLine(category);
            }
            if (sort != null)
            {
                Console.WriteLine(sort);
            }
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ProductId = _context.Reviews.Find(id);
            if (ProductId == null)
            {
                return NotFound();
            }
            return Ok(ProductId);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product Product)
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
            return StatusCode(201, Product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product UpdateProduct)
        {
            var Product = _context.Products.Find(id);
            if (Product == null);
            {
                return NotFound();
            }
            Product.Name = UpdateProduct.Name;
            Product.Price = UpdateProduct.Price;
            Product.Reviews = UpdateProduct.Reviews;
            _context.Update(UpdateProduct);
            _context.SaveChanges();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Product = _context.Products.Find();
            if (Product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(Product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

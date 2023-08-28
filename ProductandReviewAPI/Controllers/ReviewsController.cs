using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;
using ProductandReviewAPI.Data;
using ProductandReviewAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductandReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        // GET: api/<ReviewsController>
        [HttpGet]
        public IActionResult Get()
        {
            var Reviews = _context.Reviews.ToList();
            return Ok(Reviews);
        }

        [HttpGet("Search/{Reviews}")]
        public IActionResult SearchReviews(String ProductID)
        {
            _context.Reviews.Find(ProductID);
            return SearchResult();
        }



        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Review = _context.Reviews.Find(id);
            if (Review == null)
            {
                return NotFound();
            }
            return Ok(Review);
        }
        

        // POST api/<ReviewsController>
        [HttpPost]
        public IActionResult Post([FromBody] Review Review)
        {
            _context.Reviews.Add(Review);
            _context.SaveChanges();
            return StatusCode(201, Review);
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review UpdateReview)
        {
            var Review = _context.Reviews.Find(id);
            if (Review == null)
            {
                return NotFound();
            }
            Review.Product = UpdateReview.Product;
            Review.Rating = UpdateReview.Rating;
            Review.ProductId = UpdateReview.ProductId;
            Review.Text = UpdateReview.Text;
            _context.Update(UpdateReview);
            _context.SaveChanges();

            return StatusCode(201, Review);
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Review = _context.Reviews.Find();
            if (Review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(Review);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

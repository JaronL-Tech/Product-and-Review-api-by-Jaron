using System.ComponentModel.DataAnnotations;

namespace ProductandReviewAPI.DTO
{
    public class ReviewDTO
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
    }
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<ReviewDTO> Reviews  { get; set; }
        public double AverageRating { get; set; }

    }

}

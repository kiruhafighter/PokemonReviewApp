using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAPokemon(int pokeid);
        ICollection<Review> GetReviewsOfAPokemonByName(string pokeName);
        bool ReviewExists(int reviewId);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool DeleteReviews(List<Review> reviews);
        bool DeleteReview(Review review);
        bool Save();
    }
}

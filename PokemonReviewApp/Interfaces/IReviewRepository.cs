using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        Review GetReviewByName(string reviewName);
        ICollection<Review> GetReviewsOfAPokemon(int pokeid);
        ICollection<Review> GetReviewsOfAPokemonByName(string pokeName);
        bool ReviewExists(int reviewId);
    }
}

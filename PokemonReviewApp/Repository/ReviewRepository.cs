using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReview (int reviewId)
        {
            return _context.Reviews.SingleOrDefault(r => r.Id == reviewId);
        }

        public Review GetReviewByName(string reviewName) 
        {
            return _context.Reviews.SingleOrDefault(r => r.Title == reviewName);
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeid)
        {
            return _context.Reviews.Where(r=>r.Pokemon.Id== pokeid).ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemonByName(string pokemonName)
        {
            
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }


    }
}

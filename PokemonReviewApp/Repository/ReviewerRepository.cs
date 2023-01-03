using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _context.Reviewers.Any(r=>r.Id== reviewerId);
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public Reviewer GetReviewer (int reviewerId)
        {
            return _context.Reviewers.Where(r=>r.Id == reviewerId).Include(e => e.Reviews).FirstOrDefault();
        }

        public Reviewer GetReviewerByName (string reviewerFirstName, string reviewerLastName)
        {
            var reviewsName = _context.Reviewers.Where(r => r.FirstName == reviewerFirstName);
            var reviewer = reviewsName.FirstOrDefault(r => r.LastName == reviewerLastName);
            return reviewer;
        }

        
        //public ICollection<Review> GetReviewsOfReviewer(int reviewerId)
        //{
        //    return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        //}

        public ICollection<Review> GetReviewsOfReviewer(int reviewerId)
        {
            string FirstName = _context.Reviewers.FirstOrDefault(r => r.Id == reviewerId).FirstName;
            string LastName = _context.Reviewers.FirstOrDefault(r => r.Id == reviewerId).LastName;
            //var reviewers = _context.Reviewers.Where(r => r.FirstName == FirstName).Where(r => r.LastName == LastName);
            return _context.Reviews.Where(r => r.Reviewer.FirstName == FirstName).Where(r => r.Reviewer.LastName == LastName).ToList();
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            _context.Reviewers.Add(reviewer);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

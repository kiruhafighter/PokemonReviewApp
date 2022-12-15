using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationDbContext _context;
        public OwnerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
        }
        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.SingleOrDefault(o => o.Id == ownerId);
        }

        public Owner GetOwnerByName(string ownerFirstName, string ownerLastName)
        {
            var owners = _context.Owners.Where(o => o.FirstName == ownerFirstName);
            return owners.FirstOrDefault(o => o.LastName == ownerLastName);
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(po=>po.Pokemon.Id == pokeId).Select(po=>po.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(po => po.Owner.Id == ownerId).Select(po => po.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o=>o.Id== ownerId);
        }
    }
}

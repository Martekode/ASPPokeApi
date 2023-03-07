using PokemonApi2.Data;
using PokemonApi2.Interfaces;
using PokemonApi2.Models;

namespace PokemonApi2.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return Save();
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Where(o => o.ID == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.ID).ToList();
        }

        public ICollection<Owner> GetOwnersOfPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p => p.PokemonID == pokeId).Select(o => o.Owner).ToList();
        }

        public ICollection<Pokemon> GetPokemonsByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(o => o.OwnerID == ownerId).Select(o => o.Pokemon).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.ID == ownerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }
    }
}

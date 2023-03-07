using PokemonApi2.Data;
using PokemonApi2.Interfaces;
using PokemonApi2.Models;

namespace PokemonApi2.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.ID == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.ID == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };
            _context.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };
            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }

        public Pokemon GetPokemon(int Id)
        {
            return _context.Pokemon.Where(p => p.ID == Id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string Name)
        {
            return _context.Pokemon.Where(p => p.name == Name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var reviews = _context.Reviews.Where(p => p.Pokemon.ID == pokeId);

            if (reviews.Count() <= 0)
                return 0;

            return ((decimal)reviews.Sum(r => r.Rating) / reviews.Count());
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.ID).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p =>p.ID == pokeId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
    }
}

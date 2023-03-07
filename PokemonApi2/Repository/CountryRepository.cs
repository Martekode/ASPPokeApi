using AutoMapper;
using PokemonApi2.Data;
using PokemonApi2.Interfaces;
using PokemonApi2.Models;

namespace PokemonApi2.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(int countryId)
        {
            return _context.Countries.Any(c => c.ID == countryId);
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.ID).ToList();
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Where(c => c.ID == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.ID == ownerId).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersByCountry(int countryId)
        {
            return _context.Owners.Where(o => o.Country.ID == countryId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }
    }
}

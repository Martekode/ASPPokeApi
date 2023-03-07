namespace PokemonApi2.Models
{
    public class Pokemon
    {
        public int ID { get; set; }
        public string name { get; set; }
        public DateTime birthDay { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}

namespace PokemonApi2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string name { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}

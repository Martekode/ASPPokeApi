namespace PokemonApi2.Models
{
    public class PokemonCategory
    {
        public int PokemonID { get; set; }
        public int CategoryID { get; set; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}

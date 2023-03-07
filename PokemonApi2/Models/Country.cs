namespace PokemonApi2.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}

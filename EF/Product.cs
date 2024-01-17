using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FinalAPI.EF
{
    public class Product
    {
        public Product()
        {
            SoldProduct = new HashSet<SoldProducts>();
        }

        [Required]
        [JsonIgnore]
        public int Id { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Categories Category { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Types Type { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Policies Policy { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [MinLength(1000)]
        public string Description { get; set; }

        protected virtual ICollection<SoldProducts> SoldProduct { get; set; }
    }

    public enum Categories
    {
        Health,
        Travel,
        Auto
    }

    public enum Types
    {
        Silver,
        Gold,
        Platinum
    }

    public enum Policies
    {
        Family,
        Individual,
        Corporation
    }
}
using System.ComponentModel.DataAnnotations;

namespace FinalAPI.EF
{
    public class Product
    {
        public Product()
        {
            SoldProduct = new HashSet<SoldProducts>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        public Categories Category { get; set; }

        [Required]
        public Types Type { get; set; }

        [Required]
        public Policies Policy { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [MinLength(1000)]
        public required string Description { get; set; }

        public virtual ICollection<SoldProducts> SoldProduct { get; set; }
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
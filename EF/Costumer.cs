using System.ComponentModel.DataAnnotations;

namespace FinalAPI.EF
{
    public class Customer
    {
        public Customer()
        {
            SoldProduct = new HashSet<SoldProducts>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string PID { get; set; }

        public virtual ICollection<SoldProducts> SoldProduct { get; set; }
    }
}

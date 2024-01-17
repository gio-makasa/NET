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
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PID { get; set; }

        protected virtual ICollection<SoldProducts> SoldProduct { get; set; }
    }
}

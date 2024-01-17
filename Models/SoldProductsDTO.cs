using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAPI.Models
{
    public class SoldProductsDTO
    {
        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    }
}

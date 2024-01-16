using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAPI.EF
{
    public class SoldProducts
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustumerId { get; set; }


        protected virtual Product Product { get; set; }
        protected virtual Customer Customer { get; set; }
    }
}

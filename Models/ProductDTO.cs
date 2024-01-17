using FinalAPI.EF;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FinalAPI.Models
{
    public class ProductDTO
    {
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
        [MinLength(1000)]
        public string Description { get; set; }
    }
}

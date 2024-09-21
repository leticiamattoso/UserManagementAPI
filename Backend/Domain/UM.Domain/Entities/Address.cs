using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UM.Domain.Entities
{
    public class Address
    {
        public Address()
        {
            Users = [];
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Street { get; set; } = string.Empty;
        [Required]
        public int Number { get; set; }
        [Required]
        [StringLength(5)]
        public string PostCode { get; set; } = string.Empty;
        [Required]
        public decimal Latitude { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; } = new City();

        [InverseProperty("Address")]
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; } = [];
    }
}
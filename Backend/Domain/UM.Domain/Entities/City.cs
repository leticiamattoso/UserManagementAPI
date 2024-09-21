using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UM.Domain.Entities
{
    public class City
    {
        public City()
        {
            Addresses = [];
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = new State();

        [InverseProperty("City")]
        [JsonIgnore]
        public virtual ICollection<Address> Addresses { get; set; } = [];
    }
}
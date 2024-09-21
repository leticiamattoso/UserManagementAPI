using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UM.Domain.Entities
{
    public class State
    {
        public State()
        {
            Cities = [];
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = new Country();

        [InverseProperty("State")]
        [JsonIgnore]
        public virtual ICollection<City> Cities { get; set; } = [];
    }
}
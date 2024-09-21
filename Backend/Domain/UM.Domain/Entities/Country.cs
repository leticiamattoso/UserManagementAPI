using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UM.Domain.Entities
{
    public class Country
    {
        public Country()
        {
            States = [];
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [InverseProperty("Country")]
        [JsonIgnore]
        public virtual ICollection<State> States { get; set; } = [];
    }
}
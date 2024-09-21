using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UM.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(9)]
        public string Gender { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [StringLength(120)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(512)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(14)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [StringLength(14)]
        public string Cell { get; set; } = string.Empty;
        public string? PictureLarge { get; set; }
        public string? PictureMedium { get; set; }
        public string? PictureThumbnail { get; set; }
        [Required]
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; } = new Address();
    }
}
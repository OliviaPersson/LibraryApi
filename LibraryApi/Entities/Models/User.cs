using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public Guid? Id { get; set; }

        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
    }
}

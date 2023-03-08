using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Authenticated { get; set; }
    }
}

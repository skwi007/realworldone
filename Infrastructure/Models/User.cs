using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class User
    {
        
        public Guid GuidId { get; set; }
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}

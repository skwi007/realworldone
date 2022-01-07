using System.ComponentModel.DataAnnotations;

namespace Core.Dto
{
    public class NewUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

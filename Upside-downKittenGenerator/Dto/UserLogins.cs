using System.ComponentModel.DataAnnotations;

namespace Upside_downKittenGenerator.Dto
{
    public class UserLogins
    {
        [Required]
        public string Login
        {
            get;
            set;
        }

        [Required]
        public string Password
        {
            get;
            set;
        }
    }
}

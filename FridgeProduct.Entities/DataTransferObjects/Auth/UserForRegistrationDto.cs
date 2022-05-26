using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FridgeProduct.Entities.DataTransferObjects
{
    public class UserForRegistrationDto
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Pasword is required")]
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}

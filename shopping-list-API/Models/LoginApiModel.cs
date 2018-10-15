using System.ComponentModel.DataAnnotations;

namespace shopping_list_API.Models
{
    public class LoginApiModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
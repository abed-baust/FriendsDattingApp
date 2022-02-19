using System.ComponentModel.DataAnnotations;

namespace FriendsApi.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FriendsApi.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string userName { get; set; }

        [Required]
        [StringLength(8,MinimumLength = 4)]
        public string password { get; set; }
    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FriendsApi.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string knownAs { get; set; }
        
        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        [Required]
        [StringLength(8,MinimumLength = 4)]
        public string password { get; set; }
    }
}

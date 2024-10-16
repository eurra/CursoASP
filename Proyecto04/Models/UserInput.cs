﻿using System.ComponentModel.DataAnnotations;

namespace Proyecto04.Models
{    
    public class UserInput
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

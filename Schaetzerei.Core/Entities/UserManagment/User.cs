using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schaetzerei.Core.Entities.UserManagment
{
    public class User : EntityObject
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PasswordHashSalt { get; set; }
    }
}

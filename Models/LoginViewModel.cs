using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Add the following import:

using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class LoginViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fromplaytobow.co.uk.Models
{
    public class NewUserVM
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "User firstname is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "User surname is required")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "User email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must select some roles for the user")]
        public string Roles { get; set; }
    }
}
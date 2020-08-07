using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Re-Enter Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password And Confirm Password Not Match !")]
        public string RePassword { get; set; }
    }
}

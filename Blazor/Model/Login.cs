using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Blazor.Model
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}

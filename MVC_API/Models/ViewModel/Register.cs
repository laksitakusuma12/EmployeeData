using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_API.Models.ViewModel
{
    public class Register
    {
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolesId { get; set; }
    }
}

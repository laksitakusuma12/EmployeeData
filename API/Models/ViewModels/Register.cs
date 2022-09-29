using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ViewModels
{
    public class Register
    {
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolesId { get; set; }
    }
}

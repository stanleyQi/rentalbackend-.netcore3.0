using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Auth.Dto
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Auth.Models
{
    public class AuthUser:IdentityUser
    {
        public string Address { get; set; }
    }
}

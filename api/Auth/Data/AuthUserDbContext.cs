using api.Helper;
using api.Auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Auth.Data
{
    /// <summary>
    /// IdentityDbContext containts all the user tables
    /// </summary>
    public class AuthUserDbContext : IdentityDbContext<AuthUser>
    {
        public AuthUserDbContext(DbContextOptions<AuthUserDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

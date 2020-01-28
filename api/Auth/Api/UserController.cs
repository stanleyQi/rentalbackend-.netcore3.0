using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Auth.Dto;
using api.Helper;
using api.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.Auth.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<AuthUser> _signInManager;
        private readonly UserManager<AuthUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserController(
            UserManager<AuthUser> userManager,
            SignInManager<AuthUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                    var appUserRoles = await _userManager.GetRolesAsync(appUser);
                    return await JwtHelper.GenerateJwtToken(model.Email, appUser, _configuration, appUserRoles[0]);
                }

                return new { code = "00008", message = "Operation errors", error = "An operation error happened." };
            }
            catch (Exception)
            {

                return new { code = "00007", message = "System errors", error = "An system error happened." };
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            var user = new AuthUser
            {
                UserName = model.Email,
                Email = model.Email,
                Address = model.Address
            };

            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                //var roleId = await _roleManager.GetRoleIdAsync(new IdentityRole(model.Role));
                result = await _userManager.AddToRoleAsync(user, model.Role);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    var appUserRoles = await _userManager.GetRolesAsync(user);
                    return await JwtHelper.GenerateJwtToken(model.Email, user, _configuration, appUserRoles[0]);
                }

                return new { code = "00008", message = "Operation errors", error = "An operation error happened." };
            }
            catch (Exception)
            {
                return new { code = "00007", message = "System errors", error = "An system error happened." };
            }

        }

        // only for admininistrator
        [HttpPost]
        [AllowAnonymous]
        public async Task<object> CreateRoles()
        {
            try
            {
                //Adding lessor Role
                var roleCheck = await _roleManager.RoleExistsAsync("lessor");
                if (!roleCheck)
                {
                    //create the roles and seed them to the database
                    await _roleManager.CreateAsync(new IdentityRole("lessor"));
                }

                //Adding tenant Role
                roleCheck = await _roleManager.RoleExistsAsync("tenant");
                if (!roleCheck)
                {
                    //create the roles and seed them to the database
                    await _roleManager.CreateAsync(new IdentityRole("tenant"));
                }

                //Adding agent Role
                roleCheck = await _roleManager.RoleExistsAsync("agent");
                if (!roleCheck)
                {
                    //create the roles and seed them to the database
                    await _roleManager.CreateAsync(new IdentityRole("agent"));

                }

                //Adding admin Role
                roleCheck = await _roleManager.RoleExistsAsync("admin");
                if (!roleCheck)
                {
                    //create the roles and seed them to the database
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    
                }

                return "Creating roles successfully.";
            }
            catch (Exception)
            {
                return new { code = "00007", message = "System errors", error = "An system error happened." };
            }

        }
    }
}

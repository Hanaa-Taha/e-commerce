using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecomerce.Model;
using ecomerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ecomerce.Controllers
{
    [Route("api/[controller]")]
   // [Authorize]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly dbSmartAgricultureContext _context;
        private readonly UserManager<AppUser> _userManager;
        public AuthController(UserManager<AppUser> userManager, IAuthService authService, dbSmartAgricultureContext context)
        {
            _authService = authService;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] Registermodell model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetLoginAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetLoginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        [HttpPatch("{UserName}")]
        public async Task<IActionResult> UpdateAuthPatch([FromBody] JsonPatchDocument resultModel, [FromRoute] string UserName)
        {
            var result = await _context.Users.Where(s => s.UserName == UserName).SingleOrDefaultAsync();
            if (result != null)
            {
                resultModel.ApplyTo(result);
                await _context.SaveChangesAsync();

            }

            return Ok();
        }




        [HttpGet("GetHasIotVal/{UserName}")]        public async Task<IActionResult> GetHasIotVal(string UserName)        {                        var result = await _context.Users.Where(s => s.UserName == UserName).SingleOrDefaultAsync();            var allRoles = _userManager.GetRolesAsync(result).Result;            var role = false;            foreach (var EachRole in allRoles)
            {
                if (EachRole == "IOTUser")
                {
                    role = true;
                }
            }            if (result == null)            {                return NotFound();            }            var value = new HasIotModel { hasIotSystem = result.hasIotSystem , hasIotRole = role };            return Ok(value);        }




        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModell model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Email does not exit");
                //return BadRequest("Email does not exit");
            }
            if (string.Compare(model.NewPassword,model.ConfirmNewPassword) !=0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "the new password and confirm do not match");
                //return BadRequest("the new pass and confirm do not match");
            }

            var result = await _userManager.ChangePasswordAsync(user,model.CurrentPassword,model.ConfirmNewPassword);
            if (!result.Succeeded)
            {
                var errors = new List<string>();
                foreach(var error in result.Errors)
                {
                    errors.Add(error.Description);
                }

                return BadRequest(errors);

            }
            return StatusCode(StatusCodes.Status200OK, " password successfully changed");

        }
    }
}

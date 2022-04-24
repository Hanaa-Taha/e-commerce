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
        public AuthController(IAuthService authService, dbSmartAgricultureContext context)
        {
            _authService = authService;
            _context = context;
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

    }
}

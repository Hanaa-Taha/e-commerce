
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ecomerce.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ecomerce.Services;

namespace ecomerce.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IConfiguration _configuration;
        private readonly dbSmartAgricultureContext databaseContext;
       

        public AccountController(UserManager<AppUser> userManager
            , RoleManager<IdentityRole> roleManager
            , SignInManager<AppUser> signInManager
            , IConfiguration configuration
            , dbSmartAgricultureContext applicationDbContext)
            
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            _configuration = configuration;
            databaseContext = applicationDbContext;
            
        }

        
        
        /// <summary>
        /// Send Password Reset Token or Code
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("SendPasswordResetCode")]
        public async Task<IActionResult> SendPasswordResetCode(string email)
        {
            
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new Message {message= "Email should not be null or empty" });
            }

            // Get Identity User details user user manager
            var user = await userManager.FindByEmailAsync(email);

            // Generate password reset token
            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            // Generate OTP
            int otp = RandomNumberGeneartor.Generate(100000, 999999);

            var resetPassword = new ResetPassword()
            {
                Email = email,
                OTP = otp.ToString(),
                Token = token,
                UserId = user.Id,
                InsertDateTimeUTC = DateTime.UtcNow
            };

            // Save data into db with OTP
            await databaseContext.AddAsync(resetPassword);
            await databaseContext.SaveChangesAsync();

            // to do: Send token in email
            await EmailSender.SendEmailAsync(email, "Reset Password OTP", "Hello " 
                + email + "<br><br>Please find the reset password token below<br><br><b>"
                + otp + "<b><br><br>Thanks<br>");

            return Ok(new Message { message = "Token sent successfully in email" });
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email, string otp, string newPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
            {
                return BadRequest(new Message { message = "Email & New Password should not be null or empty" });
            }

            // Get Identity User details user user manager
            var user = await userManager.FindByEmailAsync(email);

            // getting token from otp
            var resetPasswordDetails = await databaseContext.ResetPasswords
                .Where(rp => rp.OTP == otp && rp.UserId == user.Id)
                .OrderByDescending(rp => rp.InsertDateTimeUTC)
                .FirstOrDefaultAsync();

            // Verify if token is older than 15 minutes
            var expirationDateTimeUtc = resetPasswordDetails.InsertDateTimeUTC.AddMinutes(15);

            if (expirationDateTimeUtc < DateTime.UtcNow)
            {
                return BadRequest(new Message { message = "OTP is expired, please generate the new OTP" });
            }

            var res = await userManager.ResetPasswordAsync(user, resetPasswordDetails.Token, newPassword);

            if (!res.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
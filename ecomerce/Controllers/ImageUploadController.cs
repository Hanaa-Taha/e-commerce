using ecomerce.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly dbSmartAgricultureContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly UserManager<AppUser> _userManager;

        public ImageUploadController(UserManager<AppUser> userManager, dbSmartAgricultureContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _userManager = userManager;

        }

        [HttpPost("Save/{id}")]
        //[Route("Save")]
        public async Task<IActionResult> Save([FromForm] ProfilePic profilePic, string id)
        {

            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            

            try
            {

                if (user.profileImage != null)
                {
                    var url = Path.Combine(_webHostEnviroment.WebRootPath, "profilePic");
                    var x =user.profileImage.Split("/profilePic/");
                    var imageUrl = Path.Combine(url, x[1]);
                    FileInfo file1 = new FileInfo(url);
                    System.IO.File.Delete(imageUrl);

                    //file1.Delete();


                }

                var file = profilePic.file;
                string folder = "profilePic/";
                folder += Guid.NewGuid().ToString() + '_' + profilePic.file.FileName;
                user.profileImage = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, folder);
                await profilePic.file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }




        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteImage( string id)
        {
            var result = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (result.profileImage != null)
            {
                var url = Path.Combine(_webHostEnviroment.WebRootPath,"profilePic");
                var x = result.profileImage.Split("/profilePic/");
                var imageUrl = Path.Combine(url ,x[1] );
                FileInfo file = new FileInfo(url);
                if (file != null)
                {
                    System.IO.File.Delete(imageUrl);
                    //file.Delete();
                }

                   
                

                result.profileImage = null;
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
        [HttpGet("GetprofileImage/{userId}")]
        public async Task<ActionResult<CheckoutInfo>> GetprofileImage(string userId)
        {
            var user = await _context.Users.Where(s => s.Id == userId).FirstOrDefaultAsync();


            if (user == null)
            {
                return NotFound();
            }
            imageModel image = new imageModel { imageUrl = user.profileImage };

            return Ok(image);
        }


    }
}

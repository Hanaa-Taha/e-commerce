using ecomerce.Model;
using ecomerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{

    public class DashboardController : Controller
    {
        private readonly dbSmartAgricultureContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailingService _mailingService;


        public DashboardController(IMailingService mailingService, UserManager<AppUser> userManager, dbSmartAgricultureContext context, IWebHostEnvironment webHostEnviroment, IUserService userService)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _userService = userService;
            _userManager = userManager;
            _mailingService = mailingService;
        }
        [Authorize(Roles = "IOTUser")]
        public async Task<IActionResult> Index()
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return View(user);
        }


        [Authorize(Roles = "User")]
        public ActionResult IOTRegistration()
        {


            var hasiot = _context.UserRoles.Where(s => s.UserId == _userService.GetUserId() && s.RoleId == "1b34bcb1-6d1e-4838-98bb-bd76fe4d0b38").FirstOrDefault();
            if (hasiot == null) { return View(); }
            else { return RedirectToAction(nameof(Index)); }

        }

        [HttpPost]
        [ActionName("IOTRegistration")]
        public async Task<IActionResult> IOTRegistration(IOTInfo dto)
        {
            var user = await _userManager.FindByIdAsync(_userService.GetUserId());
            await _userManager.AddToRoleAsync(user, "IOTUser");
            var Body = "name : " + dto.name + "<hr>" +
                "number : " + dto.number + "<hr>" +
              "Governorate  : " + dto.Governorate + "<hr>" +
               "houseNumber : " + dto.houseNumber + "<hr>" +
               "Region : " + dto.Region + "<hr>" +
               "specialMarque : " + dto.specialMarque + "<hr>" +
               "street : " + dto.street + "<hr>" +
               "city : " + dto.city;
            await _mailingService.SendEmailAsync("enghanaa.22@gmail.com", _userService.GetUserId(), Body);

            //UserRolesNew userRole = new UserRolesNew { roleId = "1b34bcb1-6d1e-4838-98bb-bd76fe4d0b38", userId = user.Id };
            //_context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}


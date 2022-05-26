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


        public DashboardController(UserManager<AppUser> userManager, dbSmartAgricultureContext context, IWebHostEnvironment webHostEnviroment, IUserService userService)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _userService = userService;
            _userManager = userManager;

        }
        [Authorize(Roles = "IOTUser")]
        public async Task<IActionResult> Index()
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return View(user);
        }

    }
}


using ecomerce.Dtos;
using ecomerce.Model;
using ecomerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbSmartAgricultureContext _context;
        private readonly IUserService _userService;
        private readonly IMailingService _mailingService;
        public HomeController(ILogger<HomeController> logger, dbSmartAgricultureContext context, IUserService userService, IMailingService mailingService)


        {
            _context = context;
            _logger = logger;
            _userService = userService;
            _mailingService = mailingService;

        }

        public IActionResult Index()
        {
            return View(_context.TblProduct.Include(t => t.Category).ToList());
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        [ActionName("SendMail")]
        public async Task<IActionResult> SendMail(MailRequestDto dto)
        {
            dto.Subject = _userService.GetUserId();
            await _mailingService.SendEmailAsync("enghanaa.22@gmail.com", dto.Subject, dto.Body);
            return RedirectToAction(nameof(Index));
        }
    }
}

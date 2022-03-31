using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{
    public class Trying : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

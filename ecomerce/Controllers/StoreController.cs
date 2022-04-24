using ecomerce.Model;
using ecomerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{

    public class StoreController : Controller
    {
        private readonly dbSmartAgricultureContext _context;
        private readonly IUserService _userService;
        public StoreController(dbSmartAgricultureContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View(_context.TblProduct.Include(t=>t.Category).ToList());
        }

        public IActionResult Features()
        {
            return View();
        }

        public IActionResult Review()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult AdminDashBoard()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Chekout()
        {
            return View();
        }

        public ActionResult Detail(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _context.TblProduct.Include(c => c.Category).FirstOrDefault(c => c.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ActionName("Detail")]
        public ActionResult ProductDetail(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var userId = _userService.GetUserId();
            var product = _context.TblProduct.Include(c => c.Category).FirstOrDefault(c => c.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            var TblCart = new TblCart
            {
                ProductId = product.ProductId,
                MemberId = userId,

            };
            _context.TblCart.Add(TblCart);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        //GET Remove action methdo
        //[ActionName("Remove")]
        //public IActionResult RemoveToCart(int? id)
        //{
        //    List<Products> products = HttpContext.Session.Get<List<Products>>("products");
        //    if (products != null)
        //    {
        //        var product = products.FirstOrDefault(c => c.Id == id);
        //        if (product != null)
        //        {
        //            products.Remove(product);
        //            HttpContext.Session.Set("products", products);
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]

        //public IActionResult Remove(int? id)
        //{
        //    List<Products> products = HttpContext.Session.Get<List<Products>>("products");
        //    if (products != null)
        //    {
        //        var product = products.FirstOrDefault(c => c.Id == id);
        //        if (product != null)
        //        {
        //            products.Remove(product);
        //            HttpContext.Session.Set("products", products);
        //        }
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult Cart()
        {
            var userId = _userService.GetUserId();
            var cart = _context.TblCart.Include(d => d.Member).Include(d => d.Product).Include(d => d.Product.Category).Where(s => s.MemberId == userId).ToList();
            if (cart == null)
            {
                cart = new List<TblCart>();
            }
            return View(cart);
        }


    }
}

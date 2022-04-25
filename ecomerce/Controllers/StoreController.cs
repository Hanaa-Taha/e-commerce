using ecomerce.Model;
using ecomerce.Services;
using Microsoft.AspNetCore.Http;
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
            return View(_context.TblProduct.Include(t => t.Category).ToList());
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
        //        public IActionResult addToCart(int id)
        //        {
        //            var cartItem = _context.TblProduct.SingleOrDefault(c => c.ProductId == id);
        //            var userId = _userService.GetUserId();
        //            if (cartItem != null)
        //            {
        //                // Create a new cart item if no cart item exists
        //               var TblCart = new TblCart
        //                {
        //                    ProductId = cartItem.ProductId,
        //                    MemberId = userId,

        //                };
        //                _context.TblCart.Add(TblCart);
        //            }
        //            _context.SaveChanges();
        //            return null;
        //        }
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
                Quantity=1
            };
            _context.TblCart.Add(TblCart);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        //GET Remove action methdo
        [ActionName("Remove")]
        public IActionResult RemoveToCart(int? id)
        {
            var userId = _userService.GetUserId();

            var cart = _context.TblCart.Where(s => s.MemberId == userId).ToList();
            if (cart != null)
            {
                var product = cart.FirstOrDefault(c => c.CartId == id);
                if (product != null)
                {
                    _context.TblCart.Remove(product);
                    _context.SaveChanges();

                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public IActionResult Remove(int? id)
        {
            var userId = _userService.GetUserId();

            var cart = _context.TblCart.Where(s => s.MemberId == userId).ToList();
            if (cart != null)
            {
                var product = cart.FirstOrDefault(c => c.CartId == id);
                if (product != null)
                {
                    _context.TblCart.Remove(product);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction(nameof(Index));
        }
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



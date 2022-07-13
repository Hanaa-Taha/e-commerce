using ecomerce.Model;
using ecomerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly dbSmartAgricultureContext _context;
        private readonly IUserService _userService;


        public CheckoutController(dbSmartAgricultureContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;

        }
        [TempData]
        public string TotalAmount { get; set; }
        public IActionResult Index()
        {
            var userId = _userService.GetUserId();

            var cart = _context.CartItems.Where(s => s.userId == userId).Include(s => s.TblProduct).ToList();
           
            checkInfoWithCart checkInfoWithCart = new checkInfoWithCart { carts = cart  };

            //var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            //ViewBag.cart = cart;
            //ViewBag.DollarAmount = cart.Sum(item => item.Product.Price * item.Quantity);
            //ViewBag.total = Math.Round(ViewBag.DollarAmount, 2) * 100;
            //ViewBag.total = Convert.ToInt64(ViewBag.total);
            //long total = ViewBag.total;
            //TotalAmount = total.ToString();





            
            //ViewBag.DollarAmount = checkInfoWithCart.carts.Sum(item => (item.TblProduct.Price* item.Quantity));
            //ViewBag.total = Math.Round(ViewBag.DollarAmount, 2) * 100;
            //ViewBag.total = Convert.ToInt64(ViewBag.total);
            //long total = ViewBag.total;
            //TotalAmount = total.ToString();

            return View(checkInfoWithCart);
        }

        [HttpPost]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            var optionsCust = new CustomerCreateOptions
            {
                Email = stripeEmail,
                Name = "Robert",
                Phone = "04-234567"

            };
            var serviceCust = new CustomerService();
            Customer customer = serviceCust.Create(optionsCust);
            var optionsCharge = new ChargeCreateOptions
            {
                /*Amount = HttpContext.Session.GetLong("Amount")*/
                Amount = Convert.ToInt64(TempData["TotalAmount"]),
                Currency = "USD",
                Description = "Buying Flowers",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,

            };
            var service = new ChargeService();
            Charge charge = service.Create(optionsCharge);
            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                ViewBag.AmountPaid = Convert.ToDecimal(charge.Amount) % 100 / 100 + (charge.Amount) / 100;
                ViewBag.BalanceTxId = BalanceTransactionId;
                ViewBag.Customer = customer.Name;
                //return View();
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCartToItemDetails(checkInfoWithCart model)
        {
            var userId = _userService.GetUserId();

            var userIformation = _context.checkoutInfo.Where(s => s.MemberId == userId).FirstOrDefault();
            if (userIformation != null)
            {

                //amount = model.checkoutInfo.amount;
                userIformation.phone = model.checkoutInfo.phone;
                userIformation.city = model.checkoutInfo.city;
                userIformation.street = model.checkoutInfo.street;
                userIformation.district = model.checkoutInfo.district;
                userIformation.governorate = model.checkoutInfo.governorate;
                userIformation.specialMarque = model.checkoutInfo.specialMarque;
                userIformation.propertyNumber = model.checkoutInfo.propertyNumber;

                await _context.SaveChangesAsync();
                var tblCart = await _context.CartItems.Where(s => s.userId == userId).Include(x=>x.TblProduct).ToListAsync();
                var result = new Order_details
                {

                    checkoutInfoId = userIformation.checkoutInfoId,
                    total =Convert.ToDecimal( tblCart.Sum(item=>item.Quantity*item.TblProduct.Price)),
                    PaymentspaymentDetailsId = 1,
                    ModifiedDate = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow
                };
                _context.Order_details.Add(result);
                await _context.SaveChangesAsync();


                //.Include(s => s.Product)
                
                foreach (var product in tblCart)
                {
                    var oldOrderItems = await _context.Order_items.SingleOrDefaultAsync(s => s.orderItemsId == result.orderDetailsId );
                    if (oldOrderItems != null)
                    {
                        oldOrderItems.Quantity = oldOrderItems.Quantity + 1;
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        Order_items orderItems = new Order_items
                        {
                            //productId = product.ProductId,
                            orderDetailsId = result.orderDetailsId,
                            Quantity = 1,
                            ModifiedDate = DateTime.UtcNow,
                            CreatedDate = DateTime.UtcNow
                        };
                        _context.Order_items.Add(orderItems);
                        await _context.SaveChangesAsync();
                    }
                  
                }

            }

            else
            {
                var resultInfo = new CheckoutInfo
                {

                    MemberId = userId,
                    //amount = model.checkoutInfo.amount,
                    phone = model.checkoutInfo.phone,
                    city = model.checkoutInfo.city,
                    street = model.checkoutInfo.street,
                    district = model.checkoutInfo.district,
                    governorate = model.checkoutInfo.governorate,
                    specialMarque = model.checkoutInfo.specialMarque,
                    propertyNumber = model.checkoutInfo.propertyNumber
                };
                _context.checkoutInfo.Add(resultInfo);
                await _context.SaveChangesAsync();
                var tblCart = await _context.CartItems.Where(s => s.userId == userId).Include(x => x.TblProduct).ToListAsync();
                var result = new Order_details
                {

                    checkoutInfoId = resultInfo.checkoutInfoId,
                    total = Convert.ToDecimal(tblCart.Sum(item => item.Quantity * item.TblProduct.Price)),
                    PaymentspaymentDetailsId = 1,
                    ModifiedDate = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow
                };
                _context.Order_details.Add(result);
                await _context.SaveChangesAsync();



                //.Include(s => s.Product)
               
                foreach (var product in tblCart)
                {
                    var oldOrderItems = await _context.Order_items.SingleOrDefaultAsync(s => s.orderItemsId == result.orderDetailsId );
                    if (oldOrderItems != null)
                    {
                        oldOrderItems.Quantity = oldOrderItems.Quantity + 1;
                        await _context.SaveChangesAsync();

                    }
                    else
                    {
                        Order_items orderItems = new Order_items
                        {
                            //productId = product.ProductId,
                            orderDetailsId = result.orderDetailsId,
                            Quantity = 1,
                            ModifiedDate = DateTime.UtcNow,
                            CreatedDate = DateTime.UtcNow
                        };
                        _context.Order_items.Add(orderItems);
                        await _context.SaveChangesAsync();
                    }

                    //_context.CartItems.Remove(product);
                    //await _context.SaveChangesAsync();
                }
            }




            return RedirectToAction(nameof(Pay));
            
            //return Ok();



        }

        public IActionResult Pay()
        {
            var userId = _userService.GetUserId();
            var tblCart = _context.CartItems.Where(s => s.userId == userId).Include(s => s.TblProduct).ToList();

            var Total = new total { Total = tblCart.Sum(s => s.Quantity * s.TblProduct.Price) };
            ViewBag.DollarAmount = Total.Total;
            ViewBag.total = Math.Round(ViewBag.DollarAmount, 2) * 100;
            ViewBag.total = Convert.ToInt64(ViewBag.total);
            long total = ViewBag.total;
            TotalAmount = total.ToString();

            foreach (var product in tblCart)
            {
               
              

                _context.CartItems.Remove(product);
                 _context.SaveChanges();
            }

            return View();
            //return RedirectToAction(nameof(Index));
        }


    }
}

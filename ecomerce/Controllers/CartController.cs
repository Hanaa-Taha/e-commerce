using ecomerce.Model;
using ecomerce.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly dbSmartAgricultureContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly IUserService _userService;

        public CartController(dbSmartAgricultureContext context, IWebHostEnvironment webHostEnviroment, IUserService userService)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
            _userService = userService;

        }// GET: api/TblCarts
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TblCart>>> GetTblCart()
        //{
        //    return  _context.TblCart.ToList();
        //}

        // GET: api/TblCarts/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<CartItems>>> GetTblCart(string userId)
        {
            var tblCart = await _context.TblCart.Where(s => s.MemberId == userId).FirstOrDefaultAsync();

            var cartItem = await _context.CartItems.Where(s => s.tblCartId == tblCart.CartId).ToListAsync();
            if (cartItem == null)
            {
                return NotFound();
            }

            return cartItem;
        }

        // PUT: api/TblCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCart(int id, CartItems CartItems)
        {
            if (id != CartItems.cartItemsId)
            {
                return BadRequest();
            }

            _context.Entry(CartItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartItems>> PostTblCart(CartModel cartModel)
        {

            

            var cart = _context.TblCart.Where(s => s.MemberId == cartModel.userId).FirstOrDefault();
            var oldtblCart = await _context.CartItems.SingleOrDefaultAsync(s => s.tblCartId == cart.CartId && s.TblProductProductId == cartModel.ProductId);
            if (oldtblCart != null)
            {
                oldtblCart.Quantity = oldtblCart.Quantity + 1;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                CartItems cartItem = new CartItems
                {
                    TblProductProductId = cartModel.ProductId,
                    tblCartId = cart.CartId,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblCart", new { id = cartItem.cartItemsId }, cartItem);
            }
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAuthPatch([FromBody] JsonPatchDocument cart, [FromRoute] int id)
        {
            var tblCart = await _context.CartItems.FindAsync(id);
            if (tblCart != null)
            {
                cart.ApplyTo(tblCart);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // DELETE: api/TblCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCart(int id)
        {
            var tblCart = await _context.CartItems.SingleOrDefaultAsync(s => s.cartItemsId == id );
            if (tblCart == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(tblCart);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("DeleteAllTblCart/{tblCartId}")]
        public async Task<IActionResult> DeleteAllTblCart(int tblCartId)
        {
            var tblCart = await _context.CartItems.Where(s => s.tblCartId == tblCartId).ToListAsync();
            if (tblCart == null)
            {
                return NotFound();
            }

            foreach (var item in tblCart)
            {
                _context.CartItems.Remove(item);
            }
            
            await _context.SaveChangesAsync();

            return Ok();
        }


        private bool TblCartExists(int id)
        {
            return _context.CartItems.Any(e => e.cartItemsId == id);
        }
    }
}



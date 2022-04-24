
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
        //public async Task>> GetTblCart()
        //{
        //    return  _context.TblCart.ToList();
        //}

        // GET: api/TblCarts/5
        [HttpGet("{userId}")]
        public async Task <ActionResult<IEnumerable<TblCart>>> GetTblCart(string userId)
        {
            var tblCart = await _context.TblCart.Include(s => s.Product).Where(s => s.MemberId == userId).ToListAsync();


            if (tblCart == null)
            {
                return NotFound();
            }

            return tblCart;
        }

        // PUT: api/TblCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCart(int id, TblCart tblCart)
        {
            if (id != tblCart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(tblCart).State = EntityState.Modified;

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
        public async Task<IActionResult> PostTblCart(CartModel cartModel)
        {
            var oldtblCart = await _context.TblCart.SingleOrDefaultAsync(s => s.MemberId == cartModel.MemberId && s.ProductId == cartModel.ProductId);
            if (oldtblCart != null)
            {
                oldtblCart.Quantity = oldtblCart.Quantity + 1;
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                TblCart tblCart = new TblCart
                {
                    ProductId = cartModel.ProductId,
                    MemberId = cartModel.MemberId,
                    Quantity = 1
                };
                _context.TblCart.Add(tblCart);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTblCart", new { id = tblCart.CartId }, tblCart);
            }
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAuthPatch([FromBody] JsonPatchDocument cart, [FromRoute] int id)
        {
            var tblCart = await _context.TblCart.FindAsync(id);
            if (tblCart != null)
            {
                cart.ApplyTo(tblCart);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // DELETE: api/TblCarts/5
        [HttpDelete("{id}/{userId}")]
        public async Task<IActionResult> DeleteTblCart(int id, string userId)
        {
            var tblCart = await _context.TblCart.SingleOrDefaultAsync(s => s.MemberId == userId && s.ProductId == id);
            if (tblCart == null)
            {
                return NotFound();
            }


            _context.TblCart.Remove(tblCart);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TblCartExists(int id)
        {
            return _context.TblCart.Any(e => e.CartId == id);
        }
    }
}

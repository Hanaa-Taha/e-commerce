using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecomerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ecomerce.Dtos;



namespace ecomerce.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly dbSmartAgricultureContext _context;
        private readonly IMapper _mapper;

        public ProductsController(dbSmartAgricultureContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TblProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProductDto>>> GetTblProduct()
        {
            var tblProduct = await _context.TblProduct.ToListAsync();
            
            
            //return await _context.TblProduct.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TblProductDto>>(tblProduct));
        }

        // GET: api/TblProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProductDto>> GetTblProduct(int id)
        {
            //var tblProduct = await _context.TblProduct.FindAsync(id);
            //if (tblProduct == null)
            //{
            //    return NotFound();
            //}
            //return tblProduct;
            //var book = await _context.Books.FindAsync(bookId);
            //return _mapper.Map<BookModel>(book);
            var tblProduct = await _context.TblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            return _mapper.Map<TblProductDto>(tblProduct);

        }

        [HttpGet("GetSeedProduct")]
        public async Task<ActionResult<IEnumerable<TblProductDto>>> GetSeedProduct()
        {
            
            var Result= await _context.TblProduct.Where(s => s.CategoryId == 1).ToListAsync();
            if (Result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<TblProductDto>>(Result));


        }

        [HttpGet("GetToolProduct")]
        public async Task<ActionResult<IEnumerable<TblProductDto>>> GetToolProduct()
        {

            var Result = await _context.TblProduct.Where(s => s.CategoryId == 2).ToListAsync();
            if (Result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<TblProductDto>>(Result));


        }

        [HttpGet("GetFerProduct")]
        public async Task<ActionResult<IEnumerable<TblProductDto>>> GetFerProduct()
        {

            var Result = await _context.TblProduct.Where(s => s.CategoryId ==3).ToListAsync();
            if (Result == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<TblProductDto>>(Result));


        }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<TblProductDto>>> Search(string name, int? price)
        {

            IQueryable<TblProduct> query = _context.TblProduct;



            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.ProductName.Contains(name) ||e.Description.Contains(name));

                }

                if (price != null)
                {
                    query = query.Where(e => e.Price == price);
                }



                if (query.Any())
                {
                    //return Ok(await query.ToListAsync());
                    var result = await query.ToListAsync();
                    return Ok(_mapper.Map<IEnumerable<TblProductDto>>(result));
                    
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        

        [HttpGet("DiscountProducts")]
        public async Task<ActionResult<IEnumerable<TblProduct>>> DiscountProducts()
        {
            var tblProduct = await _context.TblProduct.Where(s=>s.DiscountId != null).Include(s=>s.discount).ToListAsync();


            //return await _context.TblProduct.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TblProduct>>(tblProduct));
        }



    }
}


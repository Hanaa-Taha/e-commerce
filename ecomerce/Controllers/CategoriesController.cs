using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ecomerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ecomerce.Dtos;
using AutoMapper;

namespace ecomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ControllerBase
    {
        private readonly dbSmartAgricultureContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(dbSmartAgricultureContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TblCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCategoryDto>>> GetTblCategory()
        {
            //return await _context.TblCategory.ToListAsync();

            var tblCategory = await _context.TblCategory.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TblCategoryDto>>(tblCategory));
        }

        // GET: api/TblCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCategoryDto>> GetTblCategory(int id)
        {
            //var tblCategory = await _context.TblCategory.FindAsync(id);

            //if (tblCategory == null)
            //{
            //    return NotFound();
            //}

            //return tblCategory;


            var tblCategory = await _context.TblCategory.FindAsync(id);
            if (tblCategory == null)
            {
                return NotFound();
            }
            return _mapper.Map<TblCategoryDto>(tblCategory);
        }
    }
}

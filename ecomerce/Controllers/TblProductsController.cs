using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecomerce.Model;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ecomerce.Controllers
{
    public class TblProductsController : Controller
    {
        private readonly dbSmartAgricultureContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public TblProductsController(dbSmartAgricultureContext context ,IWebHostEnvironment webHostEnviroment )
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        // GET: TblProducts
        public async Task<IActionResult> Index()
        {
            var dbSmartAgricultureContext = _context.TblProduct.Include(t => t.Category).Include(t => t.Vendor);
            return View(await dbSmartAgricultureContext.ToListAsync());
        }

        // GET: TblProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct
                .Include(t => t.Category)
                .Include(t => t.Vendor)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // GET: TblProducts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.TblCategory, "CategoryId", "CategoryId");
            ViewData["VendorId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TblProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,VendorId,CategoryId,IsActive,IsDelete,CreatedDate,ModifiedDate,Description,ProductImage,IsFeatured,Quantity,Price,file")] productForm tblProduct)
        {
            


            if (ModelState.IsValid)
            {
                if (tblProduct.file != null)
                {
                    string folder = "productImages/";
                    folder +=  Guid.NewGuid().ToString() +'_' + tblProduct.file.FileName ;
                    tblProduct.ProductImage = "/"+folder;
                    string serverFolder = Path.Combine(_webHostEnviroment.WebRootPath, folder);
                   await tblProduct.file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                }
                var newtblProduct = new TblProduct
                {
                    ProductName = tblProduct.ProductName,
                    Price = tblProduct.Price,
                    ModifiedDate = DateTime.UtcNow,
                    CreatedDate = DateTime.UtcNow,
                    ProductImage = tblProduct.ProductImage

                };

                _context.Add(newtblProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TblCategory, "CategoryId", "CategoryId", tblProduct.CategoryId);
            ViewData["VendorId"] = new SelectList(_context.Users, "Id", "Id", tblProduct.VendorId);
            return View(tblProduct);
        }

        // GET: TblProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TblCategory, "CategoryId", "CategoryId", tblProduct.CategoryId);
            ViewData["VendorId"] = new SelectList(_context.Users, "Id", "Id", tblProduct.VendorId);
            return View(tblProduct);
        }

        // POST: TblProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,VendorId,CategoryId,IsActive,IsDelete,CreatedDate,ModifiedDate,Description,ProductImage,IsFeatured,Quantity,Price")] TblProduct tblProduct)
        {
            if (id != tblProduct.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductExists(tblProduct.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TblCategory, "CategoryId", "CategoryId", tblProduct.CategoryId);
            ViewData["VendorId"] = new SelectList(_context.Users, "Id", "Id", tblProduct.VendorId);
            return View(tblProduct);
        }

        // GET: TblProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProduct = await _context.TblProduct
                .Include(t => t.Category)
                .Include(t => t.Vendor)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            return View(tblProduct);
        }

        // POST: TblProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProduct = await _context.TblProduct.FindAsync(id);
            _context.TblProduct.Remove(tblProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductExists(int id)
        {
            return _context.TblProduct.Any(e => e.ProductId == id);
        }
    }
}
